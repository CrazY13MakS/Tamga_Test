using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tamga_Test_WebApp.Models;

namespace Tamga_Test_WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {         

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Employee>().HasKey(x => new { x.ApplicantId, x.CompanyId });
           builder.Entity<Applicant>()
               .HasOne(x => x.Employee)
               .WithOne(x => x.Applicant)
               .HasForeignKey<Employee>(x => x.ApplicantId);
             builder.Entity<Position>().HasOne(x => x.Company).WithMany(x=>x.Positions).HasForeignKey(x=>x.CompanyId).OnDelete(DeleteBehavior.SetNull);
        }

        public virtual DbSet<Applicant> Applicants { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
    }


}
