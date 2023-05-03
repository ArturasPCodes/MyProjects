﻿namespace CityInfo.API.Models
{
    /// <summary>
    /// A DTO for a city without points of interest
    /// </summary>
    public class CityWithoutPointsOfInterestDto
    {
        /// <summary>
        /// The if of the city
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the city
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The Description of the city
        /// </summary>
        public string? Description { get; set; }
    }
}
