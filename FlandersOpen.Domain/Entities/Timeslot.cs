using FlandersOpen.Domain.SeedWork;
using FlandersOpen.Domain.ValueObjects;
using System;

namespace FlandersOpen.Domain.Entities
{
    public class Timeslot : Entity
    {
        private Timeslot() { }

        public Time StartTime { get; private set; }
        public Time EndTime { get; private set; }
        public string Description { get; private set; }
        public ColorString Color { get; private set; }


        public Game Game { get; private set; }

        private Timeslot (Time startTime, Time endTime)
        {
            Id = Guid.NewGuid();
            StartTime = startTime;
            EndTime = endTime;
        }

        internal void UpdateDescription(string description)
        {
            Description = description;
        }

        internal void UpdateColor(ColorString color)
        {
            Color = color;
        }

        internal static Timeslot Build(Time startTime, int durationInMinutes)
        {
            if (startTime == null)
                throw new ArgumentNullException(nameof(startTime));

            return new Timeslot(startTime, startTime.AddMinutes(durationInMinutes));
        }

        internal bool InConflict(Time time)
        {
            return time >= StartTime && time <= EndTime;
        }
    }
}