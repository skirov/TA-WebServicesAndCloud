using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using RecipeApp.WebAPI.Controllers;
using RecipeApp.Repositories;
using RecipeApp.Models;
using RecipeApp.Data;
using RecipeApp.WebAPI.Persisters;
using System.Data.Entity;

namespace RecipeApp.WebAPI.Resolvers
{
    public class DbDependencyResolver : IDependencyResolver
    {
        private readonly IRepository<Recipe> recipeRepository;
        private readonly RecipeAppContext context;
        private readonly UserDataPersister data;

        public DbDependencyResolver(RecipeAppContext context)
        {
            this.context = context;
            recipeRepository = new RecipeRepository(context);
            data = new UserDataPersister(context);
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(RecipiesController))
            {
                return new RecipiesController(recipeRepository, data);
            }
            else if (serviceType == typeof(UsersController))
            {
                return new UsersController(data);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
        }
    }
}