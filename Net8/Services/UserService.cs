using Net8.Helper;
using Net8.Interface;
using Net8.Interface.DAO;
using Net8.Models;
using Net8.Models.DB;

namespace Net8.Services
{
    public class UserService : IUserService
    {
        private readonly IUserDAO _userDAO;

        public UserService(IUserDAO userDAO)
        {
            _userDAO = userDAO;
        }

        public async Task Insert(UserReq userReq)
        {
            await _userDAO.Insert(userReq);
        }

        public async Task<List<User>> GetUser(QueryUserReq query, int page)
        {
            return await _userDAO.GetUser(query, page);
        }

        public async Task<List<UserGroupRes>> GetGroup()
        {
            return await _userDAO.GetGroup();
        }

        public async Task UpadateAge(string email, int updateAge)
        {
            await _userDAO.UpadateAge(email, updateAge);
        }

        public async Task DeleteUser(string email)
        {
            await _userDAO.DeleteUser(email);
        }

        public async Task<string> GetUserNameWithMosic(string email)
        {
            User model = await _userDAO.GetUserNameWithMosic(email);
            return new StringHelper().MosaicName(model.Name);
        }
    }
}