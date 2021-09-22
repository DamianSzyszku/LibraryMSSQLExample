using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

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
            // Check album ID, if exists then return
            SqlConnection cnn = new SqlConnection(dbCredentials.ConnectionString);
            cnn.Open();
            SqlCommand command;
            string sqlQuery = "select * from dbo.BORROWER where ALBUM_ID = '" + maskedTextBoxAlbumNumber.Text.ToString() +"';";
            command = new SqlCommand(sqlQuery, cnn);
            SqlDataReader dataReader;
            dataReader = command.ExecuteReader();

            int counter = 0;
            while(dataReader.Read())
            {
                counter++;
            }
            command.Dispose();
            cnn.Close();
            if (counter > 0 )
            {
                MessageBox.Show("Podany numer albumu znajduje się w bazie");
                return;
            }

            // Check if typed data is valid.
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
                // If data is valid, perform query to database
                cnn = new SqlConnection(dbCredentials.ConnectionString);
                cnn.Open();
                sqlQuery = "INSERT INTO dbo.BORROWER (NAME,SURNAME,ALBUM_ID,PHONE_NUMBER) VALUES ('" + textBoxName.Text.ToString() + "','" + textBoxSurname.Text.ToString() + "','" + maskedTextBoxAlbumNumber.Text.ToString() + "','" + maskedTextBoxPhoneNumber.Text.ToString() + "');";
                command = new SqlCommand(sqlQuery, cnn);
                dataReader = command.ExecuteReader();
                command.Dispose();
                cnn.Close();
                MessageBox.Show("Dodano użytkownika");

                this.Close();
                this.CallingForm.Show();
            }
        }
    }
}
