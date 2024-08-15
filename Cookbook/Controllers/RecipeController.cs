using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace Cookbook.Controllers;

public class RecipeController : Controller
{
    // 
    // GET: /Recipe/
    public IActionResult Index()
    {
        return View();
    }
    // 
    // GET: /Recipe/Welcome/ 
    public IActionResult Welcome(string name, int numTimes = 1)
    {
        ViewData["Message"] = "Hello " + name;
        ViewData["NumTimes"] = numTimes;
        return View();
    }
}