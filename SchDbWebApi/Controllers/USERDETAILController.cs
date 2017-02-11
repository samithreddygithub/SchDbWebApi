using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchDbWebApi.Controllers
{
    public class USERDETAILController : ApiController
    {
        string connectionstring = ConfigurationManager.ConnectionStrings["SCHDBWEBAPI"].ConnectionString;



    }
}
