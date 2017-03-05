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
    public class CLASSSUBJECTMARKSController
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


    }
}