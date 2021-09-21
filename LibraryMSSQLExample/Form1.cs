using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
namespace LibraryMSSQLExample
{
    public partial class FormWelcome : Form
    {
        static class Global
        {
            // Global data table, required when calling cart form.
            private static DataTable globalTable = new DataTable();
            public static DataTable CartTable
            {
                get { return globalTable; }
                set { globalTable = value; }
            }

            // Database credentials
            public static string dbMachine = "DESKTOP-6DASI9L";
            public static string dbName = "AdventureWorks2019";
            public static string dbLogin = "sa";
            public static string dbPass = "123";


        }

        public FormWelcome()
        {
            InitializeComponent();
            refreshRowCount();
            MakeCartTable();
        }

        // Initialize global CartTable using sql query. 
        public void MakeCartTable()
        {

            SqlConnection cnn = new SqlConnection(MakeConnectionString(Global.dbMachine, Global.dbName, Global.dbLogin, Global.dbPass));
            cnn.Open();

            SqlCommand command;

            string sqlQuery = "select * from Person.EmailAddress where (EmailAddress like '%michael12%');";
            command = new SqlCommand(sqlQuery, cnn);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            
            dataAdapter.Fill(Global.CartTable);
            Global.CartTable.Rows[0].Delete();
            Global.CartTable.AcceptChanges();

            command.Dispose();
            cnn.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        // Administration of database. Password and login required. Space not allowed
        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            string message = "Wystąpił błąd logowania. Spróbuj ponownie. \n Możliwe przyczyny to brak loginu lub hasła lub niedozwolone znaki.";
            
            if (textBoxLogin.Text.Equals("") || textBoxPassword.Text.Equals("") || textBoxLogin.Text.Contains(" ") || textBoxPassword.Text.Contains(" "))
            {
                MessageBox.Show(message);
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
                buttonAddBorrower.Visible = true;
                buttonAddBorrower.Enabled = true;
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
            SqlConnection cnn = new SqlConnection(MakeConnectionString(Global.dbMachine, Global.dbName, Global.dbLogin, Global.dbPass));
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

            SqlConnection cnn = new SqlConnection(MakeConnectionString(Global.dbMachine, Global.dbName, Global.dbLogin, Global.dbPass));
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
                if (Global.CartTable.Rows.Count == 5)
                {
                    MessageBox.Show("Maksymalna liczba wypożyczeń to 5.");
                    dataGridViewTest.DataSource = new BindingSource(Global.CartTable, null);
                }
                else
                {
                    bool CartFlag = false;
                    int index = dataGridViewTest.CurrentCell.RowIndex;
                    DataRow row = Global.CartTable.NewRow();
                    row = (((DataRowView)dataGridViewTest.Rows[index].DataBoundItem).Row);
                    for (int j = 1; j < Global.CartTable.Rows.Count; j++)
                    {
                        // numeration begins with 1, why?
                        if (Global.CartTable.Rows[j].ItemArray[3].Equals(row.ItemArray[3]))
                        {
                            MessageBox.Show("Książka już znajduje się w koszyku.");
                            CartFlag = true;
                            break;
                        }
                    }
                    if (CartFlag == false)
                    {
                        Global.CartTable.ImportRow(row);

                        dataGridViewTest.DataSource = new BindingSource(Global.CartTable, null);
                    }
                }
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
            buttonAddBorrower.Visible = false;
            buttonAddBorrower.Enabled = false;

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

                SqlConnection cnn = new SqlConnection(MakeConnectionString(Global.dbMachine, Global.dbName, Global.dbLogin, Global.dbPass));
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
            var formCart = new FormCart(this, Global.CartTable);
            formCart.ShowDialog();
        }

        private void buttonAddBorrower_Click(object sender, EventArgs e)
        {

            this.Hide();
            var formAddBorrower = new FormAddBorrower(this);
            formAddBorrower.ShowDialog();
        }

    }
}

