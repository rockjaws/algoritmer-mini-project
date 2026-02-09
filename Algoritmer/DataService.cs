using System.Text.Json;

namespace Algoritmer;

public class DataService<T>
{
  public T[] LoadData(string FileName)
  {
    string filePath = Path.Combine(AppContext.BaseDirectory, "JSON_Data", FileName);

    if (!File.Exists(filePath))
    {
      Console.WriteLine($"{FileName} not found!");
      return [];
    }

    string json = File.ReadAllText(filePath);
    var data = JsonSerializer.Deserialize<Dictionary<string, T[]>>(json);

    T[] numbers = data!["values"];

    Console.WriteLine($"Loaded {numbers.Length} numbers");
    Console.WriteLine($"First: {numbers[0]}");
    Console.WriteLine($"Last: {numbers[^1]}");
    return numbers;
  }

  public void SaveData<TData>(TData jsonObject, string fileName)
  {
    string projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
    string outputDir = Path.Combine(projectRoot, "output");
    Directory.CreateDirectory(outputDir);
    string outputFile = Path.Combine(outputDir, fileName);
    string newJson = JsonSerializer.Serialize(jsonObject, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText(outputFile, newJson);
    Console.WriteLine($"Saved JSON to: {outputFile}");
  }
}


