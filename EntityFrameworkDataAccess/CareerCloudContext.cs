using CareerCloud.ADODataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class CareerCloudContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(config.con);


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(e => e.ApplicantEducations)
                .WithOne(p => p.ApplicantProfile)
                .HasForeignKey(a => a.Applicant)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(j => j.ApplicantJobApplications)
                .WithOne(p => p.ApplicantProfile)
                .HasForeignKey(d => d.Applicant)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(c => c.ApplicantWorkHistorys)
                .WithOne(d => d.ApplicantProfile)
                .HasForeignKey(d => d.Applicant)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(c => c.ApplicantResumes)
                .WithOne(d => d.ApplicantProfile)
                .HasForeignKey(d => d.Applicant)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(c => c.ApplicantSkills)
                .WithOne(d => d.ApplicantProfile)
                .HasForeignKey(d => d.Applicant)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(c => c.CompanyJobEducations)
                .WithOne(d => d.CompanyJob)
                .HasForeignKey(d => d.Job)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(c => c.CompanyJobSkills)
                .WithOne(d => d.CompanyJob)
                .HasForeignKey(d => d.Job)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<CompanyProfilePoco>()
                .HasMany(c => c.CompanyDescriptions)
                .WithOne(d => d.CompanyProfile)
                .HasForeignKey(d => d.Company)
                .OnDelete(DeleteBehavior.SetNull);


            modelBuilder.Entity<CompanyProfilePoco>()
                .HasMany(c => c.CompanyJobs)
                .WithOne(d => d.CompanyProfile)
                .HasForeignKey(d => d.Company)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(c => c.CompanyJobDescriptions)
                .WithOne(d => d.CompanyJob)
                .HasForeignKey(d => d.Job)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<CompanyProfilePoco>()
                .HasMany(c => c.CompanyLocations)
                .WithOne(d => d.CompanyProfile)
                .HasForeignKey(d => d.Company)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(c => c.ApplicantJobApplications)
                .WithOne(d => d.CompanyJob)
                .HasForeignKey(d => d.Job)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<SecurityLoginPoco>()
                .HasMany(c => c.SecurityLoginsLogs)
                .WithOne(d => d.SecurityLogin)
                .HasForeignKey(d => d.Login)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<SecurityLoginPoco>()
                .HasMany(c => c.SecurityLoginsRoles)
                .WithOne(d => d.SecurityLogin)
                .HasForeignKey(d => d.Login)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<SecurityRolePoco>()
                .HasMany(c => c.SecurityLoginsRoles)
                .WithOne(d => d.SecurityRole)
                .HasForeignKey(d => d.Role)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<SecurityLoginPoco>()
                .HasMany(c => c.ApplicantProfiles)
                .WithOne(d => d.SecurityLogin)
                .HasForeignKey(d => d.Login)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<SystemCountryCodePoco>()
                .HasMany(c => c.ApplicantProfiles)
                .WithOne(d => d.SystemCountryCode)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<SystemCountryCodePoco>()
                .HasMany(c => c.ApplicantWorkHistorys)
                .WithOne(d => d.SystemCountryCode)
                .HasForeignKey(d => d.CountryCode)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<SystemCountryCodePoco>()
                .HasMany(c => c.ApplicantProfiles)
                .WithOne(d => d.SystemCountryCode)
                .HasForeignKey(d => d.Country)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<SystemCountryCodePoco>()
                .HasMany(c => c.CompanyLocations)
                .WithOne(d => d.SystemCountryCode)
                .HasForeignKey(d => d.CountryCode)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<SystemLanguageCodePoco>()
                .HasMany(c => c.CompanyDescriptions)
                .WithOne(d => d.SystemLanguageCode)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder);
        }

        DbSet<ApplicantEducationPoco> ApplicantEducations { set; get; }
        DbSet<ApplicantJobApplicationPoco> ApplicantJobApplications { set; get; }
        DbSet<ApplicantProfilePoco> ApplicantProfiles { set; get; }
        DbSet<ApplicantResumePoco> ApplicantResumes { set; get; }
        DbSet<ApplicantSkillPoco> ApplicantSkills { set; get; }
        DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistoryPocos { set; get; }
        DbSet<CompanyDescriptionPoco> CompanyDescriptions { set; get; }
        DbSet<CompanyJobDescriptionPoco> CompanyJobDescriptions { set; get; }
        DbSet<CompanyJobEducationPoco> CompanyJobEducations { set; get; }
        DbSet<CompanyJobPoco> CompanyJobs { set; get; }
        DbSet<CompanyJobSkillPoco> CompanyJobSkills { set; get; }
        DbSet<CompanyLocationPoco> CompanyLocations { set; get; }
        DbSet<CompanyProfilePoco> CompanyProfiles { set; get; }
        DbSet<SecurityLoginPoco> SecurityLogins { set; get; }
        DbSet<SecurityLoginsLogPoco> SecurityLoginsLogs { set; get; }
        DbSet<SecurityLoginsRolePoco> SecurityLoginsRoles { set; get; }
        DbSet<SecurityRolePoco> SecurityRoles { set; get; }
        DbSet<SystemCountryCodePoco> SystemCountryCodes { set; get; }
        DbSet<SystemLanguageCodePoco> SystemLanguageCodes { set; get; }
    }
}