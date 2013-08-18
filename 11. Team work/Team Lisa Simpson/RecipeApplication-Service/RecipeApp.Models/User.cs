using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class User
    {
        private ICollection<Like> likes;
        private ICollection<Comment> comments;
        private ICollection<Recipe> recipies;

        public User()
        {
            this.likes = new HashSet<Like>();
            this.comments = new HashSet<Comment>();
            this.recipies = new HashSet<Recipe>();
        }

        [Key]
        public int UserId { get; set; }

        [Required]
        [MinLength(4)]
        public string Username { get; set; }

        [Required]
        public string AuthCode { get; set; }

        public string SessionKey { get; set; }

        public virtual ICollection<Recipe> Recipies
        {
            get
            {
                return this.recipies;
            }
            set
            {
                this.recipies = value;
            }
        }

        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }
            set
            {
                this.comments = value;
            }
        }

        public virtual ICollection<Like> Likes
        {
            get
            {
                return this.likes;
            }
            set
            {
                this.likes = value;
            }
        }
    }
}