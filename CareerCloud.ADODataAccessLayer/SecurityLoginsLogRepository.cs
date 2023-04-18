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
}

