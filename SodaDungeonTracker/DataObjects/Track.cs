using System;
using Newtonsoft.Json;

namespace SodaDungeonTracker.DataObjects
{
    public class Track
    {
        public int Id { get; set; }
        public int Dimension { get; set; }
        public bool LairOfDespair { get; set; }
        public int CapsStart { get; set; }
        public int CapsEnd { get; set; }
        [JsonIgnore]
        public int CapsDifference => CapsEnd - CapsStart;
        public int GoldStart { get; set; }
        public int GoldEnd { get; set; }
        [JsonIgnore]
        public int GoldDifference => GoldEnd - GoldStart;
        public int EssenceStart { get; set; }
        public int EssenceEnd { get; set; }
        [JsonIgnore]
        public int EssenceDifference => EssenceEnd - EssenceStart;
        public int LevelStart { get; set; }
        public int LevelEnd { get; set; }
        [JsonIgnore]
        public int LevelDifference => LevelEnd - LevelStart;
        public DateTime TimeStartTime { get; set; }
        public DateTime TimeEnd { get; set; }
        [JsonIgnore]
        public TimeSpan TimeDifference => TimeEnd.Subtract(TimeStartTime);
        public ClassSetup Setup { get; set; }

        public Track()
        {
            Setup = new ClassSetup();
        }
    }
}