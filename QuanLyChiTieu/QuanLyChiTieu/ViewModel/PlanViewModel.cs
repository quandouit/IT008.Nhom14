using System;
using QuanLyChiTieu.View.CustomDialog;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace QuanLyChiTieu.ViewModel
{
    public class PlanViewModel : ViewModelBase
    {
        public ICommand AddingButoonCommand { get; set; }

        public PlanViewModel()
        {
            AddingButoonCommand = new ViewModelCommand(ExecuteAddingButoonCommand);
        }

        private void ExecuteAddingButoonCommand(object obj)
        {
            AddingNewPlan addingDialog = new AddingNewPlan();
            addingDialog.ShowDialog();
        }
    }
}