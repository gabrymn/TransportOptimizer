using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportOptimizer.src.utils
{
    public static class CollectionExtensions
    {
        private static Random rd = new Random();

        /// <summary>
        /// Populate 'array' with random numbers whose sum is 'x'
        /// </summary>
        /// <param name="array"></param>
        /// <param name="x"></param>
        public static void Randomize(this int[] array, int x)
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
                        k = rd.Next((int)(0.30 * m[i]), (int)((0.70 * m[i]) + 1));
                        array[i] = m[i] + k;
                    }
                    else
                        array[i] = m[i] - k;
                    // The value of "k" is computed in the previous cycle of the loop.
                }
            }

            array.Shuffle();
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;

            while (n > 1)
            {
                n--;
                int k = rd.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static List<int> GroupValue(this int[] array, int value)
        {
            var list = new List<int>();

            for (int i = 0; i < array.Length; i++)
                if (array[i] == value)
                    list.Add(i);

            return list;
        }
    }
}
