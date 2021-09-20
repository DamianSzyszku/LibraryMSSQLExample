using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LibraryMSSQLExample
{
    public partial class FormAddBorrower : Form
    {
        private Form CallingForm = null;
        public FormAddBorrower(Form callingForm) : this()
        {
            this.CallingForm = callingForm;
        }
        public FormAddBorrower()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
            this.CallingForm.Show();
        }

        private void buttonAddBorrower_Click(object sender, EventArgs e)
        {
            string sqlCommand;
            if (textBoxName.Text.Length < 3 || textBoxSurname.Text.Length < 3 || maskedTextBoxAlbumNumber.Text.Length != 6 || maskedTextBoxPhoneNumber.Text.Length != 9 )
            {
                MessageBox.Show("Proszę uzupełnić dane. Numer telefonu składa się z 9 cyfr, numer albumu z 6 cyfr, a imię i nazwisko z conajmniej 3 liter.");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxName.Text, @"^[a-zA-Z]+$") || !System.Text.RegularExpressions.Regex.IsMatch(textBoxSurname.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Imię i nazwisko składa się z liter.");
            }
            else
            {
                sqlCommand = "INSERT INTO dbo.BORROWER (NAME,SURNAME,ALBUM_ID,PHONE_NUMBER) VALUES ('" + textBoxName.Text + "','" + textBoxSurname.Text + "','" + maskedTextBoxAlbumNumber.Text + "','" + maskedTextBoxPhoneNumber.Text + "';";
                MessageBox.Show(sqlCommand);
            }
        }
    }
}
