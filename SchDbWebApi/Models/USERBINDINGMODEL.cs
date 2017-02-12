using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchDbWebApi.Models
{
    public class USERBINDINGMODEL
    {
        public int buid { get; set; }
        public string bustudentid { get; set; }
        public string buparentid { get; set; }
        public string buclasssectionid { get; set; }
        public string bucreateddate { get; set; }
        public string bumodifieddate { get; set; }
        public string bustatus { get; set; }
        public int buoid { get; set; }
    }
}