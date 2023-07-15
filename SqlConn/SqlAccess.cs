using System.Data;
using System.Data.SqlClient;

namespace SqlConn
{
    public class SqlAccess
    {
        public static DataTable GetDataTable(SqlConnection sc, string sqlstr)
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
        public static DataTable GetDataTable(SqlConnection sc, string sqlstr, int Timeout)
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
