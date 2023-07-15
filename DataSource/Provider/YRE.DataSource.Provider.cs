using System.Data;
using System.Data.SqlClient;
using SqlConn;

namespace YRE.DataSource.Provider
{
    public class DataSourceProvider
    {
        internal static DataTable getemployee(SqlConnection sc)
        {
            string sqlstr = string.Format(@"
select * from employee
");
            DataTable getData = SqlAccess.GetDataTable(sc, sqlstr);
            return getData;
        }

        internal static DataTable GetPubInfo(SqlConnection sc)
        {
            string sqlstr = string.Format(@"
select pi.pub_id,pi.logo,ps.pub_name,pi.pr_info,ps.state,ps.city,ps.country 
from publishers ps,pub_info pi
where ps.pub_id = pi.pub_id");
            DataTable getData = SqlAccess.GetDataTable(sc, sqlstr);
            return getData;
        }
    }
}
