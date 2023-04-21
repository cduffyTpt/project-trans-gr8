using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransGr8_DD_Test.Model
{
    public class User
    {
        public int Level { get; set; }
        public bool HasVerbalComponent { get; set; }
        public bool HasSomaticComponent { get; set; }
        public bool HasMaterialComponent { get; set; }
        public int Range { get; set; }
        public bool HasConcentration { get; set; }
    }
}
