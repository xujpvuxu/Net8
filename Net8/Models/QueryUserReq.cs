namespace Net8.Models
{
    public class QueryUserReq
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 最小年齡
        /// </summary>
        public int? MinAge { get; set; }

        /// <summary>
        /// 最大年齡
        /// </summary>
        public int? MaxnAge { get; set; }

        /// <summary>
        /// 性別(0:女、1:男)
        /// </summary>
        public bool? Gender { get; set; }
    }
}