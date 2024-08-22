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
                    Cuisine = "Chinese",
                    Rating = 4.5,
                    Cooktime = 20,
                    Description = "good",
                    Ingredients = "beef, garlic, ginger",
                    Directions = "cook & serve"
                },
                new Recipe
                {
                    Title = "Fettuccine Alfredo",
                    Cuisine = "Italian",
                    Rating = 4.5,
                    Cooktime = 20,
                    Description = "good",
                    Ingredients = "fettuccine noodles, alfredo sauce",
                    Directions = "cook & serve"
                },
                new Recipe
                {
                    Title = "Egg and Cabbage",
                    Cuisine = "Chinese",
                    Rating = 4.5,
                    Cooktime = 20,
                    Description = "good",
                    Ingredients = "egg, cabbage",
                    Directions = "cook & serve"
                },
                new Recipe
                {
                    Title = "Chicken with Tomatoes and Olives",
                    Cuisine = "Mediterranean",
                    Rating = 4.5,
                    Cooktime = 20,
                    Description = "good",
                    Ingredients = "chicken, tomatoes, olives",
                    Directions = "cook & serve"
                }
            );
            context.SaveChanges();
        }
    }
}