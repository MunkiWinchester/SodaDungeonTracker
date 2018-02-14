using System;
using System.Collections.Generic;
using SodaDungeonTracker.Classes;

namespace SodaDungeonTracker
{
    public class Track
    {
        public int Dimension { get; set; }
        public bool LairOfDespair { get; set; }
        public int StartCaps { get; set; }
        public int EndCaps { get; set; }
        public int CapDifference => EndCaps - StartCaps;
        public int StartGold { get; set; }
        public int EndGold { get; set; }
        public int GoldDifference => EndGold - StartGold;
        public int StartEssence { get; set; }
        public int EndEssence { get; set; }
        public int EssenceDifference => EndEssence - StartEssence;
        public int StartLevel { get; set; }
        public int EndLevel { get; set; }
        public int LevelDifference => EndLevel - StartLevel;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan TimeDifference => EndTime.Subtract(StartTime);
        public List<IBaseClass> Setup { get; set; }

        public Track()
        {
            Setup = new List<IBaseClass>();
        }
    }
}