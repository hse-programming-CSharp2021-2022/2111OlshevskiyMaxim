namespace Seminar01c
{
    class Library
    {
        public delegate string ConvertRule(string str);

        public class Converter
        {
            public string Convert(string str, ConvertRule cr) => cr(str);
        }
    }
}
