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
                        item.PhoneNumber = "" + r["Phone_Number"];
                        item.FullName = (string)r["Full_Name"];
                        item.ForceChangePassword = (bool)r["Force_Change_Password"];
                        item.PrefferredLanguage = "" + r["Prefferred_Language"];
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
}

