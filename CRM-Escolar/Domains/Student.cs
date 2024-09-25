﻿using CRM_Escolar.Domains.Enums;
using System.ComponentModel.DataAnnotations;

namespace CRM_Escolar.Domains
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string? Name { get; set; }

        public string? ImageProfile { get; set; }
        public string? Cpf { get; set; }
        public Responsible? Mother { get; set; }
        public Responsible? Father { get; set; }

        [Required]
        [StringLength(13)]
        public string? EmergencePhone { get; set; }

        [Required]
        public DateOnly? DateOfBirth { get; set; }

        [Required]
        public string? Address { get; set; }

        public IEnumerable<string>? Allergies { get; set; }
        public IEnumerable<Medication>? Medications { get; set; }
        public IEnumerable<Illness>? Illnesses { get; set; }

        [Required]
        public School? School { get; set; }

        [Required]
        public SerieEnum Serie { get; set; }

        [Required]
        public double RegisterValue { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; }

        [Required]
        public DateOnly PaymentDay { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime LastUpdatedAt { get; set; }
    }
}