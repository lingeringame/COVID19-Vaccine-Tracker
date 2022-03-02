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

        string AppTitle = "Covid Vaccine Tracker";
        // when form load it extract type needs to be set to PPRL
        Provider ActiveProvider = new Provider();
        Patient CurrentPatient = new Patient();
        bool ExisitingPatient, NeedPPRL;
        Extracts ExtractType = new Extracts();
        string GeneratedVaxEventId, currentPPRL;
        // List to hold all of the combobox values
        List<Response> resp1 = new List<Response>();
        List<Response> resp2 = new List<Response>();
        List<Response> resp3 = new List<Response>();
        List<Dose> doses = new List<Dose>();
        List<Vaccine_Type> vTypes = new List<Vaccine_Type>();
        List<Vaccine_Product> vProducts = new List<Vaccine_Product>();
        List<Vaccine_Manufacturer> vManufacturers = new List<Vaccine_Manufacturer>();
        List<Vaccine_Admin_Site> vAdminSites = new List<Vaccine_Admin_Site>();
        List<Vaccine_Route> vRoutes = new List<Vaccine_Route>();
        List<Location_Types> lTypes = new List<Location_Types>();
        List<Provider_Suffix> pSuffixes = new List<Provider_Suffix>();

        // Error Occured will be true if the vaccine record object is not created so bad data wont go to db
        bool ErrorOccured;

        public VaccineRecordForm()
        {
            InitializeComponent();
        }
        // overloaded method that allows provider object to be passed to this form
        // then set this forms global Provider object to a copy of Provider object passed in
        public VaccineRecordForm(Provider currentProvider)
        {
            InitializeComponent();
            // copy provider
            ActiveProvider = currentProvider.CopyProvider();
            // If exisiting patient then doctor enters in Patient id
            // Note before vax record is stored must retrieve the PPRL number
            ExisitingPatient = true;
            NeedPPRL = true;
        }
        // overloaded method to pass in patient data
        public VaccineRecordForm(Provider currentProvider, Patient patient, string pprl)
        {
            InitializeComponent();
            // copy patient and provider
            CurrentPatient = patient.CopyPatient();
            ActiveProvider = currentProvider.CopyProvider();
            // new patients PPRL passed into form and store it for vaccine record insert
            currentPPRL = pprl;
            // if new patient patient id will be automatically on form.
            // Note before the records is stored must get patient's PPRL from db
            ExisitingPatient = false;
            NeedPPRL = false;
        }
        // This is the method to use for sprint 3
        public VaccineRecordForm(Patient patient, string pprl)
        {
            InitializeComponent();
            // Copy current patient
            CurrentPatient = patient.CopyPatient();
            // get patients pprl number that was passed in
            currentPPRL = pprl;
            // if new patient patient id will be automatically on form.
            // Note before the records is stored must get patient's PPRL from db
            ExisitingPatient = false;
            NeedPPRL = false;
        }
        private void AddControl(string command)
        {
            switch(command)
            {
                case "Enable":
                    AddBtn.Enabled = true;
                    break;
                case "Disable":
                    AddBtn.Enabled = false;
                    break;
            }
        }
        private void IdControl(string command)
        {
            switch (command)
            {
                case "Enable":
                    IdTxt.Enabled = true;
                    IdTxt.ReadOnly = false;
                    break;
                case "Disable":
                    IdTxt.Enabled = false;
                    IdTxt.ReadOnly = true;
                    break;
            }
        }
        private void SetIdControlType(string type)
        {
            switch(type)
            {
                case "Patient": // if textbox should let provider enter patient id
                    IDlbl.Text = "Patient Id";
                    IdControl("Enable");
                    break;
                case "PPRL": // if textbox should display pprl number 
                    IDlbl.Text = "PPRL";
                    IdTxt.Text = currentPPRL;
                    IdControl("Disable");
                    break;
            }
        }
        private void PopulateProviderInput()
        {
            try
            {
                OrganizationTxt.Text = ActiveProvider.Parent_Organization;
                AdminLocTxt.Text = ActiveProvider.Administered_Location;
                // FindString method returns index of the string passed in ..if its in cbx
                // so set the index to the string of the providers location type
                LocTypeCbx.SelectedIndex = LocTypeCbx.FindString(ActiveProvider.Location_Type);
                AdminStreetTxt.Text = ActiveProvider.Location_Street_Address;
                AdminCityTxt.Text = ActiveProvider.Location_City;
                AdminCountyTxt.Text = ActiveProvider.Location_County;
                AdminStateTxt.Text = ActiveProvider.Location_State;
                AdminZipTxt.Text = ActiveProvider.Location_Zipcode;
                ProviderSuffixCbx.SelectedIndex = ProviderSuffixCbx.FindString(ActiveProvider.Provider_Suffix);
                VtckPinTxt.Text = ActiveProvider.Vtcks_Pin;
            }
            catch(Exception ex)
            { throw ex; }
        }
        private string GetIds(string idType, string searchVal)
        {
            string requestedID = string.Empty;

            switch(idType)
            {
                case "Patient":
                    requestedID = PPRLDB.GetPatientId(searchVal);
                    break;
                case "PPRL": // this is used if a patient is exisiting patient
                    requestedID = PPRLDB.GetPPRLNumber(searchVal);
                    break;
            }

            return requestedID;
        }
        private (bool,string) CheckForm(ref int tbx)
        {
            bool valid = true;
            string emsg = string.Empty;

            if (string.IsNullOrEmpty(ExtractTxt.Text))
            {
                valid = false;
                emsg = "Extract Type cannot be blank";
                tbx = 0;
            }
            else if (string.IsNullOrEmpty(VaxEventIdTxt.Text))
            {
                valid = false;
                emsg = "Vaccine Event Id cannot be blank";
                tbx = 1;
            }
            else if (VaxTypeCbx.SelectedIndex == -1)
            {
                valid = false;
                emsg = "Must select a vaccine type";
                tbx = 2;
            }
            // The rest of validation goes here


            return (valid, emsg);
        }
        private void ResetInputs(bool dataSumbitted)
        {
            if (dataSumbitted)
            {
                VaxEventIdTxt.Text = string.Empty;
                IdTxt.Text = string.Empty;
                VtckPinTxt.Text = string.Empty;
            }
            VaxTypeCbx.SelectedIndex = -1;
            VaxProductCbx.SelectedIndex = -1;
            VaxManufacturerCbx.SelectedIndex = -1;
            LotNumberTxt.Text = string.Empty;
            ExperationDateDp.Value = ExperationDateDp.MinDate;
            DateAdminDp.Value = DateAdminDp.MinDate;
            
            ComorbitiyCbx.SelectedIndex = -1;
            SerologyCbx.SelectedIndex = -1;
            DoseNumberCbx.SelectedIndex = -1;
            SeriesCompleteCbx.SelectedIndex = -1;
            AdminSiteCbx.SelectedIndex = -1;
            AdminRouteCbx.SelectedIndex = -1;
            OrganizationTxt.Text = string.Empty;
            AdminLocTxt.Text = string.Empty;
            LocTypeCbx.SelectedIndex = -1;
            AdminStreetTxt.Text = string.Empty;
            AdminCityTxt.Text = string.Empty;
            AdminCountyTxt.Text = string.Empty;
            AdminStateTxt.Text = string.Empty;
            AdminZipTxt.Text = string.Empty;
            ProviderSuffixCbx.SelectedIndex = -1;           
        }
        private void SetVaccineRecord(VaccineRecord vaxRecord)
        {
            int CbxIndex;

            try
            {
                // Vaccine groupbox
                vaxRecord.Extract_Type = ExtractTxt.Text.Trim();
                vaxRecord.Vaccine_Event_Id = VaxEventIdTxt.Text.Trim();
                // set combox values use list and cbx index to save DB calls
                CbxIndex = VaxTypeCbx.SelectedIndex;
                vaxRecord.Vaccine_Type = vTypes[CbxIndex].Type_CVX;
                CbxIndex = VaxProductCbx.SelectedIndex;
                vaxRecord.Vaccine_Product = vProducts[CbxIndex].Product_NDC;
                CbxIndex = VaxManufacturerCbx.SelectedIndex;
                vaxRecord.Vaccine_Manufacturer = vManufacturers[CbxIndex].Manufactuer;
                vaxRecord.Lot_Number = LotNumberTxt.Text.Trim();
                vaxRecord.Vaccine_Experation_Date = ExperationDateDp.Value;
                vaxRecord.Administration_Date = DateAdminDp.Value;
                // Patient groupbox
                CbxIndex = ComorbitiyCbx.SelectedIndex;
                vaxRecord.Comorbidity_Status = resp1[CbxIndex].Response_Type;
                CbxIndex = SerologyCbx.SelectedIndex;
                vaxRecord.Serology_Results = resp2[CbxIndex].Response_Type;
                CbxIndex = DoseNumberCbx.SelectedIndex;
                vaxRecord.Dose_Number = doses[CbxIndex].Code;
                CbxIndex = SeriesCompleteCbx.SelectedIndex;
                vaxRecord.Vaccine_Series_Complete = resp3[CbxIndex].Response_Type;
                CbxIndex = AdminSiteCbx.SelectedIndex;
                vaxRecord.Vaccine_Admin_Site = vAdminSites[CbxIndex].Admin_Site;
                CbxIndex = AdminRouteCbx.SelectedIndex;
                vaxRecord.Vaccine_Admin_Route = vRoutes[CbxIndex].Route;
                // Check if pprl was passed into constructor or if need to retireve pprl from DB
                if (NeedPPRL)
                    vaxRecord.PPRL = PPRLDB.GetPPRLNumber(IdTxt.Text.Trim());
                else
                    vaxRecord.PPRL = IdTxt.Text.Trim();
                // Provider groupbox
                vaxRecord.Responsible_Organization = OrganizationTxt.Text.Trim();
                vaxRecord.Administrated_Location = AdminLocTxt.Text.Trim();
                CbxIndex = LocTypeCbx.SelectedIndex;
                vaxRecord.Administrated_Loc_Type = lTypes[CbxIndex].Location_Type;
                vaxRecord.Admin_Street_Address = AdminStreetTxt.Text.Trim();
                vaxRecord.Admin_City = AdminCityTxt.Text.Trim();
                vaxRecord.Admin_County = AdminCountyTxt.Text.Trim();
                vaxRecord.Admin_State = AdminStateTxt.Text.Trim();
                vaxRecord.Admin_Zip = AdminZipTxt.Text;
                CbxIndex = ProviderSuffixCbx.SelectedIndex;
                vaxRecord.Admin_Suffix = pSuffixes[CbxIndex].Code;
                vaxRecord.Vtcks_Pin = VtckPinTxt.Text.Trim();
            }
            catch(Exception ex)
            { throw ex; }
        }
        private void GetNewVaxEventId()
        {
            bool vaxEventExist = false;

            do
            {
                // Generate a new vaccine event id
                // Creates a string 10 characters long with 3 letters uses digits 0-9 and A-Z
                GeneratedVaxEventId = IdGenerator.GenerateId(10, 3, 0, 9, 'A', 'Z');
                vaxEventExist = VaccineRecordDB.VerifyNewVaxEventID(GeneratedVaxEventId);
            }
            while (!vaxEventExist);
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            // Note when Vaccine is added and it is a existing patient must get the patients id from txtbox
            // and then use the Patient id to retrieve the patient's PPRL and then store the vax record with the pprl




            // At the end of the Add event these things must happen inorder to allow a provider to keep entering 
            // vaccine records for existing patients
            // 1) call ResetInputs and pass in true to clear out the ids
            ResetInputs(true);
            // 2) Get a new vacinne event id
            GetNewVaxEventId();
            // 3) Allow provider to enter existing patient id bc patient id
            // will be used to get PPRL number for vax record storage
            SetIdControlType("Patient");
            // Then exit this method
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            // Since clear btn is clicked before data submitted call resetInputs and pass false
            ResetInputs(false);
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            // closeForm is a DialogResult object it holds the value of the button selected in the messagebox
            DialogResult closeForm = MessageBox.Show("Do You wish to close the entire application?", AppTitle,
             MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            // Checks to see if yes button was selected
            if (closeForm == DialogResult.Yes)
                Application.Exit();
            // Check to see if no btn was selected
            else if (closeForm == DialogResult.No)
                this.Close();
            // Dont need to check if cancel was selected because not closing app or not closing form
            // is what cancel should do
        }

        private void VaccineRecordForm_Load(object sender, EventArgs e)
        {
            // Use method to get a new vaccine event id
            GetNewVaxEventId();

            if (!ExisitingPatient)
                SetIdControlType("PPRL");
            else if (ExisitingPatient)
                SetIdControlType("Patient");

            // Diable addbtn until all inputs are filled
            AddControl("Disable");

            // Populate the list with DB data
            resp1 = ResponsesDB.GetResponses();
            resp2 = ResponsesDB.GetResponses();
            resp3 = ResponsesDB.GetResponses();
            doses = DosesDB.GetDoses();
            vTypes = Vax_TypesDB.GetTypes();
            vProducts = Vax_ProductsDB.GetProducts();
            vManufacturers = Vax_ManufacturersDB.GetManufacturers();
            vAdminSites = Vax_Admin_StitesDB.GetAdminSites();
            vRoutes = Vax_RoutesDB.GetRoutes();
            lTypes = Location_TypeDB.GetLocationTypes();
            pSuffixes = Provider_SuffixDB.GetSuffixes();

            // Bind combo-boxs with data from lists
            VaxTypeCbx.DataSource = vTypes;
            VaxTypeCbx.DisplayMember = "Location_Type";
            VaxTypeCbx.ValueMember = "Code";

            VaxProductCbx.DataSource = vProducts;
            VaxProductCbx.DisplayMember = "Product_NDC";
            VaxProductCbx.ValueMember = "Code";

            VaxManufacturerCbx.DataSource = vManufacturers;
            VaxManufacturerCbx.DisplayMember = "Manufactuer";
            VaxManufacturerCbx.ValueMember = "Code";

            AdminSiteCbx.DataSource = vAdminSites;
            AdminSiteCbx.DisplayMember = "Admin_Site";
            AdminSiteCbx.ValueMember = "Code";

            AdminRouteCbx.DataSource = vRoutes;
            AdminRouteCbx.DisplayMember = "Route";
            AdminRouteCbx.ValueMember = "Code";

            LocTypeCbx.DataSource = lTypes;
            LocTypeCbx.DisplayMember = "Location_Type";
            LocTypeCbx.ValueMember = "Code";

            ProviderSuffixCbx.DataSource = pSuffixes;
            ProviderSuffixCbx.DisplayMember = "Suffix";
            ProviderSuffixCbx.ValueMember = "Code";

            ComorbitiyCbx.DataSource = resp1;
            ComorbitiyCbx.DisplayMember = "Response_Type";
            ComorbitiyCbx.ValueMember = "Id";

            SerologyCbx.DataSource = resp2;
            SerologyCbx.DisplayMember = "Response_Type";
            SerologyCbx.ValueMember = "Id";

            DoseNumberCbx.DataSource = doses;
            DoseNumberCbx.DisplayMember = "Dose_Type";
            DoseNumberCbx.ValueMember = "Code";

            SeriesCompleteCbx.DataSource = resp3;
            SeriesCompleteCbx.DisplayMember = "Response_Type";
            SeriesCompleteCbx.ValueMember = "Id";

            // Now populate the providers data onto form
            // Cant use populateProviderInout untl provider account creation is active
            // PopulateProviderInput();
            // Get and display extract type-- Type 'P' is Privacy Perserving Record Linkage
            // Then set the extraxt textbox's text to display extract type
            ExtractType = ExtractsDB.GetExtract("P");
            ExtractTxt.Text = ExtractType.Extract_Type;
            // Display vaxEventId in txtbx
            VaxEventIdTxt.Text = GeneratedVaxEventId;
        }

    }
}
