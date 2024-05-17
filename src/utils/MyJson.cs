using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TransportOptimizer.src.utils
{
    public static class MyJson
    {
        public static void Write<T>(string path, T t, string start = "", string end = "", bool serialize = true)
        {
            try
            {
                switch (serialize)
                {
                    case true:
                        File.AppendAllText(path, start + System.Text.Json.JsonSerializer.Serialize(t) + end); 
                        break;

                    case false:
                        File.AppendAllText(path, start + t.ToString() + end); 
                        break;
                }
            }
            catch (FileNotFoundException) { System.Windows.Forms.MessageBox.Show(Const.PACKAGE_NOT_FOUND_MSG); }
            catch (ArgumentException e) { HandleE(e); }
            catch (PathTooLongException e) { HandleE(e); }
            catch (DirectoryNotFoundException e) { HandleE(e); }
            catch (IOException e) { HandleE(e); }
            catch (NotSupportedException e) { HandleE(e); }
            catch (UnauthorizedAccessException e) { HandleE(e); }
        }

        public static void Write<T>(string path, List<T> list)
        {
            Clear(path);
            list.ForEach(obj => Write(path, obj, string.Empty, string.Empty));
        }

        public static void Write<T>(string path, T[] array)
        {
            Write(path, list: array.ToList());
        }

        public static void Clear(string path)
        {
            try
            {
                File.WriteAllText(path, string.Empty);
            }
            catch (ArgumentException e) { HandleE(e); }
            catch (PathTooLongException e) { HandleE(e); }
            catch (DirectoryNotFoundException e) { HandleE(e); }
            catch (IOException e) { HandleE(e); }
            catch (NotSupportedException e) { HandleE(e); }
            catch (UnauthorizedAccessException e) { HandleE(e); }
        }

        private static void HandleE(Exception e)
        {
            Console.WriteLine(e);
            //...
        }
    }
}
