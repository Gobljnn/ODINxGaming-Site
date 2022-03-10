using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OdinXSiteMVC2.Models;
using OdinXSiteMVC2.Models.Socials;
using OdinXSiteMVC2.Models.Roles;
using OdinXSiteMVC2.Models.DTO;

namespace OdinXSiteMVC2.Data
{
    public class OdinXSiteMVC2Context : DbContext
    {
        public OdinXSiteMVC2Context (DbContextOptions<OdinXSiteMVC2Context> options)
            : base(options)
        {
        }

        public DbSet<OdinXSiteMVC2.Models.Exec> Exec { get; set; } //model the centext is based on\
        

        public DbSet<OdinXSiteMVC2.Models.DTO.NewRegDTO> NewReg { get; set; }

        public DbSet<ExecSocial> ExecSocials { get; set; }
        public DbSet<OdinXSiteMVC2.Models.UserImage> UserFiles { get; set; }

        public DbSet<Role> Roles { get; set; }

        //Mockdata is below
        //add-migration -context OdinXSiteMVC2Context
        public DbSet<OdinXSiteMVC2.Models.Socials.ExecSocial> ExecSocial { get; set; }
        //Mockdata is below
        //add-migration -context OdinXSiteMVC2Context

        //Mockdata is below
        //add-migration -context OdinXSiteMVC2Context



        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<ExecSocial>().HasData(
            new ExecSocial {
                socialID = 1,
                execId = "001",
                execName = "Gobljnn",
                ttvlink = "twitch.tv/gobljnn",
                scLink = "soundcloud.com/gobljnn",

            }

            //new ExecSocial {
            //    socialID = 2,
            //    execId = "001",
            //    execName = "K3k",
            //    ttvlink = "twitch.tv/k3k",
            //    scLink = "soundcloud.com/k3k",

            //}
            );

            modelBuilder.Entity<Exec>().HasData(
            //    new Exec {
            //        execID = "001",
            //        execFirstName = "Damm",
            //        execLastName = "Adebayo",
            //        username = "Gobljnn",
            //        execGamingTag = "Gobljnn",
            //        execTitle = "Programmer",
            //        execHierarchy = "Founding",
            //        favGame = "OW",
            //        execPic = null,
            //        bio = " Oluwadamilola Gobljnn Adebayo (Dammy), a chemical engineer, one of the co-founders of ODINxGAMING goes by the gamer His favourite genre to play is FPS, which includes a shit - ton of Overwatch and Call of Duty.He also dabbles in a bit of Rocket League buthe dog water.Gobljnn is ODINxGaming\'s Lead Developer and UI Support member."
            //    },

            new Exec {
                execID = "001",
                execFirstName = "Kitan",
                execLastName = "Adebowale",
                username = "Kitan3000",
                execGamingTag = "Kitan3000",
                execTitle = "Photographer",
                execHierarchy = "Founding",
                favGame = "COD",
                execPic = null,
                bio = "Ibukun \"Kitan 3000\" Adebowale (Kitan), a civil engineer, one of the co-founders of ODINxGAMING goes by the gamertag Kitan 3000 .His favourite genres to play are FPS and racing games.His gaming forte includes Overwatch, Call of Duty, Rocket League, Forza, and girls hearts (jokes). His role within ODINxGAMING is to oversee all server and organizational management.He also handles all disciplinary actions within our organization."
            }

            //    new Exec {
            //        execID = "003",
            //        execFirstName = "Nathan",
            //        execLastName = "Stayer",
            //        username = "Fishboy8383",
            //        execGamingTag = "Fishboy8383",
            //        execTitle = "Community Manager",
            //        execHierarchy = "Founding",
            //        favGame = "League",
            //        execPic = null
            //    }
            );

        }
        //Mockdata is below
        //add-migration -context OdinXSiteMVC2Context

        //Mockdata is below
        //add-migration -context OdinXSiteMVC2Context



        public DbSet<OdinXSiteMVC2.Models.DTO.AdminEditDTO> AdminEditDTO { get; set; }
        //Mockdata is below
        //add-migration -context OdinXSiteMVC2Context

        //Mockdata is below
        //add-migration -context OdinXSiteMVC2Context



        public DbSet<OdinXSiteMVC2.Models.DTO.RoleDTO> RoleDTO { get; set; }
        
    }
}
