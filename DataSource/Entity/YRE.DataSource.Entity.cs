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

        /// <summary>
        /// 列出指定PubID的PubInfo的資訊
        /// </summary>
        /// <param name="pub_id">傳來Employee的PubID</param>
        /// <returns>PubInfo的資訊</returns>
        public DataTable GetPubInfo()
        {
            try
            {
                DataTable dtpubinfo = new DataTable();
                #region getdt DataColumn
                dtpubinfo.Columns.Add(new DataColumn("Pub_ID"));
                dtpubinfo.Columns.Add(new DataColumn("Logo"));
                dtpubinfo.Columns.Add(new DataColumn("Pub_Name"));
                dtpubinfo.Columns.Add(new DataColumn("Pr_Info"));
                dtpubinfo.Columns.Add(new DataColumn("State"));
                dtpubinfo.Columns.Add(new DataColumn("City"));
                dtpubinfo.Columns.Add(new DataColumn("Country"));
                #endregion
                using (SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings[db_name].ConnectionString))
                {
                    DataTable dt = DataSourceProvider.GetPubInfo(sc);
                    foreach (DataRow dr in dt.Rows)
                    {
                        DataRow drpubinfo =  dtpubinfo.NewRow();
                        drpubinfo["Pub_ID"] = dr[0];
                        drpubinfo["Logo"] = "";
                        drpubinfo["Pub_Name"] = dr[2].ToString().Trim();
                        drpubinfo["Pr_Info"] = dr[3].ToString().Trim();
                        drpubinfo["State"] = dr[4].ToString().Trim();
                        drpubinfo["City"] = dr[5].ToString().Trim();
                        drpubinfo["Country"] = dr[6].ToString().Trim();
                        dtpubinfo.Rows.Add(drpubinfo);
                    }
                    return dtpubinfo;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 列出Employee所有資訊
        /// </summary>
        /// <returns>Employee所有資訊</returns>
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
