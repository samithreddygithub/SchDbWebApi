using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchDbWebApi.Models
{
    public class USERMODEL
    {
        public int usrid { get; set; }
        public string usrroletype { get; set; }
        public string usrfathername { get; set; }
        public string usrfmobilenumber { get; set; }
        public string usrfemailid { get; set; }
        public string usrmothername { get; set; }
        public string usrmmobilenumber { get; set; }
        public string usrmemailid { get; set; }
        public string usrfullname { get; set; }
        public string usrregisternumber { get; set; }
        public string usrmobilenumber { get; set; }
        public string usremailid { get; set; }
        public string usrname { get; set; }
        public string usrpassword { get; set; }
        public string usraddress { get; set; }
        public string usrcreateddate { get; set; }
        public string usrmodifieddate { get; set; }
        public string usrstatus { get; set; }
        public int usroid { get; set; }
    }
}