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
                // Check album ID, if do not exist then return
                SqlConnection cnn = new SqlConnection(dbCredentials.ConnectionString);
                cnn.Open();
                SqlCommand command;
                string sqlQuery = "select * from dbo.BORROWER where ALBUM_ID = '" + maskedTextBoxAlbumNumber.Text.ToString() + "';";
                command = new SqlCommand(sqlQuery, cnn);
                SqlDataReader dataReader;
                dataReader = command.ExecuteReader();

                int counter = 0;
                while (dataReader.Read())
                {
                    counter++;
                }
                command.Dispose();
                cnn.Close();
                if (counter == 0)
                {
                    MessageBox.Show("Podany numer albumu nie znajduje się w bazie");
                    return;
                }

                // Get number of record in Reservation table to assign unique ID in this table.
                sqlQuery = "select COUNT(*) from dbo.RESERVATION;";
                cnn.Open();
                command = new SqlCommand(sqlQuery, cnn);
                dataReader = command.ExecuteReader();
                string ID_string="";
                int ID_int = 0;
                while (dataReader.Read())
                {
                    ID_string = dataReader.GetValue(0).ToString();
                    ID_int = int.Parse(ID_string);
                }
                command.Dispose();
                cnn.Close();


                // Album ID is correct, cart is not empty, we can reserve books.
                try
                {
                    for (int j = 0; j < dataGridViewCart.Rows.Count; j++)
                    {
                        string ALBUM_ID = maskedTextBoxAlbumNumber.Text.ToString();
                        string ISBN = dataGridViewCart.Rows[j].Cells[0].Value.ToString();
                        ID_int++; 
                        DateTime myDateTime = DateTime.Now;
                        string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd");


                        cnn.Open();
                        sqlQuery = "INSERT INTO dbo.RESERVATION (ID,ALBUM_ID,ISBN,RESERVATION_DATE,RETURN_DATE,ACCEPTED,RETURNED)" +
                                                    " VALUES('" + ID_int.ToString() + "','" + ALBUM_ID + "','" + ISBN + "',GETDATE(),null,0,0);";
                        command = new SqlCommand(sqlQuery, cnn);
                        dataReader = command.ExecuteReader();
                        command.Dispose();
                        cnn.Close();
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString());
                    return;
                }


                MessageBox.Show("Zarezerwowano książki. Zgłoś się do punktu po odbiór.");
                this.CartTable.Rows.Clear();
                this.Close();
                this.CallingForm.Show();
            }
        }

        // Remove record from cart
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
