
using JWTAuth.WebApi.Models;

namespace JWTAuth.WebApi.Interface
{
    public interface IGetUserData
    {
        public Login GetSingleUser(string Email);
    }
}
