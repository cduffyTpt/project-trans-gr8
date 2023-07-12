namespace TransGr8_DD_Test.Rules
{
    public class RangeSpellRule : ISpellRule
    {
        public RulesOrdinal Ordinal => RulesOrdinal.RangeRule;
        public bool Satisfy(User user, Spell spell)
        {
            return user.Range >= spell.Range;
        }
    }
}
