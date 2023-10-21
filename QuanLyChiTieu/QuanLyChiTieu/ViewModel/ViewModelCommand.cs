using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyChiTieu.ViewModel
{
    public class ViewModelCommand : ICommand
    {
        private readonly Action<object> _executeAction;
        private readonly Predicate<object> _canExcuteAction;

        public ViewModelCommand(Action<object> executeAction)
        {
            _executeAction = executeAction;
            _canExcuteAction = null;
        }

        public ViewModelCommand(Action<object> executeAction, Predicate<object> canExcuteAction)
        {
            _executeAction = executeAction;
            _canExcuteAction = canExcuteAction;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExcuteAction == null ? true : _canExcuteAction(parameter);
        }
        public void Execute(object parameter)
        {
            _executeAction(parameter);
        }
    }
}
