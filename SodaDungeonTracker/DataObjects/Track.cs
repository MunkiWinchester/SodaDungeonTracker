using System;
using System.Collections.Generic;
using SodaDungeonTracker.DataObjects.Classes;

namespace SodaDungeonTracker.DataObjects
{
    public class Track
    {
        public int Dimension { get; set; }
        public bool LairOfDespair { get; set; }
        public int CapsStart { get; set; }
        public int CapsEnd { get; set; }
        public int CapsDifference => CapsEnd - CapsStart;
        public int GoldStart { get; set; }
        public int GoldEnd { get; set; }
        public int GoldDifference => GoldEnd - GoldStart;
        public int EssenceStart { get; set; }
        public int EssenceEnd { get; set; }
        public int EssenceDifference => EssenceEnd - EssenceStart;
        public int LevelStart { get; set; }
        public int LevelEnd { get; set; }
        public int LevelDifference => LevelEnd - LevelStart;
        public DateTime TimeStartTime { get; set; }
        public DateTime TimeEnd { get; set; }
        public TimeSpan TimeDifference => TimeEnd.Subtract(TimeStartTime);
        public List<IBaseClass> Setup { get; set; }

        public Track()
        {
            Setup = new List<IBaseClass>();
        }
    }
}