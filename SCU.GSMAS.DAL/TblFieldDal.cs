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
    public class TblFieldDal
    {
        public List<TblField> GetList()
        {
            string sql = "select * from TblField";
            List<TblField> list = new List<TblField>();
            using(SqlDataReader reader = SqlHelper.ExecuteReader(sql,System.Data.CommandType.Text))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TblField model = new TblField();
                        model.fd_id = reader.GetInt32(0);
                        model.fd_name = reader.IsDBNull(1) ? null : reader.GetString(1);
                        model.fd_addr = reader.IsDBNull(2) ? null : reader.GetString(2);
                        model.fd_desc = reader.IsDBNull(3) ? null : reader.GetString(3);
                        list.Add(model);
                    }
                }
            }
            return list; 
        }

        public DataTable GetDataTable()
        {
            string sql = "select * from TblField";
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text);
        }

    }
}
