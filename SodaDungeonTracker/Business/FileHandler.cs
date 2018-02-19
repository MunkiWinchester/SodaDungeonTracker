﻿using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using SodaDungeonTracker.DataObjects;

namespace SodaDungeonTracker.Business
{
    public static class FileHandler
    {
        public static void SaveConfig(List<Record> tracks, string file, string path = null)
        {
            if (!string.IsNullOrWhiteSpace(path))
                file = CheckPath(path, file);

            var json = JsonConvert.SerializeObject(tracks, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects
            });
            File.WriteAllText(file, json);
        }

        private static string CheckPath(string path, string file)
        {
            var correctedPath = path.EndsWith("\\") ? path : path + "\\";
            var correctedFile = file.EndsWith(".json") ? correctedPath + file : correctedPath + file + ".json";
            using (File.Create(correctedFile))
            {
            }

            return correctedFile;
        }

        public static List<Record> LoadPlaylistElements(string path)
        {
            var tracks = JsonConvert.DeserializeObject<List<Record>>(
                File.ReadAllText(path), new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects
                });
            //SaveConfig(tracks, "SodaDungeon.json", $@"{GetBaseFolder()}\Resources");
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