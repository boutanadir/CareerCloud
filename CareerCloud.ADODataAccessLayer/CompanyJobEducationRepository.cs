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
    public class CompanyJobEducationRepository : IDataRepository<CompanyJobEducationPoco>
    {
        public void Add(params CompanyJobEducationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (CompanyJobEducationPoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("insert into Company_Job_Educations (Id, Job, Major, Importance) values (@Id, @Job, @Major, @Importance)", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Job", item.Job);
                        cmd.Parameters.AddWithValue("@Major", item.Major);
                        cmd.Parameters.AddWithValue("@Importance", item.Importance);
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

        public IList<CompanyJobEducationPoco> GetAll(params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            IList<CompanyJobEducationPoco> items = new List<CompanyJobEducationPoco>();

            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select Id, Job, Major, Importance from Company_Job_Educations", conn);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        CompanyJobEducationPoco item = new CompanyJobEducationPoco();
                        item.Id = (Guid)r["Id"];
                        item.Job = (Guid)r["Job"];
                        item.Major = (string)r["Major"];
                        item.Importance = (short)r["Importance"];
                        items.Add(item);
                    }

                }
                catch (SqlException ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }

                return items;
            }
        }

        public IList<CompanyJobEducationPoco> GetList(Expression<Func<CompanyJobEducationPoco, bool>> where, params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobEducationPoco GetSingle(Expression<Func<CompanyJobEducationPoco, bool>> where, params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobEducationPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyJobEducationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (CompanyJobEducationPoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("delete from Company_Job_Educations where Id= @Id", conn);
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

        public void Update(params CompanyJobEducationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (CompanyJobEducationPoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("update Company_Job_Educations set Job= @Job, Major= @Major, Importance= @Importance where Id= @Id", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Job", item.Job);
                        cmd.Parameters.AddWithValue("@Major", item.Major);
                        cmd.Parameters.AddWithValue("@Importance", item.Importance);
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

