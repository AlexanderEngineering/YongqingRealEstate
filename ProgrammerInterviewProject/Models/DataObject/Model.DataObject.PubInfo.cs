using System;
using System.Collections.Generic;
using YRE.DataSource;

namespace YRE.ProgrammerInterviewProject.Models.DataObject
{
    public class Model_DataObject_PubInfo
    {
        /// <summary>
        /// Get Pub_info Table 
        /// Table Name : publishers, pub_info 
        /// Table Info : employee對應Pub_id的Pub_info
        /// </summary>
        public int Pub_id { get; set; }
        public string Logo { get; set; }
        public string Pub_name { get; set; }
        public string Pr_info { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        /// <summary>
        /// 分頁的參數
        /// </summary>
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int PagerCount { get; set; }

        /// <summary>
        /// Link 後段 pubinfo 資料處裡
        /// </summary>
        public List<YRE_DataSource_PubInfo> PubInfos { get; set; }
    }
}