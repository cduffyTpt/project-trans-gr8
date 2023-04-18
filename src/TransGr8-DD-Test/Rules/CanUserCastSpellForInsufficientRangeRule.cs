using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransGr8_DD_Test.Interfaces;

namespace TransGr8_DD_Test.Rules
{
    internal class CanUserCastSpellForInsufficientRangeRule : ISpellNameRule
    {
        public CanUserCastSpellEngine.RulesOrder Type => CanUserCastSpellEngine.RulesOrder.CanUserCastSpellForInsufficientRange;

        public bool UserCanCastSpell(User user, Spell spell)
        {
            if (user.Range < spell.Range)
            {
                return false;
            }
            return true;
        }
    }
}
