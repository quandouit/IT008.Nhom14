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
                sqlCmd.CommandText = "SELECT ID, MAGD, ROW_NUMBER() OVER (ORDER BY NGAYTAO DESC) AS STT, TENGD, GD.MALOAIGD, TENLOAIGD, NGAYTAO, TIEN, GHICHU, TRANGTHAI FROM GIAODICH GD, LOAIGIAODICH LGD WHERE ID = @ID AND GD.MALOAIGD = LGD.MALOAIGD"; ;
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
                MessageBox.Show(ex.Message);
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
                MessageBox.Show(ex.Message);
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
