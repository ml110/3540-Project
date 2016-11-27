namespace customerSignUp
{
    partial class Form1
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
            this.label3 = new System.Windows.Forms.Label();
            this.phNumbeInput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lNameInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tripDetails = new System.Windows.Forms.ComboBox();
            this.fNameInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numberGuestInput = new System.Windows.Forms.ComboBox();
            this.txtBoxDepartDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtShipName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.emailInput = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cityInput = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.addressInput = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.dateOfBirthGus0 = new System.Windows.Forms.DateTimePicker();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelLName = new System.Windows.Forms.Label();
            this.labelFName = new System.Windows.Forms.Label();
            this.labelPhone = new System.Windows.Forms.Label();
            this.labelCity = new System.Windows.Forms.Label();
            this.labelCountry = new System.Windows.Forms.Label();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelNumberOfGuest = new System.Windows.Forms.Label();
            this.labelItinerary = new System.Windows.Forms.Label();
            this.labelDateGus0 = new System.Windows.Forms.Label();
            this.countryInput = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(735, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Number of Guests";
            // 
            // phNumbeInput
            // 
            this.phNumbeInput.BackColor = System.Drawing.Color.GhostWhite;
            this.phNumbeInput.ForeColor = System.Drawing.Color.Black;
            this.phNumbeInput.Location = new System.Drawing.Point(208, 377);
            this.phNumbeInput.Name = "phNumbeInput";
            this.phNumbeInput.Size = new System.Drawing.Size(244, 27);
            this.phNumbeInput.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(204, 355);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Phone Number";
            // 
            // lNameInput
            // 
            this.lNameInput.BackColor = System.Drawing.Color.GhostWhite;
            this.lNameInput.ForeColor = System.Drawing.Color.Black;
            this.lNameInput.Location = new System.Drawing.Point(208, 306);
            this.lNameInput.Name = "lNameInput";
            this.lNameInput.Size = new System.Drawing.Size(244, 27);
            this.lNameInput.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 284);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Last Name";
            // 
            // tripDetails
            // 
            this.tripDetails.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tripDetails.FormattingEnabled = true;
            this.tripDetails.Location = new System.Drawing.Point(299, 89);
            this.tripDetails.Name = "tripDetails";
            this.tripDetails.Size = new System.Drawing.Size(592, 28);
            this.tripDetails.TabIndex = 12;
            this.tripDetails.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // fNameInput
            // 
            this.fNameInput.BackColor = System.Drawing.Color.GhostWhite;
            this.fNameInput.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fNameInput.ForeColor = System.Drawing.Color.Black;
            this.fNameInput.Location = new System.Drawing.Point(208, 240);
            this.fNameInput.Name = "fNameInput";
            this.fNameInput.Size = new System.Drawing.Size(244, 27);
            this.fNameInput.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(204, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "First Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(142, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 20);
            this.label5.TabIndex = 20;
            this.label5.Text = "Cruise Itinerary";
            // 
            // numberGuestInput
            // 
            this.numberGuestInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.numberGuestInput.FormattingEnabled = true;
            this.numberGuestInput.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.numberGuestInput.Location = new System.Drawing.Point(702, 165);
            this.numberGuestInput.Name = "numberGuestInput";
            this.numberGuestInput.Size = new System.Drawing.Size(220, 28);
            this.numberGuestInput.TabIndex = 21;
            // 
            // txtBoxDepartDate
            // 
            this.txtBoxDepartDate.BackColor = System.Drawing.Color.GhostWhite;
            this.txtBoxDepartDate.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtBoxDepartDate.ForeColor = System.Drawing.Color.Black;
            this.txtBoxDepartDate.Location = new System.Drawing.Point(123, 165);
            this.txtBoxDepartDate.Name = "txtBoxDepartDate";
            this.txtBoxDepartDate.ReadOnly = true;
            this.txtBoxDepartDate.Size = new System.Drawing.Size(220, 27);
            this.txtBoxDepartDate.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(164, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 20);
            this.label6.TabIndex = 22;
            this.label6.Text = "Departure Date";
            // 
            // txtShipName
            // 
            this.txtShipName.BackColor = System.Drawing.Color.GhostWhite;
            this.txtShipName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtShipName.ForeColor = System.Drawing.Color.Black;
            this.txtShipName.Location = new System.Drawing.Point(412, 165);
            this.txtShipName.Name = "txtShipName";
            this.txtShipName.ReadOnly = true;
            this.txtShipName.Size = new System.Drawing.Size(220, 27);
            this.txtShipName.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(495, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 20);
            this.label7.TabIndex = 24;
            this.label7.Text = "Ship";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(204, 428);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 20);
            this.label9.TabIndex = 28;
            this.label9.Text = "Date Of Birth";
            // 
            // emailInput
            // 
            this.emailInput.BackColor = System.Drawing.Color.GhostWhite;
            this.emailInput.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.emailInput.ForeColor = System.Drawing.Color.Black;
            this.emailInput.Location = new System.Drawing.Point(594, 451);
            this.emailInput.Name = "emailInput";
            this.emailInput.Size = new System.Drawing.Size(244, 27);
            this.emailInput.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(589, 428);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 20);
            this.label10.TabIndex = 26;
            this.label10.Text = "Email";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(589, 355);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 20);
            this.label14.TabIndex = 36;
            this.label14.Text = "Country";
            // 
            // cityInput
            // 
            this.cityInput.BackColor = System.Drawing.Color.GhostWhite;
            this.cityInput.ForeColor = System.Drawing.Color.Black;
            this.cityInput.Location = new System.Drawing.Point(594, 306);
            this.cityInput.Name = "cityInput";
            this.cityInput.Size = new System.Drawing.Size(244, 27);
            this.cityInput.TabIndex = 35;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(589, 284);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 20);
            this.label15.TabIndex = 34;
            this.label15.Text = "City";
            // 
            // addressInput
            // 
            this.addressInput.BackColor = System.Drawing.Color.GhostWhite;
            this.addressInput.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.addressInput.ForeColor = System.Drawing.Color.Black;
            this.addressInput.Location = new System.Drawing.Point(594, 240);
            this.addressInput.Name = "addressInput";
            this.addressInput.Size = new System.Drawing.Size(244, 27);
            this.addressInput.TabIndex = 33;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(589, 217);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 20);
            this.label16.TabIndex = 32;
            this.label16.Text = "Address";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SteelBlue;
            this.button1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(764, 515);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(211, 48);
            this.button1.TabIndex = 38;
            this.button1.Text = "NEXT: STATEROOM >";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Palatino Linotype", 32F);
            this.label8.Location = new System.Drawing.Point(339, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(388, 58);
            this.label8.TabIndex = 39;
            this.label8.Text = "Steve’s Cruise Line";
            // 
            // dateOfBirthGus0
            // 
            this.dateOfBirthGus0.CustomFormat = "MMMM dd yyyy";
            this.dateOfBirthGus0.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateOfBirthGus0.Location = new System.Drawing.Point(208, 452);
            this.dateOfBirthGus0.Name = "dateOfBirthGus0";
            this.dateOfBirthGus0.Size = new System.Drawing.Size(244, 27);
            this.dateOfBirthGus0.TabIndex = 40;
            this.dateOfBirthGus0.Value = new System.DateTime(2016, 11, 5, 0, 0, 0, 0);
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.Location = new System.Drawing.Point(638, 428);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(0, 15);
            this.labelEmail.TabIndex = 43;
            // 
            // labelLName
            // 
            this.labelLName.AutoSize = true;
            this.labelLName.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLName.Location = new System.Drawing.Point(298, 284);
            this.labelLName.Name = "labelLName";
            this.labelLName.Size = new System.Drawing.Size(0, 15);
            this.labelLName.TabIndex = 45;
            // 
            // labelFName
            // 
            this.labelFName.AutoSize = true;
            this.labelFName.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFName.Location = new System.Drawing.Point(299, 217);
            this.labelFName.Name = "labelFName";
            this.labelFName.Size = new System.Drawing.Size(0, 15);
            this.labelFName.TabIndex = 44;
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPhone.Location = new System.Drawing.Point(330, 355);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(0, 15);
            this.labelPhone.TabIndex = 46;
            // 
            // labelCity
            // 
            this.labelCity.AutoSize = true;
            this.labelCity.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCity.Location = new System.Drawing.Point(627, 285);
            this.labelCity.Name = "labelCity";
            this.labelCity.Size = new System.Drawing.Size(0, 15);
            this.labelCity.TabIndex = 47;
            // 
            // labelCountry
            // 
            this.labelCountry.AutoSize = true;
            this.labelCountry.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCountry.Location = new System.Drawing.Point(658, 355);
            this.labelCountry.Name = "labelCountry";
            this.labelCountry.Size = new System.Drawing.Size(0, 15);
            this.labelCountry.TabIndex = 48;
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddress.Location = new System.Drawing.Point(660, 217);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(0, 15);
            this.labelAddress.TabIndex = 49;
            // 
            // labelNumberOfGuest
            // 
            this.labelNumberOfGuest.AutoSize = true;
            this.labelNumberOfGuest.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumberOfGuest.Location = new System.Drawing.Point(889, 142);
            this.labelNumberOfGuest.Name = "labelNumberOfGuest";
            this.labelNumberOfGuest.Size = new System.Drawing.Size(0, 15);
            this.labelNumberOfGuest.TabIndex = 50;
            // 
            // labelItinerary
            // 
            this.labelItinerary.AutoSize = true;
            this.labelItinerary.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItinerary.Location = new System.Drawing.Point(275, 92);
            this.labelItinerary.Name = "labelItinerary";
            this.labelItinerary.Size = new System.Drawing.Size(0, 15);
            this.labelItinerary.TabIndex = 51;
            // 
            // labelDateGus0
            // 
            this.labelDateGus0.AutoSize = true;
            this.labelDateGus0.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDateGus0.Location = new System.Drawing.Point(319, 428);
            this.labelDateGus0.Name = "labelDateGus0";
            this.labelDateGus0.Size = new System.Drawing.Size(0, 15);
            this.labelDateGus0.TabIndex = 52;
            // 
            // countryInput
            // 
            this.countryInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.countryInput.FormattingEnabled = true;
            this.countryInput.Location = new System.Drawing.Point(594, 377);
            this.countryInput.Name = "countryInput";
            this.countryInput.Size = new System.Drawing.Size(244, 28);
            this.countryInput.Sorted = true;
            this.countryInput.TabIndex = 53;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1032, 603);
            this.Controls.Add(this.countryInput);
            this.Controls.Add(this.labelDateGus0);
            this.Controls.Add(this.labelItinerary);
            this.Controls.Add(this.labelNumberOfGuest);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.labelCountry);
            this.Controls.Add(this.labelCity);
            this.Controls.Add(this.labelPhone);
            this.Controls.Add(this.labelLName);
            this.Controls.Add(this.labelFName);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.dateOfBirthGus0);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cityInput);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.addressInput);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.emailInput);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtShipName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtBoxDepartDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numberGuestInput);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.phNumbeInput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lNameInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tripDetails);
            this.Controls.Add(this.fNameInput);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox phNumbeInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox lNameInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox tripDetails;
        private System.Windows.Forms.TextBox fNameInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox numberGuestInput;
        private System.Windows.Forms.TextBox txtBoxDepartDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtShipName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox emailInput;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox cityInput;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox addressInput;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateOfBirthGus0;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelLName;
        private System.Windows.Forms.Label labelFName;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.Label labelCity;
        private System.Windows.Forms.Label labelCountry;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label labelNumberOfGuest;
        private System.Windows.Forms.Label labelItinerary;
        private System.Windows.Forms.Label labelDateGus0;
        private System.Windows.Forms.ComboBox countryInput;
    }
}