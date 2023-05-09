using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransGr8_DD_Test.Interfaces;

namespace TransGr8_DD_Test.Components
{
    public class MaterialComponent : IComponent
    {
        private string _name = "Material";
        private string _description = "a tiny ball of bat guano and sulfur";

        public string Name
        {
            get
            {

                return _name;

            }
            set
            {
                _name = value;
            }
        }


        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

    }
}
