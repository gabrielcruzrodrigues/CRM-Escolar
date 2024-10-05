using CRM_Escolar.Domains;
using System.ComponentModel.DataAnnotations;

namespace CRM_Escolar.ViewModels
{
    public class CreateSchoolViewModel
    {
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }

        public School createSchool()
        {
            return new School
            {
                Name = Name,
                Phone = Phone,
                Address = Address,
                CreatedAt = DateTime.UtcNow,
                LastUpdatedAt = DateTime.UtcNow
            };
        }
    }
}
