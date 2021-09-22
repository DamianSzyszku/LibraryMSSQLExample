using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace LibraryMSSQLExample
{


    public partial class FormRecord : Form
    {
        private readonly Form CallingForm = null;
        private readonly String Mode = null;
        private DataTable RecordTable = null;

        // Initialization of form, 4 modes are  taken into account. Controls are hide and inactive in different modes.
        public FormRecord(Form callingForm, String mode, DataTable recordTable) : this()
        {
            this.Mode = mode;
            this.CallingForm = callingForm;
            this.RecordTable = recordTable;

            if (Mode.Equals("Add"))
            {
                buttonAdd.Visible = true;
                buttonAdd.Enabled = true;
                buttonUpdate.Visible = false;
                buttonUpdate.Enabled = false;
                buttonAcceptReturn.Visible = false;
                buttonAcceptReturn.Enabled = false;
                buttonAcceptBorrow.Visible = false;
                buttonAcceptBorrow.Enabled = false;
                buttonRejectBorrow.Visible = false;
                buttonRejectBorrow.Enabled = false;

                // Task to do
                dataGridViewRecordManagement.Columns.Add("ISBN", "ISBN");
                dataGridViewRecordManagement.Columns.Add("TITLE", "TITLE");
                dataGridViewRecordManagement.Columns.Add("AUTHOR", "AUTHOR");
                dataGridViewRecordManagement.Rows.Add();
                dataGridViewRecordManagement.AllowUserToAddRows = false;
                dataGridViewRecordManagement.Rows[0].Cells["ISBN"].Value = "";
                dataGridViewRecordManagement.Rows[0].Cells["TITLE"].Value = "";
                dataGridViewRecordManagement.Rows[0].Cells["AUTHOR"].Value = "";
            }
            else if (Mode.Equals("Update"))
            {
                buttonAdd.Visible = false;
                buttonAdd.Enabled = false;
                buttonUpdate.Visible = true;
                buttonUpdate.Enabled = true;
                buttonAcceptReturn.Visible = false;
                buttonAcceptReturn.Enabled = false;
                buttonAcceptBorrow.Visible = false;
                buttonAcceptBorrow.Enabled = false;
                buttonRejectBorrow.Visible = false;
                buttonRejectBorrow.Enabled = false;

                dataGridViewRecordManagement.DataSource = new BindingSource(this.RecordTable, null);
                dataGridViewRecordManagement.Columns["ISBN"].ReadOnly = true;
            }
            else if (Mode.Equals("Return"))
            {
                buttonUpdate.Visible = false;
                buttonUpdate.Enabled = false;
                buttonAdd.Visible = false;
                buttonAdd.Enabled = false;
                buttonAcceptReturn.Visible = true;
                buttonAcceptReturn.Enabled = true;
                buttonAcceptBorrow.Visible = false;
                buttonAcceptBorrow.Enabled = false;
                buttonRejectBorrow.Visible = false;
                buttonRejectBorrow.Enabled = false;

                // SQL connection, query borrows from database
                try
                {
                    RefreshTable(1, 0);
                }
                    catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString());
                }
        }
            else if (Mode.Equals("Borrow"))
            {
                buttonUpdate.Visible = false;
                buttonUpdate.Enabled = false;
                buttonAdd.Visible = false;
                buttonAdd.Enabled = false;
                buttonAcceptReturn.Visible = false;
                buttonAcceptReturn.Enabled = false;
                buttonAcceptBorrow.Visible = true;
                buttonAcceptBorrow.Enabled = true;
                buttonRejectBorrow.Visible = true;
                buttonRejectBorrow.Enabled = true;

                // SQL connection, query reservations from database to accept or reject
                try
                {
                    RefreshTable(0, 0);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString());
                }
            }
            dataGridViewRecordManagement.AllowUserToAddRows = false;
        }
        public FormRecord()
        {
            InitializeComponent();
        }

        // Back to main form button
        private void buttonCancel_Click(object sender, EventArgs e)
        {

            if (Mode.Equals("Update"))
            {
                int index = dataGridViewRecordManagement.CurrentCell.RowIndex;
                this.RecordTable.Rows[index].Delete();
                this.RecordTable.AcceptChanges();
            }
            this.Close();
            this.CallingForm.Show();
        }

        private void buttonAcceptBorrow_Click(object sender, EventArgs e)
        {
            if (dataGridViewRecordManagement.Rows.Count == 0)
            {
                
                MessageBox.Show("Brak wypożyczeń do zaakceptowania.");
                this.Close();
                this.CallingForm.Show();
            }
            else
            {
                try
                {
                    SqlConnection cnn = new SqlConnection(dbCredentials.ConnectionString);
                    cnn.Open();
                    SqlCommand command;
                    int index = dataGridViewRecordManagement.CurrentCell.RowIndex;
                    string sqlQuery = "UPDATE dbo.RESERVATION SET ACCEPTED = 1, RETURNED = 0 where ID = " + dataGridViewRecordManagement.Rows[index].Cells[0].Value.ToString() + ";";
                    command = new SqlCommand(sqlQuery, cnn);
                    SqlDataReader dataReader;
                    dataReader = command.ExecuteReader();
                    command.Dispose();
                    cnn.Close();
                    MessageBox.Show("Wypożyczenie zaakceptowane");
                    RefreshTable(0, 0);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString());
                }
            }
        }

        private void buttonRejectBorrow_Click(object sender, EventArgs e)
        {
            if (dataGridViewRecordManagement.Rows.Count == 0)
            {
                MessageBox.Show("Brak wypożyczeń do odrzucenia.");
                this.Close();
                this.CallingForm.Show();
            }
            else
            {
                try
                {
                    SqlConnection cnn = new SqlConnection(dbCredentials.ConnectionString);
                    cnn.Open();
                    SqlCommand command;
                    int index = dataGridViewRecordManagement.CurrentCell.RowIndex;
                    string sqlQuery = "UPDATE dbo.RESERVATION SET ACCEPTED = 1, RETURNED = 1 where ID = " + dataGridViewRecordManagement.Rows[index].Cells[0].Value.ToString() + ";";
                    command = new SqlCommand(sqlQuery, cnn);
                    SqlDataReader dataReader;
                    dataReader = command.ExecuteReader();
                    command.Dispose();
                    cnn.Close();
                    MessageBox.Show("Wypożyczenie odrzucone");
                    RefreshTable(0, 0);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString());
                }
            }

        }

        private void buttonAcceptReturn_Click(object sender, EventArgs e)
        {

            if (dataGridViewRecordManagement.Rows.Count == 0)
            {
                MessageBox.Show("Brak wypożyczeń do akceptacji.");
                this.Close();
                this.CallingForm.Show();
            }
            else
            {
                try
                {
                    SqlConnection cnn = new SqlConnection(dbCredentials.ConnectionString);
                    cnn.Open();
                    SqlCommand command;
                    int index = dataGridViewRecordManagement.CurrentCell.RowIndex;
                    string sqlQuery = "UPDATE dbo.RESERVATION SET RETURN_DATE =  GETDATE(), ACCEPTED = 1, RETURNED = 1 where ID = " + dataGridViewRecordManagement.Rows[index].Cells[0].Value.ToString() + ";";
                    command = new SqlCommand(sqlQuery, cnn);
                    SqlDataReader dataReader;
                    dataReader = command.ExecuteReader();
                    command.Dispose();
                    cnn.Close();
                    MessageBox.Show("Wypożyczenie zaakceptowane");
                    RefreshTable(1, 0);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString());
                }
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (false)
            {

            }
            else
            {
                string ISBN = dataGridViewRecordManagement.Rows[0].Cells[0].Value.ToString();
                string TITLE = dataGridViewRecordManagement.Rows[0].Cells[1].Value.ToString();
                string AUTHOR = dataGridViewRecordManagement.Rows[0].Cells[2].Value.ToString();

                SqlConnection cnn = new SqlConnection(dbCredentials.ConnectionString);
                cnn.Open();
                SqlCommand command;
                string sqlQuery = "UPDATE dbo.BOOKS SET ISBN='" + ISBN + "', TITLE = '" + TITLE + "', AUTHOR = '" + AUTHOR + "' where ISBN = '" + ISBN + "' ;";
                command = new SqlCommand(sqlQuery, cnn);
                SqlDataReader dataReader;
                dataReader = command.ExecuteReader();
                command.Dispose();
                cnn.Close();
                MessageBox.Show("Aktualizacja zakończona");

                this.RecordTable.Rows[0].Delete();
                this.RecordTable.AcceptChanges();
                this.Close();
                this.CallingForm.Show();


            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string ISBN = dataGridViewRecordManagement.Rows[0].Cells[0].Value.ToString();
            string TITLE = dataGridViewRecordManagement.Rows[0].Cells[1].Value.ToString();
            string AUTHOR = dataGridViewRecordManagement.Rows[0].Cells[2].Value.ToString();
            if (dataGridViewRecordManagement.Rows.Count == 0)
            {
                MessageBox.Show("Uzupełnij dane.");
                return;
            }
            else if (ISBN.Length != 13 || !Regex.IsMatch(ISBN, "^[0-9]+$") )
            {
                MessageBox.Show("Numer ISBN składa się z 13 cyfr.");
                return;
            }
            else if (Regex.IsMatch(AUTHOR, "^[0-9]+$") || AUTHOR.Length > 50)
            {
                MessageBox.Show("Pole autor nie może zawierać cyfr, maksymalna długość to 50 znaków.");
                return;
            }
            else if (TITLE.Length > 50)
            {
                MessageBox.Show("Maksymalna długość tytułu to 50 znaków.");
                return;
            }

            // Check if the ISBN number is unique
            bool flagIsISBNUnique = false;
            try
            {
                SqlConnection cnn = new SqlConnection(dbCredentials.ConnectionString);
                cnn.Open();
                SqlCommand command;
                string sqlQuery = "select count(*) from dbo.BOOKS where ISBN='" + ISBN + "'";
                command = new SqlCommand(sqlQuery, cnn);
                SqlDataReader dataReader;
                dataReader = command.ExecuteReader();
                dataReader.Read();
                if (dataReader.GetValue(0).ToString() == "0")
                    flagIsISBNUnique = true;

                command.Dispose();
                cnn.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
                return;
            }


            if (flagIsISBNUnique)
            {
                SqlConnection cnn = new SqlConnection(dbCredentials.ConnectionString);
                cnn.Open();
                SqlCommand command;
                string sqlQuery = "INSERT INTO dbo.BOOKS (ISBN, TITLE, AUTHOR) VALUES ('" + ISBN + "','" + TITLE + "','" + AUTHOR + "')";
                command = new SqlCommand(sqlQuery, cnn);
                command.ExecuteReader();

                command.Dispose();
                cnn.Close();
                var result = MessageBox.Show("Dodano rekord. Czy chcesz dodać kolejny rekord?","",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    this.Close();
                    this.CallingForm.Show();
                }
            }
            else
            {
                MessageBox.Show("Wprowadzony numer ISBN nie jest unikatowy. Proszę poprawić numer ISBN.");
                return;
            }
        }

        public void RefreshTable(int Accepted, int Returned)
        {

            try
            {
                SqlConnection cnn = new SqlConnection(dbCredentials.ConnectionString);
                cnn.Open();
                SqlCommand command;
                string sqlQuery = "select ID,ALBUM_ID,ISBN,RESERVATION_DATE from dbo.RESERVATION where ACCEPTED = " + Accepted.ToString() + " and RETURNED = " + Returned.ToString() + ";";
                command = new SqlCommand(sqlQuery, cnn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                dataGridViewRecordManagement.DataSource = new BindingSource(table, null);
                command.Dispose();
                cnn.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Nie udało się połączyć z bazą danych.");
                MessageBox.Show(exception.ToString());
                return;
            }

        }
    }
}
