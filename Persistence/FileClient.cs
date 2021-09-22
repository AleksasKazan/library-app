using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace Persistence
{
    public class FileClient : IFileClient
    {
        public void Append<T>(string filename, T item)
        {
            //var options = new JsonSerializerOptions { WriteIndented = true };

            //var jsonItem = JsonSerializer.Serialize(item, options);
            var jsonItem = JsonSerializer.Serialize(item);

            File.AppendAllLines(filename, new[] { jsonItem });
        }

        public void DeleteFileContent(string filename)
        {
            File.WriteAllLines(filename, Array.Empty<string>());
        }

        public IEnumerable<T> ReadAll<T>(string filename)
        {
            //var options = new JsonSerializerOptions { WriteIndented = true };

            var jsonItems = File.ReadAllLines(filename);

            return jsonItems.Select(jsonItem => JsonSerializer.Deserialize<T>(jsonItem));
        }

        public void WriteAll<T>(string filename, IEnumerable<T> items)
        {
            //var options = new JsonSerializerOptions { WriteIndented = true };

            //var jsonItems = items.Select(item => JsonSerializer.Serialize(item, options));
            var jsonItems = items.Select(item => JsonSerializer.Serialize(item));

            File.WriteAllLines(filename, jsonItems);
        }
    }
}
