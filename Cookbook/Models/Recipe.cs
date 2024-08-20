using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cookbook.Models;

public class Recipe
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Cuisine { get; set; }
    // [Display(Name = "Cook Time")]
    // public decimal? Cooktime { get; set; }
    // [Column(TypeName = "varchar(200)")]
    // public string? Description { get; set; }
    // public string? Ingredients { get; set; }

    // public string? Directions { get; set; }
}