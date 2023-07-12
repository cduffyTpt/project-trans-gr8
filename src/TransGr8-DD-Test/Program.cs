using System.Text.Json;
using Serilog;

namespace TransGr8_DD_Test
{
	public class Program
	{
		static void Main(string[] args)
		{
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

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

			//load users 
			var jsonText = File.ReadAllText("users.json");

            var users = JsonSerializer.Deserialize<List<User>>(jsonText);

			// Select a user with some attributes.
			User user = users[0];

            string spellName = args[0];
			// Use the spell checker to determine if the user can cast the spell.
			SpellChecker spellChecker = new SpellChecker(spells);
			bool canCast = spellChecker.CanUserCastSpell(user, spellName);

			// Output the result.
			Log.Information("Can the user cast {0}? {1}", spellName, canCast);
			Console.ReadKey();
		}
	}
}