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
            this.printBill = new System.Windows.Forms.Button();
            this.room_id = new System.Windows.Forms.Label();
            this.rumID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCalc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // printBill
            // 
            this.printBill.Location = new System.Drawing.Point(248, 232);
            this.printBill.Name = "printBill";
            this.printBill.Size = new System.Drawing.Size(114, 36);
            this.printBill.TabIndex = 6;
            this.printBill.Text = "Print Displayed Bill";
            this.printBill.UseVisualStyleBackColor = true;
            this.printBill.Click += new System.EventHandler(this.printBill_Click);
            // 
            // room_id
            // 
            this.room_id.AutoSize = true;
            this.room_id.Location = new System.Drawing.Point(8, 232);
            this.room_id.Name = "room_id";
            this.room_id.Size = new System.Drawing.Size(75, 13);
            this.room_id.TabIndex = 11;
            this.room_id.Text = "Room Number";
            // 
            // rumID
            // 
            this.rumID.Location = new System.Drawing.Point(8, 248);
            this.rumID.Name = "rumID";
            this.rumID.Size = new System.Drawing.Size(114, 20);
            this.rumID.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(512, 216);
            this.label5.TabIndex = 22;
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(128, 232);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(114, 36);
            this.btnCalc.TabIndex = 23;
            this.btnCalc.Text = "Calculate Bill";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // BillingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 274);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rumID);
            this.Controls.Add(this.room_id);
            this.Controls.Add(this.printBill);
            this.Name = "BillingForm";
            this.Text = "CRUISE CONTROL: Billing Management";
            this.Load += new System.EventHandler(this.BillingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button printBill;
		private System.Windows.Forms.Label room_id;
        private System.Windows.Forms.TextBox rumID;
        private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnCalc;
    }
}

