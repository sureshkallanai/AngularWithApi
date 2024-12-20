﻿using JWTAuth.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace JWTAuth.WebApi.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly DatabaseContext _context;

        public TokenController(IConfiguration config, DatabaseContext context)
        {
            _configuration = config;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Login _userData)
        {
            if (_userData != null && _userData.EmailID != null && _userData.Password != null)
            {
                var user = await GetUser(_userData.EmailID, _userData.Password);

                if (user != null)
                {                  
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserID", user.UserID.ToString()),
                        new Claim("DisplayName", user.UserName),
                        new Claim("UserName", user.UserName),
                        new Claim("Email", user.EmailID)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }
       
        private async Task<Login> GetUser(string email, string password)
        {
            List<Login> Lstlogin = new List<Login>();
            Login user = new Login();
            user.EmailID = "suresh.kk@gmail.com";
            user.Password = "admin@123";
            user.UserID = 1;
            user.UserName = "Suresh Kallanai";
            Lstlogin.Add(user);
            Login user2 = new Login();
            user2.EmailID = "raja.vinayagam@gmail.com";
            user2.Password = "admin@123";
            user2.UserID = 2;
            user2.UserName = "Raja Vinayagam";
            Lstlogin.Add(user2);
            Login user3 = new Login();
            user3.EmailID = "arun.raj@gmail.com";
            user3.Password = "admin@123";
            user3.UserID = 3;
            user3.UserName = "Arun Raj";
            Lstlogin.Add(user3);
            Login Login4 = Lstlogin.Where(u => u.EmailID == email && u.Password == password).FirstOrDefault();
            return Login4;
        }

    }
}
