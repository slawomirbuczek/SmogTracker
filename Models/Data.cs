
using System;
namespace SmogTracker.Models
{
    public class DataModel
    {
        public Current current { get; set; }
        public History[] history { get; set; }
        public Forecast[] forecast { get; set; }
        public string usesLeft { get; set; }
        public string timeOfMeasurement { get; set; }
    }

    public class Current
    {
        public DateTime fromDateTime { get; set; }
        public DateTime tillDateTime { get; set; }
        public Value[] values { get; set; }
        public Index[] indexes { get; set; }
        public Standard[] standards { get; set; }
    }

    public class Value
    {
        public string name { get; set; }
        public float value { get; set; }
    }

    public class Index
    {
        public string name { get; set; }
        public float value { get; set; }
        public string level { get; set; }
        public string description { get; set; }
        public string advice { get; set; }
        public string color { get; set; }
    }

    public class Standard
    {
        public string name { get; set; }
        public string pollutant { get; set; }
        public float limit { get; set; }
        public float percent { get; set; }
        public string averaging { get; set; }
    }

    public class History
    {
        public DateTime fromDateTime { get; set; }
        public DateTime tillDateTime { get; set; }
        public Value[] values { get; set; }
        public Index[] indexes { get; set; }
        public Standard[] standards { get; set; }
    }

    public class Forecast
    {
        public DateTime fromDateTime { get; set; }
        public DateTime tillDateTime { get; set; }
        public Value[] values { get; set; }
        public Index[] indexes { get; set; }
        public Standard[] standards { get; set; }
    }

}