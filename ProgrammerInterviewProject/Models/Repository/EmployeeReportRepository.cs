using System;
using System.Collections.Generic;
using System.Data;
using YRE.DataSource;
using YRE.DataSource.Entity;
using YRE.ProgrammerInterviewProject.Models.DataObject;


namespace YRE.ProgrammerInterviewProject.Models.Repository
{
    public class EmployeeReportRepository : IRepository_EmployeeReport
    {
        private static EmployeeReportRepository sharedRepository = new EmployeeReportRepository();
        private Dictionary<string, Model_DataObject_Employee> employees = new Dictionary<string, Model_DataObject_Employee>();
        public static EmployeeReportRepository SharedRepository => sharedRepository;

        public EmployeeReportRepository() {
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
                        Job_id = Convert.ToInt32(drEmployee[4].ToString().Trim()),
                        Job_lvl = Convert.ToInt32(drEmployee[5].ToString().Trim()),
                        Pub_id = Convert.ToInt32(drEmployee[6].ToString().Trim()),
                        Hire_date = Convert.ToInt32(drEmployee[7].ToString().Trim())
                    }
                );
            }
            foreach (var e in EmployeeItems) {
                AddEmployeeReport(e);
            }
            employees.Add("Error", null);
        }

        /// <summary>
        /// 回傳列舉<Model_DataObject_Employee> 的參數
        /// </summary>
        public IEnumerable<Model_DataObject_Employee> Employees => employees.Values;

        /// <summary>
        /// 將employee的資料加入Dictionary的employees
        /// </summary>
        /// <param name="e">Model_DataObject_Employee參數</param>
        public void AddEmployeeReport(Model_DataObject_Employee e) => employees.Add(e.Emp_id, e);
    }
}
