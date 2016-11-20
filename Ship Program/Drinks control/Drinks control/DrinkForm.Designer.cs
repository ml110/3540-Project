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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Add = new System.Windows.Forms.Button();
            this.num = new System.Windows.Forms.TextBox();
            this.minus = new System.Windows.Forms.Button();
            this.roomId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Drinks = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(529, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Inventry Control ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(523, 370);
            this.dataGridView1.TabIndex = 12;
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(532, 51);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 23);
            this.Add.TabIndex = 13;
            this.Add.Text = "Increase";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // num
            // 
            this.num.Location = new System.Drawing.Point(532, 25);
            this.num.Name = "num";
            this.num.Size = new System.Drawing.Size(156, 20);
            this.num.TabIndex = 14;
            // 
            // minus
            // 
            this.minus.Location = new System.Drawing.Point(613, 51);
            this.minus.Name = "minus";
            this.minus.Size = new System.Drawing.Size(75, 23);
            this.minus.TabIndex = 15;
            this.minus.Text = "Decrease";
            this.minus.UseVisualStyleBackColor = true;
            this.minus.Click += new System.EventHandler(this.minus_Click);
            // 
            // roomId
            // 
            this.roomId.Location = new System.Drawing.Point(532, 177);
            this.roomId.Name = "roomId";
            this.roomId.Size = new System.Drawing.Size(110, 20);
            this.roomId.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(529, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Enter the roomPass ID";
            // 
            // Drinks
            // 
            this.Drinks.Location = new System.Drawing.Point(532, 203);
            this.Drinks.Name = "Drinks";
            this.Drinks.Size = new System.Drawing.Size(75, 23);
            this.Drinks.TabIndex = 18;
            this.Drinks.Text = "filter Drinks";
            this.Drinks.UseVisualStyleBackColor = true;
            this.Drinks.Click += new System.EventHandler(this.Drinks_Click);
            // 
            // DrinkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 388);
            this.Controls.Add(this.Drinks);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.roomId);
            this.Controls.Add(this.minus);
            this.Controls.Add(this.num);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label5);
            this.Name = "DrinkForm";
            this.Text = "CRUISE CONTROL: Bar Inventory Control";
            this.Load += new System.EventHandler(this.DrinkForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.TextBox num;
        private System.Windows.Forms.Button minus;
        private System.Windows.Forms.TextBox roomId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Drinks;
    }
}

