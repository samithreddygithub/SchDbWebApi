using SchDbWebApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SchDbWebApi.Controllers
{
    public class CLASSSUBJECTMARKSController : ApiController
    {
        string connectionstring = ConfigurationManager.ConnectionStrings["SCHDBWEBAPI"].ConnectionString;

        //Read Subject
        [HttpGet]
        [ActionName("subjectread")]
        [Route("api/CLASSSUBJECTMARKS/subjectread/{classid}")]
        public List<CLASSSUBJECT> subjectread(int classid)
        {
            CLASSSUBJECT CS = new CLASSSUBJECT();
            List<CLASSSUBJECT> LCS = new List<CLASSSUBJECT>();

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("CLASSSUBJECTSTUDENT_READ", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "R");
                    command.Parameters.AddWithValue("@CLASSID", classid);
                    command.Parameters.AddWithValue("@TYPE", "SUBJECT");
                    SqlDataReader sdatareader = null;
                    sdatareader = command.ExecuteReader();
                    while (sdatareader.Read())
                    {
                        LCS.Add(new CLASSSUBJECT()
                        {
                            clssubid = Convert.ToInt32(sdatareader["CSUBID"]),
                            clssubjectname = sdatareader["CSUBSUBJECTNAME"].ToString()
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return LCS;
            }

        }


        //Read Students
        [HttpGet]
        [ActionName("studentsread")]
        [Route("api/CLASSSUBJECTMARKS/studentsread/{classid}")]
        public List<CLASSSTUDENT> studentsread(int classid)
        {
            CLASSSTUDENT CST = new CLASSSTUDENT();
            List<CLASSSTUDENT> LCST = new List<CLASSSTUDENT>();

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("CLASSSUBJECTSTUDENT_READ", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "R");
                    command.Parameters.AddWithValue("@CLASSID", classid);
                    command.Parameters.AddWithValue("@TYPE", "STUDENT");
                    SqlDataReader sdatareader = null;
                    sdatareader = command.ExecuteReader();
                    while (sdatareader.Read())
                    {
                        LCST.Add(new CLASSSTUDENT()
                        {
                            clsstudid = Convert.ToInt32(sdatareader["USRID"]),
                            clsstudentname = sdatareader["USRFULLNAME"].ToString()
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return LCST;
            }

        }


        //Create or Update
        [HttpPost]
        [ActionName("classsubjectstudentmark")]
        [Route("api/CLASSSUBJECTMARKS/classsubjectstudentmark")]
        public string classsubjectstudentmark(CLASSSUBJECTSTUDENTMARK CSSM)
        {
            string savedcount;
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("CLASSSUBJECTSTUDENTMARK_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;                   
                    command.Parameters.AddWithValue("@CSSMID", "");
                    command.Parameters.AddWithValue("@CLASSID", CSSM.classid);
                    command.Parameters.AddWithValue("@TESTID", CSSM.testid.Trim());
                    command.Parameters.AddWithValue("@STUDENTID", CSSM.studentid);
                    command.Parameters.AddWithValue("@SUBJECTID", CSSM.subjectid);
                    command.Parameters.AddWithValue("@MARKS", CSSM.marks);                    
                    savedcount = command.ExecuteNonQuery().ToString();
                }
                catch (Exception ex)
                {
                    savedcount = ex.ToString();
                }
            }
            return savedcount;
        }

        //Read Class Subject Student Marks
        [HttpGet]
        [ActionName("classsubjectstudentmarkread")]
        [Route("api/CLASSSUBJECTMARKS/classsubjectstudentmarkread/{classid}/{testid}")]
        public List<CLASSSUBJECTSTUDENTMARKREAD> classsubjectstudentmarkread(int classid,string testid)
        {
            CLASSSUBJECTSTUDENTMARKREAD CSSMR = new CLASSSUBJECTSTUDENTMARKREAD();
            List<CLASSSUBJECTSTUDENTMARKREAD> LCSSMR = new List<CLASSSUBJECTSTUDENTMARKREAD>();

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("CLASSSUBJECTSTUDENTMARK_READ", connection);
                    command.CommandType = CommandType.StoredProcedure;                    
                    command.Parameters.AddWithValue("@CLASSID", classid);
                    command.Parameters.AddWithValue("@TESTID", testid);
                    SqlDataReader sdatareader = null;
                    sdatareader = command.ExecuteReader();
                    while (sdatareader.Read())
                    {
                        LCSSMR.Add(new CLASSSUBJECTSTUDENTMARKREAD()
                        {
                            classid = Convert.ToInt32(sdatareader["CSID"]),
                            testid = sdatareader["TESTID"].ToString(),
                            studentid = Convert.ToInt32(sdatareader["USRID"]),
                            studentname = sdatareader["USRFULLNAME"].ToString(),
                            subjectid = Convert.ToInt32(sdatareader["SUBJECTID"]),
                            subjectname = sdatareader["CSUBSUBJECTNAME"].ToString(),
                            marks = Convert.ToInt32(sdatareader["MARKS"])
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return LCSSMR;
            }

        }

    }
}