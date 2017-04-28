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
    public class TblSpecimenDal
    {
        public List<TblSpecimen> GetList()
        {
            string sql = "select * from TblSpecimen";
            List<TblSpecimen> list = new List<TblSpecimen>();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, System.Data.CommandType.Text))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TblSpecimen model = new TblSpecimen();
                        model.sp_id = reader.GetInt32(0);
                        model.sp_no = reader.GetString(1);
                        model.sp_name = reader.IsDBNull(2) ? null : reader.GetString(2);
                        model.sp_desc = reader.IsDBNull(3) ? null : reader.GetString(3);
                        model.field_id = reader.GetInt32(4);
                        model.category_id = reader.GetInt32(5);
                        list.Add(model);
                    }
                }
            }
            return list;
        }


        public List<TblSpecimen> GetListByFieldId(int fid)
        {
            string strSql = "select * from TblSpecimen where field_id = @fid";
            List<TblSpecimen> list = new List<TblSpecimen>();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(strSql.ToString(), System.Data.CommandType.Text,
                new SqlParameter("@fid", System.Data.SqlDbType.Int) { Value = fid }))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TblSpecimen model = new TblSpecimen();
                        model.sp_id = reader.GetInt32(0);
                        model.sp_no = reader.GetString(1);
                        model.sp_name = reader.IsDBNull(2) ? null : reader.GetString(2);
                        model.sp_desc = reader.IsDBNull(3) ? null : reader.GetString(3);
                        model.field_id = reader.GetInt32(4);
                        model.category_id = reader.GetInt32(5);
                        list.Add(model);
                    }
                }
            }
            return list;
        }

        public DataTable GetDataTable()
        {
            string sql = "select * from TblSpecimen";
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text);
        }

        public DataTable GetDataTableByFieldId(int fid)
        {
            string strSql = "select * from TblSpecimen where field_id = @fid";
            return SqlHelper.ExecuteDataTable(strSql.ToString(), System.Data.CommandType.Text,
                new SqlParameter("@fid", System.Data.SqlDbType.Int) { Value = fid });
        }



    }

    
}