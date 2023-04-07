using Serilog;
using TransGr8_DD_Test.Models;

namespace TransGr8_DD_Test.Services;

public class SpellChecker
{
    private readonly List<Spell> _spellList;

    public SpellChecker(List<Spell> spells)
    {
        _spellList = spells;
    }

    public bool CanUserCastSpell(User user, string spellName)
    {
        var spell = GetSpellBySpellName(spellName);

        if (spell is null)
        {
            Log.Warning("The spell name : {spellName} is not found", spellName);
            return false;
        }

        if (!IsUserHaveSufficientLevel(user, spell))
        {
            return false;
        }

        if (!IsUserHaveComponent(user, spell.Components))
        {
            return false;
        }

        if (!IsUserHaveSufficientRange(user, spell))
        {
            return false;
        }

        if (!IsUserHaveConcentration(user, spell))
        {
            return false;
        }

        return true;
    }

    private static bool IsUserHaveConcentration(User user, Spell spell)
    {
        if (spell.Duration.Contains("Concentration"))
        {
            if (!user.HasConcentration)
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsUserHaveSufficientRange(User user, Spell spell)
    {
        if (user.Range < spell.Range)
        {
            return false;
        }

        return true;
    }

    private static bool IsUserHaveSufficientLevel(User user, Spell spell)
    {
        if (user.Level < spell.Level)
        {
            return false;
        }

        return true;
    }

    private static bool IsUserHaveComponent(User user, string components)
    {
        if (components.Contains('V'))
        {
            if (!user.HasVerbalComponent)
            {
                return false;
            }
        }

        if (components.Contains('S'))
        {
            if (!user.HasSomaticComponent)
            {
                return false;
            }
        }

        if (components.Contains('M'))
        {
            if (!user.HasMaterialComponent)
            {
                return false;
            }
        }

        return true;
    }

    private Spell GetSpellBySpellName(string spellName)
    {
        return _spellList.Find(s => s.Name == spellName);
    }
}