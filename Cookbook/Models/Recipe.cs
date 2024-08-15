using System.ComponentModel.DataAnnotations;

namespace Cookbook.Models;

public class Recipe
{
    public int Id { get; set; }
    public string? Title { get; set; }
    [DataType(DataType.Date)]
    public string? Cuisine { get; set; }

}