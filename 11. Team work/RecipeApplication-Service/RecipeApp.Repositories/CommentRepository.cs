//using RecipeApp.Models;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace RecipeApp.Repositories
//{
//    public class CommentRepository : IRepository<Comment>
//    {
//        public CommentRepository(DbContext context)
//        {
//            if (context == null)
//            {
//                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
//            }

//            this.Context = context;
//            this.DbSet = this.Context.Set<Comment>();
//        }

//        protected IDbSet<Comment> DbSet { get; set; }

//        protected DbContext Context { get; set; }

//        public void Add(Comment item)
//        {
//            throw new NotImplementedException();
//        }

//        public void Delete(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<Comment> All()
//        {
//            return this.DbSet;
//        }

//        public Comment Get(int id)
//        {
//            return this.DbSet.Find(id);
//        }

//        public void Update(int id, Comment item)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
