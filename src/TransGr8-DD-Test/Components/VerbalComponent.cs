using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransGr8_DD_Test.Interfaces;

namespace TransGr8_DD_Test.Component
{
    public class VerbalComponent : IComponent
    {
        private string _name = "Verbal";

        public string Name { 
            get { 
            
                return _name; 
            
            } set { 
                _name= value;
            }  
        }


    }
}
