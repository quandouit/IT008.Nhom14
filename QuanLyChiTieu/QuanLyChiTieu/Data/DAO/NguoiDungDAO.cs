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
using QuanLyChiTieu.View.CustomDialog;
using QuanLyChiTieu.ViewModel.CustomDialogModel;

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
                reader.Close();

                sqlCmd.CommandText = "SELECT * FROM NGUOIDUNG WHERE SDT = @SDT";
                SqlParameter parameter1 = new SqlParameter("@SDT", user.Sdt);
                sqlCmd.Parameters.Add(parameter1);

                reader = sqlCmd.ExecuteReader();
                if (reader.HasRows) return 3;
                reader.Close();

                SqlCommand sqlCmdAdd = new SqlCommand();
                sqlCmdAdd.CommandType = CommandType.Text;
                sqlCmdAdd.Connection = sqlCon;

                sqlCmdAdd.CommandText = "INSERT INTO NGUOIDUNG (TAIKHOAN, MATKHAU, SDT, TONGTIEN)\r\nVALUES\r\n(@TAIKHOAN , @MATKHAU , @SDT , @TONGTIEN);";
                SqlParameter parameter2 = new SqlParameter("@TAIKHOAN", user.TaiKhoan);
                sqlCmdAdd.Parameters.Add(parameter2);
                SqlParameter parameter3 = new SqlParameter("@MATKHAU", user.MatKhau);
                sqlCmdAdd.Parameters.Add(parameter3);
                SqlParameter parameter4 = new SqlParameter("@SDT", user.Sdt);
                sqlCmdAdd.Parameters.Add(parameter4);
                SqlParameter parameter5 = new SqlParameter("@TONGTIEN", user.TongTien);
                sqlCmdAdd.Parameters.Add(parameter5);

                sqlCmdAdd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                CustomMessageBoxViewModel dialogViewModel = new CustomMessageBoxViewModel("Lỗi database", ex.Message);
                CustomMessageBox messageBox = new CustomMessageBox { DataContext = dialogViewModel };
                messageBox.ShowDialog();

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
                CustomMessageBoxViewModel dialogViewModel = new CustomMessageBoxViewModel("Lỗi database", ex.Message);
                CustomMessageBox messageBox = new CustomMessageBox { DataContext = dialogViewModel };
                messageBox.ShowDialog();

                return 1;
            }
            finally
            {
                CloseConn();
            }
            return 0;
        }
        public static int DoiSotien(decimal sotien, int ID)
        {
            try
            {
                OpenConn();

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Connection = sqlCon;

                sqlCmd.CommandText = "UPDATE NGUOIDUNG\r\nSET TONGTIEN = @TONGTIEN\r\nWHERE ID = @ID";
                SqlParameter parameter0 = new SqlParameter("@TONGTIEN", sotien);
                sqlCmd.Parameters.Add(parameter0);
                SqlParameter parameter1 = new SqlParameter("@ID", ID);
                sqlCmd.Parameters.Add(parameter1);

                sqlCmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                CustomMessageBoxViewModel dialogViewModel = new CustomMessageBoxViewModel("Lỗi database", ex.Message);
                CustomMessageBox messageBox = new CustomMessageBox { DataContext = dialogViewModel };
                messageBox.ShowDialog();

                return 1;
            }
            finally
            {
                CloseConn();
            }
            return 0;
        }
        public static NguoiDungDTO ThongTinNguoiDung(NguoiDungDTO user)
        {
            NguoiDungDTO rt = new NguoiDungDTO();
            try
            {
                OpenConn();

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Connection = sqlCon;

                sqlCmd.CommandText = "SELECT * FROM NGUOIDUNG WHERE ID = @ID";
                SqlParameter parameter0 = new SqlParameter("@ID", user.ID);
                sqlCmd.Parameters.Add(parameter0);

                using (SqlDataReader reader = sqlCmd.ExecuteReader())
                {
                    if (reader.HasRows)
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

            catch (Exception ex)
            {
                CustomMessageBoxViewModel dialogViewModel = new CustomMessageBoxViewModel("Lỗi database", ex.Message);
                CustomMessageBox messageBox = new CustomMessageBox { DataContext = dialogViewModel };
                messageBox.ShowDialog();

                return null;
            }
            finally
            {
                CloseConn();
            }

            return rt;
        }
        public static decimal LaySoDu(int ID)
        {
            decimal rt = 0;
            try
            {
                OpenConn();

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Connection = sqlCon;

                sqlCmd.CommandText = "SELECT TONGTIEN FROM NGUOIDUNG WHERE ID = @ID";
                SqlParameter parameter0 = new SqlParameter("@ID", ID);
                sqlCmd.Parameters.Add(parameter0);

                var reader = sqlCmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read() && !reader.IsDBNull(0))
                    {
                        rt = reader.GetDecimal(0);
                    }
                }
            }

            catch (Exception ex)
            {
                CustomMessageBoxViewModel dialogViewModel = new CustomMessageBoxViewModel("Lỗi database", ex.Message);
                CustomMessageBox messageBox = new CustomMessageBox { DataContext = dialogViewModel };
                messageBox.ShowDialog();

                return -1;
            }
            finally
            {
                CloseConn();
            }
            return rt;
        }
        public static decimal LayTongChi(int ID, int month, int year)
        {
            decimal rt = 0;
            try
            {
                OpenConn();

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Connection = sqlCon;

                sqlCmd.CommandText = "SELECT SUM(TIEN) FROM GIAODICH " +
                                     "\r\nINNER JOIN NGUOIDUNG ON GIAODICH.ID = NGUOIDUNG.ID" +
                                     "\r\nINNER JOIN LOAIGIAODICH ON GIAODICH.MALOAIGD = LOAIGIAODICH.MALOAIGD" +
                                     "\r\nWHERE NGUOIDUNG.ID = @ID AND TRANGTHAI = 'OUT' AND MONTH(NGAYTAO) = @MONTH AND YEAR(NGAYTAO) = @YEAR";
                SqlParameter parameter0 = new SqlParameter("@ID", ID);
                sqlCmd.Parameters.Add(parameter0);
                SqlParameter parameter1 = new SqlParameter("@MONTH", month);
                sqlCmd.Parameters.Add(parameter1);
                SqlParameter parameter2 = new SqlParameter("@YEAR", year);
                sqlCmd.Parameters.Add(parameter2);

                var reader = sqlCmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read() && !reader.IsDBNull(0))
                    {
                        rt = reader.GetDecimal(0);
                    }
                }
            }

            catch (Exception ex)
            {
                CustomMessageBoxViewModel dialogViewModel = new CustomMessageBoxViewModel("Lỗi database", ex.Message);
                CustomMessageBox messageBox = new CustomMessageBox { DataContext = dialogViewModel };
                messageBox.ShowDialog();

                return -1;
            }
            finally
            {
                CloseConn();
            }
            return rt;
        }
        public static decimal LayTongThu(int ID, int month, int year)
        {
            decimal rt = 0;
            try
            {
                OpenConn();

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Connection = sqlCon;

                sqlCmd.CommandText = "SELECT SUM(TIEN) FROM GIAODICH " +
                                     "\r\nINNER JOIN NGUOIDUNG ON GIAODICH.ID = NGUOIDUNG.ID" +
                                     "\r\nINNER JOIN LOAIGIAODICH ON GIAODICH.MALOAIGD = LOAIGIAODICH.MALOAIGD" +
                                     "\r\nWHERE NGUOIDUNG.ID = @ID AND TRANGTHAI = 'IN' AND MONTH(NGAYTAO) = @MONTH AND YEAR(NGAYTAO) = @YEAR";
                SqlParameter parameter0 = new SqlParameter("@ID", ID);
                sqlCmd.Parameters.Add(parameter0);
                SqlParameter parameter1 = new SqlParameter("@MONTH", month);
                sqlCmd.Parameters.Add(parameter1);
                SqlParameter parameter2 = new SqlParameter("@YEAR", year);
                sqlCmd.Parameters.Add(parameter2);

                var reader = sqlCmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read() && !reader.IsDBNull(0))
                    {
                        rt = reader.GetDecimal(0);
                    }
                }
            }

            catch (Exception ex)
            {
                CustomMessageBoxViewModel dialogViewModel = new CustomMessageBoxViewModel("Lỗi database", ex.Message);
                CustomMessageBox messageBox = new CustomMessageBox { DataContext = dialogViewModel };
                messageBox.ShowDialog();

                return -1;
            }
            finally
            {
                CloseConn();
            }
            return rt;
        }
    }
}
