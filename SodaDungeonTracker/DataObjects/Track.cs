using System;
using Newtonsoft.Json;

namespace SodaDungeonTracker.DataObjects
{
    public class Track
    {
        public Track()
        {
            Setup = new ClassSetup();
        }

        public int Id { get; set; }
        public int Dimension { get; set; }
        public bool LairOfDespair { get; set; }
        public int CapsStart { get; set; }
        public int CapsEnd { get; set; }
        [JsonIgnore] public int CapsDifference => CapsEnd - CapsStart;
        [JsonIgnore] public double CapsPerMinute => CapsDifference / TimeDifference.TotalMinutes;
        public long GoldStart { get; set; }
        public long GoldEnd { get; set; }
        [JsonIgnore] public long GoldDifference => GoldEnd - GoldStart + (long) CapsDifference * 1500000000;
        [JsonIgnore] public double GoldPerMinute => GoldDifference / TimeDifference.TotalMinutes;
        public int EssenceStart { get; set; }
        public int EssenceEnd { get; set; }
        [JsonIgnore] public int EssenceDifference => EssenceEnd - EssenceStart;
        [JsonIgnore] public double EssencePerMinute => EssenceDifference / TimeDifference.TotalMinutes;
        public int LevelStart { get; set; }
        public int LevelEnd { get; set; }
        [JsonIgnore] public int LevelDifference => LevelEnd - LevelStart;
        [JsonIgnore] public double LevelPerMinute => LevelDifference / TimeDifference.TotalMinutes;
        public DateTime TimeStartTime { get; set; }
        public DateTime TimeEnd { get; set; }
        [JsonIgnore] public TimeSpan TimeDifference => TimeEnd.Subtract(TimeStartTime);
        public ClassSetup Setup { get; set; }
        public bool IsRunFinished { get; set; }
    }
}