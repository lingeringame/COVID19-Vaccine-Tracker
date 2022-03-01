using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid_Vaccine_Tracker.Business_Objects
{
    public class VaccineRecord
    {
        public string extract_type; //15
        public string vaccine_event_id; //10
        public DateTime administration_date; 
        public string vaccine_type; // 150
        public string vaccine_product; //75
        public string vaccine_manufacturer;//35
        public string lot_number;//10
        public string vaccine_experation_date;
        public string vaccine_admin_site;//50
        public string vaccine_admin_route;//35
        public string dose_number;//3
        public string vaccine_series_complete;//7
        public string responsible_organization;//100
        public string administrated_location;//100
        public string vtcks_pin;//6
        public string administered_loc_type;//35
        public string admin_street_address;//100
        public string admin_city;//100
        public string admin_county;//100
        public string admin_state;//50
        public string admin_zip;//5
        public string admin_suffix;//3
        public string comorbidity_status;//7
        public string serology_results;//7
        public string pprl;//10

        public string Extract_Type
        {
            get => this.extract_type;
            set
            {
                (bool, string) validData = InputValidator.IsValidStringData(value);

                if (value.Length > 15)
                    throw new Exception("Extract type must be 15 characters or less");
                else if (string.IsNullOrEmpty(value))
                    throw new Exception("Extract type cannot be empty or null");
                else if (!validData.Item1)
                    throw new Exception(validData.Item2);
                else
                    this.extract_type = value;
            }
        }
        public string Vaccine_Event_Id
        {
            get => this.vaccine_event_id;
            set
            {
                try
                {
                    (bool, string) validData = InputValidator.IsValidVaccineEvent(value);

                    if (value.Length > 10)
                        throw new Exception("Vaccine Event must 10 characters");
                    else if (string.IsNullOrEmpty(value))
                        throw new Exception("Vaccine Event Id cannot be empty or null");
                    else if (!validData.Item1)
                        throw new Exception(validData.Item2);
                    else
                        this.vaccine_event_id = value;
                }
                catch(Exception ex)
                { throw ex; }
            }
        }
    }
}
