using SchDbWebApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchDbWebApi.Controllers
{
    public class USERDETAILController : ApiController
    {
        string connectionstring = ConfigurationManager.ConnectionStrings["SCHDBWEBAPI"].ConnectionString;

        //Create
        [HttpPost]
        [ActionName("usercreate")]
        [Route("api/USERDETAIL/usercreate")]
        public string usercreate(USERMODEL UM)
        {
            string savedcount;
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("USERTABLEDETAILS_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "C");
                    command.Parameters.AddWithValue("@USRID", "");
                    command.Parameters.AddWithValue("@USRROLETYPE", UM.usrroletype);
                    command.Parameters.AddWithValue("@USRFATHERNAME", UM.usrfathername);
                    command.Parameters.AddWithValue("@USRFMOBILENEUMBER", UM.usrfmobilenumber);
                    command.Parameters.AddWithValue("@USRFEMAILID", UM.usrfemailid);
                    command.Parameters.AddWithValue("@USRMOTHERNAME", UM.usrmothername);
                    command.Parameters.AddWithValue("@USRMMOBILENUMBER", UM.usrmmobilenumber);
                    command.Parameters.AddWithValue("@USRMEMAILID", UM.usrmemailid);
                    command.Parameters.AddWithValue("@USRFULLNAME", UM.usrfullname);
                    command.Parameters.AddWithValue("@USRREGISTERNUMBER", UM.usrregisternumber);
                    command.Parameters.AddWithValue("@USRMOBILENUMBER", UM.usrmobilenumber);
                    command.Parameters.AddWithValue("@USREMAILID", UM.usremailid);
                    command.Parameters.AddWithValue("@USRNAME", UM.usrname);
                    command.Parameters.AddWithValue("@USRPASSWORD", UM.usrpassword);
                    command.Parameters.AddWithValue("@USRADDRESS", UM.usraddress);
                    command.Parameters.AddWithValue("@USRCREATEDDATE", UM.usrcreateddate);
                    command.Parameters.AddWithValue("@USRMODIFIEDDATE", UM.usrmodifieddate);
                    command.Parameters.AddWithValue("@USRSTATUS", UM.usrstatus);
                    command.Parameters.AddWithValue("@USROID", UM.usroid);
                    savedcount = command.ExecuteNonQuery().ToString();
                }
                catch (Exception ex)
                {
                    savedcount = ex.ToString();
                }
            }
            return savedcount;
        }


        //Update
        [HttpPut]
        [ActionName("userupdate")]
        [Route("api/USERDETAIL/userupdate")]
        public string userupdate(USERMODEL UM)
        {
            string updatecount;
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("USERTABLEDETAILS_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "U");
                    command.Parameters.AddWithValue("@USRID", UM.usrid);
                    command.Parameters.AddWithValue("@USRROLETYPE", UM.usrroletype);
                    command.Parameters.AddWithValue("@USRFATHERNAME", UM.usrfathername);
                    command.Parameters.AddWithValue("@USRFMOBILENEUMBER", UM.usrfmobilenumber);
                    command.Parameters.AddWithValue("@USRFEMAILID", UM.usrfemailid);
                    command.Parameters.AddWithValue("@USRMOTHERNAME", UM.usrmothername);
                    command.Parameters.AddWithValue("@USRMMOBILENUMBER", UM.usrmmobilenumber);
                    command.Parameters.AddWithValue("@USRMEMAILID", UM.usrmemailid);
                    command.Parameters.AddWithValue("@USRFULLNAME", UM.usrfullname);
                    command.Parameters.AddWithValue("@USRREGISTERNUMBER", UM.usrregisternumber);
                    command.Parameters.AddWithValue("@USRMOBILENUMBER", UM.usrmobilenumber);
                    command.Parameters.AddWithValue("@USREMAILID", UM.usremailid);
                    command.Parameters.AddWithValue("@USRNAME", UM.usrname);
                    command.Parameters.AddWithValue("@USRPASSWORD", UM.usrpassword);
                    command.Parameters.AddWithValue("@USRADDRESS", UM.usraddress);
                    command.Parameters.AddWithValue("@USRCREATEDDATE", UM.usrcreateddate);
                    command.Parameters.AddWithValue("@USRMODIFIEDDATE", UM.usrmodifieddate);
                    command.Parameters.AddWithValue("@USRSTATUS", UM.usrstatus);
                    command.Parameters.AddWithValue("@USROID", UM.usroid);
                    updatecount = command.ExecuteNonQuery().ToString();
                }
                catch (Exception ex)
                {
                    updatecount = ex.ToString();
                }
            }
            return updatecount;
        }


        //Read
        [HttpGet]
        [ActionName("userread")]
        [Route("api/USERDETAIL/userread")]
        public List<USERMODEL> userread()
        {
            USERMODEL UM = new USERMODEL();
            List<USERMODEL> LUM = new List<USERMODEL>();

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("USERDETAILS_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "R");
                    SqlDataReader sdatareader = null;
                    sdatareader = command.ExecuteReader();
                    while (sdatareader.Read())
                    {
                        LUM.Add(new USERMODEL()
                        {
                            usrid = Convert.ToInt32(sdatareader["USRID"]),
                            usrroletype = sdatareader["USRROLETYPE"].ToString(),
                            usrfathername = sdatareader["USRFATHERNAME"].ToString(),
                            usrfmobilenumber = sdatareader["USRFMOBILENEUMBER"].ToString(),
                            usrfemailid = sdatareader["USRFEMAILID"].ToString(),
                            usrmothername = sdatareader["USRMOTHERNAME"].ToString(),
                            usrmmobilenumber = sdatareader["USRMMOBILENUMBER"].ToString(),
                            usrmemailid = sdatareader["USRMEMAILID"].ToString(),
                            usrfullname = sdatareader["USRFULLNAME"].ToString(),
                            usrregisternumber = sdatareader["USRREGISTERNUMBER"].ToString(),
                            usrmobilenumber = sdatareader["USRMOBILENUMBER"].ToString(),
                            usremailid = sdatareader["USREMAILID"].ToString(),
                            usrname = sdatareader["USRNAME"].ToString(),
                            usrpassword = sdatareader["USRPASSWORD"].ToString(),
                            usraddress = sdatareader["USRADDRESS"].ToString(),
                            usrcreateddate = sdatareader["USRCREATEDDATE"].ToString(),
                            usrmodifieddate = sdatareader["USRMODIFIEDDATE"].ToString(),
                            usrstatus = sdatareader["USRSTATUS"].ToString(),                            
                            usroid = Convert.ToInt32(sdatareader["USROID"])
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return LUM;
            }
        }

        //Read id
        [HttpGet]
        [ActionName("userread")]
        [Route("api/USERDETAIL/userread/{id}")]
        public List<USERMODEL> userread(int id)
        {
            USERMODEL UM = new USERMODEL();
            List<USERMODEL> LUM = new List<USERMODEL>();

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("USERDETAILS_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "R");
                    command.Parameters.AddWithValue("@USRID", id);
                    SqlDataReader sdatareader = null;
                    sdatareader = command.ExecuteReader();
                    while (sdatareader.Read())
                    {
                        LUM.Add(new USERMODEL()
                        {
                            usrid = Convert.ToInt32(sdatareader["USRID"]),
                            usrroletype = sdatareader["USRROLETYPE"].ToString(),
                            usrfathername = sdatareader["USRFATHERNAME"].ToString(),
                            usrfmobilenumber = sdatareader["USRFMOBILENEUMBER"].ToString(),
                            usrfemailid = sdatareader["USRFEMAILID"].ToString(),
                            usrmothername = sdatareader["USRMOTHERNAME"].ToString(),
                            usrmmobilenumber = sdatareader["USRMMOBILENUMBER"].ToString(),
                            usrmemailid = sdatareader["USRMEMAILID"].ToString(),
                            usrfullname = sdatareader["USRFULLNAME"].ToString(),
                            usrregisternumber = sdatareader["USRREGISTERNUMBER"].ToString(),
                            usrmobilenumber = sdatareader["USRMOBILENUMBER"].ToString(),
                            usremailid = sdatareader["USREMAILID"].ToString(),
                            usrname = sdatareader["USRNAME"].ToString(),
                            usrpassword = sdatareader["USRPASSWORD"].ToString(),
                            usraddress = sdatareader["USRADDRESS"].ToString(),
                            usrcreateddate = sdatareader["USRCREATEDDATE"].ToString(),
                            usrmodifieddate = sdatareader["USRMODIFIEDDATE"].ToString(),
                            usrstatus = sdatareader["USRSTATUS"].ToString(),
                            usroid = Convert.ToInt32(sdatareader["USROID"])
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return LUM;
            }
        }
    }
}
