using System;
using FlandersOpen.Domain.Entities;
using Xunit;

namespace FlandersOpen.Domain.Test
{
    public class UserFact
    {
        [Fact]
        public void RegisterReturnsNewUser()
        {
            var user = User.Register("test", "firstname", "lastname", "testpassword");

            Assert.False(user.Id == Guid.Empty);

            Assert.Equal("test", user.Username);
            Assert.Equal("firstname", user.FirstName);
            Assert.Equal("lastname", user.LastName);

            Assert.NotEmpty(user.PasswordHash);
            Assert.NotEmpty(user.PasswordSalt);
        }

        [Fact]
        public void VerifyPasswordReturnsTrue()
        {
            var user = User.Register("test", "firstname", "lastname", "testpassword");

            Assert.True(user.IsCorrectPassword("testpassword"));
        }

        [Fact]
        public void VerifyPasswordReturnsFalse()
        {
            var user = User.Register("test", "firstname", "lastname", "testpassword");

            Assert.False(user.IsCorrectPassword("testpassword."));
        }

        [Fact]
        public void HasSameUsernameReturnsTrue()
        {
            var user = User.Register("test", "firstname", "lastname", "testpassword");

            Assert.True(user.HasSameUsername("test"));
        }

        [Fact]
        public void HasSameUsernameReturnsFalse()
        {
            var user = User.Register("test", "firstname", "lastname", "testpassword");

            Assert.False(user.HasSameUsername("test1"));
        }

        [Fact]
        public void HasDifferentUsernameReturnsTrue()
        {
            var user = User.Register("test", "firstname", "lastname", "testpassword");

            Assert.True(user.HasDifferentUsername("test1"));
        }

        [Fact]
        public void HasDifferentUsernameReturnsFalse()
        {
            var user = User.Register("test", "firstname", "lastname", "testpassword");

            Assert.False(user.HasDifferentUsername("test"));
        }
    }
}
