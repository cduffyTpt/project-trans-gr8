using System.Collections.Immutable;

namespace TransGr8_DD_Test
{
    internal interface ISpellRepository
    {
        Spell GetSpell(string spellName);
    }
    internal class SpellRepository : ISpellRepository
    {
		private readonly ImmutableArray<Spell> _spellList;
        public SpellRepository(List<Spell> spellList)
        {
            _spellList = spellList.ToImmutableArray();
        }
        public Spell GetSpell(string spellName)
        {
            return _spellList.FirstOrDefault(spell => String.Equals(spell.Name, spellName)) ?? throw new SpellNotFoundException($"{spellName} Spell is not found");
        }
    }
}
