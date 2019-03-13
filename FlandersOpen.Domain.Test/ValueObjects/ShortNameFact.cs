using FlandersOpen.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FlandersOpen.Domain.Test.ValueObjects
{    
    public class ShortNameFact
    {
        [Fact]
        public void ValidStringCreatesObject()
        {
            var shortname = new ShortName("Test");
            Assert.NotEmpty(shortname.Value);
        }

        [Fact]
        public void InvalidStringThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new ShortName("te lange tekst"));
        }
    }
}
