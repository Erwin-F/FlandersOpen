using FlandersOpen.Application.Validation;
using Xunit;

namespace FlandersOpen.Application.Test
{
    public class StringValidationRuleFact
    {
        public string TestString { get; set; }


        [Fact]
        public void ValidationRuleNotEmptyReturnsTrue()
        {
            TestString = "test";

            var rule = ValidationRule.For(() => TestString).NotEmpty();

            Assert.True(rule.IsValid);
        }

        [Fact]
        public void ValidationRuleNotEmptyReturnsFalse()
        {
            TestString = null;

            var rule = ValidationRule.For(() => TestString).NotEmpty();

            Assert.False(rule.IsValid);
        }
    }
}
