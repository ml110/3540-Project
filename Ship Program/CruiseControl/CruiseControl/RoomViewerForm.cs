using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CruiseControl
{
    public partial class RoomViewerForm : Form
    {
        public object passengers;
        public object billHolder;

        public RoomViewerForm()
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
