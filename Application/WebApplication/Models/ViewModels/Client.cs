using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Models.ViewModels
{
    public class Client
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-zА-Яа-я]+$", ErrorMessage ="Surname can consists only from Letters")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-zА-Яа-я]+$", ErrorMessage = "Name can consists only from Letters")]
        public string Surname { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-zА-Яа-я]+$", ErrorMessage = "FatherName can consists only from Letters")]
        public string FatherName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }    
        [Required]    
        public bool Male { get; set; }
        [Required]
        [RegularExpression("^[A-Z]{2}$", ErrorMessage = "Passport series should consists of 2 capital Latin letters")]
        public string PassportSeries { get; set; }
        [Required]
        [RegularExpression("^[0-9]{7}$", ErrorMessage = "Passport number should consists of 7 numbers")]
        public string PassportNumber { get; set; }
        [Required]
        public string IssuedBy { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime IssueDate { get; set; }
        [Required]
        public string IdentificationNumber { get; set; }
        [Required]
        public string BirthPlace { get; set; }
        [Required]
        public string ResidenceActualPlace { get; set; }
        [Required]
        public string ResidenceActualAddress { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string HomePhoneNumber { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string MobilePhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string ResidenceAddress { get; set; }
        [Required]
        public string MaritalStatus { get; set; }
        [Required]
        public string Citizenship { get; set; }
        [Required]
        public string Disability { get; set; }
        [Required]
        public bool Pensioner { get; set; }
        [DataType(DataType.Currency)]
        public decimal MonthlyIncome { get; set; }


        public IEnumerable<string> Towns { get; set; }
        public IEnumerable<string> Citizenships { get; set; }
        public IEnumerable<string> MartialStatuses { get; set; }
        public IEnumerable<string> DisabilityStatuses { get; set; }
    }
}