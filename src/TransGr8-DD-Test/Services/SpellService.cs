using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TransGr8_DD_Test.Services
{
    internal class SpellService
    {
        public static List<Spell> GetSpells()
        {
            var spells = new List<Spell>();
            spells.Add(new Spell
            {
                Name = "Fireball",
                Level = 3,
                CastingTime = "1 action",
                Components = "V, S, M (a tiny ball of bat guano and sulfur)",
                Range = 150,
                Duration = "Instantaneous",
                SavingThrow = "Dexterity"
            });
            spells.Add(new Spell
            {
                Name = "Magic Missile",
                Level = 1,
                CastingTime = "1 action",
                Components = "V, S",
                Range = 120,
                Duration = "Instantaneous",
                SavingThrow = ""
            });
            spells.Add(new Spell
            {
                Name = "Cure Wounds",
                Level = 1,
                CastingTime = "1 action",
                Components = "V, S",
                Range = 1,
                Duration = "Instantaneous",
                SavingThrow = ""
            });
            spells.Add(new Spell
            {
                Name = "Identify",
                Level = 1,
                CastingTime = "1 action",
                Components = "I, M",
                Range = 1,
                Duration = "Instantaneous",
                SavingThrow = ""
            }); 
            spells.Add(new Spell
            {
                Name = "Command",
                Level = 1,
                CastingTime = "1 action",
                Components = "V",
                Range = 1,
                Duration = "Instantaneous",
                SavingThrow = ""
            });
            spells.Add(new Spell
            {
                Name = "Hold Person",
                Level = 1,
                CastingTime = "1 action",
                Components = "V",
                Range = 1,
                Duration = "Concentration",
                SavingThrow = ""
            });
            return spells;
        }
    }
}
