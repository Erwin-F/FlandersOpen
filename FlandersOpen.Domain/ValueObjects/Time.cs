using FlandersOpen.Domain.Extensions;
using FlandersOpen.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlandersOpen.Domain.ValueObjects
{
    public sealed class Time : ValueObject
    {
        private Time()
        {
            Value = new DateTime(2000, 1, 1, 0, 0, 0);
        }

        public DateTime Value { get; private set; }

        public Time(int hour, int minutes)
        {
            if (!hour.IsInHourRange())
                throw new ArgumentException("Needs to be in range 0 - 24", nameof(hour));

            if (!minutes.IsInMinuteRange())
                throw new ArgumentException("Needs to be in range 0 - 60", nameof(minutes));

            Value = new DateTime(2000, 1, 1, hour, minutes, 0);
        }
        
        public Time AddMinutes(int minutes)
        {
            var newTime = Value.AddMinutes(minutes);

            return new Time(newTime.Hour, newTime.Minute);
        }

        public static bool operator <=(Time t1, Time t2)
        {
            return t1.Value <= t2.Value;
        }

        public static bool operator <(Time t1, Time t2)
        {
            return t1.Value < t2.Value;
        }

        public static bool operator >=(Time t1, Time t2)
        {
            return t1.Value >= t2.Value;
        }

        public static bool operator >(Time t1, Time t2)
        {
            return t1.Value > t2.Value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString()
        {
            return Value.ToString("HH:mm");
        }

        public bool IsEndOfDay()
        {
            return Value.Hour == 23 && Value.Minute == 59;
        }

        public bool IsTimeAvailableInDay(int minutes)
        {
            var time = Value.AddMinutes(minutes);

            return time.Day == 1;
        }
    }
}
