using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Data
{
    public class RecipeAppContext : DbContext
    {
        public RecipeAppContext()
            :base("RecipeAppDb")
        {
        }

        public DbSet<Recipe> Recipies { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Step> Steps { get; set; }
    }
}
