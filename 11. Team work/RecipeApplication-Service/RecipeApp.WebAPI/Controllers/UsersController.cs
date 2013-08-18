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
    public class UsersController : ApiController
    {
        private readonly UserDataPersister data;

        public UsersController(UserDataPersister data)
        {
            this.data = data;
        }

        [HttpPost]
        [ActionName("register")]
        public HttpResponseMessage RegisterUser([FromBody]UserNotLoggedModel user)
        {
            try
            {
                data.CreateUser(user.Username, user.AuthCode);
                var sessionKey = data.LoginUser(user.Username, user.AuthCode);
                var loggedUser = new UserLoggedModel()
                {
                    SessionKey = sessionKey
                };

                return Request.CreateResponse(HttpStatusCode.OK, loggedUser);
            }
            catch (HttpException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [HttpPost]
        [ActionName("login")]
        public HttpResponseMessage LoginUser([FromBody]UserNotLoggedModel user)
        {
            try
            {
                var sessionKey = data.LoginUser(user.Username, user.AuthCode);
                var loggedUser = new UserLoggedModel()
                {
                    SessionKey = sessionKey
                };

                return Request.CreateResponse(HttpStatusCode.OK, loggedUser);
            }
            catch (HttpException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, e.Message);
            }
        }

        [HttpGet]
        [ActionName("logout")]
        public HttpResponseMessage LogoutUser(string sessionKey)
        {
            try
            {
                data.LogoutUser(sessionKey);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (HttpException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, e.Message);
            }
        }
    }
}