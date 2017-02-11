using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchDbWebApi.Models
{
    public class COMMONMODEL
    {
    }

    public class CLASSSECTIONMODEL
    {
        public int csid { get; set; }
        public string csclassname { get; set; }
        public string cssectionname { get; set; }
        public string cscreateddate { get; set; }
        public string csmodifieddate { get; set; }
        public string csstatus { get; set; }
        public int csoid { get; set; }
    }

    public class CLASSSUBJECTMODEL
    {
        public int csubid { get; set; }
        public int csubclasssectionid { get; set; }
        public string csubsubjectname { get; set; }
        public int csstaffnameid { get; set; }
        public string csubcreateddate { get; set; }
        public string csubmodifieddate { get; set; }
        public string csubstatus { get; set; }
        public int csuboid { get; set; }
    }

}