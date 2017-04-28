using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCU.GSMAS.DAL
{
    public static class SqlHelper
    {
        private static readonly string conStr = ConfigurationManager.ConnectionStrings["mssql"].ConnectionString;

        //insert delete update
        public static int ExecuteNonQuery(string sql, CommandType cmdType, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = cmdType;
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }


        //返回单个值
        public static object ExecuteScalar(string sql,CommandType cmdType,params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = cmdType;
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        //返回reader
        public static SqlDataReader ExecuteReader(string sql, CommandType cmdType, params SqlParameter[] pms)
        {
            SqlConnection con = new SqlConnection(conStr);
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.CommandType = cmdType;
                if (pms != null)
                {
                    cmd.Parameters.AddRange(pms);
                }
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();

                    }
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                catch
                {
                    con.Close();
                    con.Dispose();
                    throw;
                }
            }
        }

        //返回datatable
        public static DataTable ExecuteDataTable(string sql, CommandType cmdType, params SqlParameter[] pms)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(conStr);
            using(SqlDataAdapter adapter = new SqlDataAdapter(sql, con))
            {
                if (pms != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(pms);
                }
                adapter.Fill(dt);
            }
            return dt;
        }

    }
}
