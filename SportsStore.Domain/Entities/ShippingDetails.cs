﻿using System.ComponentModel.DataAnnotations;

namespace SportsStore.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Please enter a name")] // Введите имя
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the first address line")] // Введите первую стоку адреса
        [Display(Name = "Line 1")]
        public string Line1 { get; set; }
        [Display(Name = "Line 2")]
        public string Line2 { get; set; }
        [Display(Name = "Line 3")]
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Please enter a city name")] // Введите название города
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a state name")] // Введите название штата
        public string State { get; set; }
        public string Zip { get; set; }

        [Required(ErrorMessage = "Please enter a country name")] // Введите название страны
        public string Country { get; set; }
        public bool GiftWrap { get; set; }
    }
}
