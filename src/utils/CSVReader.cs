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
        /// <summary>
        /// Reads and parses a CSV file, returning the data as a list of string arrays.
        /// The file can use either a comma (',') or a semicolon (';') as the delimiter. 
        /// If the data is invalid or the delimiter cannot be identified, the method returns null.
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns>
        /// A list of string arrays where each array represents a row from the CSV file. 
        /// Returns null if the delimiter is invalid or if the data fails validation.
        /// </returns>
        public static List<string[]> Parse(string filepath)
        {
            int rowCount = 0;
            int columnCount = 0;

            List<string[]> rowsData = new List<string[]>();

            string[] lines = File.ReadAllLines(filepath);

            // Controlla la prima riga per identificare il separatore
            char separator = IdentifySeparator(lines[0]);
            if (separator == '0')
            {
                return null;
            }

            using (StreamReader sr = new StreamReader(filepath))
            {
                while (!sr.EndOfStream)
                {
                    string[] rowValues = sr.ReadLine().Split(separator);
                    
                    rowsData.Add(rowValues);

                    rowCount++;

                    if (rowCount == 1)
                    {
                        columnCount = rowValues.Length; 
                    }
                }
            }

            if (ValidateData(rowsData))
                return rowsData;
            else
                return null;
        }

        /// <summary>
        /// Validate the parsed data from the CSV file
        /// </summary>
        /// <param name="rowsData"></param>
        /// <returns></returns>
        private static bool ValidateData(List<string[]> rowsData)
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

        static char IdentifySeparator(string headerLine)
        {
            int commaCount = headerLine.Count(c => c == ',');
            int semicolonCount = headerLine.Count(c => c == ';');

            if (commaCount > semicolonCount)
            {
                return ',';
            }
            else if (semicolonCount > commaCount)
            {
                return ';';
            }
            else
            {
                return '0';
            }
        }
    }
}
