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

        // Button used to verify the connection to database. Later, put it in initialization code to make it automatic process.
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            // Login to database if succeed, active buttons.
            string connectionString= @"Data Source=DESKTOP-6DASI9L;Initial Catalog=AdventureWorks2019;User ID=sa;Password=123";
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();
            MessageBox.Show("Connection open!");

            SqlCommand command;
            SqlDataReader dataReader;
            String sql, numberOfRecords = "";

            // Count and assign number of records to numberOfRecords
            sql = "select COUNT(*) from Person.EmailAddress;";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                numberOfRecords = numberOfRecords + dataReader.GetValue(0);
            }
            // Declination.
            if (numberOfRecords.EndsWith('1') && numberOfRecords.Length==1 )
            {
                labelBookCount.Text = labelBookCount.Text + " znajduje się " +  numberOfRecords + " książka.";
            }
            else if (numberOfRecords.EndsWith('2') || numberOfRecords.EndsWith('3') || numberOfRecords.EndsWith('4'))
            {
                labelBookCount.Text = labelBookCount.Text + " znajdują się " + numberOfRecords + " książki.";
            }
            else
            {
                labelBookCount.Text = labelBookCount.Text + "  znajduje się " + numberOfRecords + " książek.";
            }
            labelBookCount.Visible = true;


            // Closing session
            dataReader.Close();
            command.Dispose();
            cnn.Close();



            cnn.Open();

            sql = "select top 10 BusinessEntityID,EmailAddressID,EmailAddress from Person.EmailAddress";
            command = new SqlCommand(sql, cnn);
            
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            dataGridViewTest.DataSource = new BindingSource(table, null);

            command.Dispose();
            cnn.Close();
            buttonConnect.Enabled = false;


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
            String sql, numberOfRecords = "";

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


            if (dataGridViewTest.CurrentCell.Selected == false)
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

            //this.Hide();
            //var formRecord = new FormRecord(this);
            //formRecord.ShowDialog();


        }

        private void labelBookCountEnding_Click(object sender, EventArgs e)
        {

        }
    }
}

