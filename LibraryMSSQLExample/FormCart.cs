using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LibraryMSSQLExample
{
    public partial class FormCart : Form
    {

        private Form CallingForm = null;
        public FormCart(Form callingForm) : this()
        {
            this.CallingForm = callingForm;
        }
        public FormCart()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {

            this.Close();
            this.CallingForm.Show();
        }

        // Reservation made by student, possibility to create additional verification with password
        private void buttonReserve_Click(object sender, EventArgs e)
        {
            // User cannot reserve when cart is empty or ID number is incorrect. ID number contains 6 digits and textbox is masked
            if (dataGridViewCart.CurrentCell == null)
            {
                MessageBox.Show("Proszę dodać element do koszyka");
            }
            else if (maskedTextBoxAlbumNumber.Text.Length != 6)
            {
                MessageBox.Show("Prosze wprowadzic 6 cyfrowy numer albumu");
            }
            else 
            { 

            }
        }

        private void buttonRemoveFromCart_Click(object sender, EventArgs e)
        {
            if (dataGridViewCart.CurrentCell == null)
            {
                MessageBox.Show("Proszę dodać element do koszyka");
            }
            else if ( true )
            {

            }
        }
    }
}
