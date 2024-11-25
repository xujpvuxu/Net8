using Net8.Models;
using Net8.Models.DB;

namespace Net8.Interface
{
    public interface IUserService
    {
        Task DeleteUser(string email);
        Task<List<UserGroupRes>> GetGroup();
        Task<List<User>> GetUser(QueryUserReq query, int page);
        Task<string> GetUserNameWithMosic(string email);
        Task Insert(UserReq userReq);
        Task UpadateAge(string email, int updateAge);
    }
}