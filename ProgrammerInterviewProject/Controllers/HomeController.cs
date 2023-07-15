using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using YRE.DataSource.Entity;
using YRE.DataSource;
using YRE.ProgrammerInterviewProject.Models;
using YRE.ProgrammerInterviewProject.Models.DataObject;
using YRE.ProgrammerInterviewProject.Models.Repository;

namespace YRE.ProgrammerInterviewProject.Controllers
{
    public class HomeController : Controller
    {
        public IRepository_EmployeeReport IRepository_EmployeeReport = EmployeeReportRepository.SharedRepository;
        public IRepository_EmployeeDetail IRepository_EmployeeDetail = EmployeeDetailRepository.SharedRepository;

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult SelfResume()
        {

            return View();
        }

        # region EmployeeReport
        [HttpPost]
        public ActionResult EmployeeReport() => View(IRepository_EmployeeReport.Employees);

        [HttpGet]
        public ActionResult EmployeeReport(int? pageNumber)
        {
            DataSourceEntity _DataSourceEntity = new DataSourceEntity();
            Model_DataObject_Employee _Model_DataObject_Employee = new Model_DataObject_Employee();
            _Model_DataObject_Employee.PageNumber = (pageNumber == null ? 1 : Convert.ToInt32(pageNumber));
            _Model_DataObject_Employee.PageSize = 10;

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
        #endregion

        # region EmployeeDetail
        public ActionResult EmployeeDetail(int? pageNumber, int pub_id)
        {
            DataSourceEntity _DataSourceEntity = new DataSourceEntity();
            Model_DataObject_PubInfo _Model_DataObject_PubInfo = new Model_DataObject_PubInfo();
            _Model_DataObject_PubInfo.PageNumber = (pageNumber == null ? 1 : Convert.ToInt32(pageNumber));
            _Model_DataObject_PubInfo.PageSize = 10;

            var pubinfo = YRE_DataSource_PubInfo.GetSamplePubInfos(_DataSourceEntity.GetPubInfo()).Where(x => x.Pub_id == pub_id);

            if (pubinfo != null)
            {
                foreach (var item in pubinfo)
                {
                    _Model_DataObject_PubInfo.Pub_id = item.Pub_id;
                    _Model_DataObject_PubInfo.Logo = item.Logo;
                    _Model_DataObject_PubInfo.Pub_name = item.Pub_name;
                    _Model_DataObject_PubInfo.Pr_info = item.Pr_info;
                    _Model_DataObject_PubInfo.State = item.State;
                    _Model_DataObject_PubInfo.City = item.City;
                    _Model_DataObject_PubInfo.Country = item.Country;
                }

                _Model_DataObject_PubInfo.PubInfos = pubinfo.OrderBy(x => x.Pub_id)
                          .Skip(_Model_DataObject_PubInfo.PageSize * (_Model_DataObject_PubInfo.PageNumber - 1))
                          .Take(_Model_DataObject_PubInfo.PageSize).ToList();

                _Model_DataObject_PubInfo.TotalCount = pubinfo.Count();
                var page = (_Model_DataObject_PubInfo.TotalCount / _Model_DataObject_PubInfo.PageSize) -
                           (_Model_DataObject_PubInfo.TotalCount % _Model_DataObject_PubInfo.PageSize == 0 ? 1 : 0);
                _Model_DataObject_PubInfo.PagerCount = page + 1;

                return View("EmployeeDetail", _Model_DataObject_PubInfo);
            }

            return View();
        }
        #endregion
        [HttpGet]
        public ActionResult WebGrid_Employee()
        {
            DataSourceEntity _DataSourceEntity = new DataSourceEntity();
            Model_DataObject_Employee _Model_DataObject_Employee = new Model_DataObject_Employee();
            _Model_DataObject_Employee.PageSize = 10;

            List<YRE_DataSource_Employee> employees = YRE_DataSource_Employee.GetSampleEmployees(_DataSourceEntity.GetEmployee());

            if (employees != null)
            {
                _Model_DataObject_Employee.TotalCount = employees.Count();
                _Model_DataObject_Employee.Employees = employees;
            }

            return View(_Model_DataObject_Employee);
        }
        public ActionResult WebGrid_PubInfo()
        {
            DataSourceEntity _DataSourceEntity = new DataSourceEntity();
            Model_DataObject_PubInfo _Model_DataObject_PubInfo = new Model_DataObject_PubInfo();
            _Model_DataObject_PubInfo.PageSize = 10;

            List<YRE_DataSource_PubInfo> pubinfos = YRE_DataSource_PubInfo.GetSamplePubInfos(_DataSourceEntity.GetPubInfo());

            if (pubinfos != null)
            {
                _Model_DataObject_PubInfo.TotalCount = pubinfos.Count();
                _Model_DataObject_PubInfo.PubInfos = pubinfos;
            }

            return View(_Model_DataObject_PubInfo);
        }
    }
}