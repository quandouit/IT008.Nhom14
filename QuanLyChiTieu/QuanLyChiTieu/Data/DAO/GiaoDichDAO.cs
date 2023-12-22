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
                sqlCmd.CommandText = "SELECT ID, MAGD, ROW_NUMBER() OVER (ORDER BY NGAYTAO DESC) AS STT, TENGD, TENLOAIGD, NGAYTAO, TIEN, TRANGTHAI FROM GIAODICH GD, LOAIGIAODICH LGD WHERE ID = @ID AND GD.MALOAIGD = LGD.MALOAIGD"; ;
                SqlParameter parameterTK = new SqlParameter("@ID", QuanLyChiTieu.SourceClass.mainUser.ID);
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

                sqlCmd.CommandText = "insert into GIAODICH (ID, MALOAIGD, TENGD, TIEN, MINHHOA, GHICHU, NGAYTAO)\r\nvalues\r\n('@ID' , '@MALOAIGD' , '@TENGD' , '@TIEN' , @MINHHOA , '@GHICHU' , '@NGAYTAO');";
                SqlParameter parameter0 = new SqlParameter("@ID", obj.ID);
                sqlCmd.Parameters.Add(parameter0);
                SqlParameter parameter1 = new SqlParameter("@MALOAIGD", obj.MaLoaiGD);
                sqlCmd.Parameters.Add(parameter1);
                SqlParameter parameter2 = new SqlParameter("@TENGD", obj.TenGD);
                sqlCmd.Parameters.Add(parameter2);
                SqlParameter parameter3 = new SqlParameter("@TIEN", obj.Tien);
                sqlCmd.Parameters.Add(parameter3);
                SqlParameter parameter4 = new SqlParameter("@MINHHOA", obj.MinhHoa);
                sqlCmd.Parameters.Add(parameter4);
                SqlParameter parameter5 = new SqlParameter("@GHICHU", obj.GhiChu);
                sqlCmd.Parameters.Add(parameter5);
                SqlParameter parameter6 = new SqlParameter("@NGAYTAO", obj.NgayTao);
                sqlCmd.Parameters.Add(parameter6);

                sqlCmd.ExecuteNonQuery();
            }

            catch (Exception)
            {
                return 1;
            }
            finally
            {
                CloseConn();
            }
            return 0;
        }
        public static int XoaGiaoDich(object MAGD)
        {
            try
            {
                OpenConn();

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Connection = sqlCon;

                sqlCmd.CommandText = "BEGIN TRANSACTION;\r\nDELETE FROM GIAODICH\r\nWHERE MAGD = @MAGD;\r\nCOMMIT;";
                SqlParameter parameter0 = new SqlParameter("@MAGD", MAGD);
                sqlCmd.Parameters.Add(parameter0);

                sqlCmd.ExecuteNonQuery();
            }

            catch (Exception)
            {
                return 1;
            }
            finally
            {
                CloseConn();
            }
            return 0;
        }
        public static void HienThiChiTietGiaoDich(object MAGD)
        {
            //try
            //{
            //    OpenConn();

            //    SqlCommand sqlCmd = new SqlCommand();
            //    sqlCmd.CommandType = CommandType.Text;
            //    sqlCmd.Connection = sqlCon;
            //    sqlCmd.CommandText = "SELECT TENGD, TENLOAIGD, TIEN, NGAYTAO, GHICHU FROM GIAODICH GD, LOAIGIAODICH LGD WHERE MAGD = @MAGD AND GD.MALOAIGD = LGD.MALOAIGD";
            //    SqlParameter parameterTK = new SqlParameter("@MAGD", MAGD);
            //    sqlCmd.Parameters.Add(parameterTK);

            //    var reader = sqlCmd.ExecuteReader();
            //    DetailDialog detailDialog = new DetailDialog();

            //    if(reader.HasRows)
            //    {
            //        while(reader.Read())
            //        {
            //            detailDialog.tengiaodich.Text = reader[0].ToString();
            //            detailDialog.loaigiaodich.Text = reader[1].ToString();
            //            detailDialog.sotien.Text = reader[2].ToString();
            //            detailDialog.ngaytao.Text = reader[3].ToString();
            //            detailDialog.ghichu.Text = reader[4].ToString();
            //        }
            //    }
            //    detailDialog.Show();
                
            //}

            //catch (Exception)
            //{
            //    return;
            //}
            //finally
            //{
            //    CloseConn();
            //}
        }
    }
}
