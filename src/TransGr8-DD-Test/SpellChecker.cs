namespace TransGr8_DD_Test
{
    public interface IRule
    {
        bool Evaluate(User user, Spell spell);
    }

    public class SomaticComponentRule : IRule
    {
        public bool Evaluate(User user, Spell spell)
        {
            return !spell.Components.Contains("S") || user.HasSomaticComponent;
        }
    }

    public class VerbalComponentRule : IRule
    {
        public bool Evaluate(User user, Spell spell)
        {
            return !spell.Components.Contains("V") || user.HasVerbalComponent;
        }
    }

    public class MaterialComponentRule : IRule
    {
        public bool Evaluate(User user, Spell spell)
        {
            return !spell.Components.Contains("M") || user.HasMaterialComponent;
        }
    }

    public class ConcentrationRule : IRule
    {
        public bool Evaluate(User user, Spell spell)
        {
            return !spell.Duration.Contains("Concentration") || user.HasConcentration;
        }
    }

    public class SpellChecker
    {
        private readonly List<Spell> _spellList;

        public SpellChecker(List<Spell> spells)
        {
            _spellList = spells;
        }

        public bool CanUserCastSpell(User user, string spellName)
        {
            Spell spell = _spellList.Find(s => s.Name == spellName);

            if (spell == null)
            {
                return false;
            }

            if (user.Level < spell.Level)
            {
                return false;
            }

            if (user.Range < spell.Range)
            {
                return false;
            }

            // Evaluate all the rules to determine if the user can cast the spell.
            if (!new SomaticComponentRule().Evaluate(user, spell))
            {
                return false;
            }

            if (!new VerbalComponentRule().Evaluate(user, spell))
            {
                return false;
            }

            if (!new MaterialComponentRule().Evaluate(user, spell))
            {
                return false;
            }

            if (!new ConcentrationRule().Evaluate(user, spell))
            {
                return false;
            }

            return true;
        }
    }
}
