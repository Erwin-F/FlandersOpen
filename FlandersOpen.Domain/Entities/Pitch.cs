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
            ModificationDate = DateTime.Now;
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
            Name = name;
            Number = number;
            OrderNumber = orderNumber;
            ModificationDate = DateTime.Now;
        }

        public void AddTimeslot(Time startTime, int duration)
        {
            if (Timeslots.Any(t => t.InConflict(startTime)))
                throw new ArgumentException($"Time {startTime.Value} in conflict with existing timeslot");

            var slot = Timeslot.Build(Id, startTime, duration);
            Timeslots.Add(slot);
        }

        public void AddContinuousTimeslots(Time startTime, Time endTime, int eventDurationInMinutes)
        {
            while (true)
            {
                var slot = GetNextFreeTimeslot(startTime, eventDurationInMinutes);
                if (slot == null) return;
                if (slot.EndTime > endTime) return;

                Timeslots.Add(slot);
            }
        }

        public Timeslot GetNextFreeTimeslot(Time starttime, int duration)
        {
            var realStarttime = starttime;

            while (Timeslots.Any(t => t.InConflict(realStarttime)))
            {
                if (realStarttime.IsEndOfDay()) return null;

                realStarttime = realStarttime.AddMinutes(1);
            }

            return realStarttime.IsTimeAvailableInDay(duration) ? Timeslot.Build(Id, realStarttime, duration) : null;
        }







        //public void ModifyTimeslotDuration(Time time, int duration)
        //{
        //    var slot = Timeslots.FirstOrDefault(t => t.StartTime == time);
        //    if (slot == null)
        //        throw new ArgumentException($"No timeslot found at given time {time.Value}");
        //}

        //public void AddEvent(Time time, Event @event)
        //{
        //    var slot = Timeslots.FirstOrDefault(t => t.StartTime == time);
        //    if (slot == null)
        //        throw new ArgumentException($"No timeslot found at given time {time.Value}");
        //}
    }
}
