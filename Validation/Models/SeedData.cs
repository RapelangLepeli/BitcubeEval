using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Validation.Data;

namespace Validation.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider provider)
        {
            using(var dbContext = new ApplicationDbContext(provider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (dbContext.Lecturer.Any())
                {
                    return;
                }
                else
                {
                    dbContext.Lecturer.AddRange(
                        new Lecturer {
                            EmailAddress = "Raps@gmail.com",
                            Name ="Raps",
                            Students = { new Student { Name ="Joe",EmailAddress="Joe@12"},new Student { Name="Ken",EmailAddress="Ken@1"},
                                            new Student{Name="Scott",EmailAddress="Gamer@12"}
                                        },
                                Degrees = { new Degree { Name ="IT"}, new Degree { Name = "Genectics" }, new Degree { Name = "Demesic Law" } }               
                        },
                        new Lecturer
                        {
                            EmailAddress = "King@gmail.com",
                            Name = "King",
                            Students = { new Student { Name ="Paul",EmailAddress="p@12"},new Student { Name="zen",EmailAddress="zen@1"},
                                            new Student{Name="kat",EmailAddress="kt@12"}
                                        },
                            Degrees = { new Degree { Name = "Logistics" }, new Degree { Name = "Chemistry" }, new Degree { Name = "Physcs" } }
                        }              
                        );
                }
                dbContext.SaveChanges();
            }
        }
    }
}
