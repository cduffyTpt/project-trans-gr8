﻿using Newtonsoft.Json;
using Serilog;
using Serilog.Events;

namespace TransGr8_DD_Test
{
	public class Program
	{
		static void Main(string[] args)
		{
			Log.Logger = new LoggerConfiguration()
				.WriteTo.Console()
				.CreateLogger();

			using StreamReader reader = new("../../users.json");
    		var json = reader.ReadToEnd();
			
			if (args == null || args.Length == 0)
			{
				Log.Warning("Please provide a spell name as a command line argument.");
				
			}else{

				// Create a user with some attributes.
				List<Spell> spells = new List<Spell>();
				spells.Add(new Spell
				{
					Name = "Fireball",
					Level = 3,
					CastingTime = "1 action",
					Components = "",
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

				
				string spellName = args[0];
				// Use the spell checker to determine if the user can cast the spell.
				SpellChecker spellChecker = new SpellChecker(spells);
				
				//Get users from json file
				List<User> users = JsonConvert.DeserializeObject<List<User>>(json);
				foreach(var user in users){
					bool canCast = spellChecker.CanUserCastSpell(user, spellName);
					// Output the result.
					Log.Information("Can {2} cast {0}? {1}", spellName, canCast, user.Name);
				}
				
			}
			Console.ReadKey();
		}
	}
}