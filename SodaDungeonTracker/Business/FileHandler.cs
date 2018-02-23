using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using SodaDungeonTracker.DataObjects;

namespace SodaDungeonTracker.Business
{
    public static class FileHandler
    {
        public static void SaveRecordsAsJson(List<Record> records, string file)
        {
            var json = JsonConvert.SerializeObject(records, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects
            });
            File.WriteAllText(file, json);
        }

        public static List<Record> LoadRecordsFromJson(string path)
        {
            var tracks = JsonConvert.DeserializeObject<List<Record>>(
                File.ReadAllText(path), new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects
                });
            return tracks;
        }

        /// <summary>
        ///     Gets the path of the base folder
        /// </summary>
        /// <returns>The path of the base folder</returns>
        public static string GetBaseFolder()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }
    }
}