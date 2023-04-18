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
    public class ApplicantEducationRepository : IDataRepository<ApplicantEducationPoco>
    {
        public void Add(params ApplicantEducationPoco[] items)
        {

            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (ApplicantEducationPoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("insert into Applicant_Educations (Id, Applicant, Major, Certificate_Diploma, Start_Date, Completion_Date, Completion_Percent) values (@Id, @Applicant, @Major, @Certificate_Diploma, @Start_Date, @Completion_Date, @Completion_Percent)", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                        cmd.Parameters.AddWithValue("@Major", item.Major);
                        cmd.Parameters.AddWithValue("@Certificate_Diploma", item.CertificateDiploma);
                        cmd.Parameters.AddWithValue("@Start_Date", item.StartDate);
                        cmd.Parameters.AddWithValue("@Completion_Date", item.CompletionDate);
                        cmd.Parameters.AddWithValue("@Completion_Percent", item.CompletionPercent);
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

        public IList<ApplicantEducationPoco> GetAll(params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {

            IList<ApplicantEducationPoco> items = new List<ApplicantEducationPoco>();

            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select * from Applicant_Educations", conn);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        ApplicantEducationPoco item = new ApplicantEducationPoco();
                        item.Id = (Guid)r["Id"];
                        item.Applicant = (Guid)r["Applicant"];
                        item.Major = (string)r["Major"];
                        item.CertificateDiploma = (string)r["Certificate_Diploma"];
                        item.StartDate = (DateTime?)r["Start_Date"];
                        item.CompletionDate = (DateTime?)r["Completion_Date"];
                        item.CompletionPercent = (byte?)r["Completion_Percent"];
                        items.Add(item);
                    }


                }
                catch (SqlException ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }

                return items;
            }

        }

        public IList<ApplicantEducationPoco> GetList(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();

        }

        public ApplicantEducationPoco GetSingle(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantEducationPoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantEducationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (ApplicantEducationPoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("delete from Applicant_Educations where Id=@Id", conn);
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

        public void Update(params ApplicantEducationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (ApplicantEducationPoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("update Applicant_Educations set Applicant=@Applicant, Major=@Major, Certificate_Diploma=@Certificate_Diploma, Start_Date=@Start_Date, Completion_Date=@Completion_Date, Completion_Percent=@Completion_Percent where Id=@Id", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                        cmd.Parameters.AddWithValue("@Major", item.Major);
                        cmd.Parameters.AddWithValue("@Certificate_Diploma", item.CertificateDiploma);
                        cmd.Parameters.AddWithValue("@Start_Date", item.StartDate);
                        cmd.Parameters.AddWithValue("@Completion_Date", item.CompletionDate);
                        cmd.Parameters.AddWithValue("@Completion_Percent", item.CompletionPercent);
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

