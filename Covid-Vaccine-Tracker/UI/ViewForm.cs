// Covid Vax Tracker - View Form
// By Zachary Palmer 2/15/2022

///<summary>
/// This form is used by Providers and CDC Users
/// when an instance of this form is created a
/// a bool is passed in that determines if the current
/// user is a CDC. Certain views are only available to Providers.
/// After view is selected then it is displayed in a Data Grid View
/// The graph shows the selected view data value versus the value for Mo and the for the Country
/// </summary>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Using statements needed to access other namespaces in the project
using Covid_Vaccine_Tracker.Business_Objects;
using Covid_Vaccine_Tracker.Data_Access_Layer;


namespace Covid_Vaccine_Tracker.UI
{
    public partial class ViewForm : Form
    {
        bool IsCdcUser;
        List<Views> RecordViews = new List<Views>();
        string AppTitle = "Covid Vaccine Tracker";

        public ViewForm()
        {
            InitializeComponent();
        }
        public ViewForm(bool cView)
        {
            // Method needed to setup form boilerplate code
            InitializeComponent();

            // Determine truth values; these values will be used to get correct views
            if (cView)
                IsCdcUser = true;
            else if (!cView)
                IsCdcUser = false;
        }
        // When the form loads determine user type and bind view options to combo-boxs
        private void ViewForm_Load(object sender, EventArgs e)
        {
            // Ceck to see which type of user to get respective views
            if (IsCdcUser)
                RecordViews = ViewDB.GetCdcViews();

            if (!IsCdcUser)
                RecordViews = ViewDB.GetProviderViews();

            // Bind views to combo box
            ViewsCbx.DataSource = RecordViews;
            ViewsCbx.DisplayMember = "View_Type";
            ViewsCbx.ValueMember = "Id";
            // Disable chart button
            ChartControl("Disable");
        }
        private void ChartControl(string command)
        {
            switch(command)
            {
                case "Disable":
                    chartBtn.Enabled = false;
                    break;
                case "Enable":
                    chartBtn.Enabled = true;
                    break;
            }
        }
        private void PatientInput(string command)
        {
            switch(command)
            {
                case "Disable":
                    IdLbl.Visible = false;
                    IdLbl.Enabled = false;
                    PatientIdTxt.Visible = false;
                    PatientIdTxt.Enabled = false;
                    break;
                case "Enable":
                    IdLbl.Visible = true;
                    IdLbl.Enabled = true;
                    PatientIdTxt.Visible = true;
                    PatientIdTxt.Enabled = true;
                    break;
            }
        }
        private (bool,string) CheckForm(ref int tbx)
        {
            bool valid = true;
            string errMsg = string.Empty;

            if (string.IsNullOrEmpty(PatientIdTxt.Text))
            {
                valid = false;
                errMsg = "You must enter patient id to search by patient";
                tbx = 1;
            }

            return (valid, errMsg);
        }
        private void SetErrorPv(int tbx, string errMsg)
        {
            // This checks tbx to determine where to place errorpv error msg and icon
            // is set up so more validation can be incorporated later if need be
            switch(tbx)
            {
                case 1:
                    ErrorPv.SetError(PatientIdTxt, errMsg);
                    break;
            }
        }
        private void ResetErrorPv()
        { ErrorPv.Clear(); }
        private void DisplaySuccess(string msg, string title)
        { MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information); }
        private void DisplayError(string msg, string title)
        { MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        private List<VaccineRecord> GetRecords_CDC(int indx)
        {
            // Create lists that will store respective record type
            List<VaccineRecord> vaccineRecords = new List<VaccineRecord>();

            // determine the view selected index vale then get data from the database and then stores it in a list
            try
            {
                switch (indx)
                {
                    // This switch block is out of scope for this sprint
                    // it is code that gets the data for CDC view and chartform
                    //case 0:
                    //    vaxRecords = VaccineRecordDB.GetReccordBy("Uncomplete");
                    //    break;
                    //case 1:
                    //    vaxRecords = VaccineRecordDB.GetReccordsBy("Complete");
                    //    break;
                    //case 2:
                    //    vaxRecords = VaccineRecordDB.GetReccordsBy("All");
                }
            }
            catch (Exception ex)
            { throw ex; }

            return vaccineRecords;
        }
        private List<Identifying_VaccineRecord> GetRecords_Provider(int indx)
        {
            // Used to determine if patient id is entered 
            (bool, string) isValid;
            int Tbx = -1;
            // Create lists that will store respective record type
            List<Identifying_VaccineRecord> vaccineRecords = new List<Identifying_VaccineRecord>();

            // determine the view selected index vale then get data from the database and then stores it in a list
            try
            {
                switch (indx)
                {
                    case 0: // all vaccine records
                        vaccineRecords = VaccineRecordDB.GetVaccineRecords_Identifying();
                        break;
                    case 1: // vaccine series complete = yes
                        vaccineRecords = VaccineRecordDB.GetVaxSeries_Identifying("Yes");
                        break;
                    case 2: // vaccine sereis complete = no
                        vaccineRecords = VaccineRecordDB.GetVaxSeries_Identifying("No");
                        break;
                    case 3: // vaccine series complete = unknown 
                        vaccineRecords = VaccineRecordDB.GetVaxSeries_Identifying("Unknown");
                        break;
                    case 4: // vaccine records by patient
                        isValid = CheckForm(ref Tbx);
                        if (isValid.Item1) // If patient id is not null or empty then find patient's records
                            vaccineRecords = VaccineRecordDB.GetVaccineRecord_Identifying(PatientIdTxt.Text);
                        else // patient id was null or empty so display error msg with error provider
                            SetErrorPv(Tbx, isValid.Item2);
                        break;
                }
            }
            catch (Exception ex)
            { throw ex; }

            return vaccineRecords;
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            // Close form and return control to previous form that called this one
            this.Close();
        }
        // The chart button is out of scope for sprint on 2/17/22 so just display notification 
        private void chartBtn_Click(object sender, EventArgs e)
        { DisplaySuccess("This feature is coming soom!!!! This Button has Business Events out of scope for this sprint", AppTitle); }

        private void EnterBtn_Click(object sender, EventArgs e)
        {
            // Lists to hold respective records
            List<VaccineRecord> vaxRecords_CDC = new List<VaccineRecord>();
            List<Identifying_VaccineRecord> vaxRecords_Provider = new List<Identifying_VaccineRecord>();
            // Holds the index of the view selected in view combo-box
            int selectedView;

            try
            {
                // Get the selected index of view combo box
                selectedView = ViewsCbx.SelectedIndex;

                if (IsCdcUser)
                {
                    // If IsCdcUser is true then get the records for selected view
                    vaxRecords_CDC = GetRecords_CDC(selectedView);
                    // Then bind the list to the Records Datagrid control
                    RecordsDg.DataSource = vaxRecords_CDC;
                }
                else if (!IsCdcUser)
                {
                    // If IsCdcUser is false then get the records for selected view
                    vaxRecords_Provider = GetRecords_Provider(selectedView);
                    // Then bind the list to the Records Datagrid control
                    RecordsDg.DataSource = vaxRecords_Provider;
                }
                else // something unexpected happened this is probably unessacary and redundant
                    DisplayError("Error, Unknown view selection please select a view type in combo-box", AppTitle);

                // Check to make sure that list has values before enabling chart button
                if (vaxRecords_CDC.Count > 0 || vaxRecords_Provider.Count > 0)
                    ChartControl("Enable");
                
            }
            catch (Exception ex)
            { DisplayError(ex.Message, AppTitle); }
        }

        private void ViewsCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If provider user then determine if the selected index is 3 which is View by patient
            if (!IsCdcUser)
            {
                // If view by patient then enable Patient label and txtbx
                if (ViewsCbx.SelectedIndex == 4)
                    PatientInput("Enable");
                        
                else // Anything else Disable Patient lbl and txtbx
                    PatientInput("Disable");
            }
            else // If cdc user then disable patient lbl and txtbx
                PatientInput("Disable");
        }
    }
}
