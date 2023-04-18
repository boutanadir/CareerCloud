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
    public class SystemCountryCodeRepository : IDataRepository<SystemCountryCodePoco>
    {
        public void Add(params SystemCountryCodePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (SystemCountryCodePoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("insert into System_Country_Codes (Code, Name) values (@Code, @Name)", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Code", item.Code);
                        cmd.Parameters.AddWithValue("@Name", item.Name);
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

        public IList<SystemCountryCodePoco> GetAll(params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            IList<SystemCountryCodePoco> items = new List<SystemCountryCodePoco>();

            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select Code, Name from System_Country_Codes", conn);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        SystemCountryCodePoco item = new SystemCountryCodePoco();
                        item.Code = (string)r["Code"];
                        item.Name = (string)r["Name"];
                        items.Add(item);
                    }

                }
                catch (SqlException ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }

                return items;
            }
        }

        public IList<SystemCountryCodePoco> GetList(Expression<Func<SystemCountryCodePoco, bool>> where, params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SystemCountryCodePoco GetSingle(Expression<Func<SystemCountryCodePoco, bool>> where, params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            IQueryable<SystemCountryCodePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SystemCountryCodePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (SystemCountryCodePoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("delete from System_Country_Codes where Code= @Code", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Code", item.Code);
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

        public void Update(params SystemCountryCodePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (SystemCountryCodePoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("update System_Country_Codes set Name= @Name where Code= @Code", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Code", item.Code);
                        cmd.Parameters.AddWithValue("@Name", item.Name);
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

