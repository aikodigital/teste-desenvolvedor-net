﻿using System.ComponentModel.DataAnnotations;

namespace PublicTransportation.App.Models.Stops
{
    public class CreateStop
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }
    }
}
