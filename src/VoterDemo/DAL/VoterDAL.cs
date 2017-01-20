
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VoterDemo.Models;
using Microsoft.ApplicationBlocks.Data;
namespace VoterDemo.DAL
{
    public class VoterDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public List<voterModel> GetallVoter()
        {
            List<voterModel> VoterList = new List<voterModel>();
            var projectList = getvoters();
            if (projectList.Tables.Count > 0)
            {
                DataTable table = projectList.Tables[0];

                foreach (DataRow record in table.Rows)
                {
                    if (record["isdeleted"] == DBNull.Value)
                    {
                        // nothing to do  
                    }
                    else if (Convert.ToInt32(record["isdeleted"]) == 1)
                    {
                        // nothing to do  
                    }
                    else
                    {
                        VoterList.Add(new voterModel()
                        {
                            AreaId = Convert.ToInt32(record["AreaId"]),
                            Fullname = Convert.ToString(record["lastname"]) + " " + Convert.ToString(record["firstname"]) + " " + Convert.ToString(record["middlename"]),
                            firstname = Convert.ToString(record["firstname"]),
                            lastname = Convert.ToString(record["lastname"]),
                            middlename = Convert.ToString(record["middlename"]),
                            voter_id = Convert.ToString(record["voter_id"]),
                            WardId = Convert.ToInt32(record["WardId"]),
                            WardName = Convert.ToString(record["WardName"]),
                            AreaName = Convert.ToString(record["AreaName"])
                        });
                    }
                }
            }

            return VoterList.ToList();
        }

        public List<voterModel> GetallVoterWithDeleted()
        {
            List<voterModel> VoterList = new List<voterModel>();
            var projectList = getvoters();
            if (projectList.Tables.Count > 0)
            {
                DataTable table = projectList.Tables[0];

                foreach (DataRow record in table.Rows)
                {
                    VoterList.Add(new voterModel()
                    {
                        AreaId = Convert.ToInt32(record["AreaId"]),
                        firstname = Convert.ToString(record["firstname"]),
                        lastname = Convert.ToString(record["lastname"]),
                        middlename = Convert.ToString(record["middlename"]),
                        voter_id = Convert.ToString(record["voter_id"]),
                        WardId = Convert.ToInt32(record["WardId"]),
                        WardName = Convert.ToString(record["WardName"]),
                        AreaName = Convert.ToString(record["AreaName"])
                    });

                }
            }

            return VoterList.ToList();
        }

        public DataSet getvoters()
        {
            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetActiveVoters";//write sp name here
            cmd.Connection = con;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet VoterData = new DataSet();
            da.Fill(VoterData);
            return VoterData;
        }
        public void AddVoters(voterModel v)
        {
            try
            {
                SqlParameter[] objParam = new SqlParameter[6];
                objParam[0] = new SqlParameter("@voter_id", v.voter_id);
                objParam[1] = new SqlParameter("@firstname", v.firstname);
                objParam[2] = new SqlParameter("@middlename", v.middlename);
                objParam[3] = new SqlParameter("@lastname", v.lastname);
                objParam[4] = new SqlParameter("@WardId", v.WardId);
                objParam[5] = new SqlParameter("@AreaId", v.AreaId);

                SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "AddVoter", objParam);
            }
            catch (System.Exception ex)
            {

            }
        }

        public void EditVoters(voterModel v)
        {
            try
            {
                SqlParameter[] objParam = new SqlParameter[6];
                objParam[0] = new SqlParameter("@voter_id", v.voter_id);
                objParam[1] = new SqlParameter("@firstname", v.firstname);
                objParam[2] = new SqlParameter("@middlename", v.middlename);
                objParam[3] = new SqlParameter("@lastname", v.lastname);
                objParam[4] = new SqlParameter("@WardId", v.WardId);
                objParam[5] = new SqlParameter("@AreaId", v.AreaId);

                SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "EditVoter", objParam);
            }
            catch (System.Exception ex)
            {

            }
        }

        public void Addvoter(voterModel v)
        {
            List<voterModel> VoterList = new List<voterModel>();
            AddVoters(v);
        }

        public List<voterModel> GetvoterbyID(string v)
        {
            voterModel v1 = new voterModel();
            List<voterModel> Voters = new List<voterModel>();
            v1 = GetallVoter().Find(x => x.voter_id == v);
            Voters.Add(v1);
            return Voters.ToList();
        }

        public void UpdateVoter(voterModel v)
        {
            voterModel v1 = new voterModel();
            List<voterModel> Voters = new List<voterModel>();
            // add code to Get ALL the voters and add to List 
            //Search the voter
            v1 = GetallVoter().Find(x => x.voter_id == v.voter_id);
            v1.voter_id = v.voter_id;
            v1.lastname = v.lastname;
            v1.middlename = v.middlename;
            v1.WardId = v.WardId;
            v1.AreaId = v.AreaId;
            v1.firstname = v.firstname;
            EditVoters(v1);
        }

        public void DeleteVoter(voterModel v)
        {
            voterModel v1 = new voterModel();
            List<voterModel> Voters = new List<voterModel>();
            // add code to Get ALL the voters and add to List 
            //Search the voter
            v1 = GetallVoter().Find(x => x.voter_id == v.voter_id);
            v1.voter_id = v.voter_id;
            v1.lastname = v.lastname;
            v1.middlename = v.middlename;
            v1.WardId = v.WardId;
            v1.AreaId = v.AreaId;
            v1.firstname = v.firstname;
            v1.isdeleted = true;
            delVoter(v1);
        }

        public void delVoter(voterModel v)
        {
            try
            {
                SqlParameter[] objParam = new SqlParameter[7];
                objParam[0] = new SqlParameter("@voter_id", v.voter_id);
                objParam[1] = new SqlParameter("@firstname", v.firstname);
                objParam[2] = new SqlParameter("@middlename", v.middlename);
                objParam[3] = new SqlParameter("@lastname", v.lastname);
                objParam[4] = new SqlParameter("@WardId", v.WardId);
                objParam[5] = new SqlParameter("@AreaId", v.AreaId);
                objParam[6] = new SqlParameter("@isdeleted", v.isdeleted);
                SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "DeleteVoter", objParam);
            }
            catch (System.Exception ex)
            {

            }
        }

    }
}