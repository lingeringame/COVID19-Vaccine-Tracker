using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid_Vaccine_Tracker.Business_Objects
{
    public class HealthCareProvider
    {




        public HealthCareProvider CopyProvider()
        {
            // this copys the current provider object and allows you to assign
            // a copy to a new provider object
            return (HealthCareProvider)this.MemberwiseClone();
        }
    }

}
