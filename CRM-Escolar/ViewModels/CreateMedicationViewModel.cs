﻿using CRM_Escolar.Domains;
using System.ComponentModel.DataAnnotations;

namespace CRM_Escolar.ViewModels
{
    public class CreateMedicationViewModel
    {
        [Required(ErrorMessage = "The name of medication can't to be null")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "The times of medication can't to be null")]
        public required IList<TimeOnly> Times { get; set; }

        [Required(ErrorMessage = "The dosage of medication can't to be null")]
        public required IList<string> Dosage { get; set; }

        [Required(ErrorMessage = "The id of student can't to be null")]
        public required int StudentId { get; set; }

        public Medication CreateMedicationObj()
        {
            return new Medication
            {
                Name = Name,
                Times = Times,
                Dosage = Dosage,
                StudentId = StudentId
            };
        }
    }
}
