using System.ComponentModel.DataAnnotations;

namespace CRM_Escolar.Domains;

public class School
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(80)]
    [MinLength(3)]
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    public DateTime LastUpdatedAt { get; set; }

    public ICollection<Student>? Student { get; set; }
}
