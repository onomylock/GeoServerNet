using Shared.Common.Models;

namespace Shared.Common.Helpers;

public static class FileHelper
{
    public static readonly string HomePath = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), Consts.HomeDirectory);
    public static readonly string BuildsPath = Path.Join(HomePath, "Builds");
    public static readonly string ResultsPath = Path.Join(HomePath, "Results");

    public static void EnsureCreated()
    {
        if(!Directory.Exists(HomePath))
            Directory.CreateDirectory(HomePath);
        
        if(!Directory.Exists(BuildsPath))
            Directory.CreateDirectory(BuildsPath);
    }
    
    //public static async Task SaveFileAsync()
}