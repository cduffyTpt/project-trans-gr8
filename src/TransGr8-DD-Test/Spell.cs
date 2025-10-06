using System.Text.Json;
using System.Text.Json.Serialization;

namespace TransGr8_DD_Test
{
    public interface ISpellRepository
    {
        Task<IReadOnlyList<Spell>> GetAllAsync(CancellationToken ct = default);
    }
    public sealed class JsonSpellRepository : ISpellRepository
    {
        private readonly string _jsonPath;
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            ReadCommentHandling = JsonCommentHandling.Skip,
            AllowTrailingCommas = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public JsonSpellRepository(string jsonPath) => _jsonPath = jsonPath;

        public async Task<IReadOnlyList<Spell>> GetAllAsync(CancellationToken ct = default)
        {
            if (!File.Exists(_jsonPath))
                throw new FileNotFoundException($"Fichier JSON introuvable: {_jsonPath}");

            await using var stream = File.OpenRead(_jsonPath);
            var spells = await JsonSerializer.DeserializeAsync<List<Spell>>(stream, _jsonOptions, ct)
                         ?? new List<Spell>();

            foreach (var s in spells) s.Validate(); // validation légère côté domaine
            return spells;
        }
        
        public sealed class SpellService
        {
            private readonly ISpellRepository _repo;
            public SpellService(ISpellRepository repo) => _repo = repo;

            public Task<IReadOnlyList<Spell>> GetAllAsync(CancellationToken ct = default)
                => _repo.GetAllAsync(ct);

            public async Task<IReadOnlyList<Spell>> GetByLevelAsync(int level, CancellationToken ct = default)
                => (await _repo.GetAllAsync(ct)).Where(s => s.Level == level).ToList();
        }
        
    }
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