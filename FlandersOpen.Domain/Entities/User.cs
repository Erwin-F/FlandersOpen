using System;
using System.Linq;
using FlandersOpen.Domain.SeedWork;

namespace FlandersOpen.Domain.Entities
{
    public class User : Entity
    {
        private User() {}

        protected User(string username, string firstname, string lastname, string password)
        {
            Id = Guid.NewGuid();
            Username = username;
            FirstName = firstname;
            LastName = lastname;
            SetPassword(password);
            ModificationDate = DateTime.Now;
            Enabled = false;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Username { get; private set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }
        public bool Enabled { get; private set; }

        public static User Register(string username, string firstname, string lastname, string password)
        {
            return new User(username, firstname, lastname, password);
        }

        public bool HasDifferentUsername(string username)
        {
            return Username != username;
        }

        public bool HasSameUsername(string username)
        {
            return Username == username;
        }

        public void Update(string username, string firstname, string lastname, string password)
        {
            Username = username;
            FirstName = firstname;
            LastName = lastname;

            SetPassword(password);
            ModificationDate = DateTime.Now;
        }

        public void Enable()
        {
            Enabled = true;
        }

        public bool IsEnabledAndHasCorrectPassword(string password)
        {
            if (!Enabled) return false;

            if (PasswordHash.Length != 64) throw new ArgumentException("User has a corrupt password.");
            if (PasswordSalt.Length != 128) throw new ArgumentException("User has a corrupt password.");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                if (computedHash.Where((t, i) => t != PasswordHash[i]).Any())
                {
                    return false;
                }
            }

            return true;
        }

        private void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password)) return;

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                PasswordSalt = hmac.Key;
                PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }
    }
}