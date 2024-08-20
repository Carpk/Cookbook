using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Cookbook.Models;

public class RecipeCuisineViewModel
{
    public List<Recipe>? Recipes { get; set; }
    public SelectList? Cuisine { get; set; }
    public string? RecipeCuisine { get; set; }
    public string? SearchString { get; set; }
}