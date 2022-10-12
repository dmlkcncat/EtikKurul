using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EtikContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));

            optionsBuilder.UseMySql(@"Server=localhost; database=etik; uid=root; pwd=1513", serverVersion);

        }

        public DbSet<ApplicantUser> ApplicantUser { get; set; }
        public DbSet<Application> Application { get; set; }
        public DbSet<ApplicationForm> ApplicationForm { get; set; }
        public DbSet<ApplicationQualification> ApplicationQualification { get; set; }
        public DbSet<ApplicationStatus> ApplicationStatus { get; set; }
        public DbSet<AssistantInvestigator> AssistantInvestigator { get; set; }
        public DbSet<DocumentFile> DocumentFile { get; set; }
        public DbSet<Form> Form { get; set; }
        public DbSet<RedApplication> RedApplication { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UnderTakingForm> UnderTakingForm { get; set; }
        public DbSet<UpdateApplication> UpdateApplication { get; set; }
        public DbSet<User> User { get; set; }

    }
}
