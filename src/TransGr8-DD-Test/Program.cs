using Newtonsoft.Json;
using Serilog;
using TransGr8_DD_Test.Interface;

namespace TransGr8_DD_Test
{
	public class Program
	{
		static void Main(string[] args)
		{
			//Code to import users from json
            //List<User> users;
            //string jsonFilePath = ".\\usersmocked.json";
            //using (StreamReader r = new StreamReader(jsonFilePath))
            //{
            //    string json = r.ReadToEnd();
            //    users = JsonConvert.DeserializeObject<List<User>>(json);
            //}
            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
            // Create a user with some attributes.
            ISpellRepository spellRepository = new SpellRepository();
            spellRepository.AddSpell(new Spell
			{
				Name = "Fireball",
				Level = 3,
				CastingTime = "1 action",
				Components = "V, S, M (a tiny ball of bat guano and sulfur)",
				Range = 150,
				Duration = "Instantaneous",
				SavingThrow = "Dexterity"
			});
			spellRepository.AddSpell(new Spell
			{
				Name = "Magic Missile",
				Level = 1,
				CastingTime = "1 action",
				Components = "V, S",
				Range = 120,
				Duration = "Instantaneous",
				SavingThrow = ""
			});
			spellRepository.AddSpell(new Spell
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
				HasSomaticComponent = true,
				HasMaterialComponent = true,
				Range = 200,
				HasConcentration = true
			};

			string spellName = "Cure Wounds";
			// Use the spell checker to determine if the user can cast the spell.
			SpellChecker spellChecker = new SpellChecker(spellRepository);
			bool canCast = spellChecker.CanUserCastSpell(user, spellName);

			// Output the result.
			Log.Information("Can the user cast {0}? {1}", spellName, canCast);
			Console.ReadKey();
		}
	}
}