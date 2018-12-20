using System;
using System.Linq;

namespace FlandersOpen.Domain.Entities
{
    public class User : IEntity
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
        }

        public Guid Id { get; private set; }
        public DateTime ModificationDate { get; private set; }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Username { get; private set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }

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

        private void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password)) return;

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                PasswordSalt = hmac.Key;
                PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }

        public bool IsCorrectPassword(string password)
        {
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
    }
}



/*

    public static class Security
    {
        private const string ApplicationKey = "FlandersOpenShizzle2017";

        public static bool IsValidAppKey(string appKey)
        {
            if (string.IsNullOrWhiteSpace(appKey) || appKey.Length < 4) return false;

            var salt1 = appKey.Substring(0, 1);
            var salt2 = appKey.Substring(1, 1);
            var iteraions = appKey.Substring(2, 1);

            if (!int.TryParse(salt1, out int salt1Key) ||
                !int.TryParse(salt2, out int salt2Key) ||
                !int.TryParse(iteraions, out int iterationCount)) return false;

            var generatedAppKey = GenerateSpecificAppKey(salt1Key, salt2Key, iterationCount);
            return generatedAppKey == appKey;
        }

        public static string GenerateRandomAppKey()
        {
            var salt1Key = RandomNumberInRange(0, 9);
            var salt2Key = RandomNumberInRange(0, 9);
            var iterationCount = RandomNumberInRange(1, 9);

            return GenerateSpecificAppKey(salt1Key, salt2Key, iterationCount);
        }

        public static string GenerateSpecificAppKey(int salt1Key, int salt2Key, int iterationCount)
        {
            var salt1 = GetSpecificSaltByKey(salt1Key);
            var salt2 = GetSpecificSaltByKey(salt2Key);

            var password = $"{ApplicationKey}={Convert.ToBase64String(salt2)}";
            var hash = CreateHash(password, salt1, iterationCount);

            return $"{salt1Key}{salt2Key}{iterationCount}{hash}";
        }

        public static int RandomNumberInRange(int min, int max)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                var scale = uint.MaxValue;
                while (scale == uint.MaxValue)
                {
                    // Get four random bytes.
                    var fourBytes = new byte[4];
                    rng.GetBytes(fourBytes);

                    // Convert that into an uint.
                    scale = BitConverter.ToUInt32(fourBytes, 0);
                }

                // Add min to the scaled difference between max and min.
                return (int) (min + (max - min) *
                              (scale / (double) uint.MaxValue));
            }
        }

        public static string GetRandomSalt()
        {
            var salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return Convert.ToBase64String(salt);
        }

        public static string CreateHash(string password, byte[] salt, int iterations)
        {
            var iterationCount = iterations * 10000;

            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: iterationCount,
                numBytesRequested: 256 / 8));
            return hashed;
        }

        public static byte[] GetSpecificSaltByKey(int key)
        {
            string salt;

            switch (key)
            {
                case 0:
                    salt = "XAtt+3i2hIyOpmTkQ8Gu+Q==";
                    break;
                case 1:
                    salt = "puvk2Lgjzy8GIkjx9kA0Uw==";
                    break;
                case 2:
                    salt = "NRzgfT+YWD9SqT6IbQEdGA==";
                    break;
                case 3:
                    salt = "nli5zzPMmSKd5qpbQyX3iA==";
                    break;
                case 4:
                    salt = "2sJyN2tlAO1YhVxY3WaXxw==";
                    break;
                case 5:
                    salt = "uU7PJbOgXg1wCz+3VP3yiA==";
                    break;
                case 6:
                    salt = "08E1v/20KTHm2yGIdVE4cQ==";
                    break;
                case 7:
                    salt = "JuJk1TN8jruEeUt78nUTGQ==";
                    break;
                case 8:
                    salt = "8kkrFD1MZva3jFkPnnj99A==";
                    break;
                default:
                    salt = "8kkrFD1MZva3jFkPnnj99A==";
                    break;
            }
            return Convert.FromBase64String(salt);
        }
    }
 */
