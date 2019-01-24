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
        }

        public string Name { get; private set; }
        public int Number { get; private set; }
        public int OrderNumber { get; private set; }

        public List<Timeslot> Timeslots { get; private set; }

        public static Pitch Add(string name, int number, int orderNumber)
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

        public void AddTimeslot(Time time, int duration)
        {
            if (Timeslots.Any(t => t.InConflict(time)))
                throw new ArgumentException($"Time {time.Value} in conflict with existing timeslot");

            var slot = new Timeslot(Id, time, duration);
            Timeslots.Add(slot);
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
