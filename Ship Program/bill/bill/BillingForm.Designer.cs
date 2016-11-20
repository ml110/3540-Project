namespace bill
{
    partial class BillingForm
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
            this.calcBill = new System.Windows.Forms.Button();
            this.printBill = new System.Windows.Forms.Button();
            this.ship_id = new System.Windows.Forms.Label();
            this.room_id = new System.Windows.Forms.Label();
            this.shipId = new System.Windows.Forms.TextBox();
            this.rumID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // calcBill
            // 
            this.calcBill.Location = new System.Drawing.Point(70, 273);
            this.calcBill.Name = "calcBill";
            this.calcBill.Size = new System.Drawing.Size(100, 35);
            this.calcBill.TabIndex = 5;
            this.calcBill.Text = "Calculate Bill";
            this.calcBill.UseVisualStyleBackColor = true;
            this.calcBill.Click += new System.EventHandler(this.calcBill_Click);
            // 
            // printBill
            // 
            this.printBill.Location = new System.Drawing.Point(501, 250);
            this.printBill.Name = "printBill";
            this.printBill.Size = new System.Drawing.Size(124, 58);
            this.printBill.TabIndex = 6;
            this.printBill.Text = "Print Bill";
            this.printBill.UseVisualStyleBackColor = true;
            this.printBill.Click += new System.EventHandler(this.printBill_Click);
            // 
            // ship_id
            // 
            this.ship_id.AutoSize = true;
            this.ship_id.Location = new System.Drawing.Point(395, 6);
            this.ship_id.Name = "ship_id";
            this.ship_id.Size = new System.Drawing.Size(42, 13);
            this.ship_id.TabIndex = 10;
            this.ship_id.Text = "Ship ID";
            // 
            // room_id
            // 
            this.room_id.AutoSize = true;
            this.room_id.Location = new System.Drawing.Point(12, 250);
            this.room_id.Name = "room_id";
            this.room_id.Size = new System.Drawing.Size(52, 13);
            this.room_id.TabIndex = 11;
            this.room_id.Text = "Room ID:";
            // 
            // shipId
            // 
            this.shipId.Location = new System.Drawing.Point(442, 3);
            this.shipId.Name = "shipId";
            this.shipId.Size = new System.Drawing.Size(100, 20);
            this.shipId.TabIndex = 13;
            // 
            // rumID
            // 
            this.rumID.Location = new System.Drawing.Point(70, 247);
            this.rumID.Name = "rumID";
            this.rumID.Size = new System.Drawing.Size(100, 20);
            this.rumID.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(613, 216);
            this.label5.TabIndex = 22;
            // 
            // BillingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 315);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rumID);
            this.Controls.Add(this.shipId);
            this.Controls.Add(this.room_id);
            this.Controls.Add(this.ship_id);
            this.Controls.Add(this.printBill);
            this.Controls.Add(this.calcBill);
            this.Name = "BillingForm";
            this.Text = "CRUISE CONTROL: Billing Management";
            this.Load += new System.EventHandler(this.BillingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button calcBill;
        private System.Windows.Forms.Button printBill;
        private System.Windows.Forms.Label ship_id;
        private System.Windows.Forms.Label room_id;
        private System.Windows.Forms.TextBox shipId;
        private System.Windows.Forms.TextBox rumID;
        private System.Windows.Forms.Label label5;
    }
}

