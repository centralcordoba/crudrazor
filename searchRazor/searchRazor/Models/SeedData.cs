using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using searchRazor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace searchRazor.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Data.searchRazorContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<searchRazorContext>>()))
            {
                if (context == null || context.Cars == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                // Look for any movies.
                if (context.Cars.Any())
                {
                    return;   // DB has been seeded
                }

                context.Cars.AddRange(
                    new Car
                    {
                        Model = "Tesla",
                        Make = "M3",
                        Color = "Black",
                        Year = "2019",
                        Price = 5500
                    },

                    new Car
                    {
                        Model = "Mercedes Benz",
                        Make = "C250",
                        Color = "White",
                        Year = "2020",
                        Price = 5500
                    },

                    new Car
                    {
                        Model = "Bmw",
                        Make = "b1",
                        Color = "Red",
                        Year = "2015",
                        Price = 4000
                    },

                    new Car
                    {
                        Model = "Audi",
                        Make = "A3",
                        Color = "Green",
                        Year = "2010",
                        Price = 3000
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
