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
            refreshRowCount();
            MakeCartTable();
        }

        private void MakeCartTable()
        {

            SqlConnection cnn = new SqlConnection(MakeConnectionString("DESKTOP-6DASI9L", "AdventureWorks2019", "sa", "123"));
            cnn.Open();

            SqlCommand command;

            string sqlQuery = "select * from Person.EmailAddress where (EmailAddress like '%michael12%');";
            command = new SqlCommand(sqlQuery, cnn);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
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
            else if (textBoxLogin.Text.Equals("root") || textBoxPassword.Text.Equals("root"))
            {
                buttonAddRecord.Visible = true;
                buttonAddRecord.Enabled = true;
                buttonDeleteRecord.Visible = true;
                buttonDeleteRecord.Enabled = true;
                buttonUpdate.Visible = true;
                buttonUpdate.Enabled = true;
                buttonLogout.Enabled = true;
                textBoxLogin.Enabled = false;
                textBoxPassword.Enabled = false;
                buttonSignIn.Enabled = false;
                buttonLogout.Enabled = true;
                buttonLogout.Visible = true;
                buttonCartManagement.Visible = true;
                buttonCartManagement.Enabled = true;



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

        private void buttonAddToCart_Click(object sender, EventArgs e)
        {


            if (dataGridViewTest.CurrentCell == null)
            {
                MessageBox.Show("wybierz komorke ktora chcesz dodac do koszyka wypozyczen");
            }
            else
            {
                MessageBox.Show(dataGridViewTest.CurrentCell.RowIndex.ToString());
            }



        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {

            buttonAddRecord.Visible = false;
            buttonAddRecord.Enabled = false;
            buttonDeleteRecord.Visible = false;
            buttonDeleteRecord.Enabled = false;
            buttonUpdate.Visible = false;
            buttonUpdate.Enabled = false;
            textBoxLogin.Enabled = true;
            textBoxPassword.Enabled = true;
            buttonSignIn.Enabled = true;
            buttonLogout.Enabled = false;
            buttonLogout.Visible = false;
            buttonCartManagement.Visible = false;
            buttonCartManagement.Enabled = false;

        }

        private void buttonDeleteRecord_Click(object sender, EventArgs e)
        {
            if (dataGridViewTest.CurrentCell == null)
            {
                MessageBox.Show("Wyszukaj rekord a następnie go zaznacz");
            }
            else
            {
                int rowIndex = dataGridViewTest.CurrentCell.RowIndex;
                string sqlQuery="", columnName, columnValue;

                //for (int i = 0; i < dataGridViewTest.CurrentRow.Cells.Count; i++)
                for (int i = 0; i < 3; i++)
                    {
                    columnValue = dataGridViewTest.Rows[rowIndex].Cells[i].Value.ToString();
                    columnName = dataGridViewTest.Columns[i].Name.ToString();
                    //if (i == dataGridViewTest.CurrentRow.Cells.Count - 1)
                    if (i == 2)
                            sqlQuery = sqlQuery + columnName + "='" + columnValue + "'";
                    else
                        sqlQuery = sqlQuery + columnName + "='" + columnValue + "' and ";

                }
                MessageBox.Show(sqlQuery) ;

                SqlConnection cnn = new SqlConnection(MakeConnectionString("DESKTOP-6DASI9L", "AdventureWorks2019", "sa", "123"));
                cnn.Open();
                sqlQuery = "select * from Person.EmailAddress where (" + sqlQuery + ");";
                //sqlDeleteQuery = "Delete from Person.EmailAddress where (" + sqlQuery + ");";
                
                SqlCommand command;
                command = new SqlCommand(sqlQuery, cnn);
                SqlDataReader dataReader = command.ExecuteReader();
                int counter = 0;
                while (dataReader.Read())
                {
                    counter++;
                }
                if (counter == 1)
                {

                    MessageBox.Show("Usunięto rekord. Aktualizacja listy");
                    dataGridViewTest.Rows.Remove(dataGridViewTest.Rows[rowIndex]);
                }
                else
                {
                    MessageBox.Show("Znaleziono więcej niż jeden rekord.");
                }

                command.Dispose();
                cnn.Close();


            }
        }

        private void buttonShowCart_Click(object sender, EventArgs e)
        {

            this.Hide();
            var formCart = new FormCart(this);
            formCart.ShowDialog();
        }
    }
}

