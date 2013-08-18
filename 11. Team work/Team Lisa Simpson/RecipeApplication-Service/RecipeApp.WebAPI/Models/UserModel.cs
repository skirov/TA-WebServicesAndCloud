using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecipeApp.WebAPI.Models
{
    public class UserModel : UserDetails
    {
        private ICollection<Like> likes;
        private ICollection<Comment> comments;
        private ICollection<Recipe> recipies;

        public UserModel()
        {
            this.likes = new HashSet<Like>();
            this.comments = new HashSet<Comment>();
            this.recipies = new HashSet<Recipe>();
        }

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
