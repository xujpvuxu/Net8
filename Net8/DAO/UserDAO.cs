using Microsoft.EntityFrameworkCore;
using Net8.Interface.DAO;
using Net8.Models;
using Net8.Models.DB;
using Net8.Util;

namespace Net8.DAO
{
    public class UserDAO : IUserDAO
    {
        private DingContext Context { get; set; }

        public UserDAO(DingContext context)
        {
            Context = context;
        }

        /// <summary>
        /// 塞入資料
        /// </summary>
        /// <param name="userReq"></param>
        /// <returns></returns>
        public async Task Insert(UserReq userReq)
        {
            User user = new User
            {
                Email = userReq.Email,
                Password = userReq.Password,
                Name = userReq.Name,
                Age = userReq.Age,
                Gender = userReq.Gender,
                Region = userReq.Region,
                City = userReq.City,
            };
            Context.Users.Add(user);
            await Context.SaveChangesAsync();
        }

        /// <summary>
        /// 取得資訊
        /// </summary>
        /// <param name="user">查詢內容</param>
        /// <param name="page">分頁</param>
        /// <returns></returns>
        public async Task<List<User>> GetUser(QueryUserReq user, int page)
        {
            IQueryable<User> queryCommand = Context.Users.WhereIf(!string.IsNullOrEmpty(user.Name), x => EF.Functions.Like(x.Name, $"%{user.Name}%"))
                                                   .WhereIf(user.MinAge != null, x => x.Age >= user.MinAge.Value)
                                                   .WhereIf(user.MaxnAge != null, x => x.Age <= user.MaxnAge.Value)
                                                   .WhereIf(user.Gender != null, x => x.Gender == user.Gender.Value);

            return await queryCommand.Skip(page * Constant.PageCount)
                                     .Take(Constant.PageCount)
                                     .AsNoTracking()
                                     .ToListAsync();
        }

        public async Task<List<UserGroupRes>> GetGroup()
        {
            List<UserGroupRes> userSummary = await Context.Users
                                                          .GroupBy(u => new { u.City, u.Gender })
                                                          .Select(
                                                                g => new UserGroupRes
                                                                {
                                                                    City = g.Key.City,
                                                                    Gender = g.Key.Gender,
                                                                    PeopleCount = g.Count()
                                                                })
                                                          .AsNoTracking()
                                                          .ToListAsync();

            return userSummary;
        }

        public async Task UpadateAge(string email, int updateAge)
        {
            User? model = await Context.Users.FindAsync(email);
            if (model is not null)
            {
                model.Age = updateAge;
                await Context.SaveChangesAsync();
            }
        }

        public async Task DeleteUser(string email)
        {
            User? model = await Context.Users.FindAsync(email);
            if (model is not null)
            {
                Context.Users.Remove(model);
                await Context.SaveChangesAsync();
            }
        }

        public async Task<User> GetUserNameWithMosic(string email)
        {
            User? model = await Context.Users   .FindAsync(email);
            if (model is null)
            {
                throw new Exception();
            }
            return model;
        }
    }
}