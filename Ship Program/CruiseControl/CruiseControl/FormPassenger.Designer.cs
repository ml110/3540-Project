namespace CruiseControl
{
    partial class FormPassenger
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPassenger));
			this.dgPass = new System.Windows.Forms.DataGridView();
			this.dgBill = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgPass)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgBill)).BeginInit();
			this.SuspendLayout();
			// 
			// dgPass
			// 
			this.dgPass.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgPass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgPass.Location = new System.Drawing.Point(12, 25);
			this.dgPass.Name = "dgPass";
			this.dgPass.Size = new System.Drawing.Size(283, 150);
			this.dgPass.TabIndex = 0;
			// 
			// dgBill
			// 
			this.dgBill.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgBill.Location = new System.Drawing.Point(12, 194);
			this.dgBill.Name = "dgBill";
			this.dgBill.Size = new System.Drawing.Size(283, 68);
			this.dgBill.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Passengers";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 178);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Bill Holder";
			// 
			// FormPassenger
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(426, 392);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dgBill);
			this.Controls.Add(this.dgPass);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormPassenger";
			this.Text = "CRUISE CONTROL: Room Viewer";
			this.Load += new System.EventHandler(this.FormPassenger_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgPass)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgBill)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgPass;
        private System.Windows.Forms.DataGridView dgBill;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}