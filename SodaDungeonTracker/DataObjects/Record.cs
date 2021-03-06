﻿using System;
using Newtonsoft.Json;

namespace SodaDungeonTracker.DataObjects
{
    public class Record
    {
        public Record()
        {
            Setup = new ClassSetup();
        }

        public int Id { get; set; }
        public int Dimension { get; set; } = 1;
        public bool LairOfDespair { get; set; }
        public int CapsStart { get; set; } = 0;
        public int CapsEnd { get; set; } = 0;
        [JsonIgnore] public int CapsDifference => CapsEnd - CapsStart;
        [JsonIgnore] public double CapsPerMinute => CapsDifference / TimeDifference.TotalMinutes;
        public long GoldStart { get; set; } = 0;
        public long GoldEnd { get; set; } = 0;
        [JsonIgnore] public long GoldDifference => GoldEnd - GoldStart;
        [JsonIgnore] public long GoldDifferenceWithCaps => GoldEnd - GoldStart + (long) CapsDifference * 1000000000; // Auto converts 1 bil at 1,5 bil
        [JsonIgnore] public double GoldPerMinute => GoldDifference / TimeDifference.TotalMinutes;
        [JsonIgnore] public double GoldWithCapsPerMinute => GoldDifferenceWithCaps / TimeDifference.TotalMinutes;
        public int EssenceStart { get; set; } = 0;
        public int EssenceEnd { get; set; } = 0;
        [JsonIgnore] public int EssenceDifference => EssenceEnd - EssenceStart;
        [JsonIgnore] public double EssencePerMinute => EssenceDifference / TimeDifference.TotalMinutes;
        public int LevelStart { get; set; } = 1;
        public int LevelEnd { get; set; } = 1;
        [JsonIgnore] public int LevelDifference => LevelEnd - LevelStart;
        [JsonIgnore] public double LevelPerMinute => LevelDifference / TimeDifference.TotalMinutes;
        public DateTime TimeStart { get; set; } = DateTime.Now;
        public DateTime TimeEnd { get; set; } = DateTime.Now;
        [JsonIgnore] public TimeSpan TimeDifference => TimeEnd.Subtract(TimeStart);
        public ClassSetup Setup { get; set; }
        public bool WasRunAborted { get; set; }
    }
}