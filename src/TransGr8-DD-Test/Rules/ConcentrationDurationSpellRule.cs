namespace TransGr8_DD_Test.Rules
{
    public class ConcentrationDurationSpellRule : ISpellRule
    {
        public RulesOrdinal Ordinal => RulesOrdinal.ConcentrationRule;
        public bool Satisfy(User user, Spell spell)
        {
            if(spell.Duration.Contains("Concentration") && !user.HasConcentration)
            {
                return false;
            }

            return true;
        }
    }
}
