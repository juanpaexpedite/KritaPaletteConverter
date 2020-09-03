using KritaPaletteReader.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using static KritaPaletteReader.Managers.ErrorsManager;

namespace KritaPaletteReader.Managers
{
    public class ColorsManager
    {
        public static void Process(string input, string output)
        {
            ColorSet kritapal = Read(input);

            PaletteFileManager.SavePalette(kritapal, output);
        }

        private static ColorSet Read(string filepath)
        {
            try
            {
                //Does not implement IDisposable in 2020.
                XmlSerializer serializer = new XmlSerializer(typeof(ColorSet));

                using (var reader = new StreamReader(filepath))
                {
                    return (ColorSet)serializer.Deserialize(reader);
                }
            }
            catch (FileNotFoundException)
            {
                HandleError<ColorsManager>(nameof(Read),ErrorModes.FileError);
            }
            catch
            {
                HandleError<ColorsManager>(nameof(Read),ErrorModes.Generic);
            }

            return null;
        }
    }
}
