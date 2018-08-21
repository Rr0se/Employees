﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiToProject.InputModels
{
    public class InputEmployeeModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public int Rating { get; set; }
        public string OverallTenure { get; set; }        
    }

    public class EmployeeLanguageInputModel
    {
        public Guid EmployeeId { get; set; }
        public Guid LanguageId { get; set; }

        [Required(ErrorMessage = "Uzupełnij pole.")]
        [Range(1, 3, ErrorMessage = "Oceń w skali od 1 do 3")]
        public int SpeakingLevel { get; set; }

        [Required(ErrorMessage = "Uzupełnij pole.")]
        [Range(1, 3, ErrorMessage = "Oceń w skali od 1 do 3")]
        public int WritingLevel { get; set; }

        [Required(ErrorMessage = "Uzupełnij pole.")]
        [Range(1, 3, ErrorMessage = "Oceń w skali od 1 do 3")]
        public int ReadingLevel { get; set; }
    }
}
