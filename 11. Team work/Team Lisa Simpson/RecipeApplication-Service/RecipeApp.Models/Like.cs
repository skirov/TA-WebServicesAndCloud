using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class Like
    {
        [Key, Column(Order = 0)]
        public int Recipe_Id { get; set; }

        [Key, Column(Order = 1)]
        public int User_Id { get; set; }
    }
}
