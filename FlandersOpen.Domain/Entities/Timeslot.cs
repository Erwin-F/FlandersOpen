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

        public Pitch Pitch { get; private set; }

        public Event Event { get; private set; }

        private Timeslot (Guid pitchId, Time startTime, Time endTime)
        {
            Id = Guid.NewGuid();
            PitchId = pitchId;
            StartTime = startTime;
            EndTime = endTime;
            ModificationDate = DateTime.Now;
        }

        internal static Timeslot Build(Guid pitchId, Time startTime, Time endTime)
        {
            return new Timeslot(pitchId, startTime, endTime);
        }

        internal static Timeslot Build(Guid pitchId, Time startTime, int durationInMinutes)
        {
            return new Timeslot(pitchId, startTime, startTime.AddMinutes(durationInMinutes));
        }

        internal bool InConflict(Time time)
        {
            return time >= StartTime && time <= EndTime;
        }
    }
}