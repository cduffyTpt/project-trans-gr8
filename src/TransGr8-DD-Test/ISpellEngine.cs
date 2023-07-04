namespace TransGr8_DD_Test
{
    public interface ISpellEngine
    {
        bool CheckLevel(User user, Spell spell);
        bool Components(User user, Spell spell);
        bool ConcentrationCheck(User user, Spell spell);
        bool RangeCheck(User user, Spell spell);
    }
}