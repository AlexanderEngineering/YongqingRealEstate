using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace ProgrammerInterviewProject.Models
{
    public class Entity
    {
        private static string db_name = "pubs";

        public DataTable GetData()
        {
            Provider _provider = new Provider();
            DataTable getdt = new DataTable();
            try 
            {
                using (SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings[db_name].ConnectionString))
                {
                    //sc.Open();
                    //sc.CreateCommand();

                    getdt = _provider.getData(sc);
                    
                    return getdt;

                }
            }
            catch (Exception ex)
            { 
                return null;
            }
        }

    }
}