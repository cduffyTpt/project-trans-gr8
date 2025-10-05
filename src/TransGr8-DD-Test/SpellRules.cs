namespace TransGr8_DD_Test
{
    public interface ISpellRule
    {
        bool Validate(User user, Spell spell);
    }
    
    public class LevelRule : ISpellRule
    {
        public bool Validate(User user, Spell spell)
            => user.Level >= spell.Level;
    }

    public class VerbalRule : ISpellRule
    {
        public bool Validate(User user, Spell spell)
            => spell.Components.Contains("V") && user.HasVerbalComponent;
    }

    public class SomaticRule : ISpellRule
    {
        public bool Validate(User user, Spell spell)
            => spell.Components.Contains("S") && user.HasSomaticComponent;
    }

    public class MaterialRule : ISpellRule
    {
        public bool Validate(User user, Spell spell)
            => spell.Components.Contains("M") && user.HasMaterialComponent;
    }

    public class RangeRule : ISpellRule
    {
        public bool Validate(User user, Spell spell)
            => user.Range >= spell.Range;
    }

    public class ConcentrationRule : ISpellRule
    {
        public bool Validate(User user, Spell spell)
            => spell.Duration.Contains("Concentration") && user.HasConcentration;
    }
    
    // Add additional checks as needed for specific saving throws or other requirements.
    
}