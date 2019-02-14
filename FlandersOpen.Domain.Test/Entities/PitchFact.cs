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
            var pitch = Pitch.Create("test", 1, 1);

            Assert.Empty(pitch.Timeslots);
        }

        [Fact]
        public void AddTimeslotAddsAdditional()
        {
            var pitch = Pitch.Create("test", 1, 1);
            pitch.AddTimeslot(new Time(1, 1), 10);

            Assert.Single(pitch.Timeslots);
        }
    }
}
