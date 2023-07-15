using System.Collections.Generic;
using YRE.DataSource;
using YRE.ProgrammerInterviewProject.Models.DataObject;


namespace YRE.ProgrammerInterviewProject.Models.Repository
{

    public interface IRepository_EmployeeReport
    {
        IEnumerable<Model_DataObject_Employee> Employees { get; }
        void AddEmployeeReport(Model_DataObject_Employee e);
    }

    public interface IRepository_EmployeeDetail
    {
        IEnumerable<Model_DataObject_PubInfo> PubInfos { get; }
        void AddPubInfoDetail(Model_DataObject_PubInfo p);
    }
}

