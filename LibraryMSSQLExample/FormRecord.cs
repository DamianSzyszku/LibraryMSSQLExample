using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LibraryMSSQLExample
{
    public partial class FormRecord : Form
    {
        private Form CallingForm = null;
        public FormRecord(Form callingForm) : this()
        {
            this.CallingForm = callingForm;
        }
        public FormRecord()
        {
            InitializeComponent();
            //tableRecordPanel.
        }

        private void buttonAddToCart_Click(object sender, EventArgs e)
        {
            

            this.Close();
            this.CallingForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();
            this.CallingForm.Show();
        }
    }
}
