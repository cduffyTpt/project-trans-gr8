namespace TransGr8_DD_Test.Interfaces
{
    public interface ISpell
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public string CastingTime { get; set; }
        public IComponent[] Components { get; set; }
        public int Range { get; set; }
        public string Duration { get; set; }
        public string SavingThrow { get; set; }
    }
}