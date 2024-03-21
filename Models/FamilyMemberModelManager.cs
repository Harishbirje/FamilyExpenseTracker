using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace FamilyExpenseTracker.Models
{
    public class FamilyMemberModelManager
    {
        private string cs = ConfigurationManager.ConnectionStrings["familyexpensetracker_cs"].ConnectionString;
        public List<FamilyMember> GetFamilyMembers()
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand command = new SqlCommand("GetFamilyMembers", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    try
                    {
                        if (connection.State == System.Data.ConnectionState.Closed)
                        {
                            connection.Open();
                            SqlDataReader dr = command.ExecuteReader();
                            List<FamilyMember> familyMembers = new List<FamilyMember>();
                            while (dr.Read())
                            {
                                FamilyMember familyMember = new FamilyMember();
                                familyMember.FamilyMemberId = Convert.ToInt32(dr["FamilyMemberId"]);
                                familyMember.Name = Convert.ToString(dr["Name"]);
                                familyMember.Cell = Convert.ToString(dr["Cell"]);
                                familyMember.Work = Convert.ToString(dr["Work"]);
                                familyMember.Income = Convert.ToInt32(dr["Income"]);
                                familyMembers.Add(familyMember);
                            }
                            return familyMembers;
                        }
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        if (connection.State == System.Data.ConnectionState.Open)
                        {
                            connection.Close();
                        }
                    }
                }
            }
            return null;
        }
        public bool AddFamilyMember(FamilyMember familyMember)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand command = new SqlCommand("AddFamilyMember", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("name", familyMember.Name);
                    command.Parameters.AddWithValue("@cell", familyMember.Cell);
                    command.Parameters.AddWithValue("@work", familyMember.Work);
                    command.Parameters.AddWithValue("@income", familyMember.Income);
                    try
                    {
                        if (connection.State == System.Data.ConnectionState.Closed)
                        {
                            connection.Open();
                            int addedRows = command.ExecuteNonQuery();
                            if (addedRows > 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        if (connection.State == System.Data.ConnectionState.Open)
                        {
                            connection.Close();
                        }
                    }
                }
            }
            return false;
        }
        public bool EditFamilyMember(FamilyMember familyMember)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand command = new SqlCommand("EditFamilyMember", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("familyMemberId", familyMember.FamilyMemberId);
                    command.Parameters.AddWithValue("name", familyMember.Name);
                    command.Parameters.AddWithValue("@cell", familyMember.Cell);
                    command.Parameters.AddWithValue("@work", familyMember.Work);
                    command.Parameters.AddWithValue("@income", familyMember.Income);
                    try
                    {
                        if (connection.State == System.Data.ConnectionState.Closed)
                        {
                            connection.Open();
                            int editedRows = command.ExecuteNonQuery();
                            if (editedRows > 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        if (connection.State == System.Data.ConnectionState.Open)
                        {
                            connection.Close();
                        }
                    }
                }
            }
            return false;
        }
        public bool DeleteFamilyMember(int Id)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand command = new SqlCommand("DeleteFamilyMember", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@familyMemberId", Id);
                    try
                    {
                        if (connection.State == System.Data.ConnectionState.Closed)
                        {
                            connection.Open();
                            int status = command.ExecuteNonQuery();
                            if (status > 0)
                            {
                                return true;
                            }
                        }
                    }
                    catch(SqlException ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (connection.State == System.Data.ConnectionState.Open)
                        {
                            connection.Close();
                        }
                    }
                }
            }
            return false;
        }
    }
}    