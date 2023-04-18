using Serilog;
using TransGr8_DD_Test.Rules;

namespace TransGr8_DD_Test
{
    public class SpellChecker
    {
        private readonly List<Spell> _spellList;

        public SpellChecker(List<Spell> spells)
        {
            _spellList = spells;
        }

        public bool CanUserCastSpell(User user, string spellName)
        {
            Spell spell = _spellList.Find(s => s.Name == spellName);
            CanUserCastSpellEngine canUserCastSpellEngine = new CanUserCastSpellEngine();
            return canUserCastSpellEngine.Evaluate(user, spell);
        }

    }
}
