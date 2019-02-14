using System;
using System.Collections.Generic;
using System.Text;
using FlandersOpen.Domain.ValueObjects;
using Xunit;

namespace FlandersOpen.Domain.Test.ValueObjects
{
    public class TimeFact
    {
        [Fact]
        public void CreateReturnsNewTime()
        {
            var time = new Time(1,1);

            Assert.Equal(1, time.Value.Hour);
            Assert.Equal(1, time.Value.Minute);
            Assert.Equal(1, time.Value.Day);
            Assert.Equal(1, time.Value.Month);
            Assert.Equal(2000, time.Value.Year);
        }

        [Fact]
        public void AddTimeReturnsNewTime()
        {
            var time = new Time(1, 1);
            var newTime = time.AddMinutes(1);

            Assert.NotEqual(time, newTime);
        }

        [Fact]
        public void AddTimeReturnsCorrectNewTime()
        {
            var time = new Time(1, 1);
            var newTime = time.AddMinutes(61);

            Assert.Equal(2, newTime.Value.Hour);
            Assert.Equal(2, newTime.Value.Minute);
            Assert.Equal(1, newTime.Value.Day);
            Assert.Equal(1, newTime.Value.Month);
            Assert.Equal(2000, newTime.Value.Year);
        }

        [Fact]
        public void ToStringReturnsHHmm()
        {
            var time = new Time(14, 57);

            Assert.Equal("14:57", time.ToString());
        }

        [Fact]
        public void ToStringReturnsHHmmWithLeadingZeros()
        {
            var time = new Time(4, 5);

            Assert.Equal("04:05", time.ToString());
        }

        [Fact]
        public void EndOfDayReturnsTrue()
        {
            var time = new Time(23, 59);

            Assert.True(time.IsEndOfDay());
        }

        [Theory]
        [InlineData(23,58)]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(11, 59)]
        public void EndOfDayReturnsFalse(int hour, int minutes)
        {
            var time = new Time(hour, minutes);

            Assert.False(time.IsEndOfDay());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(109)]
        public void IsTimeAvailableInDayReturnsTrue(int minutes)
        {
            var time = new Time(22, 10);

            Assert.True(time.IsTimeAvailableInDay(minutes));
        }

        [Theory]
        [InlineData(1000)]
        [InlineData(110)]
        [InlineData(123)]
        [InlineData(500)]
        public void IsTimeAvailableInDayReturnsFalse(int minutes)
        {
            var time = new Time(22, 10);

            Assert.False(time.IsTimeAvailableInDay(minutes));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(25)]
        public void HourOutOfRangeThrowsException(int hours)
        {
            Assert.Throws<ArgumentException>(() => new Time(hours, 0));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(61)]
        public void MinuteOutOfRangeThrowsException(int minutes)
        {
            Assert.Throws<ArgumentException>(() => new Time(0, minutes));
        }

        [Fact]
        public void LargerOrEqualReturnsTrue()
        {
            var time1 = new Time(2, 1);
            var time2 = new Time(1, 1);
            var time3 = new Time(2, 1);

            Assert.True(time1 >= time2);
            Assert.True(time1 >= time3);
        }

        [Fact]
        public void LargerOrEqualReturnsFalse()
        {
            var time1 = new Time(1, 1);
            var time2 = new Time(2, 2);

            Assert.False(time1 >= time2);
        }

        [Fact]
        public void SmallerOrEqualReturnsTrue()
        {
            var time1 = new Time(2, 1);
            var time2 = new Time(1, 2);
            var time3 = new Time(2, 1);

            Assert.True(time1 >= time2);
            Assert.True(time1 >= time3);
        }

        [Fact]
        public void SmallerOrEqualReturnsFalse()
        {
            var time1 = new Time(1, 1);
            var time2 = new Time(2, 2);

            Assert.False(time1 >= time2);
        }

        [Fact]
        public void LargerReturnsTrue()
        {
            var time1 = new Time(2, 1);
            var time2 = new Time(1, 2);

            Assert.True(time1 > time2);
        }

        [Fact]
        public void LargerReturnsFalse()
        {
            var time1 = new Time(1, 1);
            var time2 = new Time(1, 2);

            Assert.False(time1 > time2);
        }

        [Fact]
        public void SmallerReturnsTrue()
        {
            var time1 = new Time(2, 1);
            var time2 = new Time(1, 2);

            Assert.True(time1 > time2);
        }

        [Fact]
        public void SmallerReturnsFalse()
        {
            var time1 = new Time(1, 1);
            var time2 = new Time(2, 2);

            Assert.False(time1 > time2);
        }
    }
}
