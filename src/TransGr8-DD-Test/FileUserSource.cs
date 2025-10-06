using System.Text.Json;

namespace TransGr8_DD_Test
{
    public sealed class FileUserSource : IUserSource
    {
        private readonly string _path;
        public FileUserSource(string path) => _path = path;

        public Task<Stream> OpenAsync(CancellationToken ct = default)
            => Task.FromResult<Stream>(File.OpenRead(_path));
    }
    
    public sealed class JsonUserDeserializer : IUserDeserializer
    {
        private static readonly JsonSerializerOptions Options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public async Task<UserDto> DeserializeAsync(Stream stream, CancellationToken ct = default)
        {
            var dto = await JsonSerializer.DeserializeAsync<UserDto>(stream, Options, ct);
            if (dto is null) throw new InvalidDataException("Invalid JSON or empty.");
            return dto;
        }
    }
}