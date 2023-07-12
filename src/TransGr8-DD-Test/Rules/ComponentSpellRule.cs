namespace TransGr8_DD_Test.Rules
{
    public class ComponentSpellRule : ISpellRule
    {
        public RulesOrdinal Ordinal => RulesOrdinal.ComponentRule;
        public bool Satisfy(User user, Spell spell)
        {
            bool spellHasMaterial = spell.Components.Contains("M");
            bool spellHasSomatic = spell.Components.Contains("S");
            bool spellHasVerbal = spell.Components.Contains("V");

            if (spellHasMaterial && !user.HasMaterialComponent)
            {
                return false;
            }

            if (spellHasSomatic && !user.HasSomaticComponent)
            {
                return false;
            }

            if (spellHasVerbal && !user.HasVerbalComponent)
            {
                return false;
            }

            if (!(spellHasMaterial || spellHasSomatic || spellHasVerbal))
            {
                return false;
            }

            return true;
        }
    }

}
