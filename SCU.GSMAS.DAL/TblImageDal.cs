using SCU.GSMAS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCU.GSMAS.DAL
{
    public class TblImageDal
    {
        public List<TblImage> GetList()
        {
            string sql = "select * from TblImage";
            List<TblImage> list = new List<TblImage>();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, System.Data.CommandType.Text))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TblImage model = new TblImage();
                        model.im_id = reader.GetInt32(0);
                        model.im_path = reader.GetString(1);
                        model.im_fileName = reader.GetString(2);
                        model.im_time = reader.GetDateTime(3);
                        model.im_resolution = reader.IsDBNull(4) ? null : (int?)reader.GetInt32(4);
                        model.im_saveLevel = reader.IsDBNull(5) ? null : (int?)reader.GetInt32(5);
                        model.cam_id = reader.IsDBNull(6) ? null : (int?)reader.GetInt32(6);
                        model.sp_id = reader.IsDBNull(7) ? null : (int?)reader.GetInt32(7);
                        model.userId = reader.GetInt32(8);
                        list.Add(model);
                    }
                }
            }
            return list;
        }


        public List<TblImage> GetListBySpId(int sid)
        {
            string sql = "select * from TblImage where sp_id=@sid";
            List<TblImage> list = new List<TblImage>();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, System.Data.CommandType.Text,
                new SqlParameter("@sid", System.Data.SqlDbType.Int) { Value = sid }))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TblImage model = new TblImage();
                        model.im_id = reader.GetInt32(0);
                        model.im_path = reader.GetString(1);
                        model.im_fileName = reader.GetString(2);
                        model.im_time = reader.GetDateTime(3);
                        model.im_resolution = reader.IsDBNull(4) ? null : (int?)reader.GetInt32(4);
                        model.im_saveLevel = reader.IsDBNull(5) ? null : (int?)reader.GetInt32(5);
                        model.cam_id = reader.IsDBNull(6) ? null : (int?)reader.GetInt32(6);
                        model.sp_id = reader.IsDBNull(7) ? null : (int?)reader.GetInt32(7);
                        model.userId = reader.GetInt32(8);
                        list.Add(model);
                    }
                }
            }
            return list;
        }

        public DataTable GetDataTable()
        {
            string sql = "select * from TblImage";
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text);
        }

        public DataTable GetDataTableBySpId(int sid)
        {
            string sql = "select * from TblImage where sp_id=@sid";
            return SqlHelper.ExecuteDataTable(sql, System.Data.CommandType.Text,
                new SqlParameter("@sid", System.Data.SqlDbType.Int) { Value = sid });
        }


        public TblImage GetModel(int id)
        {
            string sql = "select * from TblImage where im_id=@id";
            TblImage model = new TblImage();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, System.Data.CommandType.Text,
                new SqlParameter("@id", System.Data.SqlDbType.Int) { Value = id }))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        model.im_id = reader.GetInt32(0);
                        model.im_path = reader.GetString(1);
                        model.im_fileName = reader.GetString(2);
                        model.im_time = reader.GetDateTime(3);
                        model.im_resolution = reader.IsDBNull(4) ? null : (int?)reader.GetInt32(4);
                        model.im_saveLevel = reader.IsDBNull(5) ? null : (int?)reader.GetInt32(5);
                        model.cam_id = reader.IsDBNull(6) ? null : (int?)reader.GetInt32(6);
                        model.sp_id = reader.IsDBNull(7) ? null : (int?)reader.GetInt32(7);
                        model.userId = reader.GetInt32(8);
                    }
                }
            }
            return model;
        }

    }
}
