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
    public class USERBINDINGDETAILController : ApiController
    {
        string connectionstring = ConfigurationManager.ConnectionStrings["SCHDBWEBAPI"].ConnectionString;

        //Create
        [HttpPost]
        [ActionName("userbindingcreate")]
        [Route("api/USERBINDINGDETAIL/userbindingcreate")]
        public string userbindingcreate(USERBINDINGMODEL UBM)
        {
            string savedcount;
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("BINDINGUSERTABLEDETAILS_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "C");
                    command.Parameters.AddWithValue("@BUID", "");
                    command.Parameters.AddWithValue("@BUSTUDENTID", UBM.bustudentid);
                    command.Parameters.AddWithValue("@BUPARENTID", UBM.buparentid);
                    command.Parameters.AddWithValue("@BUCLASSSECTIONID", UBM.buclasssectionid);
                    command.Parameters.AddWithValue("@BUCREATEDDATE", UBM.bucreateddate);
                    command.Parameters.AddWithValue("@BUMODIFIEDDATE", UBM.bumodifieddate);
                    command.Parameters.AddWithValue("@BUSTATUS", UBM.bustatus);
                    command.Parameters.AddWithValue("@BUOID", UBM.buoid);
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
        [ActionName("userbindingupdate")]
        [Route("api/USERBINDINGDETAIL/userbindingupdate")]
        public string userbindingupdate(USERBINDINGMODEL UBM)
        {
            string savedcount;
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("BINDINGUSERTABLEDETAILS_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "U");
                    command.Parameters.AddWithValue("@BUID", UBM.buid);
                    command.Parameters.AddWithValue("@BUSTUDENTID", UBM.bustudentid);
                    command.Parameters.AddWithValue("@BUPARENTID", UBM.buparentid);
                    command.Parameters.AddWithValue("@BUCLASSSECTIONID", UBM.buclasssectionid);
                    command.Parameters.AddWithValue("@BUCREATEDDATE", UBM.bucreateddate);
                    command.Parameters.AddWithValue("@BUMODIFIEDDATE", UBM.bumodifieddate);
                    command.Parameters.AddWithValue("@BUSTATUS", UBM.bustatus);
                    command.Parameters.AddWithValue("@BUOID", UBM.buoid);
                    savedcount = command.ExecuteNonQuery().ToString();
                }
                catch (Exception ex)
                {
                    savedcount = ex.ToString();
                }
            }
            return savedcount;
        }

        //Read
        [HttpGet]
        [ActionName("userbindingread")]
        [Route("api/COMMONDETAIL/userbindingread")]
        public List<USERBINDINGMODEL> userbindingread()
        {
            USERBINDINGMODEL UBM = new USERBINDINGMODEL();
            List<USERBINDINGMODEL> LUBM = new List<USERBINDINGMODEL>();

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("BINDINGUSERTABLEDETAILS_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;                    
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "R");
                    SqlDataReader sdatareader = null;
                    sdatareader = command.ExecuteReader();
                    while (sdatareader.Read())
                    {
                        LUBM.Add(new USERBINDINGMODEL()
                        {
                            buid = Convert.ToInt32(sdatareader["BUID"]),
                            bustudentid = sdatareader["BUSTUDENTID"].ToString(),
                            buparentid = sdatareader["BUPARENTID"].ToString(),
                            buclasssectionid = sdatareader["BUCLASSSECTIONID"].ToString(),
                            bucreateddate = sdatareader["BUCREATEDDATE"].ToString(),
                            bumodifieddate = sdatareader["BUMODIFIEDDATE"].ToString(),
                            bustatus = sdatareader["BUSTATUS"].ToString(),
                            buoid = Convert.ToInt32(sdatareader["BUOID"])
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return LUBM;
            }
        }

        //Read id
        [HttpGet]
        [ActionName("userbindingread")]
        [Route("api/COMMONDETAIL/userbindingread/{id}")]
        public List<USERBINDINGMODEL> userbindingread(int id)
        {
            USERBINDINGMODEL UBM = new USERBINDINGMODEL();
            List<USERBINDINGMODEL> LUBM = new List<USERBINDINGMODEL>();

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("BINDINGUSERTABLEDETAILS_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "R");
                    command.Parameters.AddWithValue("@BUID", id);
                    SqlDataReader sdatareader = null;
                    sdatareader = command.ExecuteReader();
                    while (sdatareader.Read())
                    {
                        LUBM.Add(new USERBINDINGMODEL()
                        {
                            buid = Convert.ToInt32(sdatareader["BUID"]),
                            bustudentid = sdatareader["BUSTUDENTID"].ToString(),
                            buparentid = sdatareader["BUPARENTID"].ToString(),
                            buclasssectionid = sdatareader["BUCLASSSECTIONID"].ToString(),
                            bucreateddate = sdatareader["BUCREATEDDATE"].ToString(),
                            bumodifieddate = sdatareader["BUMODIFIEDDATE"].ToString(),
                            bustatus = sdatareader["BUSTATUS"].ToString(),
                            buoid = Convert.ToInt32(sdatareader["BUOID"])
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return LUBM;
            }
        }

    }
}
