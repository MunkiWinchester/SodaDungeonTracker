using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using SodaDungeonTracker.Classes;

namespace SodaDungeonTracker
{
    public static class FileHandler
    {
        public static void LoadCsv()
        {
            var tracks = new List<Track>();
            var firstLine = true;
            var type = typeof(IBaseClass);
            var classes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p)).ToList();

            using(var reader = new StreamReader($@"{GetBaseFolder()}\Resource\SodaDungeon.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line != null && !firstLine)
                    {
                        var values = line.Split(';');

                        var list = new List<string>
                        {
                            values[13],
                            values[14],
                            values[15],
                            values[16],
                            values[17]
                        };

                        var classSetup = new List<IBaseClass>();
                        foreach (var s in list)
                        {
                            foreach (var baseClass in classes)
                            {
                                if(baseClass.ToString().Contains(s))
                                    classSetup.Add((IBaseClass)Activator.CreateInstance(baseClass));
                            }
                        }

                        tracks.Add(new Track
                        {
                            Dimension = int.Parse(values[0]),
                            LairOfDespair = bool.Parse(values[1]),
                            StartCaps = int.Parse(values[2]),
                            EndCaps = int.Parse(values[3]),
                            StartGold = int.Parse(values[4]),
                            EndGold = int.Parse(values[5]),
                            StartEssence = int.Parse(values[6]),
                            EndEssence = int.Parse(values[7]),
                            StartLevel = int.Parse(values[8]),
                            EndLevel = int.Parse(values[9]),
                            StartTime = DateTime.Parse(values[11]),
                            EndTime = DateTime.Parse(values[12]),
                            Setup = classSetup
                        });
                    }

                    firstLine = false;
                }
            }

            SaveConfig(tracks, "SodaDungeonV1.json", $@"{GetBaseFolder()}\Resource\");
        } 

        public static void SaveConfig(List<Track> tracks, string file, string path = null)
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

        public static List<Track> LoadPlaylistElements(string path)
        {
            return JsonConvert.DeserializeObject<List<Track>>(
                File.ReadAllText(path), new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects
                });
        }

        /// <summary>
        /// Gets the path of the base folder
        /// </summary>
        /// <returns>The path of the base folder</returns>
        public static string GetBaseFolder()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

    }
}