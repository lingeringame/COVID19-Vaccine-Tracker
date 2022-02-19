// Covid Vax Tracker - Provider Form
// By Zachary Palmer 2/15/2022

///<summary>
/// This form is used by Providers to input
/// and update patient information. When a
/// instance of this form is created the current
/// Provider object is passed in to keep track of 
/// Providers information. This data will be passed to Vaccine Record Form
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
// using statements to needed to access other namespaces in the project 
using Covid_Vaccine_Tracker.Business_Objects;
using Covid_Vaccine_Tracker.Data_Access_Layer;

namespace Covid_Vaccine_Tracker.UI
{
    public partial class ProviderForm : Form
    {
        // The variables from apptile to Isvalid are global varriables
        // Therefor every method on this form has access to them

        // Title of app used in DisplayError and DisplaySuccess methods
        string appTitle = "Covid Vaccine Tracker";

        // Newly generated patient id and PPRL if new patient menu item clicked
        string GeneratedPatientId;
        string GeneratedPPRL;

        // Variable for a new patient dont create instance until new patient menu item click
        // so every time new patient menu item is clicked there is a new id generated and old one is gone 
        Patient FreshPatient;

        // Holds the current providers data
        HealthCareProvider ActiveProvider = new HealthCareProvider();

        // Lists to hold the values for combo boxs
        List<States> States50 = new List<States>();
        List<Race> Races1 = new List<Race>();
        List<Race> Races2 = new List<Race>();
        List<Ethnicity> Ethnicities = new List<Ethnicity>();
        List<Sex> Sexes = new List<Sex>();

        // this is the extract type but will be read only on Identifiy
        Extracts ExtractType = new Extracts();

        // IsValid is a tuple that is used for checking the form
        // it holds a bool which is set if there are any missing data and a string that holds the errormessage
        // it is assigned to the CheckForm Method
        (bool, string) IsValid;

