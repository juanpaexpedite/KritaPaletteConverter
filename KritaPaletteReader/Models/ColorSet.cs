using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KritaPaletteReader.Models
{
    [XmlRoot("ColorSet", Namespace = "", IsNullable = false)]
    public class ColorSet
    {

        [XmlElement("ColorSetEntry")] //Odd logic for this but works.
        public ColorSetEntry[] Colors { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("columns")]
        public int Columns { get; set; }

        [XmlAttribute("rows")]
        public int Rows { get; set; }

    }


    
}
