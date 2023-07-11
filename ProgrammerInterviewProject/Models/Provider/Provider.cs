using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using ProgrammerInterviewProject.Models.dbconn;

namespace ProgrammerInterviewProject.Models
{
    public class Provider
    {
        conn dbconn = new conn();
        internal DataTable getData(SqlConnection sc)
        {
            string sqlstr = "";
            sqlstr = string.Format(@"
select * from employee
");
            DataTable getData = new DataTable();
            getData = dbconn.GetDataTable(sc, sqlstr);
            return getData;
        }
    }
}