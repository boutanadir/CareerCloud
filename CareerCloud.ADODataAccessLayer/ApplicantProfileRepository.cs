using CareerCloud.Pocos;
using CareerCloud.DataAccessLayer;
using System.Linq.Expressions;
using System.Data.SqlClient;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantProfileRepository : IDataRepository<ApplicantProfilePoco>
    {
        public void Add(params ApplicantProfilePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (ApplicantProfilePoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("insert into Applicant_Profiles (Id, Login, Current_Salary, Current_Rate, Currency, Country_Code, State_Province_Code, Street_Address, City_Town, Zip_Postal_Code) values (@Id, @Login, @Current_Salary, @Current_Rate, @Currency, @Country_Code, @State_Province_Code, @Street_Address, @City_Town, @Zip_Postal_Code)", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Login", item.Login);
                        cmd.Parameters.AddWithValue("@Current_Salary", item.CurrentSalary);
                        cmd.Parameters.AddWithValue("@Current_Rate", item.CurrentRate);
                        cmd.Parameters.AddWithValue("@Currency", item.Currency);
                        cmd.Parameters.AddWithValue("@Country_Code", item.Country);
                        cmd.Parameters.AddWithValue("@State_Province_Code", item.Province);
                        cmd.Parameters.AddWithValue("@Street_Address", item.Street);
                        cmd.Parameters.AddWithValue("@City_Town", item.City);
                        cmd.Parameters.AddWithValue("@Zip_Postal_Code", item.PostalCode);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    Assert.AreEqual(true, false, ex.Message);
                }
                finally { conn.Close(); }

            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantProfilePoco> GetAll(params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            IList<ApplicantProfilePoco> items = new List<ApplicantProfilePoco>();

            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select Id, Login, Current_Salary, Current_Rate, Currency, Country_Code, State_Province_Code, Street_Address, City_Town, Zip_Postal_Code from Applicant_Profiles", conn);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        ApplicantProfilePoco item = new ApplicantProfilePoco();
                        item.Id = (Guid)r["Id"];
                        item.Login = (Guid)r["Login"];
                        item.CurrentSalary = (decimal?)r["Current_Salary"];
                        item.CurrentRate = (decimal?)r["Current_Rate"];
                        item.Currency = (string)r["Currency"];
                        item.Country = (string)r["Country_Code"];
                        item.Province = (string)r["State_Province_Code"];
                        item.Street = (string)r["Street_Address"];
                        item.City = (string)r["City_Town"];
                        item.PostalCode = (string)r["Zip_Postal_Code"];
                        items.Add(item);
                    }

                }
                catch (SqlException ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }

                return items;
            }


        }

        public IList<ApplicantProfilePoco> GetList(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantProfilePoco GetSingle(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantProfilePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantProfilePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (ApplicantProfilePoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("delete from Applicant_Profiles where Id= @Id", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    Assert.AreEqual(true, false, ex.Message);
                }
                finally { conn.Close(); }

            }

        }

        public void Update(params ApplicantProfilePoco[] items)
        {

            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (ApplicantProfilePoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("update Applicant_Profiles set Login= @Login, Current_Salary= @Current_Salary, Current_Rate= @Current_Rate, Currency= @Currency, Country_Code= @Country_Code, State_Province_Code= @State_Province_Code, Street_Address= @Street_Address, City_Town= @City_Town, Zip_Postal_Code= @Zip_Postal_Code where Id= @Id", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Login", item.Login);
                        cmd.Parameters.AddWithValue("@Current_Salary", item.CurrentSalary);
                        cmd.Parameters.AddWithValue("@Current_Rate", item.CurrentRate);
                        cmd.Parameters.AddWithValue("@Currency", item.Currency);
                        cmd.Parameters.AddWithValue("@Country_Code", item.Country);
                        cmd.Parameters.AddWithValue("@State_Province_Code", item.Province);
                        cmd.Parameters.AddWithValue("@Street_Address", item.Street);
                        cmd.Parameters.AddWithValue("@City_Town", item.City);
                        cmd.Parameters.AddWithValue("@Zip_Postal_Code", item.PostalCode);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    Assert.AreEqual(true, false, ex.Message);
                }
                finally { conn.Close(); }

            }
        }
    }
}

