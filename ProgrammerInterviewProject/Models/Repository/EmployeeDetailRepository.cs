using System;
using System.Collections.Generic;
using System.Data;
using YRE.DataSource;
using YRE.DataSource.Entity;
using YRE.ProgrammerInterviewProject.Models.DataObject;


namespace YRE.ProgrammerInterviewProject.Models.Repository
{
    public class EmployeeDetailRepository : IRepository_EmployeeDetail
    {
        private static EmployeeDetailRepository sharedRepository = new EmployeeDetailRepository();
        private Dictionary<string, Model_DataObject_PubInfo> pubinfos = new Dictionary<string, Model_DataObject_PubInfo>();
        public static EmployeeDetailRepository SharedRepository => sharedRepository;

        public EmployeeDetailRepository() {
            DataSourceEntity _DataSourceEntity = new DataSourceEntity();
            DataTable dtPubInfo = _DataSourceEntity.GetPubInfo();
            var EmployeeItems = new List<Model_DataObject_PubInfo>();
            foreach (DataRow drPubInfo in dtPubInfo.Rows)
            {
                EmployeeItems.Add(
                    new Model_DataObject_PubInfo
                    {
                        Pub_id = Convert.ToInt32(drPubInfo[0].ToString().Trim()),
                        Logo = "",
                        Pub_name = drPubInfo[2].ToString().Trim(),
                        Pr_info = drPubInfo[3].ToString().Trim(),
                        State = drPubInfo[4].ToString().Trim(),
                        City = drPubInfo[5].ToString().Trim(),
                        Country = drPubInfo[6].ToString().Trim()
                    }
                );
            }
            foreach (var p in EmployeeItems) {
                AddPubInfoDetail(p);
            }
            pubinfos.Add("Error", null);
        }

        /// <summary>
        /// 回傳列舉<Model_DataObject_PubInfo> 的參數
        /// </summary>
        public IEnumerable<Model_DataObject_PubInfo> PubInfos => pubinfos.Values;

        /// <summary>
        /// 將pubinfo的資料加入Dictionary的pubinfos
        /// </summary>
        /// <param name="p">Model_DataObject_PubInfo參數</param>
        public void AddPubInfoDetail(Model_DataObject_PubInfo p) => pubinfos.Add(p.Pub_id.ToString().Trim(), p);
    }
}
