namespace FlandersOpen.Domain.Entities
{
    public class User
    {
        private User() {}

        protected User(string username, string firstname, string lastname, string password)
        {
            Username = username;
            FirstName = firstname;
            LastName = lastname;
            SetPassword(password);
        }

        public int Id { get; private set; }
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
        }

        private void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password)) return;

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                PasswordHash = hmac.Key;
                PasswordSalt = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }

    }
}


/*


public class Student : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }

        private readonly IList<Enrollment> _enrollments = new List<Enrollment>();
        public virtual IReadOnlyList<Enrollment> Enrollments => _enrollments.ToList();
        public virtual Enrollment FirstEnrollment => GetEnrollment(0);
        public virtual Enrollment SecondEnrollment => GetEnrollment(1);

        private readonly IList<Disenrollment> _disenrollments = new List<Disenrollment>();
        public virtual IReadOnlyList<Disenrollment> Disenrollments => _disenrollments.ToList();

        protected Student()
        {
        }

        public Student(string name, string email)
            : this()
        {
            Name = name;
            Email = email;
        }

        public virtual Enrollment GetEnrollment(int index)
        {
            if (_enrollments.Count > index)
                return _enrollments[index];

            return null;
        }

        public virtual void RemoveEnrollment(Enrollment enrollment, string comment)
        {
            _enrollments.Remove(enrollment);

            var disenrollment = new Disenrollment(enrollment.Student, enrollment.Course, comment);
            _disenrollments.Add(disenrollment);
        }

        public virtual void Enroll(Course course, Grade grade)
        {
            if (_enrollments.Count >= 2)
                throw new Exception("Cannot have more than 2 enrollments");

            var enrollment = new Enrollment(this, course, grade);
            _enrollments.Add(enrollment);
        }
    }
 */
