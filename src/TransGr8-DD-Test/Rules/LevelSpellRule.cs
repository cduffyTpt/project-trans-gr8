namespace TransGr8_DD_Test.Rules
{
    public class LevelSpellRule : ISpellRule
    {
        public RulesOrdinal Ordinal => RulesOrdinal.LevelRule;
        public bool Satisfy(User user, Spell spell)
        {
            return user.Level >= spell.Level;
        }
    }
}
