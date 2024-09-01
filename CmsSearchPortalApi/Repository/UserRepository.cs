using JWTAuth.WebApi.Interface;
using JWTAuth.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JWTAuth.WebApi.Repository
{
    public class UserRepository : IGetUserData
    {

        private readonly DatabaseContext _dbContext;

        public UserRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public List<Login> GetIAllUser()
        //{
        //    try
        //    {
        //        return _dbContext.Login.ToList();
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        public Login GetSingleUser(string Email)
        {
            try
            {
                List<Login> Lstlogin = new List<Login>();
                Login user = new Login();
                user.EmailID = "suresh.kk@gmail.com";
                user.Password = "password";
                user.UserID = 1;
                user.UserName = "Suresh Kallanai";
                Lstlogin.Add(user);
                Login user2 = new Login();
                user2.EmailID = "raja.vinayagam@gmail.com";
                user2.Password = "password";
                user2.UserID = 2;
                user2.UserName = "Raja Vinayagam";
                Lstlogin.Add(user2);
                Login user3 = new Login();
                user3.EmailID = "arun.raj@correla.com";
                user3.Password = "password";
                user3.UserID = 3;
                user3.UserName = "Arun Raj";
                Lstlogin.Add(user3);
                //return _dbContext.Login.ToList().Where(x => x.EmailID.Equals(Email)).FirstOrDefault();
                return Lstlogin.ToList().Where(x => x.EmailID.Equals(Email)).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }


    }
}
