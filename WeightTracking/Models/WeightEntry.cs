﻿using System;
namespace WeightTracking.Models
{
    public class WeightEntry
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Weight { get; set; }
        public string UserId { get; set; }
    }
}
