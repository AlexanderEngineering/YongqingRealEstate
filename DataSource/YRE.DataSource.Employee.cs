﻿using System;
using System.Collections.Generic;
using System.Data;

namespace YRE.DataSource
{
    public class YRE_DataSource_Employee
    {
        readonly string emp_id;
        readonly string fname;
        readonly string minit;
        readonly string lname;
        readonly int job_id;
        readonly int job_lvl;
        readonly int pub_id;
        readonly int hire_date;

        public string Emp_id { get { return emp_id; } }
        public string Fname { get { return fname; } }
        public string Minit { get { return minit; } }
        public string Lname { get { return lname; } }
        public int Job_id { get { return job_id; } }
        public int Job_lvl { get { return job_lvl; } }
        public int Pub_id { get { return pub_id; } }
        public int Hire_date { get { return hire_date; } }

        public YRE_DataSource_Employee(string emp_id, string fname, string minit, string lname, int job_id, int job_lvl, int pub_id, int hire_date)
        {
            this.emp_id = emp_id;
            this.fname = fname;
            this.minit = minit;
            this.lname = lname;
            this.job_id = job_id;
            this.job_lvl = job_lvl;
            this.pub_id = pub_id;
            this.hire_date = hire_date;
        }

        YRE_DataSource_Employee() { }

        public static List<YRE_DataSource_Employee> GetSampleEmployees(DataTable dtemployees)
        {
            List<YRE_DataSource_Employee> lstemployees = new List<YRE_DataSource_Employee>();

            foreach (DataRow dremployees in dtemployees.Rows)
            {
                lstemployees.Add
                    (
                        new YRE_DataSource_Employee
                        (
                            emp_id: dremployees[0].ToString().Trim(),
                            fname: dremployees[1].ToString().Trim(),
                            minit: dremployees[2].ToString().Trim(),
                            lname: dremployees[3].ToString().Trim(),
                            job_id: Convert.ToInt32(dremployees[4].ToString().Trim()),
                            job_lvl: Convert.ToInt32(dremployees[5].ToString().Trim()),
                            pub_id: Convert.ToInt32(dremployees[6].ToString().Trim()),
                            hire_date: Convert.ToInt32(dremployees[7].ToString().Trim())
                        )
                    );
            }
            return lstemployees;
        }
    }
}
