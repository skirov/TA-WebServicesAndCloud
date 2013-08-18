//using RecipeApp.Data;
//using RecipeApp.Models;
//using RecipeApp.Repositories;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;

//namespace RecipeApp.WebAPI.Controllers
//{
//    public class CommentsController : ApiController
//    {
//        private readonly IRepository<Comment> data;

//        public CommentsController(IRepository<Comment> data)
//        {
//            this.data = data;
//        }

//        public CommentsController()
//        {
//            this.data = new CommentRepository(new RecipeAppContext());
//        }
//        // GET api/comments
//        //public IEnumerable<string> Get()
//        //{
//        //    //var allComments = this.data.All().Select(x => new CommentModel
//        //    //{
                
//        //    //});
//        //    //return allComments;
//        //}

//        // GET api/comments/5
//        public string Get(int id)
//        {
//            return "value";
//        }

//        // POST api/comments
//        public void Post([FromBody]string value)
//        {
//        }

//        // PUT api/comments/5
//        public void Put(int id, [FromBody]string value)
//        {
//        }

//        // DELETE api/comments/5
//        public void Delete(int id)
//        {
//        }
//    }
//}
