using QuanLyChiTieu.Data.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanLyChiTieu.Data.DAO
{
    public class LoginDAO : DBConnection
    {
        public static NguoiDungDTO Try_Login(NguoiDungDTO user)
        {
            NguoiDungDTO rt = new NguoiDungDTO();
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
                    else
                    {
                        rt.ID = 0;
                        rt.TaiKhoan = null;
                        rt.MatKhau = null;
                        rt.Sdt = null;
                        rt.TongTien = 0;
                    }    
                }    
            }

            catch (Exception  ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                CloseConn();
            }

            return rt;
        }
    }
}
