namespace ChallengeProject.Models.Entities
{
    public class Student
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public string Email { get; set; } = String.Empty;

        public string Phone { get; set; } = String.Empty;

        public Student() {}

        public Student(string name, string email, string phone)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Phone = phone;
        }

    }
}
