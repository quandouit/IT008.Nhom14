using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using QuanLyChiTieu.Data.DTO;
using QuanLyChiTieu.View.CustomDialog;
using QuanLyChiTieu.ViewModel;
using QuanLyChiTieu.ViewModel.CustomDialogModel;

namespace QuanLyChiTieu.Data.DAO
{
    public class GiaoDichDAO : DBConnection
    {
        public static DataTable LietKeGiaoDich()
        {
            try
            {
                OpenConn();

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "SELECT ID, MAGD, TENGD, GD.MALOAIGD, TENLOAIGD, NGAYTAO, TIEN, GHICHU, TRANGTHAI FROM GIAODICH GD, LOAIGIAODICH LGD WHERE ID = @ID AND GD.MALOAIGD = LGD.MALOAIGD"; ;
                SqlParameter parameterTK = new SqlParameter("@ID", MainViewModel.currentUser.ID);
                sqlCmd.Parameters.Add(parameterTK);

                var reader = sqlCmd.ExecuteReader();

                var dt = new DataTable();
                dt.Load(reader);
                reader.Close();
                return dt;
            }

            catch (Exception)
            {
                return null;
            }
            finally
            {
                CloseConn();
            }
        }
        public static int ThemGiaoDich(GiaoDichDTO obj)
        {
            try
            {
                OpenConn();

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Connection = sqlCon;

                sqlCmd.CommandText = "BEGIN TRANSACTION insert into GIAODICH (ID, MALOAIGD, TENGD, TIEN, GHICHU, NGAYTAO)\r\nvalues\r\n(@ID , @MALOAIGD , @TENGD , @TIEN , @GHICHU , @NGAYTAO) COMMIT;";
                SqlParameter parameter0 = new SqlParameter("@ID", obj.ID);
                sqlCmd.Parameters.Add(parameter0);
                SqlParameter parameter1 = new SqlParameter("@MALOAIGD", obj.MaLoaiGD);
                sqlCmd.Parameters.Add(parameter1);
                SqlParameter parameter2 = new SqlParameter("@TENGD", obj.TenGD);
                sqlCmd.Parameters.Add(parameter2);
                SqlParameter parameter3 = new SqlParameter("@TIEN", obj.Tien);
                sqlCmd.Parameters.Add(parameter3);
                SqlParameter parameter4 = new SqlParameter("@GHICHU", obj.GhiChu);
                sqlCmd.Parameters.Add(parameter4);
                SqlParameter parameter5 = new SqlParameter("@NGAYTAO", obj.NgayTao);
                sqlCmd.Parameters.Add(parameter5);

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
        public static int XoaGiaoDich(int MAGD)
        {
            try
            {
                OpenConn();

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Connection = sqlCon;
                
                sqlCmd.CommandText = "DELETE FROM GIAODICH WHERE MAGD = @MAGD"; 
                SqlParameter parameter0 = new SqlParameter("@MAGD", MAGD);
                sqlCmd.Parameters.Add(parameter0);
                
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
        public static int SuaGiaoDich(GiaoDichDTO obj)
        {
            try
            {
                OpenConn();

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Connection = sqlCon;

                sqlCmd.CommandText = "UPDATE GIAODICH\r\nSET MALOAIGD = @MALOAIGD, TENGD = @TENGD, TIEN = @TIEN, GHICHU = @GHICHU, NGAYTAO = @NGAYTAO\r\nWHERE MAGD = @MAGD;";

                SqlParameter parameter1 = new SqlParameter("@MALOAIGD", obj.MaLoaiGD);
                sqlCmd.Parameters.Add(parameter1);
                SqlParameter parameter2 = new SqlParameter("@TENGD", obj.TenGD);
                sqlCmd.Parameters.Add(parameter2);
                SqlParameter parameter3 = new SqlParameter("@TIEN", obj.Tien);
                sqlCmd.Parameters.Add(parameter3);
                SqlParameter parameter4 = new SqlParameter("@GHICHU", obj.GhiChu);
                sqlCmd.Parameters.Add(parameter4);
                SqlParameter parameter5 = new SqlParameter("@NGAYTAO", obj.NgayTao);
                sqlCmd.Parameters.Add(parameter5);

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
        public static DataTable PhanLoaiGiaoDichOUT()
        {
            try
            {
                OpenConn();

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Connection = sqlCon;

                sqlCmd.CommandText = "select GIAODICH.MALOAIGD, TENLOAIGD, SUM(TIEN) AS SUMTIEN from GIAODICH" +
                                     "\r\ninner join LOAIGIAODICH on GIAODICH.MALOAIGD = LOAIGIAODICH.MALOAIGD" +
                                     "\r\nWHERE ID = @ID AND TRANGTHAI = 'OUT' AND MONTH(NGAYTAO) = @MONTH AND YEAR(NGAYTAO) = @YEAR" +
                                     "\r\nGROUP BY GIAODICH.MALOAIGD, TENLOAIGD";
                SqlParameter parameterTK = new SqlParameter("@ID", MainViewModel.currentUser.ID);
                sqlCmd.Parameters.Add(parameterTK);
                SqlParameter parameterM = new SqlParameter("@MONTH", DateTime.Now.Month);
                sqlCmd.Parameters.Add(parameterM);
                SqlParameter parameterY = new SqlParameter("@YEAR", DateTime.Now.Year);
                sqlCmd.Parameters.Add(parameterY);

                var reader = sqlCmd.ExecuteReader();

                var dt = new DataTable();
                dt.Load(reader);
                reader.Close();
                return dt;
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
        }
        public static DataTable PhanLoaiGiaoDichIN()
        {
            try
            {
                OpenConn();

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Connection = sqlCon;

                sqlCmd.CommandText = "select GIAODICH.MALOAIGD, TENLOAIGD, SUM(TIEN) AS SUMTIEN from GIAODICH" +
                                     "\r\ninner join LOAIGIAODICH on GIAODICH.MALOAIGD = LOAIGIAODICH.MALOAIGD" +
                                     "\r\nWHERE ID = @ID AND TRANGTHAI = 'IN' AND MONTH(NGAYTAO) = @MONTH AND YEAR(NGAYTAO) = @YEAR" +
                                     "\r\nGROUP BY GIAODICH.MALOAIGD, TENLOAIGD";
                SqlParameter parameterTK = new SqlParameter("@ID", MainViewModel.currentUser.ID);
                sqlCmd.Parameters.Add(parameterTK);
                SqlParameter parameterM = new SqlParameter("@MONTH", DateTime.Now.Month);
                sqlCmd.Parameters.Add(parameterM);
                SqlParameter parameterY = new SqlParameter("@YEAR", DateTime.Now.Year);
                sqlCmd.Parameters.Add(parameterY);

                var reader = sqlCmd.ExecuteReader();

                var dt = new DataTable();
                dt.Load(reader);
                reader.Close();
                return dt;
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
        }
    }
}
