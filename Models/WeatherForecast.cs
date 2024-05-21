using System;

namespace EksamenGruppe7.Models
{
    public class WeatherForecast
    {
        public Guid Id { get; set; } // UUID for primary key
        public DateTime Date { get; set; }
        public double Temperature { get; set; }
        public string Comment { get; set; }
    }
}

