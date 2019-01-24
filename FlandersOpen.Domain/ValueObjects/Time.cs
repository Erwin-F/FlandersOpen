using FlandersOpen.Domain.Extensions;
using FlandersOpen.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlandersOpen.Domain.ValueObjects
{
    public sealed class Time : ValueObject
    {
        public DateTime Value { get; }

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
            return new Time(Value.Hour, Value.Minute + minutes);
        }

        public static bool operator <=(Time t1, Time t2)
        {
            return t1.Value <= t2.Value;
        }

        public static bool operator >=(Time t1, Time t2)
        {
            return t1.Value >= t2.Value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString()
        {
            return Value.ToString("HH:mm");
        }
    }
}
