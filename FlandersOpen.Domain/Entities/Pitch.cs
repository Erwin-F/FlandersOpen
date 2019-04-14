using FlandersOpen.Domain.SeedWork;
using FlandersOpen.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlandersOpen.Domain.Entities
{
    public class Pitch : Entity
    {
        private Pitch() { }

        protected Pitch(string name, int number, int orderNumber)
        {
            Id = Guid.NewGuid();
            Name = name;
            Number = number;
            OrderNumber = orderNumber;
            Timeslots = new List<Timeslot>();
        }

        public string Name { get; private set; }
        public int Number { get; private set; }
        public int OrderNumber { get; private set; }

        public List<Timeslot> Timeslots { get; private set; }

        public static Pitch Build(string name, int number, int orderNumber)
        {
            return new Pitch(name, number, orderNumber);
        }

        public void Update(string name, int number, int orderNumber)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            Name = name;
            Number = number;
            OrderNumber = orderNumber;
        }

        public void AddTimeslot(Time startTime, int duration)
        {
            if (startTime == null)
                throw new ArgumentNullException(nameof(startTime));

            if (Timeslots.Any(t => t.InConflict(startTime)))
                throw new ArgumentException($"Time {startTime.Value} in conflict with existing timeslot"); //TODO Change exception

            var slot = Timeslot.Build(startTime, duration);
            Timeslots.Add(slot);
        }

        public void AddContinuousTimeslots(Time startTime, Time endTime, int eventDurationInMinutes)
        {
            if (startTime == null)
                throw new ArgumentNullException(nameof(startTime));

            if (endTime == null)
                throw new ArgumentNullException(nameof(endTime));

            while (true)
            {
                var slot = GetNextFreeTimeslot(startTime, eventDurationInMinutes);
                if (slot == null) return;
                if (slot.EndTime > endTime) return;

                Timeslots.Add(slot);
            }
        }

        public Timeslot GetNextFreeTimeslot(Time startTime, int duration)
        {
            if (startTime == null)
                throw new ArgumentNullException(nameof(startTime));

            var realStarttime = startTime;

            while (Timeslots.Any(t => t.InConflict(realStarttime)))
            {
                if (realStarttime.IsEndOfDay()) return null;

                realStarttime = realStarttime.AddMinutes(1);
            }

            return realStarttime.IsTimeAvailableInDay(duration) ? Timeslot.Build(realStarttime, duration) : null;
        }
    }
}
