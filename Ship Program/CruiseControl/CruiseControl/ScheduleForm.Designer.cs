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
			this.gbDisplay = new System.Windows.Forms.GroupBox();
			this.cbDept = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.gbAdd = new System.Windows.Forms.GroupBox();
			this.cbAddDept = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cbName = new System.Windows.Forms.ComboBox();
			this.cbAddArea = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.rbMorning = new System.Windows.Forms.RadioButton();
			this.rbAfternoon = new System.Windows.Forms.RadioButton();
			this.rbEvening = new System.Windows.Forms.RadioButton();
			this.btnInsert = new System.Windows.Forms.Button();
			this.gbDelete = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.dgvSched)).BeginInit();
			this.gbDisplay.SuspendLayout();
			this.gbAdd.SuspendLayout();
			this.SuspendLayout();
			// 
			// cbDay
			// 
			this.cbDay.FormattingEnabled = true;
			this.cbDay.Location = new System.Drawing.Point(8, 40);
			this.cbDay.Name = "cbDay";
			this.cbDay.Size = new System.Drawing.Size(200, 21);
			this.cbDay.TabIndex = 0;
			this.cbDay.SelectedIndexChanged += new System.EventHandler(this.cbDay_SelectedIndexChanged);
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
			this.dgvSched.Location = new System.Drawing.Point(0, 8);
			this.dgvSched.Name = "dgvSched";
			this.dgvSched.ReadOnly = true;
			this.dgvSched.RowHeadersVisible = false;
			this.dgvSched.Size = new System.Drawing.Size(720, 584);
			this.dgvSched.TabIndex = 1;
			// 
			// gbDisplay
			// 
			this.gbDisplay.Controls.Add(this.label2);
			this.gbDisplay.Controls.Add(this.label1);
			this.gbDisplay.Controls.Add(this.cbDept);
			this.gbDisplay.Controls.Add(this.cbDay);
			this.gbDisplay.Location = new System.Drawing.Point(728, 8);
			this.gbDisplay.Name = "gbDisplay";
			this.gbDisplay.Size = new System.Drawing.Size(216, 120);
			this.gbDisplay.TabIndex = 2;
			this.gbDisplay.TabStop = false;
			this.gbDisplay.Text = "DISPLAY OPTIONS";
			// 
			// cbDept
			// 
			this.cbDept.FormattingEnabled = true;
			this.cbDept.Location = new System.Drawing.Point(8, 88);
			this.cbDept.Name = "cbDept";
			this.cbDept.Size = new System.Drawing.Size(200, 21);
			this.cbDept.TabIndex = 0;
			this.cbDept.Text = "-----";
			this.cbDept.SelectedIndexChanged += new System.EventHandler(this.cbDept_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(26, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Day";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Department";
			// 
			// gbAdd
			// 
			this.gbAdd.Controls.Add(this.btnInsert);
			this.gbAdd.Controls.Add(this.rbEvening);
			this.gbAdd.Controls.Add(this.rbAfternoon);
			this.gbAdd.Controls.Add(this.rbMorning);
			this.gbAdd.Controls.Add(this.label6);
			this.gbAdd.Controls.Add(this.label5);
			this.gbAdd.Controls.Add(this.cbAddArea);
			this.gbAdd.Controls.Add(this.cbName);
			this.gbAdd.Controls.Add(this.label4);
			this.gbAdd.Controls.Add(this.label3);
			this.gbAdd.Controls.Add(this.cbAddDept);
			this.gbAdd.Location = new System.Drawing.Point(728, 144);
			this.gbAdd.Name = "gbAdd";
			this.gbAdd.Size = new System.Drawing.Size(216, 288);
			this.gbAdd.TabIndex = 3;
			this.gbAdd.TabStop = false;
			this.gbAdd.Text = "SCHEDULE NEW SHIFT";
			// 
			// cbAddDept
			// 
			this.cbAddDept.FormattingEnabled = true;
			this.cbAddDept.Location = new System.Drawing.Point(8, 40);
			this.cbAddDept.Name = "cbAddDept";
			this.cbAddDept.Size = new System.Drawing.Size(200, 21);
			this.cbAddDept.TabIndex = 0;
			this.cbAddDept.SelectedIndexChanged += new System.EventHandler(this.cbAddDept_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(8, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(62, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Department";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(8, 168);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(60, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "Staff Name";
			// 
			// cbName
			// 
			this.cbName.FormattingEnabled = true;
			this.cbName.Location = new System.Drawing.Point(8, 184);
			this.cbName.Name = "cbName";
			this.cbName.Size = new System.Drawing.Size(200, 21);
			this.cbName.TabIndex = 5;
			// 
			// cbAddArea
			// 
			this.cbAddArea.FormattingEnabled = true;
			this.cbAddArea.Location = new System.Drawing.Point(8, 88);
			this.cbAddArea.Name = "cbAddArea";
			this.cbAddArea.Size = new System.Drawing.Size(200, 21);
			this.cbAddArea.TabIndex = 6;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(8, 72);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(54, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "Duty Area";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(8, 120);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(55, 13);
			this.label6.TabIndex = 8;
			this.label6.Text = "Shift Type";
			// 
			// rbMorning
			// 
			this.rbMorning.AutoSize = true;
			this.rbMorning.Location = new System.Drawing.Point(8, 136);
			this.rbMorning.Name = "rbMorning";
			this.rbMorning.Size = new System.Drawing.Size(63, 17);
			this.rbMorning.TabIndex = 9;
			this.rbMorning.TabStop = true;
			this.rbMorning.Text = "Morning";
			this.rbMorning.UseVisualStyleBackColor = true;
			// 
			// rbAfternoon
			// 
			this.rbAfternoon.AutoSize = true;
			this.rbAfternoon.Location = new System.Drawing.Point(72, 136);
			this.rbAfternoon.Name = "rbAfternoon";
			this.rbAfternoon.Size = new System.Drawing.Size(71, 17);
			this.rbAfternoon.TabIndex = 10;
			this.rbAfternoon.TabStop = true;
			this.rbAfternoon.Text = "Afternoon";
			this.rbAfternoon.UseVisualStyleBackColor = true;
			// 
			// rbEvening
			// 
			this.rbEvening.AutoSize = true;
			this.rbEvening.Location = new System.Drawing.Point(144, 136);
			this.rbEvening.Name = "rbEvening";
			this.rbEvening.Size = new System.Drawing.Size(64, 17);
			this.rbEvening.TabIndex = 11;
			this.rbEvening.TabStop = true;
			this.rbEvening.Text = "Evening";
			this.rbEvening.UseVisualStyleBackColor = true;
			// 
			// btnInsert
			// 
			this.btnInsert.Location = new System.Drawing.Point(8, 224);
			this.btnInsert.Name = "btnInsert";
			this.btnInsert.Size = new System.Drawing.Size(200, 56);
			this.btnInsert.TabIndex = 12;
			this.btnInsert.Text = "INSERT SHIFT";
			this.btnInsert.UseVisualStyleBackColor = true;
			// 
			// gbDelete
			// 
			this.gbDelete.Location = new System.Drawing.Point(728, 448);
			this.gbDelete.Name = "gbDelete";
			this.gbDelete.Size = new System.Drawing.Size(216, 144);
			this.gbDelete.TabIndex = 4;
			this.gbDelete.TabStop = false;
			this.gbDelete.Text = "CANCEL EXISTING SHIFT";
			// 
			// ScheduleForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(948, 595);
			this.Controls.Add(this.gbDelete);
			this.Controls.Add(this.gbAdd);
			this.Controls.Add(this.gbDisplay);
			this.Controls.Add(this.dgvSched);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ScheduleForm";
			this.Text = "CRUISE CONTROL: Schedule Manager";
			this.Load += new System.EventHandler(this.ScheduleForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvSched)).EndInit();
			this.gbDisplay.ResumeLayout(false);
			this.gbDisplay.PerformLayout();
			this.gbAdd.ResumeLayout(false);
			this.gbAdd.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox cbDay;
		private System.Windows.Forms.DataGridView dgvSched;
		private System.Windows.Forms.GroupBox gbDisplay;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbDept;
		private System.Windows.Forms.GroupBox gbAdd;
		private System.Windows.Forms.Button btnInsert;
		private System.Windows.Forms.RadioButton rbEvening;
		private System.Windows.Forms.RadioButton rbAfternoon;
		private System.Windows.Forms.RadioButton rbMorning;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cbAddArea;
		private System.Windows.Forms.ComboBox cbName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbAddDept;
		private System.Windows.Forms.GroupBox gbDelete;
	}
}