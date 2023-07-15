﻿using System.Collections.Generic;
using System.Data;
using YRE.DataSource;
using YRE.DataSource.Entity;
using YRE.ProgrammerInterviewProject.Models.DataObject;


namespace YRE.ProgrammerInterviewProject.Models 
{
    public class EmployeeRepository : IRepository_Employee
    {
        private static EmployeeRepository sharedRepository = new EmployeeRepository();
        private Dictionary<string, Model_DataObject_Employee> employees = new Dictionary<string, Model_DataObject_Employee>();
        public static EmployeeRepository SharedRepository => sharedRepository;

        public EmployeeRepository() {
            DataSourceEntity _DataSourceEntity = new DataSourceEntity();
            DataTable dtEmployee = _DataSourceEntity.GetEmployee();
            var EmployeeItems = new List<Model_DataObject_Employee>();
            foreach (DataRow drEmployee in dtEmployee.Rows)
            {
                EmployeeItems.Add(
                    new Model_DataObject_Employee
                    {
                        Emp_id = drEmployee[0].ToString().Trim(),
                        Fname = drEmployee[1].ToString().Trim(),
                        Minit = drEmployee[2].ToString().Trim(),
                        Lname = drEmployee[3].ToString().Trim(),
                        Job_id = drEmployee[4].ToString().Trim(),
                        Job_lvl = drEmployee[5].ToString().Trim(),
                        Pub_id = drEmployee[6].ToString().Trim(),
                        Hire_date = drEmployee[7].ToString().Trim()
                    }
                );
            }
            foreach (var e in EmployeeItems) {
                AddEmployee(e);
            }
            employees.Add("Error", null);
        }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Model_DataObject_Employee> Employees => employees.Values;

        /// <summary>
        /// 將employee的資料加入Dictionary的employees
        /// </summary>
        /// <param name="e">Model_DataObject_Employee參數</param>
        public void AddEmployee(Model_DataObject_Employee e) => employees.Add(e.Emp_id, e);
    }
}
