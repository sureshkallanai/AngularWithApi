
using JWTAuth.WebApi.Interface;
using JWTAuth.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JWTAuth.WebApi.Controllers
{
    [Authorize]
  
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IGetUserData _IGetUserData;

        public HomeController(IGetUserData IGetUserData)
        {
            _IGetUserData = IGetUserData;
        }        
       

        [Route("api/GetSingleUser")]
        [HttpGet]
        public async Task<ActionResult<Login>> GetSingleUser(string Email)
        {
            return await Task.FromResult(_IGetUserData.GetSingleUser(Email));
        }

       

    }
}
