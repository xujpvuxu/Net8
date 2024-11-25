using Net8.Interface.Service;
using System.Text.RegularExpressions;

namespace Net8.Helper
{
    public class StringHelper : IStringHelper
    {
        public string MosaicName(string sourceName)
        {
            if (string.IsNullOrEmpty(sourceName) || sourceName.Length < 2)
            {
                return sourceName;
            }

            // 將名字的第二個字替換成 *
            return $"{sourceName[0]}*{sourceName.Substring(2)}";
        }

        public bool IsEnglish(string text)
        {
            return Regex.IsMatch(text, "[a-zA-Z]");
        }
    }
}