namespace TextMangLib
{
    public class TextManip
    {
        public static bool IsPalin(string text)
        {
            string newText = text.Replace(" ", "").ToLower();
            string reversT = new string(newText.Reverse().ToArray());
            return newText == reversT;
        }
        public static int CountSentences(string text)
        {
            return text.Split('.').Length - 1;
        }
        public static string ReversText(string text)
        {
            char[] cArr = text.ToCharArray();
            Array.Reverse(cArr);
            return new string(cArr);
        }
    }
}