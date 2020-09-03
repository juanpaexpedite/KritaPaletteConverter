using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KritaPaletteReader.Models
{
    [Serializable]
    public class RGBEntry
    {
        [XmlAttribute("r")]
        public double R { get; set; }

        [XmlAttribute("g")]
        public double G { get; set; }

        [XmlAttribute("b")]
        public double B { get; set; }
    }
}
