using System;
using System.Collections.Generic;
using System.Text;

namespace KritaPaletteReader.Managers
{
    public class ErrorsManager
    {
        public static void HandleError<T>(string method, ErrorModes mode)
        {
            string error = $"There was an error: Instance {typeof(T)}, method {method}:";
            switch (mode)
            {
                case ErrorModes.FileError:
                    error = $"{error} File path not found";
                    break;
                case ErrorModes.Parameters:
                    error = "\r\n#1.- Extract the .kpl file (It is a zip file)\r\n#2.- Export example: kritapalconvert -i colorset.xml -o output.gpl";
                    break;
                case ErrorModes.Generic:
                    error = $"{error} Not contempled error";
                    break;
                default:
                    break;
            }
            Console.WriteLine(error);
        }
    }

    public enum ErrorModes
    {
        FileError,
        Parameters,
        Generic
    }
}
