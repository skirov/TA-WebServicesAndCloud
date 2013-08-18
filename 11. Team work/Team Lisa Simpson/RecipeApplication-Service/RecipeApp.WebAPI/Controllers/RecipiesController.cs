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
using System.Web;
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
                LikesCount = x.Likes.Where(l => l.Recipe_Id == x.RecipeId).Count(),
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

        public HttpResponseMessage UploadImage()
        {
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            // Check if files are available
            var reader = httpRequest.InputStream;

            if (httpRequest.Files.Count > 0)
            {
                var files = new List<string>();
                var filePath = string.Empty;
                // interate the files and save on the server
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];

                    DropboxDataPersister dbPrersister = new DropboxDataPersister(postedFile.InputStream, postedFile.FileName);

                    filePath = dbPrersister.UploadFile();
                }

                result = Request.CreateResponse(HttpStatusCode.Created, filePath);

                return result;
            }
            else
            {
                // return BadRequest (no file(s) available)
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return result;
        }

        // GET api/recipies/StartCooking
        [HttpPost]
        public void StartCooking(StepModel step, string sessionKey)
        {
            PubnubAPI pubnub = new PubnubAPI(
            "pub-c-40427e1d-7b94-4f2c-bde6-6c93636f2a6f",               // PUBLISH_KEY
            "sub-c-db9871f4-05e0-11e3-8dc9-02ee2ddab7fe",               // SUBSCRIBE_KEY
            "sec-c-M2FlN2E1ZTMtNGRkMi00MTg4LTgxYmQtM2E1OWUxMjJlMWMx",   // SECRET_KEY
            true                                                        // SSL_ON?
        );
            string channel = "startCooking-channel";


            System.Threading.Thread.Sleep(step.Time * 60 * 1000);

            pubnub.Publish(channel, "Step " + step.Number + " has finished.");

        }
    }
}