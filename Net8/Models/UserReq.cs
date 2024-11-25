using System.ComponentModel.DataAnnotations;

namespace Net8.Models
{
    public class UserReq
    {
        /// <summary>
        /// 信箱
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// 密碼
        /// </summary>
        /// [Required]
        [StringLength(100, MinimumLength = 6)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$", ErrorMessage = "密碼必須至少包含一個字母和一個數字，且長度不少於6位")]
        public string Password { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 年齡
        /// </summary>
        public int? Age { get; set; }

        /// <summary>
        /// 性別(0:女、1:男)
        /// </summary>
        [Required]
        public bool Gender { get; set; }

        /// <summary>
        /// 省份
        /// </summary>
        [Required]
        public string Region { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }
    }
}