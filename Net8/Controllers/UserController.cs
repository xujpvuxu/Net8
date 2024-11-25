using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Net8.Models.DB;
using Net8.Interface;
using Net8.Models;

namespace Net8.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;

    private readonly IUserService _userService;

    public UserController(ILogger<UserController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    /// <summary>
    /// 新增資料
    /// </summary>
    /// <param name="userReq"></param>
    /// <returns></returns>
    [HttpPost("")]
    public async Task Insert(UserReq userReq)
    {
        await _userService.Insert(userReq);
    }

    /// <summary>
    /// 查詢資料
    /// </summary>
    /// <param name="user">查詢條件</param>
    /// <param name="page">分頁</param>
    /// <returns></returns>
    [HttpPost("{page}")]
    public async Task<object> GetUser(QueryUserReq user, int page)
    {
        List<User> users = await _userService.GetUser(user, page);
        return users.Select(x => new
        {
            Name = x.Name,
            Age = x.Age,
            Gender = x.Gender,
            Region = x.Region,
            City = x.City
        });
    }

    /// <summary>
    /// 查詢群組result
    /// </summary>
    /// <returns></returns>
    [HttpGet("Group")]
    public async  Task<ActionResult<List<UserGroupRes>>> GetGroup()
    {
        List<UserGroupRes> result = await _userService.GetGroup();
        return Ok(result);
    }

    /// <summary>
    /// 修改使用者資料
    /// </summary>
    /// <param name="email">信箱</param>
    /// <param name="updateAge">修改後的年齡</param>
    /// <returns></returns>
    [HttpPut("")]
    public async Task UpdateAge(string email, int updateAge)
    {
        await _userService.UpadateAge(email, updateAge);
    }

    /// <summary>
    /// 刪除使用者
    /// </summary>
    /// <param name="email">信箱</param>
    /// <returns></returns>
    [HttpDelete("")]
    public async Task DeleteUser(string email)
    {
        await _userService.DeleteUser(email);
    }

    [HttpGet("MosicName")]
    public async Task<string> MosicName(string email)
    {
        return await _userService.GetUserNameWithMosic(email);
    }
}