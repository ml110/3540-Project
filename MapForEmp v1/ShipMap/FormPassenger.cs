using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShipMap
{
    public partial class FormPassenger : Form
    {
        public object passengers;
        public object billHolder;

        public FormPassenger()
        {
            InitializeComponent();
            object passengers = new object();
            object billHoder = new object();
        }

        private void FormPassenger_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            dgBill.DataSource = billHolder;
            dgPass.DataSource = passengers;

           


        }
    }
}
