using CRM_Escolar.Domains.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CRM_Escolar.Domains
{
    public class Responsible
    {
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        [MinLength(2)]
        public string? Name { get; set; }

        [Required]
        [StringLength(13)]
        [MinLength(11)]
        public string? Phone { get; set; }

        [Required]
        public ResponsibleTypeEnum Type { get; set; }

        [Required]
        [StringLength(11)]
        public string? Cpf { get; set; }

        [Required]
        [StringLength(50)]
        public string? Address { get; set; }

        public string? Email { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime LastUpdatedAt { get; set; }


        //navigation propertie
        public ICollection<Student> Students { get; set; }
    }
}
