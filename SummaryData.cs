using System;
using System.Collections.Generic;
using System.Text;

namespace RicercaOperativa
{
    public class SummaryData
    {
        string id;
        int quantity;
        string fromTo;
        int price;

        public string ID { get => id; set => id = value; }
        public int Quantity { get => quantity; set => quantity = Math.Abs(value); }
        public string FromTo { get => fromTo; set => fromTo = value; }
        public int Price { get => price; set => price = Math.Abs(value); }

        public SummaryData(string id, int quantity, string fromTo, int price) 
        {
            this.id = id;
            this.quantity = quantity;
            this.fromTo = fromTo;
            this.price = price;
        }

        public SummaryData()
        {
            id = fromTo = string.Empty;
            quantity = price = 0;
        }

        public static int Sum(SummaryData[] array, string c)
        {
            c = c.ToLower();
            if (c != "quantity" && c != "price") return -1;
            int s = 0;
            switch (c)
            {
                case "quantity":
                    for (int i = 0; i < array.Length; i++) s += array[i].Quantity;
                    break;
                case "price":
                    for (int i = 0; i < array.Length; i++) s += array[i].Price;
                    break;
            }
            return s;
        }

        public static string PriceFormat(long value)
        {
            string str = value.ToString();
            if (str.Length < 4) return str;
            StringBuilder price = new StringBuilder(value.ToString());
            int serie = price.Length - 3;
            int p = price.Length - 1;
            
            do
            {
                if (p == serie && p != 0) {
                    price.Insert(serie, '.');
                    serie = serie - 3;
                }
                p--;
            } while (p > -1);

            return price.ToString();
        }

        public static void SaveArrayToJSON(string path, SummaryData[] array)
        {
            string start = "\t", end = ",\n";
            JSON.Write(path, '[', end: "\n", serialize: false);
            for (int i = 0; i < array.Length; i++)
            {
                if (i == array.Length - 1) end = "\n";
                JSON.Write(path, new { ID = array[i].ID, Quantitativo = array[i].Quantity, Movimento = array[i].FromTo, Prezzo = SummaryData.PriceFormat(array[i].Price) }, start: start, end: end);
            }
            JSON.Write(path, ']', serialize: false);
        }
    }
}
