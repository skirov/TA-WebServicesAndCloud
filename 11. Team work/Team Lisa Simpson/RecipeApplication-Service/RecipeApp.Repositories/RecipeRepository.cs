using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Repositories
{
    public class RecipeRepository : IRepository<Recipe>
    {
        public RecipeRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.Context = context;
            this.DbSet = this.Context.Set<Recipe>();
        }

        protected IDbSet<Recipe> DbSet { get; set; }

        protected DbContext Context { get; set; }

        public void Add(Recipe item)
        {
            this.DbSet.Add(item);
            this.Context.SaveChanges();
        }

        public void Delete(int id)
        {
            this.DbSet.Remove(this.DbSet.Find(id));
            this.Context.SaveChanges();
        }

        public IEnumerable<Recipe> All()
        {
            return this.DbSet;
        }

        public Recipe Get(int id)
        {
            return this.DbSet.Find(id);
        }

        public void Update(int id, Recipe item)
        {
            Recipe recipe = this.DbSet.Find(id);
            if (item.ImageUrl != null)
            {
                recipe.ImageUrl = item.ImageUrl;
            }

            if (item.Likes != null)
            {
                recipe.Likes = recipe.Likes.Union(item.Likes).ToList();
            }

            if (item.Ingredients != null)
            {
                recipe.Ingredients = item.Ingredients;
            }

            if (item.PrepContent != null)
            {
                recipe.PrepContent = item.PrepContent;
            }

            if (item.Steps != null)
            {
                recipe.Steps = item.Steps;
            }

            if (item.Title != null)
            {
                recipe.Title = item.Title;
            }

            if (item.Comments.Count>0)
            {
                recipe.Comments = recipe.Comments.Union(item.Comments).ToList();
            }

            this.Context.SaveChanges();
        }
    }
}
