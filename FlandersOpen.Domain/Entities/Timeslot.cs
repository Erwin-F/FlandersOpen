using FlandersOpen.Domain.SeedWork;
using FlandersOpen.Domain.ValueObjects;
using System;

namespace FlandersOpen.Domain.Entities
{
    public class Timeslot : Entity
    {
        private Timeslot() { }

        public Pitch Pitch { get; private set; }
        public Guid PitchId { get; private set; }
        public Time StartTime { get; private set; }
        public Time EndTime { get; private set; }
        public string Description { get; private set; }
        public ColorString Color { get; private set; }


        public Game Game { get; private set; }

        private Timeslot (Pitch pitch, Time startTime, Time endTime)
        {
            Id = Guid.NewGuid();
            Pitch = pitch;
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

        internal static Timeslot Build(Pitch pitch, Time startTime, int durationInMinutes)
        {
            if (startTime == null)
                throw new ArgumentNullException(nameof(startTime));

            if (pitch == null)
                throw new ArgumentNullException(nameof(pitch));

            return new Timeslot(pitch, startTime, startTime.AddMinutes(durationInMinutes));
        }

        internal bool InConflict(Time time)
        {
            return time >= StartTime && time <= EndTime;
        }
    }
}