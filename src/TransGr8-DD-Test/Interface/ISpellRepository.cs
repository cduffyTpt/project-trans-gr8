namespace TransGr8_DD_Test.Interface
{
    public interface ISpellRepository
    {
        Spell GetSpellByName(string name);
        void AddSpell(Spell spell);
        void UpdateSpell(Spell spell);
        void RemoveSpell(Spell spell);
        List<Spell> GetAllSpells();
    }
}