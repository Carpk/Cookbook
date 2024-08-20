using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Cookbook.Data;
using System;
using System.Linq;

namespace Cookbook.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new CookbookContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<CookbookContext>>()))
        {
            // Look for any movies.
            if (context.Recipe.Any())
            {
                return;   // DB has already been seeded
            }

            context.Recipe.AddRange(
                new Recipe
                {
                    Title = "Mongolian Beef",
                    Cuisine = "Chinese"
                },
                new Recipe
                {
                    Title = "Fettuccine Alfredo",
                    Cuisine = "Italian"
                },
                new Recipe
                {
                    Title = "Egg and Cabbage",
                    Cuisine = "Chinese"
                },
                new Recipe
                {
                    Title = "Chicken with Tomatoes and Olives",
                    Cuisine = "Mediterranean"
                }
            );
            context.SaveChanges();
        }
    }
}