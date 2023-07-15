using System.Collections.Generic;
using YRE.DataSource;
using YRE.ProgrammerInterviewProject.Models.DataObject;


namespace YRE.ProgrammerInterviewProject.Models {

    public interface IRepository_Employee
    {

        IEnumerable<Model_DataObject_Employee> Employees { get; }
        void AddEmployee(Model_DataObject_Employee e);
    }
}

