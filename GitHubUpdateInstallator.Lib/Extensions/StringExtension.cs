namespace GitHubUpdateInstallator.Lib.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="url"></param>
        /// <returns>-1 if not found sub string</returns>
        public static int StartIndexOf(this string str, string subStr) // я не знаю, зачем, но сделал это
        {
            int index = -1;

            string? currentCut = null;

            for (var i = 0; i < str.Length; i++)
            {
                var symbol = str[i];

                if (currentCut == null)
                {
                    var subStrFirstSymbol = subStr[0];

                    if (symbol == subStrFirstSymbol)
                        currentCut = subStrFirstSymbol.ToString();
                }
                else
                {
                    if (currentCut.Length == subStr.Length)
                        return i - subStr.Length;

                    var currentStartSymbol = subStr[currentCut.Length];

                    if (symbol == currentStartSymbol)
                        currentCut += currentStartSymbol;
                    else
                        currentCut = null;
                }
            }

            return index;
        }
    }
}
