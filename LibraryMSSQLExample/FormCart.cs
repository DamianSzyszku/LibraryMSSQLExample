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
        private DataTable CartTable = null;

            public FormCart(Form callingForm, DataTable cartTable) : this()
        {
            this.CallingForm = callingForm;
            this.CartTable = cartTable;
            dataGridViewCart.DataSource = new BindingSource(this.CartTable, null);
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
                // sprawdz czy uzytkownik istnieje, jezeli tak, to dokonaj rezerwacji

            }
        }

        private void buttonRemoveFromCart_Click(object sender, EventArgs e)
        {
            if (dataGridViewCart.CurrentCell == null)
            {
                MessageBox.Show("Proszę dodać element do koszyka");
            }
            else
            {
                int index = dataGridViewCart.CurrentCell.RowIndex;
                dataGridViewCart.Rows.Remove(dataGridViewCart.Rows[index]);
                this.CartTable.Rows[index].Delete();
                this.CartTable.AcceptChanges();
                dataGridViewCart.DataSource = new BindingSource(this.CartTable, null);
            }
        }
    }
}
