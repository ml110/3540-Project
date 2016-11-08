namespace CruiseControl
{
	partial class ScheduleForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScheduleForm));
			this.cbDay = new System.Windows.Forms.ComboBox();
			this.dgvSched = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dgvSched)).BeginInit();
			this.SuspendLayout();
			// 
			// cbDay
			// 
			this.cbDay.FormattingEnabled = true;
			this.cbDay.Location = new System.Drawing.Point(8, 8);
			this.cbDay.Name = "cbDay";
			this.cbDay.Size = new System.Drawing.Size(200, 21);
			this.cbDay.TabIndex = 0;
			// 
			// dgvSched
			// 
			this.dgvSched.AllowUserToAddRows = false;
			this.dgvSched.AllowUserToDeleteRows = false;
			this.dgvSched.AllowUserToOrderColumns = true;
			this.dgvSched.AllowUserToResizeColumns = false;
			this.dgvSched.AllowUserToResizeRows = false;
			this.dgvSched.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgvSched.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dgvSched.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvSched.Location = new System.Drawing.Point(8, 40);
			this.dgvSched.Name = "dgvSched";
			this.dgvSched.Size = new System.Drawing.Size(456, 568);
			this.dgvSched.TabIndex = 1;
			// 
			// ScheduleForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(675, 613);
			this.Controls.Add(this.dgvSched);
			this.Controls.Add(this.cbDay);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ScheduleForm";
			this.Text = "CRUISE CONTROL: Schedule Manager";
			this.Load += new System.EventHandler(this.ScheduleForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvSched)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox cbDay;
		private System.Windows.Forms.DataGridView dgvSched;
	}
}