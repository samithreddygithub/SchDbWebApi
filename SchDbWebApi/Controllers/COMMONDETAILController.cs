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
    public class COMMONDETAILController : ApiController
    {
        string connectionstring = ConfigurationManager.ConnectionStrings["SCHDBWEBAPI"].ConnectionString;

        //Screen - Class Section

        //Create
        [HttpPost]
        [ActionName("classsectioncreate")]
        [Route("api/COMMONDETAIL/classsectioncreate")]
        public string classsectioncreate(CLASSSECTIONMODEL CSM)
        {
            string savedcount;
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("COMMONDETAILS_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TABLE_NAME", "CLASSSECTIONTABLE");
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "C");
                    command.Parameters.AddWithValue("@CSID", "");
                    command.Parameters.AddWithValue("@CSCLASSNAME", CSM.csclassname);
                    command.Parameters.AddWithValue("@CSSECTIONNAME", CSM.cssectionname);
                    command.Parameters.AddWithValue("@CREATEDDATE", CSM.cscreateddate);
                    command.Parameters.AddWithValue("@MODIFIEDDATE", CSM.csmodifieddate);
                    command.Parameters.AddWithValue("@STATUS", CSM.csstatus);
                    command.Parameters.AddWithValue("@OID", CSM.csoid);
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
        [ActionName("classsectionupdate")]
        [Route("api/COMMONDETAIL/classsectionupdate")]
        public string classsectionupdate(CLASSSECTIONMODEL CSM)
        {
            string updatecount;
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("COMMONDETAILS_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TABLE_NAME", "CLASSSECTIONTABLE");
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "U");
                    command.Parameters.AddWithValue("@CSID", CSM.csid);
                    command.Parameters.AddWithValue("@CSCLASSNAME", CSM.csclassname);
                    command.Parameters.AddWithValue("@CSSECTIONNAME", CSM.cssectionname);
                    command.Parameters.AddWithValue("@CREATEDDATE", CSM.cscreateddate);
                    command.Parameters.AddWithValue("@MODIFIEDDATE", CSM.csmodifieddate);
                    command.Parameters.AddWithValue("@STATUS", CSM.csstatus);
                    command.Parameters.AddWithValue("@OID", CSM.csoid);
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
        [ActionName("classsectionread")]
        [Route("api/COMMONDETAIL/classsectionread")]
        public List<CLASSSECTIONMODEL> classsectionread()
        {
            CLASSSECTIONMODEL CSM = new CLASSSECTIONMODEL();
            List<CLASSSECTIONMODEL> LCSM = new List<CLASSSECTIONMODEL>();

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("COMMONDETAILS_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TABLE_NAME", "CLASSSECTIONTABLE");
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "R");
                    SqlDataReader sdatareader = null;
                    sdatareader = command.ExecuteReader();
                    while (sdatareader.Read())
                    {
                        LCSM.Add(new CLASSSECTIONMODEL()
                        {
                            csid = Convert.ToInt32(sdatareader["CSID"]),
                            csclassname = sdatareader["CSCLASSNAME"].ToString(),
                            cssectionname = sdatareader["CSSECTIONNAME"].ToString(),
                            cscreateddate = sdatareader["CSCREATEDDATE"].ToString(),
                            csmodifieddate = sdatareader["CSMODIFIEDDATE"].ToString(),
                            csoid = Convert.ToInt32(sdatareader["CSOID"])
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return LCSM;
            }
        }

        //Read id
        [HttpGet]
        [ActionName("classsectionread")]
        [Route("api/COMMONDETAIL/classsectionread/{id}")]
        public List<CLASSSECTIONMODEL> classsectionread(int id)
        {
            CLASSSECTIONMODEL CSM = new CLASSSECTIONMODEL();
            List<CLASSSECTIONMODEL> LCSM = new List<CLASSSECTIONMODEL>();

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("COMMONDETAILS_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TABLE_NAME", "CLASSSECTIONTABLE");
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "R");
                    command.Parameters.AddWithValue("@CSID", id);
                    SqlDataReader sdatareader = null;
                    sdatareader = command.ExecuteReader();
                    while (sdatareader.Read())
                    {
                        LCSM.Add(new CLASSSECTIONMODEL()
                        {
                            csid = Convert.ToInt32(sdatareader["CSID"]),
                            csclassname = sdatareader["CSCLASSNAME"].ToString(),
                            cssectionname = sdatareader["CSSECTIONNAME"].ToString(),
                            cscreateddate = sdatareader["CSCREATEDDATE"].ToString(),
                            csmodifieddate = sdatareader["CSMODIFIEDDATE"].ToString(),
                            csoid = Convert.ToInt32(sdatareader["CSOID"])
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return LCSM;
            }
        }


        //Screen - Class Subject Staff

        //Create
        [HttpPost]
        [ActionName("classsubjectstaffcreate")]
        [Route("api/COMMONDETAIL/classsubjectstaffcreate")]
        public string classsubjectstaffcreate(CLASSSUBJECTMODEL CSSM)
        {
            string savedcount;
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("COMMONDETAILS_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TABLE_NAME", "CLASSSUBJECTTABLE");
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "C");
                    command.Parameters.AddWithValue("@CSUBOID", "");
                    command.Parameters.AddWithValue("@CSUBCLASSSECTIONID", CSSM.csubclasssectionid);
                    command.Parameters.AddWithValue("@CSUBSUBJECTNAME", CSSM.csubsubjectname);
                    command.Parameters.AddWithValue("@CSUBSTAFFNAMEID", CSSM.csstaffnameid);
                    command.Parameters.AddWithValue("@CREATEDDATE", CSSM.csubcreateddate);
                    command.Parameters.AddWithValue("@MODIFIEDDATE", CSSM.csubmodifieddate);
                    command.Parameters.AddWithValue("@STATUS", CSSM.csubstatus);
                    command.Parameters.AddWithValue("@OID", CSSM.csuboid);
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
        [ActionName("classsubjectstaffupdate")]
        [Route("api/COMMONDETAIL/classsubjectstaffupdate")]
        public string classsubjectstaffupdate(CLASSSUBJECTMODEL CSSM)
        {
            string updatecount;
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("COMMONDETAILS_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TABLE_NAME", "CLASSSUBJECTTABLE");
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "U");
                    command.Parameters.AddWithValue("@CSUBOID", CSSM.csubid);
                    command.Parameters.AddWithValue("@CSUBCLASSSECTIONID", CSSM.csubclasssectionid);
                    command.Parameters.AddWithValue("@CSUBSUBJECTNAME", CSSM.csubsubjectname);
                    command.Parameters.AddWithValue("@CSUBSTAFFNAMEID", CSSM.csstaffnameid);
                    command.Parameters.AddWithValue("@CREATEDDATE", CSSM.csubcreateddate);
                    command.Parameters.AddWithValue("@MODIFIEDDATE", CSSM.csubmodifieddate);
                    command.Parameters.AddWithValue("@STATUS", CSSM.csubstatus);
                    command.Parameters.AddWithValue("@OID", CSSM.csuboid);
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
        [ActionName("classsubjectstaffread")]
        [Route("api/COMMONDETAIL/classsubjectstaffread")]
        public List<CLASSSUBJECTMODEL> classsubjectstaffread()
        {
            CLASSSUBJECTMODEL CSSM = new CLASSSUBJECTMODEL();
            List<CLASSSUBJECTMODEL> LCSSM = new List<CLASSSUBJECTMODEL>();

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("COMMONDETAILS_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TABLE_NAME", "CLASSSUBJECTTABLE");
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "R");
                    SqlDataReader sdatareader = null;
                    sdatareader = command.ExecuteReader();
                    while (sdatareader.Read())
                    {
                        LCSSM.Add(new CLASSSUBJECTMODEL()
                        {
                            csubid = Convert.ToInt32(sdatareader["CSUBID"]),
                            csubclasssectionid = Convert.ToInt32(sdatareader["CSUBCLASSSECTIONID"]),
                            csubsubjectname = sdatareader["CSUBSUBJECTNAME"].ToString(),
                            csstaffnameid = Convert.ToInt32(sdatareader["CSUBSTAFFNAMEID"]),
                            csubcreateddate = sdatareader["CSUBCREATEDDATE"].ToString(),
                            csubmodifieddate = sdatareader["CSUBMODIFIEDDATE"].ToString(),
                            csuboid = Convert.ToInt32(sdatareader["CSUBOID"])
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return LCSSM;
            }
        }

        //Read id
        [HttpGet]
        [ActionName("classsubjectstaffread")]
        [Route("api/COMMONDETAIL/classsubjectstaffread/{id}")]
        public List<CLASSSUBJECTMODEL> classsubjectstaffread(int id)
        {
            CLASSSUBJECTMODEL CSSM = new CLASSSUBJECTMODEL();
            List<CLASSSUBJECTMODEL> LCSSM = new List<CLASSSUBJECTMODEL>();

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("COMMONDETAILS_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TABLE_NAME", "CLASSSUBJECTTABLE");
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "R");
                    command.Parameters.AddWithValue("@CSUBID", id);
                    SqlDataReader sdatareader = null;
                    sdatareader = command.ExecuteReader();
                    while (sdatareader.Read())
                    {
                        LCSSM.Add(new CLASSSUBJECTMODEL()
                        {
                            csubid = Convert.ToInt32(sdatareader["CSUBID"]),
                            csubclasssectionid = Convert.ToInt32(sdatareader["CSUBCLASSSECTIONID"]),
                            csubsubjectname = sdatareader["CSUBSUBJECTNAME"].ToString(),
                            csstaffnameid = Convert.ToInt32(sdatareader["CSUBSTAFFNAMEID"]),
                            csubcreateddate = sdatareader["CSUBCREATEDDATE"].ToString(),
                            csubmodifieddate = sdatareader["CSUBMODIFIEDDATE"].ToString(),
                            csuboid = Convert.ToInt32(sdatareader["CSUBOID"])
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return LCSSM;
            }
        }

    }
}
