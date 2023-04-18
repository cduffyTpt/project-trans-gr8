using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TransGr8_DD_Test.Interfaces;

namespace TransGr8_DD_Test.Rules
{
    internal class CanUserCastSpellEngine
    {
        private readonly IEnumerable<ISpellNameRule> _rules;
        public enum RulesOrder
        {
            CanUserCastSpellForInsufficientLevel,
            CanUserCastSpellForMissingVerbalComponentRule,
            CanUserCastSpellForMissingSomaticComponentRule,
            CanUserCastSpellForMissingMaterialComponentRule,
            CanUserCastSpellForInsufficientRange,
            CanUserCastSpellForMissingConcentration
        }

        public CanUserCastSpellEngine() 
        {
            _rules = GetRules();
        }

        private static IEnumerable< ISpellNameRule> GetRules()
        {
            var type = typeof(ISpellNameRule);
            var rules = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(item => type.IsAssignableFrom(item) && !item.IsInterface)
                .Select(item=>(ISpellNameRule)Activator
                .CreateInstance(item))
                .OrderBy(item => item.Type)
                .ToList();
            return rules;
        }

        public bool Evaluate(User user, Spell spell)
        {
            foreach (var rule in _rules)
            {
                if(!rule.UserCanCastSpell(user, spell))
                    return false;
            }

            return true;
        }
    }
}
