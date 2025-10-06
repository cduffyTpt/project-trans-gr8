using System.Text.Json;
using System.Text.Json.Serialization;

namespace TransGr8_DD_Test
{
    public interface ISpellRepository
    {
        Task<IReadOnlyList<Spell>> GetAllAsync(CancellationToken ct = default);
        public Task<Spell>  FindByNameAsync(string name, CancellationToken ct = default);
    }
    
    
    public sealed class JsonSpellRepository : ISpellRepository
    {
        private readonly string _jsonPath;
        private List<Spell> _spells; 
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            ReadCommentHandling = JsonCommentHandling.Skip,
            AllowTrailingCommas = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public JsonSpellRepository(string jsonPath) => _jsonPath = jsonPath;
        
        private async Task EnsureLoadedAsync(CancellationToken ct = default)
        {
            if (_spells is not null)
                return; 

            if (!File.Exists(_jsonPath))
                throw new FileNotFoundException($"JSON File not found: {_jsonPath}");

            await using var stream = File.OpenRead(_jsonPath);
            var spells = await JsonSerializer.DeserializeAsync<List<Spell>>(stream, _jsonOptions, ct)
                         ?? new List<Spell>();

            foreach (var s in spells)
                s.Validate();

            _spells = spells;
        }

        public async Task<IReadOnlyList<Spell>> GetAllAsync(CancellationToken ct = default)
        {
            await EnsureLoadedAsync(ct);
            return _spells!;
        }

        public async Task<Spell> FindByNameAsync(string name, CancellationToken ct = default)
        {
            await EnsureLoadedAsync(ct);
            return _spells!.FirstOrDefault(s => 
                string.Equals(s.Name, name, StringComparison.OrdinalIgnoreCase));
        }
    }
}