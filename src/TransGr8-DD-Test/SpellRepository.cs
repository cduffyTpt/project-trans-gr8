using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransGr8_DD_Test.Interface;

namespace TransGr8_DD_Test
{
    public class SpellRepository : ISpellRepository
    {
        private readonly List<Spell> _spellList;

        public SpellRepository()
        {
            _spellList = new List<Spell>();
        }

        public Spell GetSpellByName(string name)
        {
            return _spellList.FirstOrDefault(s => s.Name == name);
        }

        public void AddSpell(Spell spell)
        {
            _spellList.Add(spell);
        }

        public void UpdateSpell(Spell spell)
        {
            var index = _spellList.FindIndex(s => s.Name == spell.Name);
            _spellList[index] = spell;
        }

        public void RemoveSpell(Spell spell)
        {
            _spellList.Remove(spell);
        }

        public List<Spell> GetAllSpells()
        {
            return _spellList.ToList();
        }
    }
}
