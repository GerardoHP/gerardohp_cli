namespace business.Utils;

public static class FileUtils
{
    public static string[] ReadFile(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException(nameof(path));
        }

        return File.ReadAllLines(path);
    }
    
}