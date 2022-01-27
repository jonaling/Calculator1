using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Calculator1
{
    public class StackSerial

    {
        StreamWriter sw;
        XmlSerializer serial;
        const string StackSerial_Filename = "@../StackSerialFile.xml";

        public List<StackSerial> StackType {
            get;
            set;
        }

    }
}
