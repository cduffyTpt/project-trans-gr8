namespace TransGr8_DD_Test
{
    public interface ISpellRule
    {
        bool Validate(User user, Spell spell);
    }
    
    public class LevelRule : ISpellRule
    {
        public bool Validate(User user, Spell spell)
        {
            if (user.Level >= spell.Level)
            {
                return true;
            }
            return false;
        }
    }

    public class VerbalRule : ISpellRule
    {
        public bool Validate(User user, Spell spell)
        {
            if (spell.Components.Contains('V') && user.HasVerbalComponent)
            {
                return true;
            }
            return false;
        }
    }

    public class SomaticRule : ISpellRule
    {
        public bool Validate(User user, Spell spell)
        {
            if (spell.Components.Contains('S') && user.HasSomaticComponent)
            {
                return true;
            }
            return false;
        }
    }

    public class MaterialRule : ISpellRule
    {
        public bool Validate(User user, Spell spell)
        {
            if (spell.Components.Contains('M') && user.HasMaterialComponent)
            {
                return true;
            }
            return false;
        }
    }

    public class RangeRule : ISpellRule
    {
        public bool Validate(User user, Spell spell)
        {
            if (user.Range >= spell.Range)
            {
                return true;
            }
            return false;
        }
    }

    public class ConcentrationRule : ISpellRule
    {
        public bool Validate(User user, Spell spell)
        {
            if (spell.Duration.Contains("Concentration") && user.HasConcentration)
            {
                return true;
            } 
            if (!spell.Duration.Contains("Concentration"))
            {
                return true;
            }
            return false;
        }
    }
    
    // Add additional checks as needed for specific saving throws or other requirements.
    
}