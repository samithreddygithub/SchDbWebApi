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

    public class CLASSSUBJECTSTUDENTMARK
    {
        public int cssmid { get; set; }
        public int classid { get; set; }
        public string testid { get; set; }
        public int studentid { get; set; }
        public int subjectid { get; set; }
        public int marks { get; set; }
    }

    public class CLASSSUBJECTSTUDENTMARKREAD
    {
        public int classid { get; set; }
        public string testid { get; set; }
        public int studentid { get; set; }
        public string studentname { get; set; }
        public int subjectid { get; set; }
        public string subjectname { get; set; }
        public int marks { get; set; }
    }

}
