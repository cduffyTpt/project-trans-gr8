using System.Text.Json;
using System.Text.Json.Serialization;

namespace TransGr8_DD_Test
{
	public class Spell
	{
        public required string Name { get; init; }
        public int Level { get; init; }
        public required string CastingTime { get; init; }
        public required string Components { get; init; }
        public int Range { get; init; }
        public required string Duration { get; init; }
        public string? SavingThrow { get; init; }
        
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name)) throw new InvalidOperationException("Spell.Name missing.");
            if (Level < 0) throw new InvalidOperationException($"Spell.Level invalid for {Name}.");
            if (Range < 0) throw new InvalidOperationException($"Spell.Range invalid for {Name}.");
        }
	}
}