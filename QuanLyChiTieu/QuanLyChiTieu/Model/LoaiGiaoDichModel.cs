﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Model
{
    public class LoaiGiaoDichModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public LoaiGiaoDichModel() { }
        public int MaLoaiGD { get; set; }
        public string TenLoaiGD { get; set; }
        public string TrangThai { get; set; }
    }
}
