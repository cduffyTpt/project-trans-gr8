using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransGr8_DD_Test.Component;
using TransGr8_DD_Test.Components;
using TransGr8_DD_Test.Interfaces;

namespace TransGr8_DD_Test.Spells
{
    public class CureWoundsSpell : ISpell
    {

        private string _name = SpellType.cureWounds;
        private string _castingTime = "1 action";
        private string _duration = "Instantaneous";

        private IComponent[] _components =
        {
            new VerbalComponent(),
            new SomaticComponent(),
        };


        private string _savingThrow = "";
        private int _level = 1;
        private int _range = 1;



        public string Name
        {
            get { return _name; }
            set { _name = value; }

        }


        public string CastingTime
        {
            get
            {
                return _castingTime;
            }
            set { _castingTime = value; }

        }

        public string Duration
        {
            get { return _duration; }
            set
            {
                _duration = value;
            }
        }


        public string SavingThrow
        {
            get { return _savingThrow; }
            set
            {
                _savingThrow = value;
            }
        }


        public int Level
        {
            get { return _level; }
            set
            {
                _level = value;
            }
        }


        public IComponent[] Components
        {
            get { return _components; }
            set
            {
                _components = value;
            }
        }
        public int Range
        {
            get { return _range; }
            set
            {
                _range = value;
            }
        }
    }
}
