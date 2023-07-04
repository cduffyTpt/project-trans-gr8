namespace TransGr8_DD_Test
{
	public class Program
	{
		static void Main(string[] args)
        {
            // Create a user with some attributes.
            List<Spell> spells = GetSpells();
            spells.Add(new Spell
            {
                Name = "Fireball",
                Level = 3,
                CastingTime = "1 action",
                Components = "R, U (a tiny ball of bat guano and sulfur)",
                Range = 150,
                Duration = "Concentration",
                SavingThrow = "Dexterity"
            });
            spells.Add(new Spell
            {
                Name = "Magic Missile",
                Level = 1,
                CastingTime = "1 action",
                Components = "V, K",
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
                Range = 120,
                Duration = "Instantaneous",
                SavingThrow = ""
            });

            // Create a user with some attributes.
            User user = new User
            {
                Level = 3,
                HasVerbalComponent = true,
                HasSomaticComponent = false,
                HasMaterialComponent = true,
                Range = 200,
                HasConcentration = true
            };

            string spellName = args[0];
            // Use the spell checker to determine if the user can cast the spell.
            SpellChecker spellChecker = new SpellChecker(spells);

            bool canCast = spellChecker.CanUserCastSpell(user, spellName);
            var engine = new EngineRules();
            foreach (Spell spell in spells)
            {
                //Console.WriteLine(spell.Name);
                // Output the result.
                Console.WriteLine("Can the user cast {0}? {1}", spell.Name,engine.run(user, spell));
                Console.ReadKey();
            }
                

        }

        private static List<Spell> GetSpells()
        {
            return new List<Spell>();
        }
    }
}