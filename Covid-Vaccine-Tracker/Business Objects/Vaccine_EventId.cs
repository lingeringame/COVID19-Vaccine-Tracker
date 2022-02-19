using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Covid_Vaccine_Tracker.Business_Objects
{
    public class Vaccine_EventId
    {
        [Required]
        [MaxLength(10,ErrorMessage ="Vaccine event id must be 20 characters or less")]
        [RegularExpression(@"\D{7}?\w{3}?", ErrorMessage = "Invalid format, Vaccine event id must be 7 digits followed by 3 letters a-z")]
        public string Vax_Event_Id { get; set; }

        [Required]
        [MaxLength(10,ErrorMessage ="Patient id must be 20 characters or less")]
        [RegularExpression(@"\D{7}?\w{3}?", ErrorMessage = "Invalid format, Patient id must be 7 digits followed by 3 letters a-z")]
        public string PPRL { get; set; }
    }
}
