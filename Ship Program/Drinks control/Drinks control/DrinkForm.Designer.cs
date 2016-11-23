namespace Drinks_control
{
    partial class DrinkForm
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
			this.label5 = new System.Windows.Forms.Label();
			this.dgvDisplay = new System.Windows.Forms.DataGridView();
			this.Add = new System.Windows.Forms.Button();
			this.num = new System.Windows.Forms.TextBox();
			this.minus = new System.Windows.Forms.Button();
			this.btnLog = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvDisplay)).BeginInit();
			this.SuspendLayout();
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(365, 6);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(84, 13);
			this.label5.TabIndex = 5;
			this.label5.Text = "Inventry Control ";
			// 
			// dgvDisplay
			// 
			this.dgvDisplay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgvDisplay.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dgvDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDisplay.Location = new System.Drawing.Point(0, 3);
			this.dgvDisplay.Name = "dgvDisplay";
			this.dgvDisplay.Size = new System.Drawing.Size(359, 460);
			this.dgvDisplay.TabIndex = 12;
			// 
			// Add
			// 
			this.Add.Location = new System.Drawing.Point(365, 48);
			this.Add.Name = "Add";
			this.Add.Size = new System.Drawing.Size(75, 23);
			this.Add.TabIndex = 13;
			this.Add.Text = "Increase";
			this.Add.UseVisualStyleBackColor = true;
			this.Add.Click += new System.EventHandler(this.Add_Click);
			// 
			// num
			// 
			this.num.Location = new System.Drawing.Point(365, 22);
			this.num.Name = "num";
			this.num.Size = new System.Drawing.Size(156, 20);
			this.num.TabIndex = 14;
			// 
			// minus
			// 
			this.minus.Location = new System.Drawing.Point(446, 48);
			this.minus.Name = "minus";
			this.minus.Size = new System.Drawing.Size(75, 23);
			this.minus.TabIndex = 15;
			this.minus.Text = "Decrease";
			this.minus.UseVisualStyleBackColor = true;
			this.minus.Click += new System.EventHandler(this.minus_Click);
			// 
			// btnLog
			// 
			this.btnLog.Location = new System.Drawing.Point(365, 77);
			this.btnLog.Name = "btnLog";
			this.btnLog.Size = new System.Drawing.Size(156, 41);
			this.btnLog.TabIndex = 19;
			this.btnLog.Text = "Show Transaction History";
			this.btnLog.UseVisualStyleBackColor = true;
			// 
			// DrinkForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(526, 467);
			this.Controls.Add(this.btnLog);
			this.Controls.Add(this.minus);
			this.Controls.Add(this.num);
			this.Controls.Add(this.Add);
			this.Controls.Add(this.dgvDisplay);
			this.Controls.Add(this.label5);
			this.Name = "DrinkForm";
			this.Text = "CRUISE CONTROL: Bar Inventory Control";
			this.Load += new System.EventHandler(this.DrinkForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvDisplay)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvDisplay;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.TextBox num;
		private System.Windows.Forms.Button minus;
		private System.Windows.Forms.Button btnLog;
    }
}

