using System;
using FlandersOpen.Domain.SeedWork;
using FlandersOpen.Domain.ValueObjects;

namespace FlandersOpen.Domain.Entities
{
    public class Competition : Entity
    {
        private Competition() {}

        protected Competition(string name, ShortName shortName, ColorString color)
        {
            Id = Guid.NewGuid();
            ModificationDate = DateTime.Now;
            Name = name;
            ShortName = shortName;
            Color = color;
        }

        public string Name { get; private set; }
        public ShortName ShortName { get; private set; }
        public ColorString Color { get; private set; }

        public static Competition Create(string name, ShortName shortName, ColorString color)
        {
            return new Competition(name, shortName, color);
        }
        
        public void Update(string name, ShortName shortName, ColorString color)
        {
            Name = name;
            ShortName = shortName;
            Color = color;
            ModificationDate = DateTime.Now;
        }
        
    }
}
