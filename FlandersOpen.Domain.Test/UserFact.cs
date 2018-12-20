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

        [Fact]
        public void RegisterSetsModificationDate()
        {
            var user = User.Register("test", "firstname", "lastname", "testpassword");

            Assert.False(user.ModificationDate == default(DateTime));
        }

        [Fact]
        public void UpdateModifiesUser()
        {
            var user = User.Register("test", "firstname", "lastname", "testpassword");

            var id = user.Id;

            user.Update("bla", "bla", "bla", "bla");

            Assert.True(user.Id == id);

            Assert.Equal("bla", user.Username);
            Assert.Equal("bla", user.FirstName);
            Assert.Equal("bla", user.LastName);
        }

        [Fact]
        public void UpdateModifiesPassword()
        {
            var user = User.Register("test", "firstname", "lastname", "testpassword");

            user.Update("bla", "bla", "bla", "bla");

            Assert.False(user.IsCorrectPassword("testpassword"));
            Assert.True(user.IsCorrectPassword("bla"));            
        }
    }
}
