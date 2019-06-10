using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практика2
{
    public class Program
    {
        static void Main(string[] args)
        {
            StreamReader f = new StreamReader("INPUT.TXT");
            string s = f.ReadToEnd();
            f.Close();
            int[] arr = s.Split(' ').Select(m => int.Parse(m)).ToArray();
            int n = arr[0];
            int k = arr[1];
            int pow10 = 1;
            while (pow10 * 10 <= k) pow10 *= 10;
            int origK = k;
            int origPow10 = pow10;
            int pos = 0;
            while (pow10 >= 1)
            {
                pos += (k - pow10 + 1);
                pow10 /= 10;
                k /= 10;
            }
            k = origK;
            pow10 = origPow10;
            if (k != pow10)
            {
                while (true)
                {
                    pow10 *= 10;
                    if (pow10 > n) break;
                    k *= 10;
                    if (k >= n)
                    {
                        pos += (n - pow10 + 1);
                        break;
                    }
                    else pos += (k - pow10);
                }
            }
            StreamWriter d = new StreamWriter("OUTPUT.TXT");
            d.WriteLine(pos);
            d.Close();
        }
    }
}
