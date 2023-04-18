using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransGr8_DD_Test.Interfaces;

namespace TransGr8_DD_Test.Rules
{
    internal class CanUserCastSpellForMissingVerbalComponentRule : ISpellNameRule
    {
        public CanUserCastSpellEngine.RulesOrder Type => CanUserCastSpellEngine.RulesOrder.CanUserCastSpellForMissingVerbalComponentRule;

        public bool UserCanCastSpell(User user, Spell spell)
        {

            if (spell.Components.Contains("V"))
            {
                if (!user.HasVerbalComponent)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
