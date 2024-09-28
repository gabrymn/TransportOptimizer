using System;
using System.Linq;
using System.Windows.Forms;

namespace TransportOptimizer.src.utils
{
    public static class Utils
    {
        private static Random rng = new Random();

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
                if (i == 0 && str[0] == '0') 
                    continue;

                if (IsN(str[i].ToString())) 
                    s += str[i].ToString();
            }

            return s;
        }

        public static void ValidateTextBox(TextBox tb)
        {
            bool is_num = IsN(tb.Text);

            if (is_num)
            {
                int num = int.Parse(tb.Text);

                if (num <= 0)
                    tb.Text = string.Empty;

                return;
            }

            if (is_num == false && tb.Text.Equals(string.Empty) == false)
            {
                tb.Text = RemoveChar(tb.Text);
                int len = tb.Text.Length;
                tb.Select(len, len);
            }
        }

        public static bool SkipCheck(string s1, string s2, string[] array)
        {
            return (array.Contains(s1) || array.Contains(s2));
        }

        public static void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;

            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        /// <summary>
        /// Populate 'array' with random numbers whose sum is 'x'
        /// </summary>
        /// <param name="array"></param>
        /// <param name="x"></param>
        public static void RandomizeArray(int[] array, int x)
        {
            int avg = x / array.Length;

            int[] m = Enumerable.Repeat(avg, array.Length).ToArray();

            while (m.Sum() < x)
                m[m.Length - 1]++;

            // 0 is not a specific value for k, it could be anything, just to init the variable
            int k = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (i == (array.Length - 1))
                {
                    array[i] = 0;
                    array[i] = x - array.Sum();
                }
                else
                {
                    if (i % 2 == 0)
                    {
                        k = rng.Next((int)(0.30 * m[i]), (int)((0.70 * m[i]) + 1));
                        array[i] = m[i] + k;
                    }
                    else
                        array[i] = m[i] - k;
                        // The value of "k" is computed in the previous cycle of the loop.
                }
            }

            Utils.Shuffle(array);
        }

        public static List<int> CountVal(int[] array, int value)
        {
            var list = new List<int>();

            for (int i = 0; i < array.Length; i++)
                if (array[i] == value)
                    list.Add(i);

            return list;
        }

        public static void Swap<T>(ref T v1, ref T v2)
        {
            T t = v2;
            v2 = v1;
            v1 = t;
        }

        /// <summary>
        ///  Equals Ignore Case
        /// </summary>
        public static bool EqualsICase(string str1, string str2)
        {
            if (str1 == null || str2 == null)
                return false;

            bool equals = string.Equals(str1, str2, StringComparison.OrdinalIgnoreCase);
            return equals;
        }
    }
}
