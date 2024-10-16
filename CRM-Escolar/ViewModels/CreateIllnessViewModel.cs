using CRM_Escolar.Domains;
using System.ComponentModel.DataAnnotations;

namespace CRM_Escolar.ViewModels
{
    public class CreateIllnessViewModel
    {
        [Required(ErrorMessage = "The name is required!")]
        [MinLength(3, ErrorMessage = "The min caracteres for name is 3!")]
        public required string Name { get; set; }

        public string? Observation { get; set; }

        [Required(ErrorMessage = "The id of student is required")]
        public required int StudentId { get; set; }

        public Illness CreateIlless()
        {
            return new Illness
            {
                Name = Name,
                Observation = Observation,
                StudentId = StudentId,
                CreatedAt = DateTime.UtcNow,
                LastUpdatedAt = DateTime.UtcNow
            };
        }
    }
}