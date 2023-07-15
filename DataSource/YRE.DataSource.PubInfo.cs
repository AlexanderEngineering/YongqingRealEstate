using System;
using System.Collections.Generic;
using System.Data;

namespace YRE.DataSource
{
    public class YRE_DataSource_PubInfo
    {
        readonly int pub_id;
        readonly string logo;
        readonly string pub_name;
        readonly string pr_info;
        readonly string state;
        readonly string city;
        readonly string country;

        public int Pub_id { get { return pub_id; } }
        public string Logo { get { return logo; } }
        public string Pub_name { get { return pub_name; } }
        public string Pr_info { get { return pr_info; } }
        public string State { get { return state; } }
        public string City { get { return city; } }
        public string Country { get { return country; } }

        public YRE_DataSource_PubInfo(int pub_id, string logo, string pub_name, string pr_info, string state, string city, string country)
        {
            this.pub_id = pub_id;
            this.logo = logo;
            this.pub_name = pub_name;
            this.pr_info = pr_info;
            this.state = state;
            this.city = city;
            this.country = country;
        }

        YRE_DataSource_PubInfo() { }

        public static List<YRE_DataSource_PubInfo> GetSamplePubInfos(DataTable dtpubinfo)
        {
            List<YRE_DataSource_PubInfo> lstpubinfo = new List<YRE_DataSource_PubInfo>();

            foreach (DataRow drpubinfo in dtpubinfo.Rows)
            {
                lstpubinfo.Add
                    (
                        new YRE_DataSource_PubInfo
                        (
                            pub_id: Convert.ToInt32(drpubinfo[0].ToString().Trim()),
                            logo: "",
                            pub_name: drpubinfo[2].ToString().Trim(),
                            pr_info: drpubinfo[3].ToString().Trim(),
                            state: drpubinfo[4].ToString().Trim(),
                            city: drpubinfo[5].ToString().Trim(),
                            country: drpubinfo[6].ToString().Trim()
                        )
                    );
            }
            return lstpubinfo;
        }
    }
}
