using System;
using System.Collections.Generic;
using System.Text;
using TransportOptimizer.src.utils;

namespace TransportOptimizer.src.model
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
            id = string.Empty;
            quantity = 0;
            fromTo = string.Empty;
            price = 0;
        }

        /// <summary>
        /// Converts price attribute from a int to a string (int: 478879 => string: "478.879")
        /// </summary>
        /// <returns></returns>
        public string PriceToString()
        {
            // if this.price has less than 4 digits:
            if (this.price < 1000)
                return this.price.ToString();

            var price_str = new StringBuilder(this.price.ToString());

            int serie = price_str.Length - 3;
            int p = price_str.Length - 1;

            do
            {
                if (p == serie && p != 0)
                {
                    price_str.Insert(serie, '.');
                    serie = serie - 3;
                }

                p--;

            } while (p > -1);

            return price_str.ToString();
        }

        /// <summary>
        ///  Returns the sum of quantity or price in a SummaryData array
        /// </summary>
        /// <param name="array"></param>
        /// <param name="attribute_name"></param>
        /// <returns></returns>
        public static int SumOf(SummaryData[] array, string attribute_name)
        {
            int sum = 0;

            if (Utils.EqualsICase(Const.ATTR_QNT_NAME, attribute_name))
            {
                for (int i = 0; i < array.Length; i++)
                    sum += array[i].Quantity;
            }

            else if (Utils.EqualsICase(Const.ATTR_PRICE_NAME, attribute_name))
            {
                for (int i = 0; i < array.Length; i++)
                    sum += array[i].Price;
            }

            else
                sum = -1;

            return sum;
        }

        /// <summary>
        /// Write an array of SummaryData in a json file 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="path"></param>
        public static void ToJsonFile(SummaryData[] array, string path)
        {
            string start = "\t", end = ",\n";

            MyJson.Write(path, '[', end: "\n", serialize: false);

            for (int i = 0; i < array.Length; i++)
            {
                if (i == array.Length - 1)
                    end = "\n";

                MyJson.Write
                (
                    path,
                    new { 
                        ID = array[i].ID, 
                        Quantity = array[i].Quantity, 
                        Movement = array[i].FromTo, 
                        Price = array[i].PriceToString()
                    }, 
                    start: start, 
                    end: end
                );
            }

            MyJson.Write(path, ']', serialize: false);
        }
    }
}
