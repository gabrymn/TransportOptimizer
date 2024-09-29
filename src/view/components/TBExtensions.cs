using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportOptimizer.src.utils;

namespace TransportOptimizer.src.view.components
{
    public static class TBExtensions
    {
        public static void ValidateText(this TextBox tb)
        {
            bool is_int = tb.Text.IsInteger();

            if (is_int)
            {
                int num = int.Parse(tb.Text);

                if (num <= 0)
                    tb.Text = string.Empty;

                return;
            }

            if (is_int == false && tb.Text.Equals(string.Empty) == false)
            {
                tb.Text = tb.Text.ExtractDigits();
                int len = tb.Text.Length;
                tb.Select(len, len);
            }
        }
    }
}
