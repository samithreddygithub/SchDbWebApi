using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchDbWebApi.Models
{
    public class CLASSSUBJECTMARKS
    { 
        public int cssmrkid { get; set; }
        public string clssecid { get; set; }
    }

    public class CLASSSUBJECT
    {
        public int clssubid { get; set; }
        public string clssubjectname { get; set; }
    }

    public class CLASSSTUDENT
    {
        public int clsstudid { get; set; }
        public string clsstudentname { get; set; }
    }

}
