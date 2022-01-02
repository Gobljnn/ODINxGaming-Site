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

        public DbSet<OdinXSiteMVC2.Models.Exec> Exec { get; set; } //model the centext is based on

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
                    //loginAmt = 2,
                    //lastLogin = DateTime.Parse("2021-12-29")
                    favGame = "OW"

                },

                new Exec {
                    execID = 002,
                    execFirstName = "Kitan",
                    execLastName = "Adebowale",
                    username = "Kitan3000",
                    execGamingTag = "Kitan3000",
                    execTitle = "Photographer",
                    execHierarchy = "Founding",
                    favGame = "COD"
                    //loginAmt = 9,
                    //lastLogin = DateTime.Parse("2021-9-3")
                },

                new Exec {
                    execID = 003,
                    execFirstName = "Nathan",
                    execLastName = "Stayer",
                    username = "Fishboy8383",
                    execGamingTag = "Fishboy8383",
                    execTitle = "Community Manager",
                    execHierarchy = "Founding",
                    favGame = "League"
                    //loginAmt = 12,
                    //lastLogin = DateTime.Parse("2021-12-15")
                }
            );

        }
    }
}
