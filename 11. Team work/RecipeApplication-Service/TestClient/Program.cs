using RecipeApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            RecipeAppContext context = new RecipeAppContext();

            var asd = context.Users;
        }
    }
}
