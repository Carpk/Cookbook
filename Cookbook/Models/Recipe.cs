using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cookbook.Models;

public class Recipe
{
    public int Id { get; set; }
    public string? Title { get; set; }     public string? Cuisine { get; set; }
    public double? Rating {  get; set; }
    [Display(Name = "Cook Time")]
    public int? Cooktime { get; set; }
    [Column(TypeName = "varchar(200)")]
    public string? Description { get; set; }
    public string? Ingredients { get; set; }
    public string? Directions { get; set; }
}