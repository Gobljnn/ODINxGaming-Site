﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OdinXSiteMVC2.Models;
using System;
using System.Collections.Generic;
using System.Text;

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

        //Mockdata is below
        //add-migration -context OdinXSiteMVC2Context

        
    }
}
