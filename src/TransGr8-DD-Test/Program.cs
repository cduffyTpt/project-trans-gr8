using Newtonsoft.Json;
using Serilog;

namespace TransGr8_DD_Test
{
	public class Program
	{
		static void Main(string[] args)
		{
            // Load the users from the JSON file.
            List<User> users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText("Users.json"));

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
				.WriteTo.Console()
                .CreateLogger();

            // Create a list of spells
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

			
			string spellName = "Cure Wounds"; //args[0];

            // Use the spell checker to determine if the user can cast the spell.
            SpellChecker spellChecker = new SpellChecker(spells);

            // Prompt the user to select a user to check the spell for.
            Console.WriteLine("Please enter the user's name to check the spell for: ");
			string userName = Console.ReadLine().ToString().ToLower();

            foreach (User user in users)
            {
				if(!String.IsNullOrWhiteSpace(userName) && user.Name.ToLower() == userName)
				{
                    bool canCast = spellChecker.CanUserCastSpell(user, spellName);
                    Log.Information("{0} - Can the user cast {1}? {2}", user.Name, spellName, canCast);
                }
            }

            

            // Clean up Serilog
            Log.CloseAndFlush();

            Console.ReadKey();
		}
	}
}