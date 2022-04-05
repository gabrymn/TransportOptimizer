using System.Drawing;

namespace RicercaOperativa
{
    public static class CONST
    {
        public static readonly string[] Terms = new string[] { "UP", "D", "MIN", "MAX" };
        public static readonly string[] MS = new string[] { "Nord-Ovest", "Minimi-Costi", "Vogel", "Russell" };
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

        public static void ESound()
        {
            System.Media.SystemSounds.Hand.Play();
        }

        public static void Shuffle<T>(System.Collections.Generic.IList<T> list)
        {
            System.Security.Cryptography.RNGCryptoServiceProvider provider = new System.Security.Cryptography.RNGCryptoServiceProvider();
            int n = list.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static void Swap<T>(ref T v1, ref T v2)
        {
            T t = v2;
            v2 = v1;
            v1 = t;
        }

        public static void ShowMsg<T>(T alertMessage)
        {
            System.Windows.Forms.MessageBox.Show(alertMessage.ToString());
        }

        public static System.Collections.Generic.List<int> CountVal(int[] array, int value)
        {
            var list = new System.Collections.Generic.List<int>();
            for (int i=0; i<array.Length; i++)  if (array[i] == value)  list.Add(i);
            return list;
        }
    }
}
