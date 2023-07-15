using System.Collections.Generic;
using YRE.DataSource;

namespace YRE.ProgrammerInterviewProject.Models.DataObject
{
    public class Model_DataObject_Employee
    {
        /// <summary>
        /// Get Employ Table 
        /// Table Name : employee
        /// Table Info : 公司資訊
        /// </summary>
        public string Emp_id { get; set; }
        public string Fname { get; set; }
        public string Minit { get; set; }
        public string Lname { get; set; }
        public int Job_id { get; set; }
        public int Job_lvl { get; set; }
        public int Pub_id { get; set; }
        public int Hire_date { get; set; }

        /// <summary>
        /// 分頁的參數
        /// </summary>
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int PagerCount { get; set; }

        /// <summary>
        /// Link 後段 employee 資料處裡
        /// </summary>
        public List<YRE_DataSource_Employee> Employees { get; set; }
    }
}