﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

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
                sqlCmd.CommandText = "SELECT ROW_NUMBER() OVER (ORDER BY NGAYTAO DESC) AS STT, TENGD, TENLOAIGD, NGAYTAO, TIEN, TRANGTHAI FROM GIAODICH GD, LOAIGIAODICH LGD WHERE ID = @ID AND GD.MALOAIGD = LGD.MALOAIGD"; ;
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
    }
}
