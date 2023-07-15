using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using YRE.DataSource.Entity;
using YRE.DataSource;
using YRE.ProgrammerInterviewProject.Models;
using YRE.ProgrammerInterviewProject.Models.DataObject;

namespace YRE.ProgrammerInterviewProject.Controllers
{
    public class HomeController : Controller
    {
        public IRepository_Employee IRepository_Employee = EmployeeRepository.SharedRepository;

        public ActionResult Index()
        {

            return View();
        }


        public ActionResult AddEmployee() 
        {
            return View();
        }

        //[HttpGet]
        //public ActionResult AddEmployee() => View(new Model_DataObject_Employee());

        //[HttpPost]
        //public ActionResult AddEmployee(Model_DataObject_Employee e)
        //{
        //    IRepository_Employee.AddEmployee(e);
        //    return RedirectToAction("Index");
        //}

        public ActionResult SelfResume()
        {

            return View();
        }

        
        [HttpPost]
        public ActionResult EmployeeReport() => View(IRepository_Employee.Employees);

        [HttpGet]
        public ActionResult EmployeeReport(int? pageNumber)
        {
            DataSourceEntity _DataSourceEntity = new DataSourceEntity();
            Model_DataObject_Employee _Model_DataObject_Employee = new Model_DataObject_Employee();
            _Model_DataObject_Employee.PageNumber = (pageNumber == null ? 1 : Convert.ToInt32(pageNumber));
            _Model_DataObject_Employee.PageSize = 4;

            List<YRE_DataSource_Employee> employees = YRE_DataSource_Employee.GetSampleEmployees(_DataSourceEntity.GetEmployee());

            if (employees != null)
            {
                _Model_DataObject_Employee.Employees = employees.OrderBy(x => x.Emp_id)
                          .Skip(_Model_DataObject_Employee.PageSize * (_Model_DataObject_Employee.PageNumber - 1))
                          .Take(_Model_DataObject_Employee.PageSize).ToList();

                _Model_DataObject_Employee.TotalCount = employees.Count();
                var page = (_Model_DataObject_Employee.TotalCount / _Model_DataObject_Employee.PageSize) -
                           (_Model_DataObject_Employee.TotalCount % _Model_DataObject_Employee.PageSize == 0 ? 1 : 0);
                _Model_DataObject_Employee.PagerCount = page + 1;
            }

            return View(_Model_DataObject_Employee);
        }

        public ActionResult WebGrid()
        {
            DataSourceEntity _DataSourceEntity = new DataSourceEntity();
            Model_DataObject_Employee _Model_DataObject_Employee = new Model_DataObject_Employee();
            _Model_DataObject_Employee.PageSize = 4;

            List<YRE_DataSource_Employee> employees = YRE_DataSource_Employee.GetSampleEmployees(_DataSourceEntity.GetEmployee());

            if (employees != null)
            {
                _Model_DataObject_Employee.TotalCount = employees.Count();
                _Model_DataObject_Employee.Employees = employees;
            }

            return View(_Model_DataObject_Employee);
        }

        public ActionResult GetProducts(string sidx, string sord, int page, int rows)
        {
            DataSourceEntity _DataSourceEntity = new DataSourceEntity();
            var employees = YRE_DataSource_Employee.GetSampleEmployees(_DataSourceEntity.GetEmployee());
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            int totalRecords = employees.Count;
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);

            var data = employees.OrderBy(x => x.Emp_id)
                          .Skip(pageSize * (page - 1))
                          .Take(pageSize).ToList();

            var jsonData = new
            {
                total = totalPages,
                page = page,
                records = totalRecords,
                rows = data
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult jqGrid()
        {

            return View();
        }

    }
}