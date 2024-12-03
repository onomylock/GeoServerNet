namespace Shared.Application.Services;

public interface IFileService
{
    Task<string> ExtractArchiveAsync(Stream stream, string buildName, CancellationToken cancellationToken = default);
    Task<Stream> ZipFolderAsync(string path, CancellationToken cancellationToken = default);
}