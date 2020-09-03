using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KritaPaletteReader.Models
{
    [Serializable]
    public class PositionEntry
    {
        [XmlAttribute("column")]
        public int Column { get; set; }

        [XmlAttribute("row")]
        public int Row { get; set; }
    }
}
