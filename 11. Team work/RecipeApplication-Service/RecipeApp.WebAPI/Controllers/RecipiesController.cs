using RecipeApp.Data;
using RecipeApp.Models;
using RecipeApp.Repositories;
using RecipeApp.WebAPI.Models;
using RecipeApp.WebAPI.Persisters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RecipeApp.WebAPI.Controllers
{
    public class RecipiesController : ApiController
    {
        private readonly IRepository<Recipe> recipeRepository;
        private readonly UserDataPersister persister;

        public RecipiesController(IRepository<Recipe> recipeRepository, UserDataPersister data)
        {
            this.recipeRepository = recipeRepository;
            this.persister = data;
        }

        // GET api/recipies
        public IEnumerable<RecipeModel> Get()
        {
            var allRecipies = this.recipeRepository.All().Select(x => new RecipeModel
            {
                Comments = x.Comments,
                ImageUrl = x.ImageUrl,
                Ingredients = x.Ingredients,
                Likes = x.Likes,
                LikesCount = x.Likes.Where(l=>l.Recipe_Id == x.RecipeId).Count(),
                PrepContent = x.PrepContent,
                RecipeId = x.RecipeId,
                Steps = x.Steps.OrderBy(s => s.Number).ToList(),
                Title = x.Title
            });
            return allRecipies;
        }

        // GET api/recipies/5
        public RecipeModel Get(int id)
        {
            var recipe = RecipeModel.FromRecipeToRecipeModel(recipeRepository.Get(id));
            return recipe;
        }

        // POST api/recipies
        public void Post(RecipeModel recipe, string sessionKey)
        {
            var user = persister.GetUser(sessionKey);
            if (user.SessionKey != null)
            {
                Recipe newRecipe = RecipeModel.FromRecipeModeltoRecipe(recipe, user.UserId);
                this.recipeRepository.Add(newRecipe);
            }
        }

        // PUT api/recipies/5
        public void Put(int id, string sessionKey, RecipeModel recipe)
        {
            var user = persister.GetUser(sessionKey);
            recipe.RecipeId = id;
            if (user.SessionKey != null)
            {
                Recipe currentRecipe = RecipeModel.FromRecipeModeltoRecipe(recipe, user.UserId);
                this.recipeRepository.Update(id, currentRecipe);
            }
        }

        // DELETE api/recipies/5
        public void Delete(int id, string sessionKey)
        {
            var user = persister.GetUser(sessionKey);
            if (user.SessionKey != null)
            {
                this.recipeRepository.Delete(id);
            }
        }
    }
}