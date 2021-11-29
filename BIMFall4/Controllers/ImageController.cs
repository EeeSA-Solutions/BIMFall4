using BIMFall4.Authenticator;
using BIMFall4.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using BIMFall4.Manager.Repeat;
using BIMFall4.Models;

namespace BIMFall4.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ImageController : ApiController
    {
        // GET: Image
        TokenManager tokenManager = new TokenManager();
        ImageManager imageManager = new ImageManager();

        // GET: api/Expense/5
        public ImageDTO Get(string date)
        {
            string userid = tokenManager.ValidateToken(Request);
            if (userid != null)
            {
                return imageManager.GetPictureByUserIdDTO(Convert.ToInt32(userid));
            }
            else
            {
                return null;
            }
        }

        public void Post([FromBody] Image image )
        {
            string userid = tokenManager.ValidateToken(Request);
            if (userid != null)
            {
                 imageManager.CreateImage(image);
            }
            else
            {
                 return;
            }
        }
    }
}