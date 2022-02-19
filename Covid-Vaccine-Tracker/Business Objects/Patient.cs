using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Covid_Vaccine_Tracker.Business_Objects
{
    public class Patient
    {
        // Data Annotations are between the []
        // they are data validations for the class
        // makes sure that the correct data is entered
        // into the class properties directly below
        [Required]
        [MaxLength(10, ErrorMessage = "Patient Id must be 10 digits long")]
        [RegularExpression(@"\D\D\D\D\D\D\D[a-zA-Z][a-zA-Z][a-zA-Z]", ErrorMessage = "Patient Id must be in 1234567AAA format")]
        public string Id { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "First name must be 20 characters or less")]
        [RegularExpression(@"[a-zA-Z]{1,20}$", ErrorMessage = "First name characters can only contain a-z letters")]
        public string First_name { get; set; }

        [Required]
        [MaxLength(35, ErrorMessage = "Middle name must be 35 characters or less")]
        [RegularExpression(@"[a-zA-Z]{1,35}$", ErrorMessage = "Middle name characers can only contain a-z letters")]
        public string Middle_name { get; set; }

        [Required]
        [MaxLength(35, ErrorMessage = "Last name must be 35 characters or less")]
        [RegularExpression(@"[a-zA-Z]{1,35}$", ErrorMessage = "Last name characters can only contain a-z letters")]
        public string Last_name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date_of_birth { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Street address must be 100 characters or less")]
        [RegularExpression(@"[^{1,5}?0-9\sa-zA-Z]{1,100}$", ErrorMessage = "Address must contain a 1-5 digits for building number followed by street name")]
        public string Street_address { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "City must be 100 characters or less")]
        [RegularExpression(@"[a-zA-Z]{1,100}$", ErrorMessage = "City name characters can only contain a-z letters")]
        public string City { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "County must be 100 characters or less")]
        [RegularExpression(@"[a-zA-Z]{1,100}$", ErrorMessage = "County chacters must contain a-z letters only")]
        public string County { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "State must be 50 characters or less")]
        [RegularExpression(@"[a-zA-Z]{1,50}$", ErrorMessage = "State characters must contain only a-z letters")]
        public string State { get; set; }

        [Required]
        [StringLength(5)]
        [RegularExpression(@"\D{5}?")]
        public string Zip_code { get; set; }

        [Required]
        [MaxLength(75, ErrorMessage = "Race must be 75 characters or less")]
        [RegularExpression(@"[a-zA-Z]{1,75}$", ErrorMessage = "Race characters must contain only a-z letters")]
        public string Race1 { get; set; }

        [MaxLength(75, ErrorMessage = "Race must be 75 characters or less")]
        [RegularExpression(@"[a-zA-Z]{1,75}$", ErrorMessage = "Race characters must contain only a-z letters")]
        public string Race2 { get; set; }

        [MaxLength(150, ErrorMessage = "Ethnicity must be 150 characters or less")]
        [RegularExpression(@"[a-zA-Z]{1,150}$", ErrorMessage = "Ethnicity characters must contain only a-z letters")]
        public string Ethnicity { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Sex must be 20 characters or less")]
        [RegularExpression(@"[a-zA-Z]{1,10}$", ErrorMessage = "Sex chacters must contain only a-z letters")]
        public string Sex { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Extract must be 15 characters or less")]
        [RegularExpression(@"[a-zA-Z]{1,15}$",ErrorMessage ="Extract character must contain only a-z letters")]
        public string Extract_Type { get; set; }

        // method to copy a Patient object allows you to assign a copy of a patient to another patient obj
        public Patient CopyPatient()
        {
            return (Patient)this.MemberwiseClone();
        }
    }
}
