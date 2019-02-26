using System;
using FlandersOpen.Domain.SeedWork;
using FlandersOpen.Domain.ValueObjects;

namespace FlandersOpen.Domain.Entities
{
    public class Event : Entity
    {
        private Event() { }

        protected Event(string name, ColorString color)
        {
            Id = Guid.NewGuid();
            Name = name;
            Color = color;
            ModificationDate = DateTime.Now;
        }

        public string Name { get; private set; }
        public ColorString Color { get; private set; }

        //GameId

        public static Event Build(string name, ColorString color)
        {
            return new Event(name, color);
        }
    }
}