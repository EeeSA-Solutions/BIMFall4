using BIMFall4.Authenticator;
using BIMFall4.Manager.CalculateManagers;
using System;
using System.Collections.Generic;
using System.Web.Http;


namespace BIMFall4.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CalculateController : ApiController
    {
         TokenManager tokenManager = new TokenManager();
        // GET: api/Calculate
        [HttpGet]
        public List<List<ProgressCalculations.ProgressDTO>> Get()
        {
            string userid = tokenManager.ValidateToken(Request);
            if (userid != null)
            {
                return ProgressCalculations.Calculate(Convert.ToInt32(userid));
            }
            else
            {
                return null;
            }
        }
    }
}
