using ACCharging.Common;
using ACCharging.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCharging.Data
{
    public class DbDataContext : DbContext
    {
        #region Database tables

        public DbSet<User> Users { get; set; }

        public DbSet<TestHistory> Histories { get; set; }

        public DbSet<TestCaseResult> TestCaseResults { get; set; }

        public DbSet<TestCaseCheckpoint> TestCaseCheckpoints { get; set; }

        #endregion

        public DbDataContext()
        {
            Database.EnsureCreatedAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ACCharging.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    UserId = "BF83819F-0CBF-4522-8375-BE650A6622C8",
                    UserName = "admin",
                    Password = CryptographyHelper.Encrypt("admin"),
                    Gender = "0",
                    Mobile = "13456789012",
                    Email = "ad@AcCharging.com",
                    LastLogonTime = new DateTime(1990, 1, 1),
                    CreateTime = new DateTime(1990, 1, 1),
                    IsSystemUser = true
                });

            modelBuilder.Entity<TestCaseResult>()
                .HasOne<TestHistory>()
                .WithMany(h => h.TestResults)
                .HasForeignKey(t => t.HistoryId);

            modelBuilder.Entity<TestCaseCheckpoint>()
                .HasOne<TestCaseResult>()
                .WithMany(r => r.Checkpoints)
                .HasForeignKey(tr => tr.TestCaseResultId);
        }
    }
}
