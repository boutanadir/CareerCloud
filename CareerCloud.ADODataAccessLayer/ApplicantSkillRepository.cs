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
    public class ApplicantSkillRepository : IDataRepository<ApplicantSkillPoco>
    {
        public void Add(params ApplicantSkillPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (ApplicantSkillPoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("insert into Applicant_Skills (Id, Applicant, Skill, Skill_Level, Start_Month, Start_Year, End_Month, End_Year) values (@Id, @Applicant, @Skill, @Skill_Level, @Start_Month, @Start_Year, @End_Month, @End_Year)", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                        cmd.Parameters.AddWithValue("@Skill", item.Skill);
                        cmd.Parameters.AddWithValue("@Skill_Level", item.SkillLevel);
                        cmd.Parameters.AddWithValue("@Start_Month", item.StartMonth);
                        cmd.Parameters.AddWithValue("@Start_Year", item.StartYear);
                        cmd.Parameters.AddWithValue("@End_Month", item.EndMonth);
                        cmd.Parameters.AddWithValue("@End_Year", item.EndYear);
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

        public IList<ApplicantSkillPoco> GetAll(params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            IList<ApplicantSkillPoco> items = new List<ApplicantSkillPoco>();

            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select Id, Applicant, Skill, Skill_Level, Start_Month, Start_Year, End_Month, End_Year from Applicant_Skills", conn);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        ApplicantSkillPoco item = new ApplicantSkillPoco();
                        item.Id = (Guid)r["Id"];
                        item.Applicant = (Guid)r["Applicant"];
                        item.Skill = (string)r["Skill"];
                        item.SkillLevel = (string)r["Skill_Level"];
                        item.StartMonth = (byte)r["Start_Month"];
                        item.StartYear = (int)r["Start_Year"];
                        item.EndMonth = (byte)r["End_Month"];
                        item.EndYear = (int)r["End_Year"];
                        items.Add(item);
                    }

                }
                catch (SqlException ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }

                return items;
            }
        }

        public IList<ApplicantSkillPoco> GetList(Expression<Func<ApplicantSkillPoco, bool>> where, params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantSkillPoco GetSingle(Expression<Func<ApplicantSkillPoco, bool>> where, params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantSkillPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantSkillPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (ApplicantSkillPoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("delete from Applicant_Skills where Id= @Id", conn);
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

        public void Update(params ApplicantSkillPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (ApplicantSkillPoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("update Applicant_Skills set Applicant= @Applicant, Skill= @Skill, Skill_Level= @Skill_Level, Start_Month= @Start_Month, Start_Year= @Start_Year, End_Month= @End_Month, End_Year= @End_Year where Id= @Id", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                        cmd.Parameters.AddWithValue("@Skill", item.Skill);
                        cmd.Parameters.AddWithValue("@Skill_Level", item.SkillLevel);
                        cmd.Parameters.AddWithValue("@Start_Month", item.StartMonth);
                        cmd.Parameters.AddWithValue("@Start_Year", item.StartYear);
                        cmd.Parameters.AddWithValue("@End_Month", item.EndMonth);
                        cmd.Parameters.AddWithValue("@End_Year", item.EndYear);
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

