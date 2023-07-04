
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace TransGr8_DD_Test;

public interface ISpellRule
{
    bool CheckLevel(User user, Spell spell);
    bool Components(User user, Spell spell);
    bool RangeCheck(User user, Spell spell);
    bool ConcentrationCheck(User user, Spell spell);
}
public class SpellEngine : ISpellRule
{
    public bool CheckLevel(User user, Spell spell)
        => user.Level < spell.Level ? true : false;

    public bool Components(User user, Spell spell)
        => spell.Components.Contains("S") ? (!user.HasSomaticComponent ? false : true) : false;

    public bool ConcentrationCheck(User user, Spell spell)
        => spell.Duration.Contains("Concentration") ? (!user.HasConcentration ? false : true) : false;

    public bool RangeCheck(User user, Spell spell)
        => user.Range < spell.Range ? false : true;
}
public class EngineRules
{
    private readonly IEnumerable<ISpellRule> _rules;
    public EngineRules()
    {
        _rules = GetRules();
    }

    public bool run(User user, Spell spell)
    {
        bool rangeCheck = false;
        bool levelCheck = false;
        bool concentrationCheck = false;
        bool componentCheck = false;
        bool canCast = false;

        foreach (var rule in _rules)
        {
            levelCheck = rule.CheckLevel(user, spell);
            rangeCheck = rule.RangeCheck(user, spell);
            concentrationCheck = rule.ConcentrationCheck(user,spell);
            componentCheck = rule.Components(user, spell);
            if (levelCheck && concentrationCheck && componentCheck && rangeCheck)
            {
                canCast = true;
            }
        }
        return canCast;
    }

    private static IEnumerable<ISpellRule> GetRules()
    {
        var type = typeof(ISpellRule);
        var rules = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(x => type.IsAssignableFrom(x) && !x.IsInterface)
            .Select(x => (ISpellRule)Activator.CreateInstance(x)!)
            .ToList();

        return rules;
    }
}