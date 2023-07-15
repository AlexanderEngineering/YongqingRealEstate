using System.Data;
using System.Data.SqlClient;
using SqlConn;

namespace YRE.DataSource.Provider
{
    public class DataSourceProvider
    {
        internal static DataTable getemployee(SqlConnection sc)
        {
            string sqlstr = "";
            sqlstr = string.Format(@"
select * from employee
");
            DataTable getData = new DataTable();
            getData = SqlAccess.GetDataTable(sc, sqlstr,1000);
            return getData;
        }

        internal static DataTable getpubinfo(SqlConnection sc)
        {
            string sqlstr = "";
            sqlstr = string.Format(@"
select pub_id,logo,pr_info from pub_info
");
            DataTable getData = new DataTable();
            getData = SqlAccess.GetDataTable(sc, sqlstr);
            return getData;
        }
    }
}
