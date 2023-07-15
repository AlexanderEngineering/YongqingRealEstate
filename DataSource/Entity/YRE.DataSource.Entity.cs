using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using YRE.DataSource.Provider;

namespace YRE.DataSource.Entity
{
    public class DataSourceEntity
    {
        private static string db_name = "pubs";

        public DataTable GetData()
        {
            DataTable getdt = new DataTable();
            try
            {
                using (SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings[db_name].ConnectionString))
                {
                    getdt = DataSourceProvider.getemployee(sc);
                    return getdt;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public DataTable GetEmployee()
        {
            try
            {
                DataTable dtemployee = new DataTable();
                #region getdt DataColumn
                dtemployee.Columns.Add(new DataColumn("Emp_id"));
                dtemployee.Columns.Add(new DataColumn("Fname"));
                dtemployee.Columns.Add(new DataColumn("Minit"));
                dtemployee.Columns.Add(new DataColumn("Lname"));
                dtemployee.Columns.Add(new DataColumn("Job_id"));
                dtemployee.Columns.Add(new DataColumn("Job_lvl"));
                dtemployee.Columns.Add(new DataColumn("Pub_id"));
                dtemployee.Columns.Add(new DataColumn("Hire_date"));
                #endregion
                using (SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings[db_name].ConnectionString))
                {
                    DataTable dt = DataSourceProvider.getemployee(sc);
                    DateTime dateTime = DateTime.Now;
                    foreach (DataRow dr in dt.Rows)
                    {
                        DataRow dremployee = dtemployee.NewRow();
                        dateTime = (DateTime)dr[7];
                        dremployee["Emp_id"] = dr[0].ToString().Trim();
                        dremployee["Fname"] = dr[1].ToString().Trim();
                        dremployee["Minit"] = dr[2].ToString().Trim();
                        dremployee["Lname"] = dr[3].ToString().Trim();
                        dremployee["Job_id"] = dr[4].ToString().Trim();
                        dremployee["Job_lvl"] = dr[5].ToString().Trim();
                        dremployee["Pub_id"] = dr[6].ToString().Trim();
                        dremployee["Hire_date"] = dateTime.ToString("yyyyMMdd").Trim();
                        dtemployee.Rows.Add(dremployee);
                    }
                    return dtemployee;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
