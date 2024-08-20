using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cookbook.Data;
using Cookbook.Models;

namespace Cookbook.Controllers
{
    public class RecipesController : Controller
    {
        private readonly CookbookContext _context;

        public RecipesController(CookbookContext context)
        {
            _context = context;
        }

        // GET: Recipes
        // public async Task<IActionResult> Index(string searchString)
        // {
        //     if (_context.Recipe == null)
        //     {
        //         return Problem("Entity set 'Cookbook.Context.Movie'  is null.");
        //     }

        //     // LINQ query 
        //     var recipes = from r in _context.Recipe
        //                 select r;

            
        //     if (!String.IsNullOrEmpty(searchString))
        //     {
        //         recipes = recipes.Where(s => s.Title!.ToUpper().Contains(searchString.ToUpper()));
        //     }

        //     return View(await recipes.ToListAsync());
        // }


        // GET: Movies
        public async Task<IActionResult> Index(string recipeCuisine, string searchString)
        {
            if (_context.Recipe == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            // Use LINQ to get list of genres.
            IQueryable<string> cuisineQuery = from m in _context.Recipe
                                            orderby m.Cuisine
                                            select m.Cuisine;
            var recipes = from m in _context.Recipe
                        select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                recipes = recipes.Where(s => s.Title!.ToUpper().Contains(searchString.ToUpper()));
            }

            if (!string.IsNullOrEmpty(recipeCuisine))
            {
                recipes = recipes.Where(x => x.Cuisine == recipeCuisine);
            }

            var recipeCuisineVM = new RecipeCuisineViewModel
            {
                Cuisine = new SelectList(await cuisineQuery.Distinct().ToListAsync()),
                Recipes = await recipes.ToListAsync()
            };

            return View(recipeCuisineVM);
        }



        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // GET: Recipes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Cuisine")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Cuisine")] Recipe recipe)
        {
            if (id != recipe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipe = await _context.Recipe.FindAsync(id);
            if (recipe != null)
            {
                _context.Recipe.Remove(recipe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipe.Any(e => e.Id == id);
        }
    }
}
