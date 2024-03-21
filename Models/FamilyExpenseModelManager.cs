using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FamilyExpenseTracker.Models
{
    public class FamilyExpenseModelManager
    {
        private string cs = ConfigurationManager.ConnectionStrings["familyexpensetracker_cs"].ConnectionString;
        public List<FamilyExpenseViewModel> GetFamilyExpenses()
        {
            //ADO Code
            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand command = new SqlCommand("GetFamilyExpenses", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    try
                    {
                        if (connection.State == System.Data.ConnectionState.Closed)
                        {
                            connection.Open();
                            SqlDataReader dr = command.ExecuteReader();
                            List<FamilyExpenseViewModel> familyExpenses = new List<FamilyExpenseViewModel>();
                            while (dr.Read())
                            {
                                FamilyExpenseViewModel familyExpense = new FamilyExpenseViewModel();
                                familyExpense.Id = Convert.ToInt32(dr["ExpenseId"]);
                                familyExpense.FamilyMemberName = Convert.ToString(dr["Name"]);
                                familyExpense.Purpose = Convert.ToString(dr["Purpose"]);
                                familyExpense.Amount= Convert.ToInt32(dr["Amount"]);
                                familyExpense.Date = Convert.ToDateTime(dr["DateTime"]);
                                familyExpenses.Add(familyExpense);
                            }
                            return familyExpenses;
                        }
                    }
                    catch(Exception ex)
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
            return null;
        }
        public bool AddFamilyExpense(FamilyExpenseViewModel familyExpenseViewModel)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand command = new SqlCommand("AddFamilyExpense",connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", familyExpenseViewModel.FamilyMemberName);
                    command.Parameters.AddWithValue("@purpose",familyExpenseViewModel.Purpose);
                    command.Parameters.AddWithValue("@amount",familyExpenseViewModel.Amount);
                    command.Parameters.AddWithValue("@date", familyExpenseViewModel.Date);
                    try
                    {
                        if (connection.State == System.Data.ConnectionState.Closed)
                        {
                            connection.Open();
                            int insertStatus = command.ExecuteNonQuery();
                            if (insertStatus > 0)
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
        public bool EditFamilyExpense(FamilyExpenseViewModel familyExpenseViewModel)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand command = new SqlCommand("EditFamilyExpense", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@expenseId",familyExpenseViewModel.Id);
                    command.Parameters.AddWithValue("@name",familyExpenseViewModel.FamilyMemberName);
                    command.Parameters.AddWithValue("@purpose",familyExpenseViewModel.Purpose);
                    command.Parameters.AddWithValue("@amount",familyExpenseViewModel.Amount);
                    command.Parameters.AddWithValue("@date",familyExpenseViewModel.Date);
                    try
                    {
                        if (connection.State == System.Data.ConnectionState.Closed)
                        {
                            connection.Open();
                            int insertStatus = command.ExecuteNonQuery();
                            if (insertStatus > 0)
                            {
                                return true;
                            }

                        }
                    }
                    catch (SqlException ex)
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
        public bool DeleteFamilyExpense(int id)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand command = new SqlCommand("DeleteFamilyExpense", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@expenseId", id);
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
                    catch (SqlException ex)
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
        public List<string>GetFamilyMemberNames()
        {
            //ADO Code
            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand command = new SqlCommand("GetFamilyMemberNames", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    try
                    {
                        if (connection.State == System.Data.ConnectionState.Closed)
                        {
                            connection.Open();
                            SqlDataReader dr = command.ExecuteReader();
                            List<string> names = new List<string>();
                            while (dr.Read())
                            {
                                names.Add(dr["name"].ToString());
                            }
                            return names;
                        }
                    }
                    catch (SqlException ex)
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
            return null;
        }
    }
}