using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CRM_Escolar.Domains
{
    public class Medication
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        [MinLength(1)]
        public string? Name { get; set; }

        [Required]
        public ICollection<TimeOnly>? Times { get; set; }

        [Required]
        public ICollection<string>? Dosage { get; set; }

        [Required]
        public int StudentId { get; set; }


        [JsonIgnore]
        public Student Student { get; set; }

    }
}
