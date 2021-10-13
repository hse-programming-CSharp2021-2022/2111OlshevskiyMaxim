using System;
using System.Text;
using static System.Console;

namespace Semki1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Let it be; All you need is love; Dizzy Miss Lizzy";
            string[] sArray = s.Split(' ');
            StringBuilder[] sbArray = new StringBuilder[sArray.Length];
            for (int i = 0; i < sArray.Length; i++)
            {
                sbArray[i] = new StringBuilder();
                int j = 0;
                sbArray[i].Append(char.ToUpper(sArray[i][j]));
                while (!"AEIOUYaeiouy".Contains(sArray[i][j]))
                {
                    sbArray[i].Append(sArray[i][j + 1]);
                    j++;
                }
                WriteLine(sbArray[i]);
            }
        }
    }
}
