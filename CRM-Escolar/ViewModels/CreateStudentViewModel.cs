using CRM_Escolar.Domains.Enums;
using CRM_Escolar.Domains;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using CRM_Escolar.Extensions;

namespace CRM_Escolar.ViewModels;

public class CreateStudentViewModel
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    public required string Name { get; set; }

    public IFormFile? ImageProfile { get; set; }

    [Required(ErrorMessage = "O CPF é obrigatório")]
    public required string Cpf { get; set; }

    [Required(ErrorMessage = "O telefone de emergência é obrigatório")]
    public required string EmergencePhone { get; set; }

    [Required(ErrorMessage = "A data de nascimento é obrigatória")]
    public required string DateOfBirth { get; set; }

    [Required(ErrorMessage = "O endereço é obrigatório")]
    public required string Address { get; set; }

    [Required(ErrorMessage = "A escola é obrigatória")]
    public required int SchoolId { get; set; }

    [Required(ErrorMessage = "A série é obrigatória")]
    public required SerieEnum Serie { get; set; }

    [Required(ErrorMessage = "O valor de matrícula é obrigatório")]
    public required double RegisterValue { get; set; }

    [Required(ErrorMessage = "O dia do pagamento é obrigatório")]
    public required string PaymentDay { get; set; }

    public Student CreateStudent()
    {
        if (string.IsNullOrEmpty(PaymentDay) || string.IsNullOrEmpty(DateOfBirth))
        {
            throw new InvalidOperationException("A Data de aniversário e a data de nascimento são obrigatórias!");
        }

        //data for date of birth
        string format = "yyyy/MM/dd";
        DateTime DateOfBirthDate;

        if (!DateTime.TryParseExact(DateOfBirth, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateOfBirthDate))
        {
            throw new HttpResponseException(400, "A Data de nascimento não esta em um formato válido!");
        }

        //data for register date
        DateTime registerDate = DateTime.UtcNow;

        return new Student
        {
            Name = Name,
            ImageProfile = "without image",
            Cpf = Cpf,
            EmergencePhone = EmergencePhone,
            DateOfBirth = new DateTime(DateOfBirthDate.Year, DateOfBirthDate.Month, DateOfBirthDate.Day),
            Address = Address,
            Serie = Serie,
            RegisterValue = RegisterValue,
            RegisterDate = new DateTime(registerDate.Year, registerDate.Month, registerDate.Day),
            PaymentDay = PaymentDay,
            SchoolId = SchoolId
        };
    }
}
