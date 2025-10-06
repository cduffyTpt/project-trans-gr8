namespace TransGr8_DD_Test
{
    
    public interface IUserSource
    {
        // Abstraction de la provenance (fichier, HTTP, BDD, mémoire…)
        Task<Stream> OpenAsync(CancellationToken ct = default);
    }

    public interface IUserDeserializer
    { 
        Task<UserDto> DeserializeAsync(Stream stream, CancellationToken ct = default);
    }

    public interface IUserFactory
    { 
        User Create(UserDto dto);
    }

    public interface IUserRepository
    { 
        Task<User> LoadAsync(CancellationToken ct = default);
    }
    
    public sealed class User
    {
        public int Level { get; set; }
        public bool HasVerbalComponent { get; set; }
        public bool HasSomaticComponent { get; set; }
        public bool HasMaterialComponent { get; set; }
        public int Range { get; set; }
        public bool HasConcentration { get; set; }

        public User(int level, bool hasVerbal, bool hasSomatic, bool hasMaterial, int range, bool hasConcentration)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(level, 1);
            ArgumentOutOfRangeException.ThrowIfLessThan(range, 0);
            
            Level = level;
            HasVerbalComponent = hasVerbal;
            HasSomaticComponent = hasSomatic;
            HasMaterialComponent = hasMaterial;
            Range = range;
            HasConcentration = hasConcentration;
        }

        public override string ToString()
        {
            return $"""
                    User:
                      Level               : {Level}
                      Has Verbal Component: {HasVerbalComponent}
                      Has Somatic Component: {HasSomaticComponent}
                      Has Material Component: {HasMaterialComponent}
                      Range               : {Range}
                      Has Concentration   : {HasConcentration}
                    """;
        }
    }
    
    public sealed class UserDto
    {
        public int Level { get; set; }
        public bool HasVerbalComponent { get; set; }
        public bool HasSomaticComponent { get; set; }
        public bool HasMaterialComponent { get; set; }
        public int Range { get; set; }
        public bool HasConcentration { get; set; }
    }
    
    public sealed class UserFactory : IUserFactory
    {
        public User Create(UserDto dto)
        {
            return new User(
                dto.Level,
                dto.HasVerbalComponent,
                dto.HasSomaticComponent,
                dto.HasMaterialComponent,
                dto.Range,
                dto.HasConcentration
            );
        }
    }
    
    public sealed class UserRepository : IUserRepository
    {
        private readonly IUserSource _source;
        private readonly IUserDeserializer _deserializer;
        private readonly IUserFactory _factory;

        public UserRepository(IUserSource source, IUserDeserializer deserializer, IUserFactory factory)
        {
            _source = source;
            _deserializer = deserializer;
            _factory = factory;
        }

        public async Task<User> LoadAsync(CancellationToken ct = default)
        {
            await using var stream = await _source.OpenAsync(ct);
            var dto = await _deserializer.DeserializeAsync(stream, ct);
            return _factory.Create(dto);
        }
    }
}