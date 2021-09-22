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
    public partial class FormRecord : Form
    {
        private Form CallingForm = null;
        private String Mode = null;
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
                dataGridViewRecordManagement.DataSource = new BindingSource(this.RecordTable, null);
                //var index = dataGridViewRecordManagement.Rows.Add();
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
                SqlConnection cnn = new SqlConnection(dbCredentials.ConnectionString);
                cnn.Open();
                SqlCommand command;
                string sqlQuery = "select * from dbo.RESERVATION;";
                command = new SqlCommand(sqlQuery, cnn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                dataGridViewRecordManagement.DataSource = new BindingSource(table, null);
                command.Dispose();
                cnn.Close();
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
                SqlConnection cnn = new SqlConnection(dbCredentials.ConnectionString);
                cnn.Open();
                SqlCommand command;
                string sqlQuery = "select * from dbo.RESERVATION;";
                command = new SqlCommand(sqlQuery, cnn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                dataGridViewRecordManagement.DataSource = new BindingSource(table, null);
                command.Dispose();
                cnn.Close();
            }
            dataGridViewRecordManagement.AllowUserToAddRows = false;
        }
        public FormRecord()
        {
            InitializeComponent();
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {

            if (Mode.Equals("Update") || dataGridViewRecordManagement.Rows.Count > 0)
            {
                int index = dataGridViewRecordManagement.CurrentCell.RowIndex;
                dataGridViewRecordManagement.Rows.Remove(dataGridViewRecordManagement.Rows[index]);
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

            }

        }

        private void buttonAcceptReturn_Click(object sender, EventArgs e)
        {

            if (dataGridViewRecordManagement.Rows.Count == 0)
            {
                MessageBox.Show("Brak wypożyczeń do odrzucenia.");
                this.Close();
                this.CallingForm.Show();
            }
            else
            {

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
            if (dataGridViewRecordManagement.Rows.Count == 0)
            {
                MessageBox.Show("Uzupełnij dane.");
            }
            else
            {
                string ISBN = dataGridViewRecordManagement.Rows[0].Cells[0].Value.ToString();
                string TITLE = dataGridViewRecordManagement.Rows[0].Cells[1].Value.ToString();
                string AUTHOR = dataGridViewRecordManagement.Rows[0].Cells[2].Value.ToString();
                SqlConnection cnn = new SqlConnection(dbCredentials.ConnectionString);
                cnn.Open();
                SqlCommand command;
                string sqlQuery = "INSERT INTO dbo.BOOKS (ISBN, TITLE, AUTHOR) VALUES (" + "," + "," + ")";
                command = new SqlCommand(sqlQuery, cnn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                dataGridViewRecordManagement.DataSource = new BindingSource(table, null);
                command.Dispose();
                cnn.Close();
            }
        }
    }
}
