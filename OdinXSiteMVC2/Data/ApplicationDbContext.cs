using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OdinXSiteMVC2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using OdinXSiteMVC2.Models.Roles;
using OdinXSiteMVC2.Models.DTO;

namespace OdinXSiteMVC2.Data {
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .Property(e => e.firstName)
                .HasMaxLength(250);

            modelBuilder.Entity<ApplicationUser>()
                .Property(e => e.lastName)
                .HasMaxLength(250);

        }

        public DbSet<OdinXSiteMVC2.Models.Roles.Role> Roles { get; set; }

        public DbSet<OdinXSiteMVC2.Models.DTO.NewRegDTO> NewRegDTO { get; set; }

        //Mockdata is below
        //add-migration -context OdinXSiteMVC2Context

        
    }
}
