using Serilog;
using TransGr8_DD_Test.Models;
using TransGr8_DD_Test.Services;

namespace TransGr8_DD_Test;

public class Program
{
    static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
            .WriteTo.Console()
            .CreateLogger();

        var spells = new List<Spell>
        {
            new Spell
            {
                Name = "Fireball",
                Level = 3,
                CastingTime = "1 action",
                Components = "V, S, M (a tiny ball of bat guano and sulfur)",
                Range = 150,
                Duration = "Instantaneous",
                SavingThrow = "Dexterity"
            },
            new Spell
            {
                Name = "Magic Missile",
                Level = 1,
                CastingTime = "1 action",
                Components = "V, S",
                Range = 120,
                Duration = "Instantaneous",
                SavingThrow = ""
            },
            new Spell
            {
                Name = "Cure Wounds",
                Level = 1,
                CastingTime = "1 action",
                Components = "V, S",
                Range = 1,
                Duration = "Instantaneous",
                SavingThrow = ""
            }
        };

        var spellName = args[0];
        var spellChecker = new SpellChecker(spells);

        Log.Information("Please enter the index of the user to check the Spell for");
        if (!int.TryParse(Console.ReadLine(), out var index))
        {
            Log.Error("Index not valid, You should enter an integer value");
            return;
        }

        var user = UserData.GetUserByIndex(index);
        if (user is null)
        {
            Log.Warning("User was not found or index is out of range");
            return;
        }

        var canCast = spellChecker.CanUserCastSpell(user, spellName);

        Log.Information("Can the user cast {spellName}? {canCast}", spellName, canCast);

        Console.ReadKey();
    }
}