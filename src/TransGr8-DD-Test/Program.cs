using NUnit.Framework.Interfaces;
using Serilog;
using System.Text.Json;

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
			//User user = new User
			//{
			//	Level = 3,
			//	HasVerbalComponent = true,
			//	HasSomaticComponent = true,
			//	HasMaterialComponent = true,
			//	Range = 200,
			//	HasConcentration = true
			//};

			string FilesPath = AppContext.BaseDirectory + "../../../Files/";

            User selected;
            // read the JSON file into a string
            string jsonString = File.ReadAllText(FilesPath + "Users.json");

            // deserialize the JSON string into an object
            List<User> users = JsonSerializer.Deserialize<List<User>>(jsonString);

			//Select the user to check the spell for
            int index;
            do
            {
                Console.Write("Enter the index of the user: ");
            } while (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > users.Count);
			selected = users[index - 1];

            string spellName = args[0];
			// Use the spell checker to determine if the user can cast the spell.
			SpellChecker spellChecker = new SpellChecker(spells);
			bool canCast = spellChecker.CanUserCastSpell(selected, spellName);

            // Output the result.
            //Console.WriteLine("Can the user cast {0}? {1}", spellName, canCast);
            //Console.ReadKey();

            // Output the result with Serilog
            Log.Logger = new LoggerConfiguration()
			.MinimumLevel.Debug()
			.WriteTo.Console()
			.CreateLogger();

            Log.Information("Can the user cast {0}? {1}", spellName, canCast); // log an informational message

            Log.CloseAndFlush(); // flush and close the logger
        }
    }
}