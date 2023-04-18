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
    public class CompanyJobSkillRepository : IDataRepository<CompanyJobSkillPoco>
    {
        public void Add(params CompanyJobSkillPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (CompanyJobSkillPoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("insert into Company_Job_Skills (Id, Job, Skill, Skill_Level, Importance) values (@Id, @Job, @Skill, @Skill_Level, @Importance)", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Job", item.Job);
                        cmd.Parameters.AddWithValue("@Skill", item.Skill);
                        cmd.Parameters.AddWithValue("@Skill_Level", item.SkillLevel);
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

        public IList<CompanyJobSkillPoco> GetAll(params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
        {
            IList<CompanyJobSkillPoco> items = new List<CompanyJobSkillPoco>();

            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select Id, Job, Skill, Skill_Level, Importance from Company_Job_Skills", conn);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        CompanyJobSkillPoco item = new CompanyJobSkillPoco();
                        item.Id = (Guid)r["Id"];
                        item.Job = (Guid)r["Job"];
                        item.Skill = (string)r["Skill"];
                        item.SkillLevel = (string)r["Skill_Level"];
                        item.Importance = (int)r["Importance"];
                        items.Add(item);
                    }

                }
                catch (SqlException ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }

                return items;
            }
        }

        public IList<CompanyJobSkillPoco> GetList(Expression<Func<CompanyJobSkillPoco, bool>> where, params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobSkillPoco GetSingle(Expression<Func<CompanyJobSkillPoco, bool>> where, params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobSkillPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyJobSkillPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (CompanyJobSkillPoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("delete from Company_Job_Skills where Id= @Id", conn);
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

        public void Update(params CompanyJobSkillPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (CompanyJobSkillPoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("update Company_Job_Skills set Job= @Job, Skill= @Skill, Skill_Level= @Skill_Level, Importance= @Importance where  Id= @Id", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Job", item.Job);
                        cmd.Parameters.AddWithValue("@Skill", item.Skill);
                        cmd.Parameters.AddWithValue("@Skill_Level", item.SkillLevel);
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

