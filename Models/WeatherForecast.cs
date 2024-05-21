using System;
using System.ComponentModel.DataAnnotations;

namespace EksamenGruppe7.Models
{
    public class WeatherForecast
    {
        public Guid Id { get; set; } // UUID for primary key
        
        [Display(Name = "Dato")]
        public DateTime Date { get; set; }

        [Display(Name = "Temperatur")]
        public double Temperature { get; set; }
        
        [Display(Name = "Kommentar")]
        public string Comment { get; set; }
    }
}

