using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// need these below using statements
using Covid_Vaccine_Tracker.Business_Objects;
using Covid_Vaccine_Tracker.Data_Access_Layer;

namespace Covid_Vaccine_Tracker.UI
{
    public partial class VaccineRecordForm : Form
    {
        // if ExisitingPatient is false then this form must look up patients PPRL and store vax record with PPRL
        // if ExisitingPatient is true then before new vax record is inserted PPRL must be verified in PPRL table

        // when form load it extract type needs to be set to PPRL
        HealthCareProvider ActiveProvider = new HealthCareProvider();
        Patient CurrentPatient = new Patient();
        bool ExisitingPatient;
        Extracts ExtractType = new Extracts();
        string VaxEvent;

        public VaccineRecordForm()
        {
            InitializeComponent();
        }
        // overloaded method that allows provider object to be passed to this form
        // then set this forms global Provider object to a copy of Provider object passed in
        public VaccineRecordForm(HealthCareProvider currentProvider)
        {
            InitializeComponent();
            // copy provider
            ActiveProvider = currentProvider.CopyProvider();
            // If exisiting patient then doctor enters in Patient id
            // Note before vax record is stored must retrieve the PPRL number
            ExisitingPatient = true;
        }
        // overloaded method to pass in patient data
        public VaccineRecordForm(HealthCareProvider currentProvider, Patient patient)
        {
            InitializeComponent();
            // copy patient and provider
            CurrentPatient = patient.CopyPatient();
            ActiveProvider = currentProvider.CopyProvider();
            // if new patient patient id will be automatically on form.
            // Note before the records is stored must get patient's PPRL from db
            ExisitingPatient = false;
        }

        private void VaccineRecordForm_Load(object sender, EventArgs e)
        {
            // Generate a new vaccine event id
            // Creates a string 10 characters long with 3 letters uses digits 0-9 and A-Z
            VaxEvent = IdGenerator.GenerateId(10, 3, 0, 9, 'A', 'Z');

            if (!ExisitingPatient)
                PatientIdTxt.Text = CurrentPatient.Id;
            else if (ExisitingPatient)
                PatientIdTxt.ReadOnly = false;

            // Get and display extract type-- Type 'P' is Privacy Perserving Record Linkage
            // Then set the extraxt textbox's text to display extract type
            ExtractType = ExtractsDB.GetExtract("P");
            ExtractTxt.Text = ExtractType.Extract_Type;
            // Display vaxEventId in txtbx
            VaxEventIdTxt.Text = VaxEvent;

            // Also when the form loads need to set the Vtcks pin & location information in form to the
            // location info stored in the ActiveProvider obj 
        }
    }
}
