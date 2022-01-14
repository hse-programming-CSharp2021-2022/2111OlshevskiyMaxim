using System.Text;
using static System.Console;

namespace Seminar01c
{
    class Program
    {
        public static string RemoveDigits(string str)
        {
            StringBuilder sb = new(str);
            for (int i = 0; i < sb.Length; i++)
                if (sb[i] >= '0' && sb[i] <= '9')
                    sb.Remove(i--, 1);
            return sb.ToString();
        }

        public static string RemoveSpaces(string str)
        {
            StringBuilder sb = new(str);
            for (int i = 0; i < sb.Length; i++)
                if (sb[i] == ' ')
                    sb.Remove(i--, 1);
            return sb.ToString();
        }

        static void Main(string[] args)
        {
            string[] strings = new string[] { "1abc def3", "abcd123 a" };
            Library.ConvertRule rule = RemoveDigits;
            rule += RemoveSpaces;
            foreach (Library.ConvertRule r in rule.GetInvocationList())
                WriteLine($"{r?.Invoke(strings[0])}\n{r?.Invoke(strings[1])}\n");
            string s = strings[0];
            foreach (Library.ConvertRule r in rule.GetInvocationList())
            {
                s = r?.Invoke(s);
                WriteLine($"{s}\n");
            }
        }
    }
}
