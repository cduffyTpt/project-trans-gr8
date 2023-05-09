
using Serilog;
using System.IO;
using TransGr8_DD_Test.Interfaces;
using TransGr8_DD_Test.Spells;
using TransGr8_DD_Test.Utilities;


namespace TransGr8_DD_Test
{
	public class Program
	{
		static void Main(string[] args)
		{
            //FOR LOGS PLEASE CHECK THE logs.txt in src/bin 
            Log.Logger = new LoggerConfiguration()
           .MinimumLevel.Verbose()
           .WriteTo.File("logs.txt")
           .CreateLogger();


            JsonReader reader = new JsonReader();
            List<User> users = reader.readJsonFile<List<User>>(@"./users.json");


            for ( int i = 0; i < users.Count ; i++)
            {
                Console.WriteLine("User : {0} \n\t|	Level : {1} \n\t|	Range : {2} \n\t|	HasVerbalComponent : {3} \n\t|	HasSomaticComponent : {4} \n\t|	HasMaterialComponent : {5} \n\t|	HasConcentration : {6} ", i , users[i].Level , users[i].Range, users[i].HasVerbalComponent, users[i].HasSomaticComponent, users[i].HasMaterialComponent, users[i].HasConcentration);

            }
            User user = new User
            {
                Level = 3,
                HasVerbalComponent = true,
                HasSomaticComponent = true,
                HasMaterialComponent = true,
                Range = 2,
                HasConcentration = true
            };

            //PLEASE IGNORE THIS , THIS MUST BE IN ANOTHER CLASS FOR SingleResponsibility Purpose

            bool correctInput = false;
            while (!correctInput)
			{
                Console.WriteLine("PICK A USER  : ");
                ConsoleKeyInfo UserInput = Console.ReadKey();
           

                if (char.IsDigit(UserInput.KeyChar))
                {
                    int val = int.Parse(UserInput.KeyChar.ToString());
                    if (val >= users.Count)
                    {
                        Console.WriteLine("PICK FROM THE LIST ABOVE 0 to {0}",users.Count-1);
                        correctInput = false;
                    }
                    else
                    {
                        correctInput = true;
                        user = users[val];

                        Log.Debug("USER SELECTED IS {0}", val);
                    }
                }
                else
                {
                    Console.WriteLine("PLEASE USE A DIGIT NUMBER");
                    Log.Error("WRONG VALUE ENTERED ");
                    correctInput = false;

                }


            }




            //UNTIL HERE // READ LAST COMMENT  ABOVE


            // Create a user with some attributes.
            List<ISpell> spells = new List<ISpell>();


			spells.Add(new FireballSpell());
            spells.Add(new MagicMissileSpell());
            spells.Add(new CureWoundsSpell());



            

			string spellName = args[0];

			// Use the spell checker to determine if the user can cast the spell.
			SpellChecker spellChecker = new SpellChecker(spells);
			bool canCast = spellChecker.CanUserCastSpell(user, SpellType.cureWounds);

            // Output the result.

            Log.Debug("Can the user cast {0}? : {1}", spellName, canCast);
            Console.WriteLine(" \n\t Can the user cast {0}? \n {1}", spellName, canCast);
			Console.ReadKey();
		}
	}
}