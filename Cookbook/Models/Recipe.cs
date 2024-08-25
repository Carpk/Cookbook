using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cookbook.Models;

public class Recipe
{
    public int Id { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string? Title { get; set; }     public string? Cuisine { get; set; }

    public string? Image { get; set; }
    
    [Range(1, 10)]
    public double? Rating {  get; set; }

    [Display(Name = "Cook Time")]
    public int? Cooktime { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? Description { get; set; }

    public string? Ingredients { get; set; }

    public string? Directions { get; set; }


    public string[] IngredientsList()
    {
        return Ingredients.Split(',');
    }

    public string[] DirectionsList()
    {
        return Directions.Split('.');
    }
}