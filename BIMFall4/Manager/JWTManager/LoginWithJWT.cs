using BIMFall4.Authenticator;
using BIMFall4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Net.Http;
using System.Web.Http;


namespace BIMFall4.Manager.JWTManager
{
    public class LoginWithJWT
    {
        //TokenManager tokenManager = new TokenManager();


        //public HttpResponseMessage Login(User user)
        //{
        //    User u = new UserRepository().GetUser(user.Email);
        //    //if (u == null)
        //    //    return HttpRequestMessage(HttpStatusCode.NotFound,
        //    //         "The user was not found.");
        //    bool credentials = u.Password.Equals(user.Password);
        //    if (!credentials) return Request.CreateResponse(HttpStatusCode.Forbidden,
        //        "The username/password combination was wrong.");
        //    return Request.CreateResponse(HttpStatusCode.OK,
        //         tokenManager.GenerateToken(user.Email));
        //}


        //[HttpGet]
        //public HttpResponseMessage Validate(string token, string username)
        //{
        //    bool exists = new UserRepository().GetUser(username) != null;
        //    if (!exists) return Request.CreateResponse(HttpStatusCode.NotFound,
        //         "The user was not found.");
        //    string tokenUsername = TokenManager.ValidateToken(token);
        //    if (username.Equals(tokenUsername))
        //        return Request.CreateResponse(HttpStatusCode.OK);
        //    return Request.CreateResponse(HttpStatusCode.BadRequest);
        //}
    }
}