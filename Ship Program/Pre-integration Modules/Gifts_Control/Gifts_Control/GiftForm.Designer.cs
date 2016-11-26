namespace Gifts_Control
{
    partial class GiftForm
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
			this.AddBtn = new System.Windows.Forms.Button();
			this.MinBtn = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.num = new System.Windows.Forms.TextBox();
			this.dgvDisplay = new System.Windows.Forms.DataGridView();
			this.btnLog = new System.Windows.Forms.Button();
			this.btnInvControl = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvDisplay)).BeginInit();
			this.SuspendLayout();
			// 
			// AddBtn
			// 
			this.AddBtn.Location = new System.Drawing.Point(105, 470);
			this.AddBtn.Name = "AddBtn";
			this.AddBtn.Size = new System.Drawing.Size(75, 23);
			this.AddBtn.TabIndex = 6;
			this.AddBtn.Text = "Increase";
			this.AddBtn.UseVisualStyleBackColor = true;
			this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
			// 
			// MinBtn
			// 
			this.MinBtn.Location = new System.Drawing.Point(105, 499);
			this.MinBtn.Name = "MinBtn";
			this.MinBtn.Size = new System.Drawing.Size(75, 23);
			this.MinBtn.TabIndex = 10;
			this.MinBtn.Text = "Decrease";
			this.MinBtn.UseVisualStyleBackColor = true;
			this.MinBtn.Click += new System.EventHandler(this.MinBtn_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(-1, 474);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(87, 13);
			this.label6.TabIndex = 16;
			this.label6.Text = "Inventory Control";
			// 
			// num
			// 
			this.num.Location = new System.Drawing.Point(-1, 490);
			this.num.Name = "num";
			this.num.Size = new System.Drawing.Size(100, 20);
			this.num.TabIndex = 22;
			// 
			// dgvDisplay
			// 
			this.dgvDisplay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgvDisplay.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dgvDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDisplay.Location = new System.Drawing.Point(1, 3);
			this.dgvDisplay.Name = "dgvDisplay";
			this.dgvDisplay.Size = new System.Drawing.Size(713, 460);
			this.dgvDisplay.TabIndex = 23;
			// 
			// btnLog
			// 
			this.btnLog.Location = new System.Drawing.Point(619, 470);
			this.btnLog.Name = "btnLog";
			this.btnLog.Size = new System.Drawing.Size(94, 51);
			this.btnLog.TabIndex = 24;
			this.btnLog.Text = "Show Transaction History";
			this.btnLog.UseVisualStyleBackColor = true;
			this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
			// 
			// btnInvControl
			// 
			this.btnInvControl.Location = new System.Drawing.Point(519, 469);
			this.btnInvControl.Name = "btnInvControl";
			this.btnInvControl.Size = new System.Drawing.Size(94, 51);
			this.btnInvControl.TabIndex = 25;
			this.btnInvControl.Text = "Show Ship Inventory";
			this.btnInvControl.UseVisualStyleBackColor = true;
			// 
			// GiftForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(715, 523);
			this.Controls.Add(this.btnInvControl);
			this.Controls.Add(this.btnLog);
			this.Controls.Add(this.dgvDisplay);
			this.Controls.Add(this.num);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.MinBtn);
			this.Controls.Add(this.AddBtn);
			this.Name = "GiftForm";
			this.Text = "CRUISE CONTROL: Gift Inventory Control";
			this.Load += new System.EventHandler(this.GiftForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvDisplay)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.Button AddBtn;
		private System.Windows.Forms.Button MinBtn;
		private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox num;
		private System.Windows.Forms.DataGridView dgvDisplay;
		private System.Windows.Forms.Button btnLog;
		private System.Windows.Forms.Button btnInvControl;
    }
}

