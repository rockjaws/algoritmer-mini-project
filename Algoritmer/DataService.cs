using System.Text.Json;

namespace Algoritmer;

/// <summary>
/// Provides services for loading and saving data to/from JSON files.
/// Supports generic type serialization and deserialization.
/// </summary>
/// <typeparam name="T">The type of data to be loaded from JSON files.</typeparam>
public class DataService<T>
{
  /// <summary>
  /// Loads data from a JSON file in the JSON_Data directory.
  /// Expects JSON format: { "values": [array of T] }
  /// </summary>
  /// <param name="FileName">The name of the JSON file to load (e.g., "sorted.json").</param>
  /// <returns>An array of values loaded from the JSON file, or an empty array if file not found.</returns>
  public T[] LoadData(string FileName)
  {
    // Construct path to file in JSON_Data directory relative to executable
    string filePath = Path.Combine(AppContext.BaseDirectory, "JSON_Data", FileName);

    // Validate file exists
    if (!File.Exists(filePath))
    {
      Console.WriteLine($"{FileName} not found!");
      return [];
    }

    // Read and deserialize JSON
    string json = File.ReadAllText(filePath);
    var data = JsonSerializer.Deserialize<Dictionary<string, T[]>>(json);

    // Extract the "values" array from the JSON structure
    T[] numbers = data!["values"];

    // Display diagnostic information
    Console.WriteLine($"Loaded {numbers.Length} numbers");
    Console.WriteLine($"First: {numbers[0]}");
    Console.WriteLine($"Last: {numbers[^1]}");  // Using index from end operator

    return numbers;
  }

  /// <summary>
  /// Saves data to a JSON file in the project's output directory.
  /// Creates the output directory if it doesn't exist.
  /// </summary>
  /// <typeparam name="TData">The type of object to serialize to JSON.</typeparam>
  /// <param name="jsonObject">The object to serialize and save.</param>
  /// <param name="fileName">The name of the file to create (e.g., "results.json").</param>
  public void SaveData<TData>(TData jsonObject, string fileName)
  {
    // Navigate up from bin/Debug/net10.0 to project root
    string projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));

    // Create output directory in project root
    string outputDir = Path.Combine(projectRoot, "output");
    Directory.CreateDirectory(outputDir);  // Creates if doesn't exist, does nothing if it does

    // Construct full file path
    string outputFile = Path.Combine(outputDir, fileName);

    // Serialize 
    string newJson = JsonSerializer.Serialize(jsonObject, new JsonSerializerOptions { WriteIndented = true });

    // Write to file
    File.WriteAllText(outputFile, newJson);
    Console.WriteLine($"Saved JSON to: {outputFile}");
  }
}
