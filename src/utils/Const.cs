using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportOptimizer.src.utils
{
    internal static class Const
    {
        public static readonly string[] Terms = new string[] { "UP", "D", "MIN", "MAX" };
        public static readonly string[] Methods = new string[] { "Nord-Ovest", "Minimi-Costi", "Vogel", "Russell" };
        public static readonly int MinMsTimeout = 1;
        public static readonly int MaxMsTimeout = 1;
        public static readonly int MedMsTimeout = (MaxMsTimeout + MinMsTimeout) / 2;
        //public static readonly Color CustomRed = Color.FromArgb(255, 0, 86);

        public static class FONT
        {
            public static readonly string Cells = "Tw Cen MT";
            public static readonly int CellsSize = 14;
            public static readonly FontStyle StdForm = FontStyle.Regular;
            public static readonly FontStyle LastForm = FontStyle.Bold;
        }
    }
}
