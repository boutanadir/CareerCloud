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
    public class CompanyProfileRepository : IDataRepository<CompanyProfilePoco>
    {
        public void Add(params CompanyProfilePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (CompanyProfilePoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("insert into Company_Profiles (Id, Registration_Date, Company_Website, Contact_Phone, Contact_Name, Company_Logo) values ( @Id, @Registration_Date, @Company_Website, @Contact_Phone, @Contact_Name, @Company_Logo)", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Registration_Date", item.RegistrationDate);
                        cmd.Parameters.AddWithValue("@Contact_Name", item.ContactName);
                        cmd.Parameters.AddWithValue("@Company_Website", item.CompanyWebsite);
                        cmd.Parameters.AddWithValue("@Contact_Phone", item.ContactPhone);
                        cmd.Parameters.AddWithValue("@Company_Logo", item.CompanyLogo);
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

        public IList<CompanyProfilePoco> GetAll(params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            IList<CompanyProfilePoco> items = new List<CompanyProfilePoco>();

            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select Id, Registration_Date, Company_Website, Contact_Phone, Contact_Name, Company_Logo from Company_Profiles", conn);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        CompanyProfilePoco item = new CompanyProfilePoco();
                        item.Id = (Guid)r["Id"];
                        item.RegistrationDate = (DateTime)r["Registration_Date"];
                        item.CompanyWebsite = r["Company_Website"].ToString();
                        item.ContactPhone = (string)r["Contact_Phone"];
                        item.ContactName = r["Contact_Name"].ToString();
                        item.CompanyLogo = Encoding.ASCII.GetBytes("" + r["Company_Logo"]);
                        items.Add(item);
                    }

                }
                catch (SqlException ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }

                return items;
            }
        }

        public IList<CompanyProfilePoco> GetList(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyProfilePoco GetSingle(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyProfilePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyProfilePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (CompanyProfilePoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("delete from Company_Profiles where Id= @Id", conn);
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

        public void Update(params CompanyProfilePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (CompanyProfilePoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("update Company_Profiles set Registration_Date= @Registration_Date, Company_Website= @Company_Website, Contact_Phone= @Contact_Phone, Contact_Name= @Contact_Name, Company_Logo= @Company_Logo where  Id= @Id", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Registration_Date", item.RegistrationDate);
                        cmd.Parameters.AddWithValue("@Company_Website", item.CompanyWebsite);
                        cmd.Parameters.AddWithValue("@Contact_Phone", item.ContactPhone);
                        cmd.Parameters.AddWithValue("@Contact_Name", item.ContactName);
                        cmd.Parameters.AddWithValue("@Company_Logo", item.CompanyLogo);
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

