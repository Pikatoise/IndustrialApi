﻿namespace Loading.Domain.Models
{
    public class Equipment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ManufacturerId { get; set; }

        public Manufacturer? Manufacturer { get; set; } = null;
    }
}
