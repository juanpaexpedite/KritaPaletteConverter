using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KritaPaletteReader.Models
{
    [Serializable]
    public class ColorSetEntry
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("RGB")]
        public RGBEntry RGB { get; set; }

        [XmlElement("Position")]
        public PositionEntry Position { get; set; }
    }
}
