using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                     new Movie
                     {
                         Title = "The RM",
                         ReleaseDate = DateTime.Parse("2003-1-31"),
                         Genre = "Comedy",
                         Price = 7.99M,
                         Rating = "PG"
                     },

                     new Movie
                     {
                         Title = "Other Side of Heaven",
                         ReleaseDate = DateTime.Parse("2002-4-12"),
                         Genre = "Adventure",
                         Price = 8.99M,
                         Rating = "G"
                     },

                     new Movie
                     {
                         Title = "Meet the Mormons",
                         ReleaseDate = DateTime.Parse("2015-2-26"),
                         Genre = "Documentary",
                         Price = 9.99M,
                         Rating = "G"
                     }
                );
                context.SaveChanges();
            }
        }
    }
}
