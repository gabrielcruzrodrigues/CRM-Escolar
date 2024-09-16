using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CRM_Escolar.Domains
{
    public class Illness
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        [MinLength(2)]
        public string? Name { get; set; }

        public string? Observation { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime LastUpdatedAt { get; set; }

        [JsonIgnore]
        public Student? Student { get; set; }
    }
}
