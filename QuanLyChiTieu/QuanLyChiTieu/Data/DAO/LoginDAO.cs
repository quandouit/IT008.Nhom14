using QuanLyChiTieu.Data.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using QuanLyChiTieu.ViewModel.CustomDialogModel;
using QuanLyChiTieu.View.CustomDialog;

namespace QuanLyChiTieu.Data.DAO
{
    public class LoginDAO : DBConnection
    {
        public static NguoiDungDTO Try_Login(NguoiDungDTO user)
        {
            NguoiDungDTO rt = new NguoiDungDTO
            {
                ID = 0,
                TaiKhoan = null,
                MatKhau = null,
                Sdt = null,
                TongTien = 0
            };
            try
            {
                OpenConn(); 

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "select * from NGUOIDUNG where TAIKHOAN = @TAIKHOAN and MATKHAU = @MATKHAU";

                SqlParameter parameterTK = new SqlParameter("@TAIKHOAN", user.TaiKhoan.ToString());
                sqlCmd.Parameters.Add(parameterTK);
                SqlParameter parameterMK = new SqlParameter("@MATKHAU", user.MatKhau.ToString());
                sqlCmd.Parameters.Add(parameterMK);
                
                using (SqlDataReader reader = sqlCmd.ExecuteReader())
                {
                    if(reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            rt.ID = reader.GetInt32(0);
                            rt.TaiKhoan = reader.GetString(1);
                            rt.MatKhau = reader.GetString(2);
                            rt.Sdt = reader.GetString(3);
                            rt.TongTien = reader.GetDecimal(4);
                        }
                    }    
                }    
            }

            catch (Exception ex)
            {
                CustomMessageBoxViewModel dialogViewModel = new CustomMessageBoxViewModel("Lỗi database", ex.Message);
                CustomMessageBox messageBox = new CustomMessageBox { DataContext = dialogViewModel };
                messageBox.ShowDialog();

                rt.ID = -1;
                return rt;
            }
            finally
            {
                CloseConn();
            }

            return rt;
        }
    }
}
