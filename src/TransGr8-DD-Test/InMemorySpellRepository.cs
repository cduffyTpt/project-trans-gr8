namespace TransGr8_DD_Test
{
    public class InMemorySpellRepository : ISpellRepository
    {
        private readonly List<Spell> _spells;

        public InMemorySpellRepository(List<Spell> spells)
        {
            _spells = spells;
        }

        public Spell FindByName(string name)
        {
            return _spells.FirstOrDefault(s => s.Name == name);
        }
    }
}