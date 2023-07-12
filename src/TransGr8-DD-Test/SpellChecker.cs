using TransGr8_DD_Test.Rules;

namespace TransGr8_DD_Test
{
    public class SpellChecker
    {
        private readonly List<Spell> _spellList;
        private readonly IEnumerable<ISpellRule> _rules;

        public SpellChecker(List<Spell> spells)
        {
            _spellList = spells;
            _rules = GetRules();
        }

        public bool CanUserCastSpell(User user, string spellName)
        {
            Spell spell = _spellList.Find(s => s.Name == spellName);

            if (spell is null)
            {
                return false;
            }

            foreach (var rule in _rules)
            {
                if (!rule.Satisfy(user, spell))
                {
                    return false;
                }
            }

            return true;
        }

        private IEnumerable<ISpellRule> GetRules()
        {
            var ruleType = typeof(ISpellRule);

            IEnumerable<ISpellRule> output = GetType().Assembly.GetTypes()
                 .Where(p => ruleType.IsAssignableFrom(p) && !p.IsInterface)
                 .Select(r => Activator.CreateInstance(r) as ISpellRule)
                 .OrderBy(x => x.Ordinal);

            return output;
        }
    }
}
