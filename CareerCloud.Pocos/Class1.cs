using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CareerCloud.Pocos
{


    public interface IPoco
    {
         Guid Id { get; set; } // Id property is public by default inside the interface
    }

    [Table("Applicant_Educations")]
    public class ApplicantEducationPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        [Column("Role")]
        public Guid Applicant { get; set; }

        [Column("Major")]
        public string Major { get; set; }

        [Column("Certificate_Diploma")]
        public string CertificateDiploma { get; set; }

        [Column("Start_Date")]
        public DateTime? StartDate { get; set; }

        [Column("Completion_Date")]
        public DateTime? CompletionDate { get; set; }

        [Column("Completion_Percent")]
        public Byte? CompletionPercent { get; set; }

        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }


    }

    [Table("Applicant_Job_Applications")]
    public class ApplicantJobApplicationPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        public Guid Applicant { get; set; }

        public Guid Job { get; set; }

        [Column("Application_Date")]
        public DateTime ApplicationDate { get; set; }

        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }

    }

    [Table("Applicant_Profiles")]
    public class ApplicantProfilePoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        public Guid Login { get; set; }

        [Column("Current_Salary")]
        public decimal? CurrentSalary { get; set; }

        [Column("Current_Rate")]
        public decimal? CurrentRate { get; set; }

        public string Currency { get; set; }

        [Column("Country_Code")]
        public string Country { get; set; }
        
        [Column("State_Province_Code")]
        public string Province { get; set; }

        [Column("Street_Address")]
        public string Street { get; set; }

        [Column("City_Town")]
        public string City { get; set; }

        [Column("Zip_Postal_Code")]
        public string PostalCode { get; set; } 

        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }

    }

    [Table("Applicant_Resumes")]
    public class ApplicantResumePoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        public Guid Applicant { get; set; }
        public string Resume { get; set; }
        [Column("Last_Updated")]
        public DateTime? LastUpdated { get; set; }

    }

    [Table("Applicant_Skills")]
    public class ApplicantSkillPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        public Guid Applicant { get; set; }

        public string Skill { get; set; }

        [Column("Skill_Level")]
        public string SkillLevel { get; set; }

        [Column("Start_Month")]
        public Byte StartMonth { get; set; }

        [Column("Start_Year")]
        public int StartYear { get; set; }

        [Column("End_Month")]
        public Byte EndMonth { get; set; }

        [Column("End_Year")]
        public int EndYear { get; set; }

        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }

    }

    [Table("Applicant_Work_History")]
    public class ApplicantWorkHistoryPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        public Guid Applicant { get; set; }

        [Column("Company_Name")]
        public string CompanyName { get; set; }

        [Column("Country_Code")]
        public string CountryCode { get; set; }

        [Column("Company_Name")]
        public string Location { get; set; }

        [Column("Job_Title")]
        public string JobTitle { get; set; }

        [Column("Job_Description")]
        public string JobDescription { get; set; }

        [Column("Start_Month")]
        public short StartMonth { get; set; }

        [Column("Start_Year")]
        public int StartYear { get; set; }

        [Column("End_Month")]
        public short EndMonth { get; set; }

        [Column("End_Year")]
        public Int32 EndYear { get; set; }

        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }

    }

    [Table("Company_Descriptions")]
    public class CompanyDescriptionPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        public Guid Company { get; set; }
        public string LanguageId { get; set; }

        [Column("Company_Name")]
        public string CompanyName { get; set; }

        [Column("Company_Description")]
        public string CompanyDescription { get; set; }

        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }

    }

    [Table("Company_Job_Educations")]
    public class CompanyJobEducationPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        public Guid Job { get; set; }
        public string Major { get; set; }
        public Int16 Importance { get; set; }

        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }

    }

    [Table("Company_Job_Skills")]
    public class CompanyJobSkillPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        public Guid Job { get; set; }
        public string Skill { get; set; }

        [Column("Skill_Level")]
        public string SkillLevel { get; set; }

        public int Importance { get; set; }

        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }

    }

    [Table("Company_Jobs")]
    public class CompanyJobPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        public Guid Company { get; set; }

        [Column("Profile_Created")]
        public DateTime ProfileCreated { get; set; }

        [Column("Is_Inactive")]
        public Boolean IsInactive { get; set; }

        [Column("Is_Company_Hidden")]
        public Boolean IsCompanyHidden { get; set; }

        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }

    }

    [Table("Company_Jobs_Descriptions")]
    public class CompanyJobDescriptionPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        public Guid Job { get; set; }

        [Column("Job_Name")]
        public string JobName { get; set; }

        [Column("Job_Descriptions")]
        public string JobDescriptions { get; set; }

        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }

    }

    [Table("Company_Locations")]
    public class CompanyLocationPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        public Guid Company { get; set; }

        [Column("Country_Code")]
        public string CountryCode { get; set; }

        [Column("State_Province_Code")]
        public string Province { get; set; }

        [Column("Street_Address")]
        public string Street { get; set; }

        [Column("City_Town")]
        public string City { get; set; }

        [Column("Zip_Postal_Code")]
        public string PostalCode { get; set; }

        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }

    }

    [Table("Company_Profiles")]
    public class CompanyProfilePoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        [Column("Registration_Date")]
        public DateTime RegistrationDate { get; set; }

        [Column("Company_Website")]
        public string CompanyWebsite { get; set; }

        [Column("Contact_Phone")]
        public string ContactPhone { get; set; }

        [Column("Contact_Name")]
        public string ContactName { get; set; }

        [Column("Company_Logo")]
        public Byte[] CompanyLogo { get; set; }

        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }

    }

    [Table("Security_Logins")]
    public class SecurityLoginPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        [Column("Created_Date")]
        public DateTime Created { get; set; }

        public string Login { get; set; }


        public string Password { get; set; }

        [Column("Email_Address")]
        public string EmailAddress { get; set; }

        [Column("Phone_Number")]
        public string PhoneNumber { get; set; }

        [Column("Full_Name")]
        public string FullName { get; set; }

        [Column("Prefferred_Language")]
        public string PrefferredLanguage { get; set; }


        [Column("Password_Update_Date")]
        public DateTime? PasswordUpdate { get; set; }

        [Column("Agreement_Accepted_Date")]
        public DateTime? AgreementAccepted { get; set; }

        [Column("Is_Locked")]
        public Boolean IsLocked { get; set; }

        [Column("Is_Inactive")]
        public Boolean IsInactive { get; set; }

        [Column("Force_Change_Password")]
        public Boolean ForceChangePassword { get; set; }

        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }

    }

    [Table("Security_Logins_Log")]
    public class SecurityLoginsLogPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        public Guid Login { get; set; }

        [Column("Source_IP")]
        public string SourceIP { get; set; }

        [Column("Logon_Date")]
        public DateTime LogonDate { get; set; }

        [Column("Is_Succesful")]
        public bool IsSuccesful { get; set; }

    }

    [Table("Security_Logins_Roles")]
    public class SecurityLoginsRolePoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        public Guid Login { get; set; }
        public Guid Role { get; set; }

        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }

    }

    [Table("Security_Roles")]
    public class SecurityRolePoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        [Column("Role")]
        public string Role { get; set; }

        [Column("Is_Inactive")]
        public Boolean IsInactive { get; set; }

    }

    [Table("System_Country_Codes")]
    public class SystemCountryCodePoco
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
    }

    [Table("System_Language_Codes")]
    public class SystemLanguageCodePoco
    {
        [Key]
        public string LanguageID { get; set; }
        public string Name { get; set; }

        [Column("Native_Name")]
        public string NativeName { get; set; }
    }
}