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
                    Image = "https://www.kitchensanctuary.com/wp-content/uploads/2020/08/Mongolian-Beef-square-FS-22.jpg",
                    Rating = 4.5,
                    Cooktime = 20,
                    Description = "good",
                    Ingredients = "1lb flank steak, 2 green onions, 4 cloves of garlic, ½ teaspoon ginger, ½ cup soy sauce, ¼ cup water, ⅓ cup cornstarch, ½ cup brown sugar",
                    Directions = "Slice the flank steak into thin ¼ inch pieces, Toss with cornstarch, shaking off any excess " + 
                        "and set aside. In a 10-inch skillet, heat 2 teaspoons of oil over medium-low heat, stir in minced ginger " +
                        "and garlic and cook until fragrant, about one minute. Add soy sauce, water, and brown sugar to the skillet, " +
                        "then bring to a boil for 3-5 minutes until slightly thickened."
                },
                new Recipe
                {
                    Title = "Fettuccine Alfredo",
                    Cuisine = "Italian",
                    Image = "https://placehold.co/370x250",
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
                    Image = "https://placehold.co/370x250",
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
                    Image = "https://placehold.co/370x250",
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