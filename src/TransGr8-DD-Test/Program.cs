namespace TransGr8_DD_Test
{
	public class Program
	{
		static void Main(string[] args)
		{
			// Create a user with some attributes.
			List<Spell> spells = new List<Spell>();
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
            ISpellRepository repo = new InMemorySpellRepository(spells);
            
			SpellChecker spellChecker = new SpellChecker(repo);
            
			bool canCast = spellChecker.CanUserCastSpell(user, spellName);

			// Output the result.
			Console.WriteLine("Can the user cast {0}? {1}", spellName, canCast);
			Console.ReadKey();
		}
	}
}