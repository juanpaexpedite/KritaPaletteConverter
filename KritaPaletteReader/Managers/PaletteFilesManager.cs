using KritaPaletteReader.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace KritaPaletteReader.Managers
{
    public class PaletteFileManager
    {
        public static void SavePalette(ColorSet set, string outputfile)
        {
            var file_ext = outputfile.Split('.');
            var filename = file_ext[0];
            var extension = file_ext[1];

            if(extension == "gpl")
            {
               var content = CreatePerfectPalettePal(set.Colors, set.Columns, set.Rows);
                File.WriteAllText(outputfile, content);
            }
            
        }

        private static string CreateFastPalettePal(ColorSetEntry[] colors)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("JASC-PAL");

            builder.AppendLine("0100");

            builder.AppendLine($"{colors.Length}");
            foreach (var color in colors)
            {
                builder.AppendLine($"{ToInt(color.RGB.R)} {ToInt(color.RGB.G)} {ToInt(color.RGB.B)}");
            }
            builder.AppendLine();

            return builder.ToString();
        }

        public static string CreatePerfectPalettePal(ColorSetEntry[] colors, int w, int h)
        {
            StringBuilder builder = new StringBuilder();

            var date = DateTime.Now;
            builder.AppendLine("GIMP Palette");
            builder.AppendLine("Channels: RGBA");
            builder.AppendLine($"Name: DoughHUE {date.Day}{date.Month}{date.Year}");
            builder.AppendLine($"Columns: {w}");
            builder.AppendLine("# Created with DOUGHUE, download it from https://mareinsula.itch.io/doughhue");

            int r, g, b = 0;

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    var color = colors.FirstOrDefault(c => c.Position.Column == x && c.Position.Row == y);

                    if (color != null)
                    {
                        r = ToInt(color.RGB.R);
                        g = ToInt(color.RGB.G);
                        b = ToInt(color.RGB.B);

                        builder.AppendLine($"{r}\t{g}\t{b}\t255\t#{color.Name}");
                    }
                    else
                    {
                        builder.AppendLine($"0\t0\t0\t0\t#0000");
                    }
                }
            }

            return builder.ToString();
        }

        private static int ToInt(double input)
        {
            double max = 255.0;

            return (int)Math.Round(max * input,0);
        }
    }
}
