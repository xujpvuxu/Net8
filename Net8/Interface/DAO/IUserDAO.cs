using Net8.Models;
using Net8.Models.DB;

namespace Net8.Interface.DAO
{
    public interface IUserDAO
    {
        Task DeleteUser(string email);
        Task<List<UserGroupRes>> GetGroup();
        Task<List<User>> GetUser(QueryUserReq user, int page);
        Task<User> GetUserNameWithMosic(string email);
        Task Insert(UserReq userReq);
        Task UpadateAge(string email, int updateAge);
    }
}