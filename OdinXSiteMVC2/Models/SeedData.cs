using OdinXSiteMVC2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace OdinXSiteMVC2.Models {
    public static class SeedData {
        public static void Initialize(IServiceProvider serviceProvider) {
            using (var context = new OdinXSiteMVC2Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<OdinXSiteMVC2Context>>())) {
                // Look for any movies.
                if (context.Exec.Any()) {
                    return;   // DB has been seeded
                }

                context.Exec.AddRange(
                    new Exec {
                        execID = 001,
                        execFirstName = "Dammy",
                        execLastName = "Adebayo",
                        username = "Gobljnn",
                        execGamingTag = "Gobljnn",
                        execTitle = "Programmer",
                        execHierarchy = "Founding"
                        //loginAmt = 2,
                        //lastLogin = DateTime.Parse("2021-12-29")

                    },

                    new Exec {
                        execID = 002,
                        execFirstName = "Kitan",
                        execLastName = "Adebowale",
                        username = "Kitan3000",
                        execGamingTag = "Kitan3000",
                        execTitle = "Photographer",
                        execHierarchy = "Founding"
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
                        execHierarchy = "Founding"
                        //loginAmt = 12,
                        //lastLogin = DateTime.Parse("2021-12-15")
                    }

                );
                context.SaveChanges();
            }
        }
    }
}
