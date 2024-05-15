using System;
using System.Linq;
using System.Windows.Forms;

namespace TransportOptimizer.src.utils
{
    public static class Utils
    {
        public static bool IsN(string str)
        {
            return int.TryParse(str, out _);
        }

        public static bool LessT1(string n)
        {
            if (int.TryParse(n, out _))
            {
                int value = int.Parse(n);
                return value < 1;
            }
            return false;
        }

        public static string RemoveChar(string str)
        {
            string s = string.Empty;
            for (int i = 0; i < str.Length; i++)
            {
                if (i == 0 && str[0] == '0') continue;
                if (IsN(str[i].ToString())) s += str[i].ToString();
            }

            return s;
        }

        public static void ValidateTextBox(TextBox tb)
        {
            if (tb.Text == "0" || (!IsN(tb.Text) && !tb.Text.Equals(string.Empty)))
            {
                tb.Text = RemoveChar(tb.Text);
                int len = tb.Text.Length;
                tb.Select(len, len);
            }
        }

        public static bool SkipCheck(string s1, string s2, string[] array)
        {
            return array.Contains(s1) || array.Contains(s2);
        }
    }
}
