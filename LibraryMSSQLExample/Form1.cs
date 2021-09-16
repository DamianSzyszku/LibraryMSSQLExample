﻿using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
namespace LibraryMSSQLExample
{
    public partial class FormWelcome : Form
    {
        public FormWelcome()
        {

            InitializeComponent();
            refreshRowCount();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        // Administration of database. Password and login required. Space not allowed
        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            string message = "Wystąpił błąd logowania. Spróbuj ponownie. \n Możliwe przyczyny to brak loginu lub hasła lub niedozwolone znaki.";
            string caption = "Wykryto błąd";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            // Displays the MessageBox.
            if (textBoxLogin.Text.Equals("") || textBoxPassword.Text.Equals("") || textBoxLogin.Text.Contains(" ") || textBoxPassword.Text.Contains(" "))
            {
                result = MessageBox.Show(message, caption, buttons);
                textBoxLogin.Text = "";
                textBoxPassword.Text = "";
            }
        }

        private string MakeConnectionString(string SourceMachine, string DatabaseCatalog, string userID, string password)
        {
            string connectionString = @"Data Source=" + SourceMachine + ";Initial Catalog=" + DatabaseCatalog + ";User ID=" + userID + ";Password=" + password;
            return connectionString;
        }

        // Refresh number of rows in table. Useful when adding next record or delete existing.
        private void refreshRowCount()
        {
            // Login to database if succeed, active buttons.
            SqlConnection cnn = new SqlConnection(MakeConnectionString("DESKTOP-6DASI9L", "AdventureWorks2019", "sa", "123"));
            cnn.Open();
            //MessageBox.Show("Connection open!");

            SqlCommand command;
            SqlDataReader dataReader;
            String sqlQuery, numberOfRecords = "";

            // Count and assign number of records to numberOfRecords
            sqlQuery = "select COUNT(*) from Person.EmailAddress;";
            command = new SqlCommand(sqlQuery, cnn);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                numberOfRecords = numberOfRecords + dataReader.GetValue(0);
            }
            // Declination.
            if (numberOfRecords.EndsWith('1') && numberOfRecords.Length == 1)
            {
                labelBookCount.Text = "W naszej bazie znajduje się " + numberOfRecords + " książka.";
            }
            else if (numberOfRecords.EndsWith('2') || numberOfRecords.EndsWith('3') || numberOfRecords.EndsWith('4'))
            {
                labelBookCount.Text = "W naszej bazie znajdują się " + numberOfRecords + " książki.";
            }
            else
            {
                labelBookCount.Text = "W naszej bazie znajduje się " + numberOfRecords + " książek.";
            }
            labelBookCount.Visible = true;


            // Closing session
            dataReader.Close();
            command.Dispose();
            cnn.Close();


            cnn.Open();
        }



        private void buttonBookSearch_Click(object sender, EventArgs e)
        {

            SqlConnection cnn = new SqlConnection(MakeConnectionString("DESKTOP-6DASI9L", "AdventureWorks2019", "sa", "123"));
            cnn.Open();

            SqlCommand command;
            string SearchString = textBoxSearchQuery.Text;

            string sqlQuery = "select * from Person.EmailAddress where (EmailAddress like '%" + SearchString + "%');";
            command = new SqlCommand(sqlQuery, cnn);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            dataGridViewTest.DataSource = new BindingSource(table, null);

            command.Dispose();
            cnn.Close();


        }

        private void buttonGetBookInfo_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(MakeConnectionString("DESKTOP-6DASI9L", "AdventureWorks2019", "sa", "123"));
            cnn.Open();
            MessageBox.Show("Connection open!");

            SqlCommand command;
            SqlDataReader dataReader;
            String sqlQuery;

            sqlQuery = "SELECT * FROM Sales.SalesOrderDetail WHERE SalesOrderID=43659 AND SalesOrderDetailID=1";
            command = new SqlCommand(sqlQuery, cnn);
            dataReader = command.ExecuteReader();
            DataTable schemaTable = new DataTable();
            schemaTable = dataReader.GetSchemaTable();
            int ordinal = 1;
            DataRow row = schemaTable.Rows[ordinal];
            foreach (DataColumn col in schemaTable.Columns)
            {
                //MessageBox.Show( col.ColumnName + "\n" +row[col.Ordinal]);
            }

            if (dataGridViewTest.CurrentCell == null)
            {
                MessageBox.Show("wybierz komorke ktora chcesz dodac do koszyka wypozyczen");
            }
            else
            {
                MessageBox.Show(dataGridViewTest.CurrentCell.RowIndex.ToString());
            }
            dataReader.Close();
            command.Dispose();
            cnn.Close();



        }

    }
}

