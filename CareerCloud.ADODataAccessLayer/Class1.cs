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
    class Class1
    {
    static public class config { static public string con = "Data Source=XPS17;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True"; }
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

    public class ApplicantJobApplicationRepository : IDataRepository<ApplicantJobApplicationPoco>
    {
        public void Add(params ApplicantJobApplicationPoco[] items)
        {

            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (ApplicantJobApplicationPoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("insert into Applicant_Job_Applications (Id, Applicant, Job, Application_Date) values (@Id, @Applicant, @Job, @Application_Date)", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                        cmd.Parameters.AddWithValue("@Job", item.Job);
                        cmd.Parameters.AddWithValue("@Application_Date", item.ApplicationDate);
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

        public IList<ApplicantJobApplicationPoco> GetAll(params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {

            IList<ApplicantJobApplicationPoco> items = new List<ApplicantJobApplicationPoco>();

            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select Id, Applicant, Job, Application_Date from Applicant_Job_Applications", conn);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        ApplicantJobApplicationPoco item = new ApplicantJobApplicationPoco();
                        item.Id = (Guid)r["Id"];
                        item.Applicant = (Guid)r["Applicant"];
                        item.Job = (Guid)r["Job"];
                        item.ApplicationDate = (DateTime)r["Application_Date"];
                        items.Add(item);
                    }


                }
                catch (SqlException ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }

                return items;
            }

        }

        public IList<ApplicantJobApplicationPoco> GetList(Expression<Func<ApplicantJobApplicationPoco, bool>> where, params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantJobApplicationPoco GetSingle(Expression<Func<ApplicantJobApplicationPoco, bool>> where, params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantJobApplicationPoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantJobApplicationPoco[] items)
        {

            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (ApplicantJobApplicationPoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("delete from Applicant_Job_Applications where Id= @Id", conn);
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

        public void Update(params ApplicantJobApplicationPoco[] items)
        {

            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (ApplicantJobApplicationPoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("update Applicant_Job_Applications set Applicant=@Applicant, Job=@Job, Application_Date=@Application_Date where  Id=@Id", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                        cmd.Parameters.AddWithValue("@Job", item.Job);
                        cmd.Parameters.AddWithValue("@Application_Date", item.ApplicationDate);
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

    public class ApplicantResumeRepository : IDataRepository<ApplicantResumePoco>
    {
        public void Add(params ApplicantResumePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (ApplicantResumePoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("insert into Applicant_Resumes (Id, Applicant, Resume, Last_Updated) values (@Id, @Applicant, @Resume, @Last_Updated)", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                        cmd.Parameters.AddWithValue("@Resume", item.Resume);
                        cmd.Parameters.AddWithValue("@Last_Updated", item.LastUpdated);
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

        public IList<ApplicantResumePoco> GetAll(params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            IList<ApplicantResumePoco> items = new List<ApplicantResumePoco>();

            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select Id, Applicant, Resume, Last_Updated from Applicant_Resumes", conn);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        ApplicantResumePoco item = new ApplicantResumePoco();
                        item.Id = (Guid)r["Id"];
                        item.Applicant = (Guid)r["Applicant"];
                        item.Resume = (string)r["Resume"];
                        item.LastUpdated = (r["Last_Updated"] == DBNull.Value) ? null : (DateTime?)r["Last_Updated"];
                        items.Add(item);
                    }

                }
                catch (SqlException ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }

                return items;
            }
        }

        public IList<ApplicantResumePoco> GetList(Expression<Func<ApplicantResumePoco, bool>> where, params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantResumePoco GetSingle(Expression<Func<ApplicantResumePoco, bool>> where, params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantResumePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantResumePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (ApplicantResumePoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("delete from Applicant_Resumes where Id= @Id", conn);
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

        public void Update(params ApplicantResumePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (ApplicantResumePoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("update Applicant_Resumes set Applicant= @Applicant, Resume= @Resume, Last_Updated= @Last_Updated where Id= @Id", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                        cmd.Parameters.AddWithValue("@Resume", item.Resume);
                        cmd.Parameters.AddWithValue("@Last_Updated", item.LastUpdated);
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

    public class ApplicantWorkHistoryRepository : IDataRepository<ApplicantWorkHistoryPoco>
    {
        public void Add(params ApplicantWorkHistoryPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (ApplicantWorkHistoryPoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("insert into Applicant_Work_History (Id, Applicant, Company_Name, Country_Code, Location, Job_Title, Job_Description, Start_Month, Start_Year, End_Month, End_Year) values (@Id, @Applicant, @Company_Name, @Country_Code, @Location, @Job_Title, @Job_Description, @Start_Month, @Start_Year, @End_Month, @End_Year)", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                        cmd.Parameters.AddWithValue("@Company_Name", item.CompanyName);
                        cmd.Parameters.AddWithValue("@Country_Code", item.CountryCode);
                        cmd.Parameters.AddWithValue("@Location", item.Location);
                        cmd.Parameters.AddWithValue("@Job_Title", item.JobTitle);
                        cmd.Parameters.AddWithValue("@Job_Description", item.JobDescription);
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

        public IList<ApplicantWorkHistoryPoco> GetAll(params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            IList<ApplicantWorkHistoryPoco> items = new List<ApplicantWorkHistoryPoco>();

            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select Id, Applicant, Company_Name, Country_Code, Location, Job_Title, Job_Description, Start_Month, Start_Year, End_Month, End_Year from Applicant_Work_History", conn);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        ApplicantWorkHistoryPoco item = new ApplicantWorkHistoryPoco();
                        item.Id = (Guid)r["Id"];
                        item.Applicant = (Guid)r["Applicant"];
                        item.CompanyName = (string)r["Company_Name"];
                        item.CountryCode = (string)r["Country_Code"];
                        item.Location = (string)r["Location"];
                        item.JobTitle = (string)r["Job_Title"];
                        item.JobDescription = (string)r["Job_Description"];
                        item.StartMonth = (short)r["Start_Month"];
                        item.StartYear = (int)r["Start_Year"];
                        item.EndMonth = (short)r["End_Month"];
                        item.EndYear = (int)r["End_Year"];
                        items.Add(item);
                    }

                }
                catch (SqlException ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }

                return items;
            }
        }

        public IList<ApplicantWorkHistoryPoco> GetList(Expression<Func<ApplicantWorkHistoryPoco, bool>> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantWorkHistoryPoco GetSingle(Expression<Func<ApplicantWorkHistoryPoco, bool>> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantWorkHistoryPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantWorkHistoryPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (ApplicantWorkHistoryPoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("delete from Applicant_Work_History where Id= @Id", conn);
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

        public void Update(params ApplicantWorkHistoryPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (ApplicantWorkHistoryPoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("update Applicant_Work_History set Applicant= @Applicant, Company_Name= @Company_Name, Country_Code= @Country_Code, Location= @Location, Job_Title= @Job_Title, Job_Description= @Job_Description, Start_Month= @Start_Month, Start_Year= @Start_Year, End_Month= @End_Month, End_Year= @End_Year where Id= @Id", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                        cmd.Parameters.AddWithValue("@Company_Name", item.CompanyName);
                        cmd.Parameters.AddWithValue("@Country_Code", item.CountryCode);
                        cmd.Parameters.AddWithValue("@Location", item.Location);
                        cmd.Parameters.AddWithValue("@Job_Title", item.JobTitle);
                        cmd.Parameters.AddWithValue("@Job_Description", item.JobDescription);
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

    public class CompanyDescriptionRepository : IDataRepository<CompanyDescriptionPoco>
    {
        public void Add(params CompanyDescriptionPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (CompanyDescriptionPoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("insert into Company_Descriptions (Id, Company, LanguageID, Company_Name, Company_Description) values (@Id, @Company, @LanguageID, @Company_Name, @Company_Description)", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Company", item.Company);
                        cmd.Parameters.AddWithValue("@LanguageID", item.LanguageId);
                        cmd.Parameters.AddWithValue("@Company_Name", item.CompanyName);
                        cmd.Parameters.AddWithValue("@Company_Description", item.CompanyDescription);
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

        public IList<CompanyDescriptionPoco> GetAll(params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            IList<CompanyDescriptionPoco> items = new List<CompanyDescriptionPoco>();

            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select Id, Company, LanguageID, Company_Name, Company_Description from Company_Descriptions", conn);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        CompanyDescriptionPoco item = new CompanyDescriptionPoco();
                        item.Id = (Guid)r["Id"];
                        item.Company = (Guid)r["Company"];
                        item.LanguageId = (string)r["LanguageID"];
                        item.CompanyName = (string)r["Company_Name"];
                        item.CompanyDescription = (string)r["Company_Description"];
                        items.Add(item);
                    }

                }
                catch (SqlException ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }

                return items;
            }
        }

        public IList<CompanyDescriptionPoco> GetList(Expression<Func<CompanyDescriptionPoco, bool>> where, params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyDescriptionPoco GetSingle(Expression<Func<CompanyDescriptionPoco, bool>> where, params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyDescriptionPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyDescriptionPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (CompanyDescriptionPoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("delete from Company_Descriptions where Id= @Id", conn);
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

        public void Update(params CompanyDescriptionPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (CompanyDescriptionPoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("update Company_Descriptions set Company= @Company, LanguageID= @LanguageID, Company_Name= @Company_Name, Company_Description= @Company_Description where Id= @Id", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Company", item.Company);
                        cmd.Parameters.AddWithValue("@LanguageID", item.LanguageId);
                        cmd.Parameters.AddWithValue("@Company_Name", item.CompanyName);
                        cmd.Parameters.AddWithValue("@Company_Description", item.CompanyDescription);
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

    public class CompanyJobRepository : IDataRepository<CompanyJobPoco>
    {
        public void Add(params CompanyJobPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (CompanyJobPoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("insert into Company_Jobs (Id, Company, Profile_Created, Is_Inactive, Is_Company_Hidden) values (@Id, @Company, @Profile_Created, @Is_Inactive, @Is_Company_Hidden)", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Company", item.Company);
                        cmd.Parameters.AddWithValue("@Profile_Created", item.ProfileCreated);
                        cmd.Parameters.AddWithValue("@Is_Inactive", item.IsInactive);
                        cmd.Parameters.AddWithValue("@Is_Company_Hidden", item.IsCompanyHidden);
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

        public IList<CompanyJobPoco> GetAll(params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            IList<CompanyJobPoco> items = new List<CompanyJobPoco>();

            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select Id, Company, Profile_Created, Is_Inactive, Is_Company_Hidden from Company_Jobs", conn);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        CompanyJobPoco item = new CompanyJobPoco();
                        item.Id = (Guid)r["Id"];
                        item.Company = (Guid)r["Company"];
                        item.ProfileCreated = (DateTime)r["Profile_Created"];
                        item.IsInactive = (bool)r["Is_Inactive"];
                        item.IsCompanyHidden = (bool)r["Is_Company_Hidden"];
                        items.Add(item);
                    }

                }
                catch (SqlException ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }

                return items;
            }
        }

        public IList<CompanyJobPoco> GetList(Expression<Func<CompanyJobPoco, bool>> where, params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobPoco GetSingle(Expression<Func<CompanyJobPoco, bool>> where, params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyJobPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (CompanyJobPoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("delete from Company_Jobs where Id= @Id", conn);
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

        public void Update(params CompanyJobPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (CompanyJobPoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("update Company_Jobs set Company= @Company, Profile_Created= @Profile_Created, Is_Inactive= @Is_Inactive, Is_Company_Hidden= @Is_Company_Hidden where Id= @Id", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Company", item.Company);
                        cmd.Parameters.AddWithValue("@Profile_Created", item.ProfileCreated);
                        cmd.Parameters.AddWithValue("@Is_Inactive", item.IsInactive);
                        cmd.Parameters.AddWithValue("@Is_Company_Hidden", item.IsCompanyHidden);
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

    public class CompanyJobDescriptionRepository : IDataRepository<CompanyJobDescriptionPoco>
    {
        public void Add(params CompanyJobDescriptionPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (CompanyJobDescriptionPoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("insert into Company_Jobs_Descriptions (Id, Job, Job_Name, Job_Descriptions) values (@Id, @Job, @Job_Name, @Job_Descriptions)", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Job", item.Job);
                        cmd.Parameters.AddWithValue("@Job_Name", item.JobName);
                        cmd.Parameters.AddWithValue("@Job_Descriptions", item.JobDescriptions);
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

        public IList<CompanyJobDescriptionPoco> GetAll(params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            IList<CompanyJobDescriptionPoco> items = new List<CompanyJobDescriptionPoco>();

            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select Id, Job, Job_Name, Job_Descriptions from Company_Jobs_Descriptions", conn);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        CompanyJobDescriptionPoco item = new CompanyJobDescriptionPoco();
                        item.Id = (Guid)r["Id"];
                        item.Job = (Guid)r["Job"];
                        item.JobName = (string)r["Job_Name"];
                        item.JobDescriptions = (string)r["Job_Descriptions"];
                        items.Add(item);
                    }

                }
                catch (SqlException ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }

                return items;
            }
        }

        public IList<CompanyJobDescriptionPoco> GetList(Expression<Func<CompanyJobDescriptionPoco, bool>> where, params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobDescriptionPoco GetSingle(Expression<Func<CompanyJobDescriptionPoco, bool>> where, params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobDescriptionPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyJobDescriptionPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (CompanyJobDescriptionPoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("delete from Company_Jobs_Descriptions where Id= @Id", conn);
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

        public void Update(params CompanyJobDescriptionPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (CompanyJobDescriptionPoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("update Company_Jobs_Descriptions set Job= @Job, Job_Name= @Job_Name, Job_Descriptions= @Job_Descriptions where Id= @Id", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Job", item.Job);
                        cmd.Parameters.AddWithValue("@Job_Name", item.JobName);
                        cmd.Parameters.AddWithValue("@Job_Descriptions", item.JobDescriptions);
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
                        item.City = ""+r["City_Town"];
                        item.PostalCode = ""+r["Zip_Postal_Code"];
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
                        item.CompanyLogo = Encoding.ASCII.GetBytes(""+r["Company_Logo"]);
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
    public class SecurityLoginRepository : IDataRepository<SecurityLoginPoco>
    {
        public void Add(params SecurityLoginPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (SecurityLoginPoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("insert into Security_Logins (Id, Login, Password, Created_Date, Password_Update_Date, Agreement_Accepted_Date, Is_Locked, Is_Inactive, Email_Address, Phone_Number, Full_Name, Force_Change_Password, Prefferred_Language) values (@Id, @Login, @Password, @Created_Date, @Password_Update_Date, @Agreement_Accepted_Date, @Is_Locked, @Is_Inactive, @Email_Address, @Phone_Number, @Full_Name, @Force_Change_Password, @Prefferred_Language)", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Login", item.Login);
                        cmd.Parameters.AddWithValue("@Password", item.Password);
                        cmd.Parameters.AddWithValue("@Created_Date", item.Created);
                        cmd.Parameters.AddWithValue("@Password_Update_Date", item.PasswordUpdate);
                        cmd.Parameters.AddWithValue("@Agreement_Accepted_Date", item.AgreementAccepted);
                        cmd.Parameters.AddWithValue("@Is_Locked", item.IsLocked);
                        cmd.Parameters.AddWithValue("@Is_Inactive", item.IsInactive);
                        cmd.Parameters.AddWithValue("@Email_Address", item.EmailAddress);
                        cmd.Parameters.AddWithValue("@Phone_Number", item.PhoneNumber);
                        cmd.Parameters.AddWithValue("@Full_Name", item.FullName);
                        cmd.Parameters.AddWithValue("@Force_Change_Password", item.ForceChangePassword);
                        cmd.Parameters.AddWithValue("@Prefferred_Language", item.PrefferredLanguage);
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

        public IList<SecurityLoginPoco> GetAll(params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            IList<SecurityLoginPoco> items = new List<SecurityLoginPoco>();

            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select Id, Login, Password, Created_Date, Password_Update_Date, Agreement_Accepted_Date, Is_Locked, Is_Inactive, Email_Address, Phone_Number, Full_Name, Force_Change_Password, Prefferred_Language from Security_Logins", conn);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        SecurityLoginPoco item = new SecurityLoginPoco();
                        item.Id = (Guid)r["Id"];
                        item.Login = (string)r["Login"];
                        item.Password = (string)r["Password"];
                        item.Created = (DateTime)r["Created_Date"];
                        item.PasswordUpdate = (r["Password_Update_Date"] == DBNull.Value) ? null : (DateTime?)r["Password_Update_Date"];
                        item.AgreementAccepted = (r["Agreement_Accepted_Date"] == DBNull.Value) ? null : (DateTime?)r["Agreement_Accepted_Date"];
                        item.IsLocked = (bool)r["Is_Locked"];
                        item.IsInactive = (bool)r["Is_Inactive"];
                        item.EmailAddress = (string)r["Email_Address"];
                        item.PhoneNumber = ""+r["Phone_Number"];
                        item.FullName = (string)r["Full_Name"];
                        item.ForceChangePassword = (bool)r["Force_Change_Password"];
                        item.PrefferredLanguage = ""+r["Prefferred_Language"];
                        items.Add(item);
                    }

                }
                catch (SqlException ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }

                return items;
            }
        }

        public IList<SecurityLoginPoco> GetList(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginPoco GetSingle(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityLoginPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityLoginPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (SecurityLoginPoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("delete from Security_Logins where Id= @Id", conn);
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

        public void Update(params SecurityLoginPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (SecurityLoginPoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("update Security_Logins set Login= @Login, Password= @Password, Created_Date= @Created_Date, Password_Update_Date= @Password_Update_Date, Agreement_Accepted_Date= @Agreement_Accepted_Date, Is_Locked= @Is_Locked, Is_Inactive= @Is_Inactive, Email_Address= @Email_Address, Phone_Number= @Phone_Number, Full_Name= @Full_Name, Force_Change_Password= @Force_Change_Password, Prefferred_Language= @Prefferred_Language where  Id= @Id", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Login", item.Login);
                        cmd.Parameters.AddWithValue("@Password", item.Password);
                        cmd.Parameters.AddWithValue("@Created_Date", item.Created);
                        cmd.Parameters.AddWithValue("@Password_Update_Date", item.PasswordUpdate);
                        cmd.Parameters.AddWithValue("@Agreement_Accepted_Date", item.AgreementAccepted);
                        cmd.Parameters.AddWithValue("@Is_Locked", item.IsLocked);
                        cmd.Parameters.AddWithValue("@Is_Inactive", item.IsInactive);
                        cmd.Parameters.AddWithValue("@Email_Address", item.EmailAddress);
                        cmd.Parameters.AddWithValue("@Phone_Number", item.PhoneNumber);
                        cmd.Parameters.AddWithValue("@Full_Name", item.FullName);
                        cmd.Parameters.AddWithValue("@Force_Change_Password", item.ForceChangePassword);
                        cmd.Parameters.AddWithValue("@Prefferred_Language", item.PrefferredLanguage);
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

    public class SecurityLoginsLogRepository : IDataRepository<SecurityLoginsLogPoco>
    {
        public void Add(params SecurityLoginsLogPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (SecurityLoginsLogPoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("insert into Security_Logins_Log (Id, Login, Source_IP, Logon_Date, Is_Succesful) values (@Id, @Login, @Source_IP, @Logon_Date, @Is_Succesful)", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Login", item.Login);
                        cmd.Parameters.AddWithValue("@Source_IP", item.SourceIP);
                        cmd.Parameters.AddWithValue("@Logon_Date", item.LogonDate);
                        cmd.Parameters.AddWithValue("@Is_Succesful", item.IsSuccesful);
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

        public IList<SecurityLoginsLogPoco> GetAll(params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            IList<SecurityLoginsLogPoco> items = new List<SecurityLoginsLogPoco>();

            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select Id, Login, Source_IP, Logon_Date, Is_Succesful from Security_Logins_Log", conn);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        SecurityLoginsLogPoco item = new SecurityLoginsLogPoco();
                        item.Id = (Guid)r["Id"];
                        item.Login = (Guid)r["Login"];
                        item.SourceIP = (string)r["Source_IP"];
                        item.LogonDate = (DateTime)r["Logon_Date"];
                        item.IsSuccesful = (bool)r["Is_Succesful"];
                        items.Add(item);
                    }

                }
                catch (SqlException ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }

                return items;
            }
        }

        public IList<SecurityLoginsLogPoco> GetList(Expression<Func<SecurityLoginsLogPoco, bool>> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginsLogPoco GetSingle(Expression<Func<SecurityLoginsLogPoco, bool>> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityLoginsLogPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityLoginsLogPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (SecurityLoginsLogPoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("delete from Security_Logins_Log where Id= @Id", conn);
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

        public void Update(params SecurityLoginsLogPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (SecurityLoginsLogPoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("update Security_Logins_Log set  Login= @Login, Source_IP= @Source_IP, Logon_Date= @Logon_Date, Is_Succesful= @Is_Succesful where Id= @Id", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Login", item.Login);
                        cmd.Parameters.AddWithValue("@Source_IP", item.SourceIP);
                        cmd.Parameters.AddWithValue("@Logon_Date", item.LogonDate);
                        cmd.Parameters.AddWithValue("@Is_Succesful", item.IsSuccesful);
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

    public class SecurityLoginsRoleRepository : IDataRepository<SecurityLoginsRolePoco>
    {
        public void Add(params SecurityLoginsRolePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (SecurityLoginsRolePoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("insert into Security_Logins_Roles (Id, Login, Role) values (@Id, @Login, @Role)", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Login", item.Login);
                        cmd.Parameters.AddWithValue("@Role", item.Role);
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

        public IList<SecurityLoginsRolePoco> GetAll(params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
        {
            IList<SecurityLoginsRolePoco> items = new List<SecurityLoginsRolePoco>();

            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select Id, Login, Role from Security_Logins_Roles", conn);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        SecurityLoginsRolePoco item = new SecurityLoginsRolePoco();
                        item.Id = (Guid)r["Id"];
                        item.Login = (Guid)r["Login"];
                        item.Role = (Guid)r["Role"];
                        items.Add(item);
                    }

                }
                catch (SqlException ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }

                return items;
            }
        }

        public IList<SecurityLoginsRolePoco> GetList(Expression<Func<SecurityLoginsRolePoco, bool>> where, params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginsRolePoco GetSingle(Expression<Func<SecurityLoginsRolePoco, bool>> where, params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityLoginsRolePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityLoginsRolePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (SecurityLoginsRolePoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("delete from Security_Logins_Roles where Id= @Id", conn);
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

        public void Update(params SecurityLoginsRolePoco[] items)
        {
            throw new NotImplementedException();
        }
    }

    public class SecurityRoleRepository : DataAccessLayer.IDataRepository<SecurityRolePoco>
    {
        public void Add(params SecurityRolePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (SecurityRolePoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("insert into Security_Roles (Id, Role, Is_Inactive) values (@Id, @Role, @Is_Inactive)", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Role", item.Role);
                        cmd.Parameters.AddWithValue("@Is_Inactive", item.IsInactive);
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

        public IList<SecurityRolePoco> GetAll(params Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
        {
            IList<SecurityRolePoco> items = new List<SecurityRolePoco>();

            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select Id, Role, Is_Inactive from Security_Roles", conn);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        SecurityRolePoco item = new SecurityRolePoco();
                        item.Id = (Guid)r["Id"];
                        item.Role = (string)r["Role"];
                        item.IsInactive = (bool)r["Is_Inactive"];
                        items.Add(item);
                    }

                }
                catch (SqlException ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }

                return items;
            }
        }

        public IList<SecurityRolePoco> GetList(Expression<Func<SecurityRolePoco, bool>> where, params Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityRolePoco GetSingle(Expression<Func<SecurityRolePoco, bool>> where, params Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityRolePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityRolePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (SecurityRolePoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("delete from Security_Roles where Id= @Id", conn);
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

        public void Update(params SecurityRolePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (SecurityRolePoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("update Security_Roles set Role= @Role, Is_Inactive= @Is_Inactive where Id= @Id", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Role", item.Role);
                        cmd.Parameters.AddWithValue("@Is_Inactive", item.IsInactive);
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

    public class SystemLanguageCodeRepository : IDataRepository<SystemLanguageCodePoco>
    {
        public void Add(params SystemLanguageCodePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (SystemLanguageCodePoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("insert into System_Language_Codes (LanguageID, Name, Native_Name) values (@LanguageID, @Name, @Native_Name)", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@LanguageID", item.LanguageID);
                        cmd.Parameters.AddWithValue("@Name", item.Name);
                        cmd.Parameters.AddWithValue("@Native_Name", item.NativeName);
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

        public IList<SystemLanguageCodePoco> GetAll(params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            IList<SystemLanguageCodePoco> items = new List<SystemLanguageCodePoco>();

            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select LanguageID, Name, Native_Name from System_Language_Codes", conn);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        SystemLanguageCodePoco item = new SystemLanguageCodePoco();
                        item.LanguageID = (string)r["LanguageID"];
                        item.Name = (string)r["Name"];
                        item.NativeName = (string)r["Native_Name"];
                        items.Add(item);
                    }

                }
                catch (SqlException ex) { Console.WriteLine(ex.Message); }
                finally { conn.Close(); }

                return items;
            }
        }

        public IList<SystemLanguageCodePoco> GetList(Expression<Func<SystemLanguageCodePoco, bool>> where, params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SystemLanguageCodePoco GetSingle(Expression<Func<SystemLanguageCodePoco, bool>> where, params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            IQueryable<SystemLanguageCodePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SystemLanguageCodePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (SystemLanguageCodePoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("delete from System_Language_Codes where LanguageID= @LanguageID", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@LanguageID", item.LanguageID);
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

        public void Update(params SystemLanguageCodePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(config.con))
            {
                try
                {
                    conn.Open();
                    foreach (SystemLanguageCodePoco item in items)
                    {
                        SqlCommand cmd = new SqlCommand("update System_Language_Codes set Name= @Name, Native_Name= @Native_Name where LanguageID= @LanguageID", conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@LanguageID", item.LanguageID);
                        cmd.Parameters.AddWithValue("@Name", item.Name);
                        cmd.Parameters.AddWithValue("@Native_Name", item.NativeName);
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
}

