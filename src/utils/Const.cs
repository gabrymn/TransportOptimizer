﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportOptimizer.src.utils
{
    internal static class Const
    {
        public static readonly string[] TERMS = ["UP", "D", "Min", "Max"];
        public static readonly string[] METHODS = ["Northwest", "Leastcost", "Vogel", "Russell"];
        public static readonly int DEFAULT_TABLE_ROWS = 15;
        public static readonly int DEFAULT_TABLE_COLUMNS = 15;

        public static readonly int MS_INTERVAL = 1;

        public static readonly string CELLS_FONT_NAME = "Seguo UI Bold";
        public static readonly int CELLS_FONT_SIZE = 14;

        public static readonly int CELLS_WIDTH = 140;
        public static readonly int CELLS_HEIGHT = 60;

        public static readonly FontStyle FONT_STYLE_STD = FontStyle.Regular;
        public static readonly FontStyle FONT_STYLE_LAST = FontStyle.Bold;

        public static readonly string ATTR_PRICE_NAME = "Price";
        public static readonly string ATTR_TOTAL_NAME = "Total";
        public static readonly string ATTR_QNT_NAME = "Quantity";
        public static readonly string ATTR_SECONDS_NAME = "seconds";
        public static readonly string ATTR_UNIT_PROD = "UP";
        public static readonly string ATTR_DEST = "D";

        public static readonly string INPUT_FILE_EXT = "csv";
        public static readonly string INPUT_FILE_MSG = "Select a CSV file";
        public static readonly string INPUT_FILE_EXT_FILTER = "\"CSV files (*.csv)|*.csv";

        public static readonly string OUTPUT_FILE_EXT = "json";
        public static readonly string OUTPUT_FILE_EXT_FILTER = "JSON file|*.json";

        public static readonly string IMPORT_ERROR_DATA_MSG = "Could not import data because the table is not empty";
        public static readonly string IMPORT_ERROR_UNKNOWN_MSG = "Could not import the file";
        public static readonly string IMPORT_ERROR_FILE_MSG = "Could not import the file, invalid file syntax";

        public static readonly string WRONG_EXT_ERROR_MSG = "Could not create the file, only JSON files allowed, remove the extension to continue";
        public static readonly string PACKAGE_NOT_FOUND_MSG = "Could not find the JSON package, check file path and try again";
        public static readonly string LOST_DATA_MSG = "Due to an unknown error the data was lost";
        public static readonly string INCONSISTENT_DATA_MSG = "INCONSISTENT DATA ERROR \n\nThe sum of the values in the last row and the right-most column must be equal and match the value in the bottom-right cell";
        public static readonly string ALL_CELLS_REQ_MSG = "Execution of this function requires that all cells are filled in";
    }
}
