using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace Web.Common
{
    public class Template
    {
        XmlDocument xml = new XmlDocument();
        string tempType;

        private Template(string path, string tempType)
        {
            this.tempType = tempType;
            xml.Load(HttpContext.Current.Server.MapPath(path));
        }

        public static Screen SmallScreen;
        public static Screen BigScreen;

        static Template()
        {
            string small = "/Views/Template/SmallScreen/Template.xml";
            SmallScreen = new Screen() {
                ContentTemplate = new Template(small, "contentTemplate"),
                HiringTemplate = new Template(small, "hiringTemplate"),
                PageTemplate = new Template(small, "pageTemplate"),
                ProductTemplate = new Template(small, "productTemplate")
            };

            string big = "/Views/Template/BigScreen/Template.xml";
            BigScreen = new Screen() {
                ContentTemplate = new Template(big, "contentTemplate"),
                HiringTemplate = new Template(big, "hiringTemplate"),
                PageTemplate = new Template(big, "pageTemplate"),
                ProductTemplate = new Template(big, "productTemplate")
            };
        }

        public Dictionary<string, string> Indexs
        {
            get
            {
                Dictionary<string, string> indexs = new Dictionary<string, string>();
                XmlNodeList nodelist = xml.SelectNodes("/template/" + tempType + "/index/shared");
                foreach (XmlNode item in nodelist)
                {
                    var key = item.Attributes["name"].Value;
                    var val = item.Attributes["pageName"].Value;
                    indexs.Add(key, val);
                }
                return indexs;
            }
        }

        public Dictionary<string, string> Lists
        {
            get
            {
                Dictionary<string, string> indexs = new Dictionary<string, string>();
                XmlNodeList nodelist = xml.SelectNodes("/template/" + tempType + "/list/shared");
                foreach (XmlNode item in nodelist)
                {
                    var key = item.Attributes["name"].Value;
                    var val = item.Attributes["pageName"].Value;
                    indexs.Add(key, val);
                }
                return indexs;
            }
        }

        public Dictionary<string, string> Contents
        {
            get
            {
                Dictionary<string, string> indexs = new Dictionary<string, string>();
                XmlNodeList nodelist = xml.SelectNodes("/template/" + tempType + "/content/shared");
                foreach (XmlNode item in nodelist)
                {
                    var key = item.Attributes["name"].Value;
                    var val = item.Attributes["pageName"].Value;
                    indexs.Add(key, val);
                }
                return indexs;
            }
        }
    }

    public class Screen
    {
        public Template PageTemplate { get; set; }
        public Template ContentTemplate { get; set; }
        public Template ProductTemplate { get; set; }
        public Template HiringTemplate { get; set; }
    }
}