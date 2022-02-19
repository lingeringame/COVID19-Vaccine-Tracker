// Covid Vax Tracker - VaccineRecord_View Class
// by Zachary Palmer 2/15/2022
///<summary>
/// This class holds the values for the Joined Patient, PPRLs, and Vaccine_Records tables.
/// It is used by the Provider user type it allows Identifying Patient info to be displayed with Vax info
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid_Vaccine_Tracker.Business_Objects
{
    public class Identifying_VaccineRecord
    {
        // need to test dataannotations and then add
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public DateTime Date_of_Birth { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Extract_Type { get; set; }
        public string PPRL { get; set; }
        public string Vaccine_Event_Id { get; set; }
        public DateTime Administration_Date { get; set; }
        public string Vaccine_Type { get; set; }
        public string Dose_Number { get; set; }
        public string Company { get; set; }
    }
}
