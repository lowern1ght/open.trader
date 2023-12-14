namespace Trader.Unit.Generator;

/// <summary>
/// Get solution files helper
/// </summary>
public static class ConfigFolderHelper
{
    /// <summary>
    /// Get root folder solution
    /// </summary>
    /// <param name="currentPath"></param>
    /// <returns></returns>
    private static DirectoryInfo? SolutionDirectoryInfo(string? currentPath = null)
    {
        var directory = new DirectoryInfo(currentPath ?? Directory.GetCurrentDirectory());
        
        while (directory != null && !directory.GetFiles("*.sln").Any())
        {
            directory = directory.Parent;
        }
        
        return directory;
    }

    /// <summary>
    /// Get Trader.Identity configFile
    /// </summary>
    /// <param name="absolutePath"></param>
    /// <param name="configName"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static string PathToIdentityConfig(string absolutePath = "src/applications/services/Trader.IdentityServer/Configs", string configName = "identity.json")
    {
        var solutionFolder = SolutionDirectoryInfo();

        if (solutionFolder is null)
        {
            throw new InvalidOperationException(nameof(solutionFolder));
        }

        return Path.Combine(solutionFolder.FullName, absolutePath, configName);
    }
}