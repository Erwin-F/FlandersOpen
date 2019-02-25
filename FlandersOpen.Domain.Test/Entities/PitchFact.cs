using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlandersOpen.Domain.Entities;
using FlandersOpen.Domain.ValueObjects;
using Xunit;

namespace FlandersOpen.Domain.Test.Entities
{
    public class PitchFact
    {
        [Fact]
        public void CreatePitchHasEmptyTimeslots()
        {
            var pitch = Pitch.Build("test", 1, 1);

            Assert.Empty(pitch.Timeslots);
        }

        [Fact]
        public void AddTimeslotAddsAdditional()
        {
            var pitch = Pitch.Build("test", 1, 1);
            pitch.AddTimeslot(new Time(1, 1), 10);

            Assert.Single(pitch.Timeslots);
        }

        [Fact]
        public void AddContinuousTimeslotAdds2Timeslots()
        {
            var pitch = Pitch.Build("test", 1, 1);
            pitch.AddContinuousTimeslots(new Time(9, 30), new Time(10, 30), 29);

            Assert.Equal(2, pitch.Timeslots.Count);
            Assert.Equal("09:30", pitch.Timeslots[0].StartTime.ToString());
            Assert.Equal("09:59", pitch.Timeslots[0].EndTime.ToString());
            Assert.Equal("10:00", pitch.Timeslots[1].StartTime.ToString());
            Assert.Equal("10:29", pitch.Timeslots[1].EndTime.ToString());
        }
    }
}
