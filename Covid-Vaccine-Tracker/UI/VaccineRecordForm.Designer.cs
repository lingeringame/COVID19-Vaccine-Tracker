
namespace Covid_Vaccine_Tracker.UI
{
    partial class VaccineRecordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VaccineRecordForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ExtractTxt = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ExperationDateDp = new System.Windows.Forms.DateTimePicker();
            this.LotNumberTxt = new System.Windows.Forms.MaskedTextBox();
            this.DateAdminDp = new System.Windows.Forms.DateTimePicker();
            this.VaxManufacturerTxt = new System.Windows.Forms.ComboBox();
            this.VaxProductTxt = new System.Windows.Forms.ComboBox();
            this.VaxTypeTxt = new System.Windows.Forms.ComboBox();
            this.VaxEventIdTxt = new System.Windows.Forms.MaskedTextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.AdminZipTxt = new System.Windows.Forms.MaskedTextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.AdminStateTxt = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.AdminCountyTxt = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.AdminCityTxt = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.AdminStreetTxt = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.ProviderSuffixCbx = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.SerologyCbx = new System.Windows.Forms.ComboBox();
            this.Comorbitiy = new System.Windows.Forms.ComboBox();
            this.ComorbidityCbx = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.VtckPinTxt = new System.Windows.Forms.MaskedTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.LocTypeCbx = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.AdminLocTxt = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.SeriesCompleteCbx = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.AdminRouteCbx = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.OrganizationTxt = new System.Windows.Forms.TextBox();
            this.DoseNumberCbx = new System.Windows.Forms.ComboBox();
            this.AdminSiteCbx = new System.Windows.Forms.ComboBox();
            this.PatientIdTxt = new System.Windows.Forms.MaskedTextBox();
            this.AddBtn = new System.Windows.Forms.Button();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ErrorPv = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorPv)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.ExtractTxt);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ExperationDateDp);
            this.groupBox1.Controls.Add(this.LotNumberTxt);
            this.groupBox1.Controls.Add(this.DateAdminDp);
            this.groupBox1.Controls.Add(this.VaxManufacturerTxt);
            this.groupBox1.Controls.Add(this.VaxProductTxt);
            this.groupBox1.Controls.Add(this.VaxTypeTxt);
            this.groupBox1.Controls.Add(this.VaxEventIdTxt);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(87, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(549, 191);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vaccine Information";
            // 
            // ExtractTxt
            // 
            this.ExtractTxt.Enabled = false;
            this.ExtractTxt.Location = new System.Drawing.Point(31, 45);
            this.ExtractTxt.Name = "ExtractTxt";
            this.ExtractTxt.ReadOnly = true;
            this.ExtractTxt.Size = new System.Drawing.Size(131, 24);
            this.ExtractTxt.TabIndex = 56;
            this.toolTip1.SetToolTip(this.ExtractTxt, "Specifies if record is Personaly Identifying");
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 128);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 18);
            this.label10.TabIndex = 23;
            this.label10.Text = "Experation Date";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(378, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 18);
            this.label9.TabIndex = 22;
            this.label9.Text = "Lot Number";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(205, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(151, 18);
            this.label8.TabIndex = 21;
            this.label8.Text = "Vaccine Manufacturer";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 18);
            this.label7.TabIndex = 20;
            this.label7.Text = "Vaccine Product";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(378, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 18);
            this.label6.TabIndex = 19;
            this.label6.Text = "Vaccine Type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(260, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 18);
            this.label5.TabIndex = 18;
            this.label5.Text = "Date Administered";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(205, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 18);
            this.label4.TabIndex = 17;
            this.label4.Text = "Vaccine Event Id";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "Extract Type";
            // 
            // ExperationDateDp
            // 
            this.ExperationDateDp.Location = new System.Drawing.Point(30, 147);
            this.ExperationDateDp.Name = "ExperationDateDp";
            this.ExperationDateDp.Size = new System.Drawing.Size(200, 24);
            this.ExperationDateDp.TabIndex = 10;
            // 
            // LotNumberTxt
            // 
            this.LotNumberTxt.Location = new System.Drawing.Point(380, 94);
            this.LotNumberTxt.Mask = "0000LLLL";
            this.LotNumberTxt.Name = "LotNumberTxt";
            this.LotNumberTxt.Size = new System.Drawing.Size(83, 24);
            this.LotNumberTxt.TabIndex = 9;
            this.LotNumberTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LotNumberTxt.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // DateAdminDp
            // 
            this.DateAdminDp.Location = new System.Drawing.Point(263, 148);
            this.DateAdminDp.Name = "DateAdminDp";
            this.DateAdminDp.Size = new System.Drawing.Size(200, 24);
            this.DateAdminDp.TabIndex = 8;
            // 
            // VaxManufacturerTxt
            // 
            this.VaxManufacturerTxt.FormattingEnabled = true;
            this.VaxManufacturerTxt.Location = new System.Drawing.Point(208, 96);
            this.VaxManufacturerTxt.Name = "VaxManufacturerTxt";
            this.VaxManufacturerTxt.Size = new System.Drawing.Size(142, 26);
            this.VaxManufacturerTxt.TabIndex = 7;
            // 
            // VaxProductTxt
            // 
            this.VaxProductTxt.FormattingEnabled = true;
            this.VaxProductTxt.Location = new System.Drawing.Point(31, 96);
            this.VaxProductTxt.Name = "VaxProductTxt";
            this.VaxProductTxt.Size = new System.Drawing.Size(150, 26);
            this.VaxProductTxt.TabIndex = 6;
            // 
            // VaxTypeTxt
            // 
            this.VaxTypeTxt.FormattingEnabled = true;
            this.VaxTypeTxt.Location = new System.Drawing.Point(380, 43);
            this.VaxTypeTxt.Name = "VaxTypeTxt";
            this.VaxTypeTxt.Size = new System.Drawing.Size(142, 26);
            this.VaxTypeTxt.TabIndex = 5;
            // 
            // VaxEventIdTxt
            // 
            this.VaxEventIdTxt.Enabled = false;
            this.VaxEventIdTxt.Location = new System.Drawing.Point(208, 45);
            this.VaxEventIdTxt.Mask = "0000000LLL";
            this.VaxEventIdTxt.Name = "VaxEventIdTxt";
            this.VaxEventIdTxt.ReadOnly = true;
            this.VaxEventIdTxt.Size = new System.Drawing.Size(113, 24);
            this.VaxEventIdTxt.TabIndex = 4;
            this.VaxEventIdTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.VaxEventIdTxt.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.toolTip1.SetToolTip(this.VaxEventIdTxt, "Id for specific administered vaccine");
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(463, 137);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(61, 18);
            this.label27.TabIndex = 55;
            this.label27.Text = "Zipcode";
            // 
            // AdminZipTxt
            // 
            this.AdminZipTxt.Location = new System.Drawing.Point(466, 156);
            this.AdminZipTxt.Mask = "00000";
            this.AdminZipTxt.Name = "AdminZipTxt";
            this.AdminZipTxt.Size = new System.Drawing.Size(83, 24);
            this.AdminZipTxt.TabIndex = 54;
            this.AdminZipTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AdminZipTxt.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(262, 137);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(42, 18);
            this.label26.TabIndex = 53;
            this.label26.Text = "State";
            // 
            // AdminStateTxt
            // 
            this.AdminStateTxt.Location = new System.Drawing.Point(265, 156);
            this.AdminStateTxt.Name = "AdminStateTxt";
            this.AdminStateTxt.Size = new System.Drawing.Size(183, 24);
            this.AdminStateTxt.TabIndex = 52;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(21, 137);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(55, 18);
            this.label25.TabIndex = 51;
            this.label25.Text = "County";
            // 
            // AdminCountyTxt
            // 
            this.AdminCountyTxt.Location = new System.Drawing.Point(24, 156);
            this.AdminCountyTxt.Name = "AdminCountyTxt";
            this.AdminCountyTxt.Size = new System.Drawing.Size(215, 24);
            this.AdminCountyTxt.TabIndex = 50;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(331, 82);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(33, 18);
            this.label24.TabIndex = 49;
            this.label24.Text = "City";
            // 
            // AdminCityTxt
            // 
            this.AdminCityTxt.Location = new System.Drawing.Point(334, 103);
            this.AdminCityTxt.Name = "AdminCityTxt";
            this.AdminCityTxt.Size = new System.Drawing.Size(215, 24);
            this.AdminCityTxt.TabIndex = 48;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(21, 82);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(105, 18);
            this.label23.TabIndex = 47;
            this.label23.Text = "Street Address";
            // 
            // AdminStreetTxt
            // 
            this.AdminStreetTxt.Location = new System.Drawing.Point(24, 103);
            this.AdminStreetTxt.Name = "AdminStreetTxt";
            this.AdminStreetTxt.Size = new System.Drawing.Size(285, 24);
            this.AdminStreetTxt.TabIndex = 46;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(22, 189);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(103, 18);
            this.label22.TabIndex = 45;
            this.label22.Text = "Provider Suffix";
            // 
            // ProviderSuffixCbx
            // 
            this.ProviderSuffixCbx.FormattingEnabled = true;
            this.ProviderSuffixCbx.Location = new System.Drawing.Point(25, 208);
            this.ProviderSuffixCbx.Name = "ProviderSuffixCbx";
            this.ProviderSuffixCbx.Size = new System.Drawing.Size(105, 26);
            this.ProviderSuffixCbx.TabIndex = 44;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(190, 26);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(121, 18);
            this.label20.TabIndex = 41;
            this.label20.Text = "Serology Results";
            // 
            // SerologyCbx
            // 
            this.SerologyCbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SerologyCbx.FormattingEnabled = true;
            this.SerologyCbx.Location = new System.Drawing.Point(193, 47);
            this.SerologyCbx.Name = "SerologyCbx";
            this.SerologyCbx.Size = new System.Drawing.Size(105, 26);
            this.SerologyCbx.TabIndex = 40;
            // 
            // Comorbitiy
            // 
            this.Comorbitiy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Comorbitiy.FormattingEnabled = true;
            this.Comorbitiy.Location = new System.Drawing.Point(35, 47);
            this.Comorbitiy.Name = "Comorbitiy";
            this.Comorbitiy.Size = new System.Drawing.Size(131, 26);
            this.Comorbitiy.TabIndex = 39;
            // 
            // ComorbidityCbx
            // 
            this.ComorbidityCbx.AutoSize = true;
            this.ComorbidityCbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComorbidityCbx.Location = new System.Drawing.Point(32, 26);
            this.ComorbidityCbx.Name = "ComorbidityCbx";
            this.ComorbidityCbx.Size = new System.Drawing.Size(134, 18);
            this.ComorbidityCbx.TabIndex = 38;
            this.ComorbidityCbx.Text = "Comorbidity Status";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(158, 189);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(70, 18);
            this.label18.TabIndex = 36;
            this.label18.Text = "Vtcks Pin";
            // 
            // VtckPinTxt
            // 
            this.VtckPinTxt.Enabled = false;
            this.VtckPinTxt.Location = new System.Drawing.Point(161, 208);
            this.VtckPinTxt.Mask = "0000LL";
            this.VtckPinTxt.Name = "VtckPinTxt";
            this.VtckPinTxt.ReadOnly = true;
            this.VtckPinTxt.Size = new System.Drawing.Size(93, 24);
            this.VtckPinTxt.TabIndex = 35;
            this.VtckPinTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.VtckPinTxt.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.toolTip1.SetToolTip(this.VtckPinTxt, "Administering provider\'s vticks pin");
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(418, 30);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(101, 18);
            this.label17.TabIndex = 34;
            this.label17.Text = "Location Type";
            // 
            // LocTypeCbx
            // 
            this.LocTypeCbx.FormattingEnabled = true;
            this.LocTypeCbx.Location = new System.Drawing.Point(421, 49);
            this.LocTypeCbx.Name = "LocTypeCbx";
            this.LocTypeCbx.Size = new System.Drawing.Size(155, 26);
            this.LocTypeCbx.TabIndex = 33;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(220, 30);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(154, 18);
            this.label16.TabIndex = 32;
            this.label16.Text = "Administered Location";
            // 
            // AdminLocTxt
            // 
            this.AdminLocTxt.Location = new System.Drawing.Point(223, 51);
            this.AdminLocTxt.Name = "AdminLocTxt";
            this.AdminLocTxt.Size = new System.Drawing.Size(175, 24);
            this.AdminLocTxt.TabIndex = 31;
            this.toolTip1.SetToolTip(this.AdminLocTxt, "Where the vaccination took place");
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(22, 30);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(178, 18);
            this.label15.TabIndex = 30;
            this.label15.Text = "Responsible Organization";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(447, 26);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(118, 18);
            this.label14.TabIndex = 29;
            this.label14.Text = "Series Complete";
            // 
            // SeriesCompleteCbx
            // 
            this.SeriesCompleteCbx.FormattingEnabled = true;
            this.SeriesCompleteCbx.Location = new System.Drawing.Point(450, 47);
            this.SeriesCompleteCbx.Name = "SeriesCompleteCbx";
            this.SeriesCompleteCbx.Size = new System.Drawing.Size(105, 26);
            this.SeriesCompleteCbx.TabIndex = 28;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(322, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 18);
            this.label13.TabIndex = 27;
            this.label13.Text = "Dose Number";
            // 
            // AdminRouteCbx
            // 
            this.AdminRouteCbx.FormattingEnabled = true;
            this.AdminRouteCbx.Location = new System.Drawing.Point(220, 101);
            this.AdminRouteCbx.Name = "AdminRouteCbx";
            this.AdminRouteCbx.Size = new System.Drawing.Size(155, 26);
            this.AdminRouteCbx.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(217, 80);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(128, 18);
            this.label12.TabIndex = 25;
            this.label12.Text = "Vaccination Route";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(32, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 18);
            this.label11.TabIndex = 24;
            this.label11.Text = "Vaccination Site";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(402, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 18);
            this.label3.TabIndex = 16;
            this.label3.Text = "PPRL";
            // 
            // OrganizationTxt
            // 
            this.OrganizationTxt.Location = new System.Drawing.Point(25, 51);
            this.OrganizationTxt.Name = "OrganizationTxt";
            this.OrganizationTxt.Size = new System.Drawing.Size(175, 24);
            this.OrganizationTxt.TabIndex = 13;
            // 
            // DoseNumberCbx
            // 
            this.DoseNumberCbx.FormattingEnabled = true;
            this.DoseNumberCbx.Location = new System.Drawing.Point(325, 47);
            this.DoseNumberCbx.Name = "DoseNumberCbx";
            this.DoseNumberCbx.Size = new System.Drawing.Size(98, 26);
            this.DoseNumberCbx.TabIndex = 12;
            // 
            // AdminSiteCbx
            // 
            this.AdminSiteCbx.FormattingEnabled = true;
            this.AdminSiteCbx.Location = new System.Drawing.Point(35, 101);
            this.AdminSiteCbx.Name = "AdminSiteCbx";
            this.AdminSiteCbx.Size = new System.Drawing.Size(155, 26);
            this.AdminSiteCbx.TabIndex = 11;
            // 
            // PatientIdTxt
            // 
            this.PatientIdTxt.Enabled = false;
            this.PatientIdTxt.Location = new System.Drawing.Point(405, 101);
            this.PatientIdTxt.Mask = "0000000LLL";
            this.PatientIdTxt.Name = "PatientIdTxt";
            this.PatientIdTxt.ReadOnly = true;
            this.PatientIdTxt.Size = new System.Drawing.Size(93, 24);
            this.PatientIdTxt.TabIndex = 3;
            this.PatientIdTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PatientIdTxt.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.toolTip1.SetToolTip(this.PatientIdTxt, "Privacy Perserving Record Linkage number used to tie a vaccine to a patient");
            // 
            // AddBtn
            // 
            this.AddBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddBtn.Location = new System.Drawing.Point(99, 676);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(107, 34);
            this.AddBtn.TabIndex = 1;
            this.AddBtn.Text = "Add";
            this.AddBtn.UseVisualStyleBackColor = true;
            // 
            // ClearBtn
            // 
            this.ClearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearBtn.Location = new System.Drawing.Point(308, 676);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(107, 34);
            this.ClearBtn.TabIndex = 2;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.UseVisualStyleBackColor = true;
            // 
            // ExitBtn
            // 
            this.ExitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.Location = new System.Drawing.Point(517, 676);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(107, 34);
            this.ExitBtn.TabIndex = 3;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.OrganizationTxt);
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.AdminZipTxt);
            this.groupBox2.Controls.Add(this.AdminLocTxt);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.AdminStateTxt);
            this.groupBox2.Controls.Add(this.LocTypeCbx);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.AdminCountyTxt);
            this.groupBox2.Controls.Add(this.VtckPinTxt);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.AdminCityTxt);
            this.groupBox2.Controls.Add(this.ProviderSuffixCbx);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.AdminStreetTxt);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(63, 393);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(596, 255);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Administed Location Information";
            this.toolTip1.SetToolTip(this.groupBox2, "Information about where the vaccination took place");
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Controls.Add(this.Comorbitiy);
            this.groupBox3.Controls.Add(this.AdminRouteCbx);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.ComorbidityCbx);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.PatientIdTxt);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.SeriesCompleteCbx);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.SerologyCbx);
            this.groupBox3.Controls.Add(this.DoseNumberCbx);
            this.groupBox3.Controls.Add(this.AdminSiteCbx);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(63, 234);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(596, 145);
            this.groupBox3.TabIndex = 57;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Patient Information";
            // 
            // ErrorPv
            // 
            this.ErrorPv.ContainerControl = this;
            this.ErrorPv.Icon = ((System.Drawing.Icon)(resources.GetObject("ErrorPv.Icon")));
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.Color.LemonChiffon;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // VaccineRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(722, 727);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VaccineRecordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vaccine Portal";
            this.Load += new System.EventHandler(this.VaccineRecordForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorPv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.MaskedTextBox AdminZipTxt;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox AdminStateTxt;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox AdminCountyTxt;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox AdminCityTxt;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox AdminStreetTxt;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox ProviderSuffixCbx;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox SerologyCbx;
        private System.Windows.Forms.ComboBox Comorbitiy;
        private System.Windows.Forms.Label ComorbidityCbx;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.MaskedTextBox VtckPinTxt;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox LocTypeCbx;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox AdminLocTxt;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox SeriesCompleteCbx;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox AdminRouteCbx;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox OrganizationTxt;
        private System.Windows.Forms.ComboBox DoseNumberCbx;
        private System.Windows.Forms.ComboBox AdminSiteCbx;
        private System.Windows.Forms.DateTimePicker ExperationDateDp;
        private System.Windows.Forms.MaskedTextBox LotNumberTxt;
        private System.Windows.Forms.DateTimePicker DateAdminDp;
        private System.Windows.Forms.ComboBox VaxManufacturerTxt;
        private System.Windows.Forms.ComboBox VaxProductTxt;
        private System.Windows.Forms.ComboBox VaxTypeTxt;
        private System.Windows.Forms.MaskedTextBox VaxEventIdTxt;
        private System.Windows.Forms.MaskedTextBox PatientIdTxt;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.TextBox ExtractTxt;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ErrorProvider ErrorPv;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}