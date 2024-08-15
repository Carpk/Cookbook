using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cookbook.Models;

namespace Cookbook.Data
{
    public class CookbookContext : DbContext
    {
        public CookbookContext (DbContextOptions<CookbookContext> options)
            : base(options)
        {
        }

        public DbSet<Cookbook.Models.Recipe> Recipe { get; set; } = default!;
    }
}
