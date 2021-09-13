using System;
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            string message = "Nie wprowadzono loginu lub hasła. Spróbuj ponownie";
            string caption = "Wykryto błąd";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            // Displays the MessageBox.
            if (textBoxLogin.Text.Equals("") || textBoxPassword.Text.Equals(""))
            {
                result = MessageBox.Show(message, caption, buttons);
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            string connectionString= @"Data Source=DESKTOP-6DASI9L;Initial Catalog=AdventureWorks2019;User ID=sa;Password=123";
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();
            MessageBox.Show("Connection open!");

            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";

            sql = "SELECT top 20 SalesOrderID,UnitPriceDiscount,ProductID FROM Sales.SalesOrderDetail";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            listBoxSearchResult.Items.Clear();
            while (dataReader.Read())
            {
                listBoxSearchResult.Items.Add(dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + " - " + dataReader.GetValue(2));
            }

            dataReader.Close();
            command.Dispose();
            cnn.Close();

        }

        private void buttonBookSearch_Click(object sender, EventArgs e)
        {

        }

        private void buttonGetBookInfo_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-6DASI9L;Initial Catalog=AdventureWorks2019;User ID=sa;Password=123";
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();
            MessageBox.Show("Connection open!");

            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";

            sql = "SELECT * FROM Sales.SalesOrderDetail WHERE SalesOrderID=43659 AND SalesOrderDetailID=1";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            DataTable schemaTable = new DataTable();
            schemaTable = dataReader.GetSchemaTable();
            int ordinal = 1;
            DataRow row = schemaTable.Rows[ordinal];
            foreach (DataColumn col in schemaTable.Columns)
            {
                //MessageBox.Show( col.ColumnName + "\n" +row[col.Ordinal]);
            }

            dataReader.Close();
            command.Dispose();
            cnn.Close();

            this.Hide();
            var formRecord = new FormRecord();
            formRecord.ShowDialog();


        }
    }
}

