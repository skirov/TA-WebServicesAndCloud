using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class Step
    {
        [Key]
        public int StepId { get; set; }

        [Required]
        public int Time { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
