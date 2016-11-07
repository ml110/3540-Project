namespace CruiseControl
{
    partial class Main_Form
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
			this.label1 = new System.Windows.Forms.Label();
			this.lblDBStatus = new System.Windows.Forms.Label();
			this.cbTripSelect = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.lblCurrentTrip = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnSetTripNum = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.btnTripPlan = new System.Windows.Forms.Button();
			this.btnMap = new System.Windows.Forms.Button();
			this.btnBill = new System.Windows.Forms.Button();
			this.btnSchedule = new System.Windows.Forms.Button();
			this.btnDinner = new System.Windows.Forms.Button();
			this.btnGift = new System.Windows.Forms.Button();
			this.btnBar = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.lblCurrentDate = new System.Windows.Forms.Label();
			this.lblTripString = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.lblVessel = new System.Windows.Forms.Label();
			this.lblPass = new System.Windows.Forms.Label();
			this.dgvCrew = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dgvCrew)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(0, 408);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Database Status:";
			// 
			// lblDBStatus
			// 
			this.lblDBStatus.AutoSize = true;
			this.lblDBStatus.ForeColor = System.Drawing.Color.Red;
			this.lblDBStatus.Location = new System.Drawing.Point(88, 408);
			this.lblDBStatus.Name = "lblDBStatus";
			this.lblDBStatus.Size = new System.Drawing.Size(100, 13);
			this.lblDBStatus.TabIndex = 1;
			this.lblDBStatus.Text = "NOT CONNECTED";
			// 
			// cbTripSelect
			// 
			this.cbTripSelect.FormattingEnabled = true;
			this.cbTripSelect.Location = new System.Drawing.Point(94, 43);
			this.cbTripSelect.Name = "cbTripSelect";
			this.cbTripSelect.Size = new System.Drawing.Size(50, 21);
			this.cbTripSelect.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(76, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Current Trip ID";
			// 
			// lblCurrentTrip
			// 
			this.lblCurrentTrip.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblCurrentTrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCurrentTrip.ForeColor = System.Drawing.Color.Red;
			this.lblCurrentTrip.Location = new System.Drawing.Point(94, 18);
			this.lblCurrentTrip.Name = "lblCurrentTrip";
			this.lblCurrentTrip.Size = new System.Drawing.Size(50, 22);
			this.lblCurrentTrip.TabIndex = 4;
			this.lblCurrentTrip.Text = "N/A";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(8, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(62, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Select New";
			// 
			// btnSetTripNum
			// 
			this.btnSetTripNum.BackColor = System.Drawing.Color.LimeGreen;
			this.btnSetTripNum.Location = new System.Drawing.Point(148, 43);
			this.btnSetTripNum.Name = "btnSetTripNum";
			this.btnSetTripNum.Size = new System.Drawing.Size(48, 23);
			this.btnSetTripNum.TabIndex = 6;
			this.btnSetTripNum.Text = "SET";
			this.btnSetTripNum.UseVisualStyleBackColor = false;
			this.btnSetTripNum.Click += new System.EventHandler(this.btnSetTripNum_Click);
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.button1.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.ForeColor = System.Drawing.Color.White;
			this.button1.Location = new System.Drawing.Point(112, 216);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(80, 24);
			this.button1.TabIndex = 7;
			this.button1.Text = "T E S T";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label4.Location = new System.Drawing.Point(0, 8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(208, 68);
			this.label4.TabIndex = 8;
			// 
			// btnTripPlan
			// 
			this.btnTripPlan.Location = new System.Drawing.Point(8, 88);
			this.btnTripPlan.Name = "btnTripPlan";
			this.btnTripPlan.Size = new System.Drawing.Size(94, 37);
			this.btnTripPlan.TabIndex = 9;
			this.btnTripPlan.Text = "Itinerary Control";
			this.btnTripPlan.UseVisualStyleBackColor = true;
			// 
			// btnMap
			// 
			this.btnMap.Location = new System.Drawing.Point(8, 128);
			this.btnMap.Name = "btnMap";
			this.btnMap.Size = new System.Drawing.Size(94, 37);
			this.btnMap.TabIndex = 10;
			this.btnMap.Text = "Deck Map";
			this.btnMap.UseVisualStyleBackColor = true;
			// 
			// btnBill
			// 
			this.btnBill.Location = new System.Drawing.Point(8, 208);
			this.btnBill.Name = "btnBill";
			this.btnBill.Size = new System.Drawing.Size(94, 37);
			this.btnBill.TabIndex = 12;
			this.btnBill.Text = "Bill Generation";
			this.btnBill.UseVisualStyleBackColor = true;
			// 
			// btnSchedule
			// 
			this.btnSchedule.Location = new System.Drawing.Point(8, 168);
			this.btnSchedule.Name = "btnSchedule";
			this.btnSchedule.Size = new System.Drawing.Size(94, 37);
			this.btnSchedule.TabIndex = 11;
			this.btnSchedule.Text = "Scheduling";
			this.btnSchedule.UseVisualStyleBackColor = true;
			// 
			// btnDinner
			// 
			this.btnDinner.Location = new System.Drawing.Point(104, 168);
			this.btnDinner.Name = "btnDinner";
			this.btnDinner.Size = new System.Drawing.Size(95, 37);
			this.btnDinner.TabIndex = 15;
			this.btnDinner.Text = "Dinner Control";
			this.btnDinner.UseVisualStyleBackColor = true;
			// 
			// btnGift
			// 
			this.btnGift.Location = new System.Drawing.Point(104, 128);
			this.btnGift.Name = "btnGift";
			this.btnGift.Size = new System.Drawing.Size(95, 37);
			this.btnGift.TabIndex = 14;
			this.btnGift.Text = "Gift Shop Control";
			this.btnGift.UseVisualStyleBackColor = true;
			// 
			// btnBar
			// 
			this.btnBar.Location = new System.Drawing.Point(104, 88);
			this.btnBar.Name = "btnBar";
			this.btnBar.Size = new System.Drawing.Size(95, 37);
			this.btnBar.TabIndex = 13;
			this.btnBar.Text = "Bar Control";
			this.btnBar.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label5.Location = new System.Drawing.Point(0, 80);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(208, 176);
			this.label5.TabIndex = 16;
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label6.Location = new System.Drawing.Point(216, 8);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(544, 432);
			this.label6.TabIndex = 17;
			// 
			// lblCurrentDate
			// 
			this.lblCurrentDate.ImageAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblCurrentDate.Location = new System.Drawing.Point(0, 424);
			this.lblCurrentDate.Name = "lblCurrentDate";
			this.lblCurrentDate.Size = new System.Drawing.Size(184, 16);
			this.lblCurrentDate.TabIndex = 18;
			this.lblCurrentDate.Text = "Connection Time Here";
			// 
			// lblTripString
			// 
			this.lblTripString.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTripString.ForeColor = System.Drawing.Color.Red;
			this.lblTripString.Location = new System.Drawing.Point(224, 16);
			this.lblTripString.Name = "lblTripString";
			this.lblTripString.Size = new System.Drawing.Size(528, 56);
			this.lblTripString.TabIndex = 19;
			this.lblTripString.Text = "NO TRIP SELECTED";
			// 
			// label8
			// 
			this.label8.BackColor = System.Drawing.SystemColors.ControlLight;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(224, 80);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(160, 18);
			this.label8.TabIndex = 20;
			this.label8.Text = "VESSEL INFORMATION";
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(224, 272);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(224, 18);
			this.label9.TabIndex = 22;
			this.label9.Text = "PASSENGERS STATUS";
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(456, 80);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(224, 18);
			this.label10.TabIndex = 23;
			this.label10.Text = "CREW STATUS";
			// 
			// lblVessel
			// 
			this.lblVessel.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.lblVessel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblVessel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblVessel.Location = new System.Drawing.Point(224, 96);
			this.lblVessel.Name = "lblVessel";
			this.lblVessel.Size = new System.Drawing.Size(224, 144);
			this.lblVessel.TabIndex = 24;
			// 
			// lblPass
			// 
			this.lblPass.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.lblPass.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPass.Location = new System.Drawing.Point(224, 288);
			this.lblPass.Name = "lblPass";
			this.lblPass.Size = new System.Drawing.Size(224, 144);
			this.lblPass.TabIndex = 25;
			// 
			// dgvCrew
			// 
			this.dgvCrew.AllowUserToAddRows = false;
			this.dgvCrew.AllowUserToDeleteRows = false;
			this.dgvCrew.AllowUserToResizeColumns = false;
			this.dgvCrew.AllowUserToResizeRows = false;
			this.dgvCrew.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgvCrew.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dgvCrew.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvCrew.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvCrew.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
			this.dgvCrew.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCrew.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvCrew.Location = new System.Drawing.Point(456, 96);
			this.dgvCrew.Name = "dgvCrew";
			this.dgvCrew.RowHeadersVisible = false;
			this.dgvCrew.Size = new System.Drawing.Size(296, 336);
			this.dgvCrew.TabIndex = 26;
			// 
			// Main_Form
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(763, 447);
			this.Controls.Add(this.dgvCrew);
			this.Controls.Add(this.lblPass);
			this.Controls.Add(this.lblVessel);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.lblTripString);
			this.Controls.Add(this.lblCurrentDate);
			this.Controls.Add(this.btnDinner);
			this.Controls.Add(this.btnGift);
			this.Controls.Add(this.btnBar);
			this.Controls.Add(this.btnBill);
			this.Controls.Add(this.btnSchedule);
			this.Controls.Add(this.btnMap);
			this.Controls.Add(this.btnTripPlan);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btnSetTripNum);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lblCurrentTrip);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cbTripSelect);
			this.Controls.Add(this.lblDBStatus);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label6);
			this.Name = "Main_Form";
			this.Text = "CRUISE CONTROL: Set Sail For Fail";
			this.Load += new System.EventHandler(this.Main_Form_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvCrew)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDBStatus;
        private System.Windows.Forms.ComboBox cbTripSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCurrentTrip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSetTripNum;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTripPlan;
        private System.Windows.Forms.Button btnMap;
        private System.Windows.Forms.Button btnBill;
        private System.Windows.Forms.Button btnSchedule;
        private System.Windows.Forms.Button btnDinner;
        private System.Windows.Forms.Button btnGift;
        private System.Windows.Forms.Button btnBar;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lblCurrentDate;
		private System.Windows.Forms.Label lblTripString;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label lblVessel;
		private System.Windows.Forms.Label lblPass;
		private System.Windows.Forms.DataGridView dgvCrew;
    }
}

