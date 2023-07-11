using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace ProgrammerInterviewProject.Models.dbconn
{
    public class conn
    {
        public DataTable GetDataTable(SqlConnection sc, string sqlstr)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection sqlConn = new SqlConnection(sc.ConnectionString))
                {
                    sqlConn.Open();
                    SqlCommand sqlComm = new SqlCommand();
                    sqlComm.Connection = sqlConn;
                    sqlComm.CommandTimeout = 3000;
                    sqlComm.CommandText = sqlstr;

                    SqlDataAdapter adapter = new SqlDataAdapter(sqlComm);
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (SqlException e)
            {
                return null;
            }
        }
        public DataTable GetDataTable(SqlConnection sc, string sqlstr, int Timeout)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection sqlConn = new SqlConnection(sc.ConnectionString))
                {
                    sqlConn.Open();
                    SqlCommand sqlComm = new SqlCommand();
                    sqlComm.Connection = sqlConn;
                    sqlComm.CommandTimeout = Timeout;
                    sqlComm.CommandText = sqlstr;

                    SqlDataAdapter adapter = new SqlDataAdapter(sqlComm);
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (SqlException e)
            {
                return null;
            }
        }
    }
}