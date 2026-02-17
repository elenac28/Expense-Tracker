using System.Text.Json;

public class StorageService
{
    private readonly string _filePath;

    public StorageService(string fileName)
    {
        var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ExpenseTracker");
        
        Directory.CreateDirectory(folder);
        _filePath = Path.Combine(folder, fileName);
    }

    public string GetFilePath() => _filePath;

    public void Save<T>(T data)
    {
        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }

    public T Load<T>() where T : new()
    {
        if (!File.Exists(_filePath))
        {
            return new T();
        }

        var json = File.ReadAllText(_filePath);

        if (string.IsNullOrWhiteSpace(json))
        {
            return new T();
        }

        return JsonSerializer.Deserialize<T>(json) ?? new T();
    }
}