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
    public class CompanyLocationRepository : IDataRepository<CompanyLocationPoco>
    {
        public void Add(params CompanyLocationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (CompanyLocationPoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("insert into Company_Locations (Id, Company, Country_Code, State_Province_Code, Street_Address, City_Town, Zip_Postal_Code) values (@Id, @Company, @Country_Code, @State_Province_Code, @Street_Address, @City_Town, @Zip_Postal_Code)", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Company", item.Company);
                        cmd.Parameters.AddWithValue("@Country_Code", item.CountryCode);
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

        public IList<CompanyLocationPoco> GetAll(params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            IList<CompanyLocationPoco> items = new List<CompanyLocationPoco>();

            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select Id, Company, Country_Code, State_Province_Code, Street_Address, City_Town, Zip_Postal_Code from Company_Locations", conn);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        CompanyLocationPoco item = new CompanyLocationPoco();
                        item.Id = (Guid)r["Id"];
                        item.Company = (Guid)r["Company"];
                        item.CountryCode = (string)r["Country_Code"];
                        item.Province = (string)r["State_Province_Code"];
                        item.Street = (string)r["Street_Address"];
                        item.City = "" + r["City_Town"];
                        item.PostalCode = "" + r["Zip_Postal_Code"];
                        items.Add(item);
                    }

                }
                catch (SqlException ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }

                return items;
            }
        }

        public IList<CompanyLocationPoco> GetList(Expression<Func<CompanyLocationPoco, bool>> where, params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyLocationPoco GetSingle(Expression<Func<CompanyLocationPoco, bool>> where, params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyLocationPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyLocationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (CompanyLocationPoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("delete from Company_Locations where Id= @Id", conn);
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

        public void Update(params CompanyLocationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (CompanyLocationPoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("update Company_Locations set Company= @Company, Country_Code= @Country_Code, State_Province_Code= @State_Province_Code, Street_Address= @Street_Address, City_Town= @City_Town, Zip_Postal_Code= @Zip_Postal_Code where Id= @Id", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Company", item.Company);
                        cmd.Parameters.AddWithValue("@Country_Code", item.CountryCode);
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

