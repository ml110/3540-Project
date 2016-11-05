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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 354);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Database Status:";
            // 
            // lblDBStatus
            // 
            this.lblDBStatus.AutoSize = true;
            this.lblDBStatus.ForeColor = System.Drawing.Color.Red;
            this.lblDBStatus.Location = new System.Drawing.Point(96, 354);
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
            this.cbTripSelect.Size = new System.Drawing.Size(48, 21);
            this.cbTripSelect.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Current Trip ID";
            // 
            // lblCurrentTrip
            // 
            this.lblCurrentTrip.AutoSize = true;
            this.lblCurrentTrip.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCurrentTrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentTrip.ForeColor = System.Drawing.Color.Red;
            this.lblCurrentTrip.Location = new System.Drawing.Point(94, 18);
            this.lblCurrentTrip.Name = "lblCurrentTrip";
            this.lblCurrentTrip.Size = new System.Drawing.Size(40, 22);
            this.lblCurrentTrip.TabIndex = 4;
            this.lblCurrentTrip.Text = "N/A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Select New";
            // 
            // btnSetTripNum
            // 
            this.btnSetTripNum.BackColor = System.Drawing.Color.Aqua;
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
            this.button1.BackColor = System.Drawing.Color.Fuchsia;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(211, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 28);
            this.button1.TabIndex = 7;
            this.button1.Text = "HAHA IT WORKS";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(2, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 69);
            this.label4.TabIndex = 8;
            // 
            // btnTripPlan
            // 
            this.btnTripPlan.Location = new System.Drawing.Point(2, 92);
            this.btnTripPlan.Name = "btnTripPlan";
            this.btnTripPlan.Size = new System.Drawing.Size(100, 37);
            this.btnTripPlan.TabIndex = 9;
            this.btnTripPlan.Text = "Itinerary Planner";
            this.btnTripPlan.UseVisualStyleBackColor = true;
            // 
            // btnMap
            // 
            this.btnMap.Location = new System.Drawing.Point(2, 135);
            this.btnMap.Name = "btnMap";
            this.btnMap.Size = new System.Drawing.Size(100, 37);
            this.btnMap.TabIndex = 10;
            this.btnMap.Text = "Deck Maps";
            this.btnMap.UseVisualStyleBackColor = true;
            // 
            // btnBill
            // 
            this.btnBill.Location = new System.Drawing.Point(2, 221);
            this.btnBill.Name = "btnBill";
            this.btnBill.Size = new System.Drawing.Size(100, 37);
            this.btnBill.TabIndex = 12;
            this.btnBill.Text = "Bill Generation";
            this.btnBill.UseVisualStyleBackColor = true;
            // 
            // btnSchedule
            // 
            this.btnSchedule.Location = new System.Drawing.Point(2, 178);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(100, 37);
            this.btnSchedule.TabIndex = 11;
            this.btnSchedule.Text = "Scheduling";
            this.btnSchedule.UseVisualStyleBackColor = true;
            // 
            // btnDinner
            // 
            this.btnDinner.Location = new System.Drawing.Point(105, 178);
            this.btnDinner.Name = "btnDinner";
            this.btnDinner.Size = new System.Drawing.Size(100, 37);
            this.btnDinner.TabIndex = 15;
            this.btnDinner.Text = "Dinner Control";
            this.btnDinner.UseVisualStyleBackColor = true;
            // 
            // btnGift
            // 
            this.btnGift.Location = new System.Drawing.Point(105, 135);
            this.btnGift.Name = "btnGift";
            this.btnGift.Size = new System.Drawing.Size(100, 37);
            this.btnGift.TabIndex = 14;
            this.btnGift.Text = "Gift Shop Control";
            this.btnGift.UseVisualStyleBackColor = true;
            // 
            // btnBar
            // 
            this.btnBar.Location = new System.Drawing.Point(105, 92);
            this.btnBar.Name = "btnBar";
            this.btnBar.Size = new System.Drawing.Size(100, 37);
            this.btnBar.TabIndex = 13;
            this.btnBar.Text = "Bar Control";
            this.btnBar.UseVisualStyleBackColor = true;
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 376);
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
            this.Name = "Main_Form";
            this.Text = "CRUISE CONTROL: Set Sail For Fail";
            this.Load += new System.EventHandler(this.Main_Form_Load);
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
    }
}

