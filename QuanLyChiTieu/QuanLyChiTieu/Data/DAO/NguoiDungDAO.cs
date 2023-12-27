using QuanLyChiTieu.Data.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyChiTieu.ViewModel;

namespace QuanLyChiTieu.Data.DAO
{
    public class NguoiDungDAO : DBConnection
    {
        public static int ThemNguoiDung(NguoiDungDTO user)
        {   
            try
            {
                OpenConn();

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Connection = sqlCon;

                sqlCmd.CommandText = "SELECT * FROM NGUOIDUNG WHERE TAIKHOAN = @TAIKHOAN";
                SqlParameter parameter0 = new SqlParameter("@TAIKHOAN", user.TaiKhoan);
                sqlCmd.Parameters.Add(parameter0);

                var reader = sqlCmd.ExecuteReader();
                if (reader.HasRows) return 2;

                SqlCommand sqlCmdAdd = new SqlCommand();
                sqlCmdAdd.CommandType = CommandType.Text;
                sqlCmdAdd.Connection = sqlCon;

                sqlCmdAdd.CommandText = "INSERT INTO NGUOIDUNG (TAIKHOAN, MATKHAU, SDT, TONGTIEN)\r\nVALUES\r\n(@TAIKHOAN , @MATKHAU , @SDT , @TONGTIEN);";
                SqlParameter parameter1 = new SqlParameter("@TAIKHOAN", user.TaiKhoan);
                sqlCmdAdd.Parameters.Add(parameter1);
                SqlParameter parameter2 = new SqlParameter("@MATKHAU", user.MatKhau);
                sqlCmdAdd.Parameters.Add(parameter2);
                SqlParameter parameter3 = new SqlParameter("@SDT", user.Sdt);
                sqlCmdAdd.Parameters.Add(parameter3);
                SqlParameter parameter4 = new SqlParameter("@TONGTIEN", user.TongTien);
                sqlCmdAdd.Parameters.Add(parameter4);

                sqlCmdAdd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 1;
            }
            finally
            {
                CloseConn();
            }
            return 0;
        }
        public static int DoiMatKhau(string pass)
        {
            try
            {
                OpenConn();

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Connection = sqlCon;

                sqlCmd.CommandText = "UPDATE NGUOIDUNG\r\nSET MATKHAU = @MATKHAU\r\nWHERE ID = @ID";
                SqlParameter parameter0 = new SqlParameter("@MATKHAU", pass);
                sqlCmd.Parameters.Add(parameter0);
                SqlParameter parameter1 = new SqlParameter("@ID", MainViewModel.currentUser.ID);
                sqlCmd.Parameters.Add(parameter1);

                sqlCmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 1;
            }
            finally
            {
                CloseConn();
            }
            return 0;
        }
    }
}
