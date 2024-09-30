using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransportOptimizer.src.model;

namespace TransportOptimizer.src.utils
{
    public abstract class CSVReader
    {
        public static List<string[]> Parse(string filepath)
        {
            int rowCount = 0;
            int columnCount = 0;
            int lastRowLen = 0;

            List<string[]> rowsData = new List<string[]>();

            using (StreamReader sr = new StreamReader(filepath))
            {
                while (!sr.EndOfStream)
                {
                    string[] rowValues = sr.ReadLine().Split(',');
                    
                    lastRowLen = rowValues.Length;

                    rowsData.Add(rowValues);

                    rowCount++;

                    if (rowCount == 1)
                    {
                        columnCount = rowValues.Length; 
                    }
                }
            }

            if (DataIsValid(rowsData))
                return rowsData;
            else
                return null;
        }

        private static bool DataIsValid(List<string[]> rowsData)
        {
            int i = 0;
            int j = 0;
            int temp = 0;

            for (i=0; i<rowsData.Count; i++)
            {
                for (j=0;  j<rowsData[i].Length; j++)
                {
                    if (rowsData[i][j].ToString().IsInteger() == false)
                        return false;
                }

                // check that every row has got the same amount of cells 
                if (i > 0)
                {
                    if (temp != j)
                        return false;
                }

                temp = j;
            }

            if (i < 2 || j < 2)
            {
                return false;
            }

            return true;
        }
    }
}
