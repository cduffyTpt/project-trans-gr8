using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransGr8_DD_Test.Interfaces;

namespace TransGr8_DD_Test.Rules
{
    internal class CanUserCastSpellForMissingSomaticComponentRule : ISpellNameRule
    {
        public CanUserCastSpellEngine.RulesOrder Type => CanUserCastSpellEngine.RulesOrder.CanUserCastSpellForMissingSomaticComponentRule;

        bool ISpellNameRule.UserCanCastSpell(User user, Spell spell)
        {
            if (spell.Components.Contains("S"))
            {
                if (!user.HasSomaticComponent)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
