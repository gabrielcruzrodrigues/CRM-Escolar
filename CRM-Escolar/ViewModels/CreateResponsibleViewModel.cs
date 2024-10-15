using CRM_Escolar.Domains.Enums;
using CRM_Escolar.Domains;
using System.ComponentModel.DataAnnotations;

namespace CRM_Escolar.ViewModels
{
    public class CreateResponsibleViewModel
    {
        [Required(ErrorMessage = "The name is required!")]
        [MinLength(3, ErrorMessage = "The min length for name is 3 characteres")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "The name is required!")]
        [MinLength(9, ErrorMessage = "The min legth for valid phone number is 9 numbers")]
        public required string Phone { get; set; }

        [Required(ErrorMessage = "The type cannot to be null")]
        public ResponsibleTypeEnum Type { get; set; }

        [MinLength(11, ErrorMessage = "The min legth for valid CPF is 11 characteres")]
        public string? Cpf { get; set; }

        [Required(ErrorMessage = "The name is required!")]
        public required string Address { get; set; }

        [EmailAddress(ErrorMessage = "The email is invalid!")]
        public string? Email { get; set; }

        public Responsible CreateResponsible()
        {
            return new Responsible
            {
                Name = Name,
                Phone = Phone,
                Type = Type,
                Cpf = Cpf ?? "",
                Address = Address,
                Email = Email ?? "",
                CreatedAt = DateTime.UtcNow,
                LastUpdatedAt = DateTime.UtcNow
            };
        }
    }
}
