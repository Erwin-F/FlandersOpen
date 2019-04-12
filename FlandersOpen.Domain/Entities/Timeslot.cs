using FlandersOpen.Domain.SeedWork;
using FlandersOpen.Domain.ValueObjects;
using System;

namespace FlandersOpen.Domain.Entities
{
    public class Timeslot : Entity
    {
        private Timeslot() { }

        public Guid PitchId { get; private set; }
        public Time StartTime { get; private set; }
        public Time EndTime { get; private set; }
        public string Description { get; private set; }
        public ColorString Color { get; private set; }


        public Game Game { get; private set; }

        private Timeslot (Guid pitchId, Time startTime, Time endTime)
        {
            Id = Guid.NewGuid();
            PitchId = pitchId;
            StartTime = startTime;
            EndTime = endTime;
        }

        public void UpdateDescription(string description)
        {
            Description = description;
        }

        public void UpdateColor(ColorString color)
        {
            Color = color;
        }

        internal static Timeslot Build(Guid pitchId, Time startTime, int durationInMinutes)
        {
            if (startTime == null)
                throw new ArgumentNullException(nameof(startTime));


            return new Timeslot(pitchId, startTime, startTime.AddMinutes(durationInMinutes));
        }

        internal bool InConflict(Time time)
        {
            return time >= StartTime && time <= EndTime;
        }
    }
}