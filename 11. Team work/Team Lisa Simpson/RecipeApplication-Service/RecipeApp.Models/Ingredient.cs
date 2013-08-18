using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace RecipeApp.Models
{
    public class Ingredient
    {
        [Key]
        public int IngredientId { get; set; }

        [Required]
        public string Product { get; set; }

        [Required]
        public double Quantity { get; set; }

        [Required]
        public string Units { get; set; }
    }
}
