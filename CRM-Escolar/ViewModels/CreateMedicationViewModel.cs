using CRM_Escolar.Domains;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CRM_Escolar.ViewModels
{
    public class CreateMedicationViewModel
    {
        public required string Name { get; set; }
        public required ICollection<TimeOnly> Times { get; set; }
        public required ICollection<string> Dosage { get; set; }
        public Student? Student { get; set; }
    }
}