        public ProviderForm()
        {
            InitializeComponent();
        }
        public ProviderForm(HealthCareProvider currentProvider)
        {
            // Current providers data is passed in and then copied to a global varriable
            InitializeComponent();
            ActiveProvider = currentProvider.CopyProvider();
        }
        // SetErrorPv take the index of the textbox that is missing data or has the error and takes the error
        // message to display.
        private void SetErrorPv(int txtBx, string emsg)
        {
            // Switch statement looks at the value of txtBx, when txtBx matches the value of a case
            // it will set the errorprovier and error message
            switch (txtBx)
            {
                case 0:
                    ErrorPv.SetError(PatientIdTxt, emsg);
                    break;
                case 1:
                    ErrorPv.SetError(FnameTxt, emsg);
                    break;
                case 2:
                    ErrorPv.SetError(MnameTxt, emsg);
                    break;
                case 3:
                    ErrorPv.SetError(LnameTxt, emsg);
                    break;
                case 4:
                    ErrorPv.SetError(DOBpicker, emsg);
                    break;
                case 5:
                    ErrorPv.SetError(StreetTxt, emsg);
                    break;
                case 6:
                    ErrorPv.SetError(CityTxt, emsg);
                    break;
                case 7:
                    ErrorPv.SetError(CountyTxt, emsg);
                    break;
                case 8:
                    ErrorPv.SetError(StatesCbx, emsg);
                    break;
                case 9:
                    ErrorPv.SetError(ZipTxt, emsg);
                    break;
                case 10:
                    ErrorPv.SetError(Race1Cbx, emsg);
                    break;
                case 11:
                    ErrorPv.SetError(Race2Cbx, emsg);
                    break;
                case 12:
                    ErrorPv.SetError(EthnicityCbx, emsg);
                    break;
            }
        }
        private void ResetErrorPv()
        {
            // clears the current positionn of ErrorProvider if any
            ErrorPv.Clear();
        }
        private void DisplaySuccess(string msg, string title)
        {
            // displays a message box with ok button and information icon used for successful actions
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void DisplayError(string msg, string title)
        {
            // displays a message box iwth ok button and error icon used for unsuccessful actions
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        private void ResetForm()
        {
            // clears all the textboxs and resets the comboboxs on form
            PatientIdTxt.Text = string.Empty;
            FnameTxt.Text = string.Empty;
            LnameTxt.Text = string.Empty;
            // Reset DatePicker
            DOBpicker.Checked = false;
            StreetTxt.Text = string.Empty;
            CityTxt.Text = string.Empty;
            CountyTxt.Text = string.Empty;
            ZipTxt.Text = string.Empty;
            // -1 is the default value for a combobox means nothing is selected
            StatesCbx.SelectedIndex = -1;
            Race1Cbx.SelectedIndex = -1;
            Race2Cbx.SelectedIndex = -1;
            EthnicityCbx.SelectedIndex = -1;
        }
        private (bool,string) CheckForm(ref int Tbx)
        {
            // Checks the form for missing data, and that a value was selected in combo-boxs
            // it returns a bool and string and gets passed a reference variable (Pointer) that will hold the location
            // of the textbox with the error.
            // The textbox location is used by SetErrorPv to know where to place the error icon
            bool valid = true;
            string errMsg = string.Empty;

            // try blocks go around code that could throw an error then passes any errors to the catch block
            try
            {
                // if the value of the text box is null or empty string then 
                // set text box index valid false and concat error Msg
                if (string.IsNullOrEmpty(PatientIdTxt.Text))
                {
                    Tbx = 0;
                    valid = false;
                    errMsg = "Must enter a patient id";
                }
                else if (string.IsNullOrEmpty(FnameTxt.Text))
                {
                    Tbx = 1;
                    valid = false;
                    errMsg = "Must enter a first name";
                }
                else if (string.IsNullOrEmpty(MnameTxt.Text))
                {
                    Tbx = 2;
                    valid = false;
                    errMsg = "Must enter a middle name";
                }
                else if (string.IsNullOrEmpty(LnameTxt.Text))
                {
                    Tbx = 3;
                    valid = false;
                    errMsg = "Must enter a last name";
                }
                // Determine if a date was selected in Datepicker control
                else if (!DOBpicker.Checked)
                {
                    Tbx = 4;
                    valid = false ;
                    errMsg = "Must enter data of birth";
                }
                else if (string.IsNullOrEmpty(StreetTxt.Text))
                {
                    Tbx = 5;
                    valid = false;
                    errMsg = "Must enter a street address";
                }
                else if (string.IsNullOrEmpty(CityTxt.Text))
                {
                    Tbx = 6;
                    valid = false;
                    errMsg = "Must enter a city";
                }
                else if (string.IsNullOrEmpty(CountyTxt.Text))
                {
                    Tbx = 7;
                    valid = false ;
                    errMsg = "Must enter a county";
                }

                else if (string.IsNullOrEmpty(ZipTxt.Text))
                {
                    Tbx = 9;
                    valid = false;
                    errMsg = "Must enter a zipcode";
                }
                // To check if user selected a item in the comboboxs check in selected index is greater then -1 which is the 
                // default value for a combo box.
                if (StatesCbx.SelectedIndex <= -1)
                {
                    Tbx = 8;
                    valid = false;
                    errMsg = "A state must be selectd";
                }
                else if (SexCbx.SelectedIndex <= -1)
                {
                    Tbx = 10;
                    valid = false;
                    errMsg = "A sex must be selected";
                }
                else if(Race1Cbx.SelectedIndex <= -1)
                {
                    Tbx = 11;
                    valid = false;
                    errMsg = "A race must be selected";
                }
                // Race 2 is not required
                else if (EthnicityCbx.SelectedIndex <= -1)
                {
                    Tbx = 13;
                    valid = false;
                    errMsg = "A ethnicity must be selected";
                }
            }
            // catch block catches any errors then will either display the error or throw error to last part of
            // the stack that has a try catch block
            catch(Exception ex)
            { throw ex; }

            // return a bool string tuple
            return (valid, errMsg);
        }
        // The methods that end in _Recjected create an event handlers so when invalid data is entered
        // in the respective masked textbox it will call the correct _Rejected method and display the
        // appopriate message all _Rejected methods follow same logic.
        // Correct data for patient id is a 10 digit string 0000000LLL which is
        // first 7 digits are 0-9 then the last three digits are a-z
        void PatientId_Rejected(object sender, MaskInputRejectedEventArgs e)
        {
            // Create a tool tip object to display message in
            ToolTip ErrorTip = new ToolTip();

            // If usr starts at begining of MaskedTxtBx and type to many characters
            if (PatientIdTxt.MaskFull)
            {
                // Give ErrorTip tooltip a title
                ErrorTip.ToolTipTitle = "Max Digits";
                // Display a tool tip error messsage
                ErrorTip.Show("Patient Id cannot only be 10 digits long",PatientIdTxt,25,-20,2500);
            }
            // If usr tries to start entering characters at end of MaskedTxtBx display error
            else if (e.Position == PatientIdTxt.Mask.Length)
            {
                ErrorTip.ToolTipTitle = "End of Field";
                ErrorTip.Show("You cannot add extra digits to end of Paitient Id", PatientIdTxt, 25 ,-20, 2500);
            }
            // If invalid data is entered display error
            else
            {
                ErrorTip.ToolTipTitle = "Input Rejected";
                ErrorTip.Show("Invalid Patient Id format, example Paitent Id: 1234567AAA", PatientIdTxt, 25, -20, 2500);
            }
        }
        void Zip_Rejected(object sender, MaskInputRejectedEventArgs e)
        {
            ToolTip ErrorTip = new ToolTip();
            if (ZipTxt.MaskFull)
            {
                ErrorTip.ToolTipTitle = "Max Digits";
                ErrorTip.Show("Max number of digits reached for Zipcode", ZipTxt, 25, -20, 2500);
            }
            else if (e.Position == ZipTxt.Mask.Length)
            {
                ErrorTip.ToolTipTitle = "End of Field";
                ErrorTip.Show("You cannot add extra digits to end of Zipcode", ZipTxt, 25, -20, 2500);
            }
            else
            {
                ErrorTip.ToolTipTitle = "Input Rejected";
                ErrorTip.Show("Invalid Zipcode format, Zipcode must be in 00000 format", ZipTxt, 25, -20, 2500);
            }
        }
        // CreatePatient is used to 
        private void CreatePatient(Patient NewPatient)
        {
            // valueIndex will hold the index for a value selected from combo-box
            int valueIndex;
            // datetime object and strings for patient data
            DateTime dob;
            // Use string to convet the DateTime obecjt in 00/00/000 00:00:00 format to just 00/00/0000 format
            string DOB;

            // try blocks go around code that could throw an error then passes any errors to the catch block
            try
            {
                NewPatient.Id = PatientIdTxt.Text;
                NewPatient.First_name = FnameTxt.Text;
                NewPatient.Middle_name = MnameTxt.Text;
                NewPatient.Last_name = LnameTxt.Text;
                // Set patient dob
                NewPatient.Date_of_birth = DOBpicker.Value;
                NewPatient.Street_address = StreetTxt.Text;
                NewPatient.City = CityTxt.Text;
                NewPatient.County = CountyTxt.Text;
                NewPatient.Zip_code = ZipTxt.Text;

                // To save calls to database take the selected index of combo-box and get objects value at index of the
                // item in the list. Then take the set to new patient attribute 
                valueIndex = StatesCbx.SelectedIndex;
                NewPatient.State = States50[valueIndex].Name;
                valueIndex = Race1Cbx.SelectedIndex;
                NewPatient.Race1 = Races1[valueIndex].Race_Type;
                valueIndex = Race2Cbx.SelectedIndex;
                NewPatient.Race2 = Races2[valueIndex].Race_Type;
                valueIndex = EthnicityCbx.SelectedIndex;
                NewPatient.Ethnicity = Ethnicities[valueIndex].Ethnicity_Type;
                valueIndex = SexCbx.SelectedIndex;
                NewPatient.Sex = Sexes[valueIndex].Sex_Type;

                NewPatient.Extract_Type = ExtractTxt.Text;
            }
            catch(Exception ex)
            { throw ex; }

        }
        private void SetNewPatient(Patient NewPatient, bool isUpdate)
        {
            string id;
            bool PatientFound;

            try
            {
                // If the provider is updating an exisiting patinet make sure patient is already
                // in the database. This will prevent Patient Ids from being updated
                if (isUpdate)
                {
                    id = PatientIdTxt.Text;
                    // Method that checks the database for a match for all 4 arguements
                    PatientFound = PatientDB.VerifyPatient(id);

                    // If patient not found then display a error message
                    if (!PatientFound)
                        DisplayError("Error, patient not found double check patient id", appTitle);
                    // If patient is found then set patient values
                    else
                        CreatePatient(NewPatient);
                }
                // If its not an update then set new patient values
                else
                    CreatePatient(NewPatient);
                
            }
            catch(Exception ex)
            { throw ex; }
        }
        private void GroupBoxControls(string command)
        {
            // disable or enable groupbox
            switch(command)
            {
                case "Disable":
                    patientGB.Visible = false;
                    patientGB.Enabled = false;
                    break;
                case "Enable":
                    patientGB.Visible = true;
                    patientGB.Enabled = true;
                    break;
            }
            
        }
        private void ShowButtons(string command)
        {
            // disable or enable buttons 
            switch(command)
            {
                case "Disable":
                    AddBtn.Visible = false;
                    UpdateBtn.Visible = false;
                    ClearBtn.Visible = false;
                    ExitBtn.Visible = false;
                    break;
                case "Enable":
                    AddBtn.Visible = true;
                    UpdateBtn.Visible = true;
                    ClearBtn.Visible = true;
                    ExitBtn.Visible = true;
                    break;
            }
            
        }
        private void DisableButtons()
        {
            ShowButtons("Disable");
            AddBtn.Enabled = false;
            UpdateBtn.Enabled = false;
            ClearBtn.Enabled = false;
            ExitBtn.Enabled = false;
        }
        private void EnableAddControls()
        {
            // If add menu item pushed display and enable add  buttons          
            AddBtn.Enabled = true;
            UpdateBtn.Enabled = false;
            ShowButtons("Enable");
            SharedButtons("Enable");
            InputControls("Enable");
        }
        private void EnableUpdateControls()
        {
            // If update menu item pushed display and enable update buttons
            // and enable patient id textbx
            PatientIdTxt.Enabled = true;
            UpdateBtn.Enabled = true;
            AddBtn.Enabled = false;
            ShowButtons("Enable");
            SharedButtons("Enable");
            InputControls("Enable");
        }
        private void InputControls(string command)
        {
            // either enable or disable group box and inputs
            switch(command)
            {
                case "Disable":
                    GroupBoxControls("Disable");
                    // Now enable input
                    FnameTxt.Enabled = false;
                    MnameTxt.Enabled = false;
                    LnameTxt.Enabled = false;
                    DOBpicker.Enabled = false;
                    StreetTxt.Enabled = false;
                    CityTxt.Enabled = false;
                    CountyTxt.Enabled = false;
                    StatesCbx.Enabled = false;
                    ZipTxt.Enabled = false;
                    Race1Cbx.Enabled = false;
                    Race2Cbx.Enabled = false;
                    SexCbx.Enabled = false;
                    EthnicityCbx.Enabled = false;
                    break;
                case "Enable": // enable groupbox
                    GroupBoxControls("Enable");
                    // Now enable input
                    FnameTxt.Enabled = true;
                    MnameTxt.Enabled = true;
                    LnameTxt.Enabled = true;
                    DOBpicker.Enabled = true;
                    StreetTxt.Enabled = true;
                    CityTxt.Enabled = true;
                    CountyTxt.Enabled = true;
                    StatesCbx.Enabled = true;
                    ZipTxt.Enabled = true;
                    Race1Cbx.Enabled = true;
                    Race2Cbx.Enabled = true;
                    SexCbx.Enabled = true;
                    EthnicityCbx.Enabled = true;
                    break;
            }    
            
        }
        private void SharedButtons(string command)
        {
            // Enables or disables buttons that are used when updating or adding 
            switch(command)
            {
                case "Disable":
                    ClearBtn.Enabled = true;
                    ExitBtn.Enabled = true;
                    break;
                case "Enable":
                    ClearBtn.Enabled = true;
                    ExitBtn.Enabled = true;
                    break;
            }
        }
        private void ProviderForm_Load(object sender, EventArgs e)
        {
            // This code executes when the form is loading 
            // This Initiates new MaskInputRejected Events for the mask text boxs of form
            PatientIdTxt.MaskInputRejected += new MaskInputRejectedEventHandler(PatientId_Rejected);
            ZipTxt.MaskInputRejected += new MaskInputRejectedEventHandler(Zip_Rejected);

            // Fill the lists with data from the Database           
            try
            {
               // Fill the lilsts with data from database
                States50 = StatesDB.GetStates();
                // If you are binding data to two combo-bxs and want them to hold the same data
                // You cannot bind the same list to each combo-bx other wise when a value is
                // selected in one combo-bx that value will automatically be selected in the other combo-bx
                Races1 = RacesDB.GetRaces();
                Races2 = RacesDB.GetRaces();
                Ethnicities = EthnicitiesDB.GetEthnicities();
                Sexes = SexesDB.GetSexes();

                // Now bind the data from lists to the respective combo-bx 
                StatesCbx.DataSource = States50;
                StatesCbx.DisplayMember = "Abbreviation";
                StatesCbx.ValueMember = "Name";

                Race1Cbx.DataSource = Races1;
                Race1Cbx.DisplayMember = "Race_Type";
                Race1Cbx.ValueMember = "Code";

                Race2Cbx.DataSource = Races2;
                Race2Cbx.DisplayMember = "Race_Type";
                Race2Cbx.ValueMember = "Code";

                EthnicityCbx.DataSource = Ethnicities;
                EthnicityCbx.DisplayMember = "Ethnicity_Type";
                EthnicityCbx.ValueMember = "Code";

                SexCbx.DataSource = Sexes;
                SexCbx.DisplayMember = "Sex_Type";
                SexCbx.ValueMember = "Code";

                // Since this data is identifiying data get the row for identified extract type to display on form
                ExtractType = ExtractsDB.GetExtract("I");
                // set the text in textbox to extract 
                ExtractTxt.Text = ExtractType.Extract_Type;
                // Make sure the buttons are not displaying
                DisableButtons();
            }
            catch (Exception ex)
            // If there are any errors then take the error message IE ex.Message and display it in a message box
            { DisplayError(ex.Message, appTitle); }
        }
        private void ViewItem_Click(object sender, EventArgs e)
        {
            // Disable group box and buttons for looks 
            InputControls("Disable");
            DisableButtons();
            // Create an instance of the provider form
            ViewForm ProviderView = new ViewForm();
            //// .ShowDialog brings up the form and gives control to the provider form
            //// This calling form will not regain control until ProviderView form is closed
            ProviderView.ShowDialog();
        }

        private void NewPatientItem_Click(object sender, EventArgs e)
        {
            // Create a new instance of a patient object
            FreshPatient = new Patient();
            // If new patient menu item is selected enable the controls with Enable methods.
            // Also generate a new patient Id and new PPRL for patient with IdGenerator class.
            // Once the add button is clicked and data verifed then must add new patient to 
            // the patient table and new PPRL to PPRL table
            InputControls("Enable");
            EnableAddControls();

            try
            {
                // Instaniate new pprl object
                PPRL pRL = new PPRL();

                // Generate a random string of length 10 with with 7 digits 0-9 and
                // 3 letters A-Z
                GeneratedPatientId = IdGenerator.GenerateId(10, 0, 9, 'A', 'Z');
                GeneratedPPRL = IdGenerator.GenerateId(10, 0, 9, 'A', 'Z');
                // Set the patient id to newly created id and set textbox to readonly
                PatientIdTxt.Text = GeneratedPatientId;
                PatientIdTxt.ReadOnly = true;
            }
            catch (Exception ex)
            { DisplayError(ex.Message, appTitle); }

        }

        private void UpdatePatientItem_Click(object sender, EventArgs e)
        {
            // Clear out any information that could still be on form
            ResetForm();
            InputControls("Enable");
            EnableUpdateControls();
            // Allow provider to enter a patient id for patient to update
            PatientIdTxt.ReadOnly = false;
        }
        private void VaccineRecordItem_Click(object sender, EventArgs e)
        {
            // If new vaccine record selected call the VaccineRecord form
            // Inorder to have the Provider data needed for the vax form
            // need to call the overloaded constructor for the vaccineForm and pass in the Provider object
            // create at sign in with providers username

            DisplaySuccess("Feature coming soon, code for inputting vaccine records is out of scope for this sprint", appTitle);

            // Start of code for sprint that includes input vaccine record
            //VaccineRecordForm vaxForm = new VaccineRecordForm(ActiveProvider);
            //vaxForm.ShowDialog();
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            // Reset any errors from before
            ResetErrorPv();
            // New patient is being added 
            // tbx will hold the index of any textboxes that have an error
            // It is set to a number that is outside the number of textboxs could be different
            int tbx = -1;
            // IsValid is a tuple that holds the (bool,string) from CheckForm
            IsValid = CheckForm(ref tbx);
            // Holds status of patient insert and PPRl insert
            bool WasSuccess, GoodAdd;

            // If IsValid item1 aka the bool is true
            if (IsValid.Item1)
            {
                try
                {
                    SetNewPatient(FreshPatient, false);

                    // Was the patient added successfully
                    WasSuccess = PatientDB.AddPatient(FreshPatient);

                    if (WasSuccess)
                    {
                        DisplaySuccess("Patient has been succesfully added", appTitle);
                        // Set PPRL
                        PPRL pRL = new PPRL();
                        pRL.Patient_Id = GeneratedPatientId;
                        pRL.PPRL_Number = GeneratedPPRL;
                        // Store PPRL
                        GoodAdd = PPRLDB.AddPPRL(pRL);

                        // If pprl added successful do nothing
                        // If add is unsuccessful display err Msg
                        if (!GoodAdd)
                            DisplayError("An error occured while storing patient's PPRL", appTitle);

                        // Vaccine form is out of scope for this sprint so display message box notification
                        // Now call vax form to enter all vaccine information
                        //VaccineRecordForm VaxForm = new VaccineRecordForm(ActiveProvider, FreshPatient);
                        //VaxForm.ShowDialog();

                        DisplaySuccess("Next the vaccine record form would display but it is out of scope this sprint", appTitle);
                    }                        
                    else if (!WasSuccess)
                        DisplayError("Error patient has not been added", appTitle);

                }
                catch(Exception ex)
                { DisplayError(ex.Message, appTitle); }
            }
            // If IsValid Item1 false then display the error on the textbox with ErrorPV
            // IsValid.Item2 holds the error msg
            else
                SetErrorPv(tbx, IsValid.Item2);

            // Disable groupbox and controls
            InputControls("Disable");
            DisableButtons();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            // Reset any errors from bfore
            ResetErrorPv();
            // Patient is being updated
            int tbx = -1;
            IsValid = CheckForm(ref tbx);
            bool WasSuccess;

            // If Item1 is true 
            if (IsValid.Item1)
            {
                try
                {
                    Patient existingPatient = new Patient();
                    // SetNewPatient takes a patient obj and a bool to determine if action is an update
                    SetNewPatient(existingPatient, true);

                    // Was patient updated successfully
                    WasSuccess = PatientDB.UpdatePatient(existingPatient);

                    // Display success or error msgs
                    if (WasSuccess)
                        DisplaySuccess("Patient was successfully updated", appTitle);
                    else if (!WasSuccess)
                        DisplayError("Error patient was not updated", appTitle);
                }
                // If there were any errors caught display err msg
                catch(Exception ex)
                { DisplayError(ex.Message, appTitle); }

                // Disable groupbox and buttons
                InputControls("Disable");
                DisableButtons();

            }
            // If there were missing or incorrect data then display set error msg on textbox with error
            else
                SetErrorPv(tbx, IsValid.Item2);
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            // This will close the current form.. and give control back to the form that called this one
            this.Close();
        }

    }
}
