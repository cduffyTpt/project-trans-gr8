using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransGr8_DD_Test.Interfaces;

namespace TransGr8_DD_Test.Rules
{
    internal class CanUserCastSpellForMissingConcentrationRule : ISpellNameRule
    {
        public CanUserCastSpellEngine.RulesOrder Type => CanUserCastSpellEngine.RulesOrder.CanUserCastSpellForMissingConcentration;

        public bool UserCanCastSpell(User user, Spell spell)
        {
            if (spell.Duration.Contains("Concentration"))
            {
                if (!user.HasConcentration)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
