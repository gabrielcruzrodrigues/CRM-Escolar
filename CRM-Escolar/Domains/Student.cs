using CRM_Escolar.Domains.Enums;
using System.ComponentModel.DataAnnotations;

namespace CRM_Escolar.Domains
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Name { get; set; }

        public string? ImageProfile { get; set; }

        [Required]
        [StringLength(11)]
        public string Cpf { get; set; }

        [Required]
        [StringLength(13)]
        public string EmergencePhone { get; set; }

        private DateTime _dateOfBirth;
        [Required]
        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set => _dateOfBirth = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }

        [Required]
        public string Address { get; set; }

        [Required]
        public int SchoolId { get; set; }

        [Required]
        public SerieEnum Serie { get; set; }

        [Required]
        public double RegisterValue { get; set; }

        private DateTime _registerDate;
        [Required]
        public DateTime RegisterDate
        {
            get => _registerDate;
            set => _registerDate = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }

        [Required]
        public string PaymentDay { get; set; }

        private DateTime _createdAt;
        [Required]
        public DateTime CreatedAt
        {
            get => _createdAt;
            set => _createdAt = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }

        private DateTime _lastUpdatedAt;
        public DateTime LastUpdatedAt
        {
            get => _lastUpdatedAt;
            set => _lastUpdatedAt = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }

        public List<string>? Allergies { get; set; }
        public ICollection<Medication>? Medications { get; set; }
        public ICollection<Illness>? Illnesses { get; set; }
        public ICollection<Responsible> Responsibles { get; set; }

        //propriedades de navegação
        public School School { get; set; }

        public Student()
        {
            CreatedAt = DateTime.UtcNow;
            LastUpdatedAt = DateTime.UtcNow;
        }

        public Student(string name, string imageProfile, string cpf, string emergencePhone,
               DateTime dateOfBirth, string address, SerieEnum serie, double registerValue,
               DateTime registerDate, string paymentDay)
        {
            Name = name;
            ImageProfile = imageProfile;
            Cpf = cpf;
            EmergencePhone = emergencePhone;
            DateOfBirth = DateTime.SpecifyKind(dateOfBirth, DateTimeKind.Utc);
            Address = address;
            Serie = serie;
            RegisterValue = registerValue;
            RegisterDate = DateTime.SpecifyKind(registerDate, DateTimeKind.Utc);
            PaymentDay = paymentDay;
            CreatedAt = DateTime.UtcNow;
            LastUpdatedAt = DateTime.UtcNow;
        }
    }
}
