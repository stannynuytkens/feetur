using System;

namespace Feetur.Shared.Models
{
    public class Feature
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public bool? Enabled { get; set; }

        public bool Deleted { get; set; }
    }
}

