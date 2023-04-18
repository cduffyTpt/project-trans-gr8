using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TransGr8_DD_Test.Rules.CanUserCastSpellEngine;

namespace TransGr8_DD_Test.Interfaces
{
    internal interface ISpellNameRule
    {
        public bool UserCanCastSpell(User user, Spell spell);
        public RulesOrder Type { get; }
    }
}
