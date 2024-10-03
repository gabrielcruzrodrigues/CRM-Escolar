using CRM_Escolar.Domains.Enums;
using CRM_Escolar.Domains;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using CRM_Escolar.Extensions;

namespace CRM_Escolar.ViewModels;

public class CreateStudentViewModel
{
    public string? Name { get; set; }
    public string? ImageProfile { get; set; }
    public string? Cpf { get; set; }
    public string? EmergencePhone { get; set; }
    public string? DateOfBirth { get; set; }
    public string? Address { get; set; }
    public SerieEnum Serie { get; set; }
    public double RegisterValue { get; set; }
    public DateOnly PaymentDay { get; set; }

    public Student CreateStudent()
    {
        if (DateOfBirth is null)
        {
            throw new InvalidOperationException("A Data de aniversário é obrigatória!");
        }

        //data for date of birth
        string format = "yyyy/MM/dd";
        DateTime myDate;

        if (!DateTime.TryParseExact(DateOfBirth, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out myDate))
        {
            throw new HttpResponseException(400, "A data não é válida!");
        }

        //data for register date
        DateTime registerDate = DateTime.UtcNow;

        return new Student
        (
            Name,
            ImageProfile,
            Cpf,
            EmergencePhone,
            new DateOnly(myDate.Year, myDate.Month, myDate.Day),
            Address,
            Serie,
            RegisterValue,
            new DateOnly(registerDate.Year, registerDate.Month, registerDate.Day),
            PaymentDay
        );
    }
}
