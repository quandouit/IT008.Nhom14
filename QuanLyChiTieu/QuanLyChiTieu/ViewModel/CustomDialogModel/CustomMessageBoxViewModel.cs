﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows;
using QuanLyChiTieu.Data.BUS;
using System.Data;
using QuanLyChiTieu.Model;
using QuanLyChiTieu.Data.DTO;
using System.Windows.Forms;

namespace QuanLyChiTieu.ViewModel.CustomDialogModel
{
    public class CustomMessageBoxViewModel : ViewModelBase
    {
        private string _title;
        private string _content;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }
        public string Content
        {
            get { return _content; }
            set
            {
                _content = value;
                OnPropertyChanged("Content");
            }
        }
        public event Action<DialogResult> DialogClosed;
        public ICommand OKCommand { get; }
        public CustomMessageBoxViewModel(string title, string content)
        {
            Title = title;
            Content = content;
            OKCommand = new ViewModelCommand(param =>
            {
                CloseDialog(DialogResult.OK);
                ExecuteOKCommand(param);
            });
        }
        public CustomMessageBoxViewModel() { }
        private void CloseDialog(DialogResult result)
        {
            DialogClosed?.Invoke(result);
        }
        private void ExecuteOKCommand(object obj)
        {
            if (obj is Window window)
            {
                window.Close();
            }
        }
    }
}
