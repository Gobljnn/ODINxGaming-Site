using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OdinXSiteMVC2.Models;

namespace OdinXSiteMVC2.Data
{
    public class OdinXSiteMVC2Context : DbContext
    {
        public OdinXSiteMVC2Context (DbContextOptions<OdinXSiteMVC2Context> options)
            : base(options)
        {
        }

        public DbSet<OdinXSiteMVC2.Models.Exec> Exec { get; set; } //model the centext is based on\
        public DbSet<OdinXSiteMVC2.Models.UserImage> UserFiles { get; set; }

        //Mockdata is below
        //add-migration -context OdinXSiteMVC2Context
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Exec>().HasData(
                new Exec {
                    execID = 001,
                    execFirstName = "Dammy",
                    execLastName = "Adebayo",
                    username = "Gobljnn",
                    execGamingTag = "Gobljnn",
                    execTitle = "Programmer",
                    execHierarchy = "Founding",
                    favGame = "OW",
                    execPic = null
                },

                new Exec {
                    execID = 002,
                    execFirstName = "Kitan",
                    execLastName = "Adebowale",
                    username = "Kitan3000",
                    execGamingTag = "Kitan3000",
                    execTitle = "Photographer",
                    execHierarchy = "Founding",
                    favGame = "COD",
                    execPic = null
                },

                new Exec {
                    execID = 003,
                    execFirstName = "Nathan",
                    execLastName = "Stayer",
                    username = "Fishboy8383",
                    execGamingTag = "Fishboy8383",
                    execTitle = "Community Manager",
                    execHierarchy = "Founding",
                    favGame = "League",
                    execPic = null
                }
            );

        }
    }
}
