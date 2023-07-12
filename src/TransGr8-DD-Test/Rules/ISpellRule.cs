namespace TransGr8_DD_Test.Rules;
public interface ISpellRule
{
    public RulesOrdinal Ordinal { get; }
    bool Satisfy(User user, Spell spell);
}
