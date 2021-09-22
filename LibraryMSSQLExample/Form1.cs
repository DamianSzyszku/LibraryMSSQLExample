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

            private static DataTable recordTable = new DataTable();
            public static DataTable RecordTable
            {
                get { return recordTable; }
                set { recordTable = value; }
            }

        }

        // Initialize form
        public FormWelcome()
        {
            InitializeComponent();
            refreshRowCount();
            MakeCartTable();
        }

        // Initialize global CartTable using sql query. 
        public void MakeCartTable()
        {

            try
            {
                SqlConnection cnn = new SqlConnection(dbCredentials.ConnectionString);
                cnn.Open();

                SqlCommand command;

                //string sqlQuery = "select * from Person.EmailAddress where (EmailAddress like '%michael12%');";
                string sqlQuery = "select * from dbo.BOOKS where (ISBN like '3454980000010');";
                command = new SqlCommand(sqlQuery, cnn);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                dataAdapter.Fill(Global.CartTable);
                Global.CartTable.Rows[0].Delete();
                Global.CartTable.AcceptChanges();


                dataAdapter.Fill(Global.RecordTable);
                Global.RecordTable.Rows[0].Delete();
                Global.RecordTable.AcceptChanges();

                command.Dispose();
                cnn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Nie udało się połączyć z bazą danych.");
                return;
            }

        }

        // Refresh number of rows in table. Useful when adding next record or delete existing.
        private void refreshRowCount()
        {
            try
            {
                // Login to database if succeed, active buttons.
                SqlConnection cnn = new SqlConnection(dbCredentials.ConnectionString);
                cnn.Open();

                SqlCommand command;
                SqlDataReader dataReader;
                String sqlQuery, numberOfRecords = "";

                // Count and assign number of records to numberOfRecords
                sqlQuery = "select COUNT(*) from dbo.BOOKS;";
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

            }
            catch (Exception e)
            {
                MessageBox.Show("Nie udało się połączyć z bazą danych.");
                return;
            }
        }



        // Administration of database. Password and login required. Space not allowed. Show controls
        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            String message = "Wystąpił błąd logowania. Spróbuj ponownie. \n Możliwe przyczyny to brak loginu lub hasła lub niedozwolone znaki.";
            
            if (textBoxLogin.Text.Equals("") || textBoxPassword.Text.Equals("") || textBoxLogin.Text.Contains(" ") || textBoxPassword.Text.Contains(" "))
            {
                MessageBox.Show(message);
                textBoxLogin.Text = "";
                textBoxPassword.Text = "";
            }
            else if (textBoxLogin.Text.Equals("root") && textBoxPassword.Text.Equals("root"))
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
                buttonBorrowManagement.Visible = true;
                buttonBorrowManagement.Enabled = true;
                buttonAddBorrower.Visible = true;
                buttonAddBorrower.Enabled = true;
                buttonReturnManagement.Visible = true;
                buttonReturnManagement.Enabled = true;
            }
        }

        // Logout and hide controls
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
            buttonBorrowManagement.Visible = false;
            buttonBorrowManagement.Enabled = false;
            buttonReturnManagement.Visible = false;
            buttonReturnManagement.Enabled = false;
            buttonAddBorrower.Visible = false;
            buttonAddBorrower.Enabled = false;
            textBoxLogin.Text = "";
            textBoxPassword.Text = "";

        }



        // Search for database entries
        private void buttonBookSearch_Click(object sender, EventArgs e)
        {

            SqlConnection cnn = new SqlConnection(dbCredentials.ConnectionString);
            cnn.Open();

            SqlCommand command;
            string SearchString = textBoxSearchQuery.Text;

            //string sqlQuery = "select * from Person.EmailAddress where (EmailAddress like '%" + SearchString + "%');";
            string sqlQuery = "select * from dbo.BOOKS where (TITLE like '%" + SearchString + "%' OR AUTHOR like '%" + SearchString + "%');";
            command = new SqlCommand(sqlQuery, cnn);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            dataGridViewTest.DataSource = new BindingSource(table, null);

            command.Dispose();
            cnn.Close();
            refreshRowCount();


        }

        // Add to cart selected books
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
                    for (int j = 0; j < Global.CartTable.Rows.Count; j++)
                    {
                        // numeration begins with 1, why?
                        if (Global.CartTable.Rows[j].ItemArray[0].Equals(row.ItemArray[0]))
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

        // Show cart and manage books in cart
        private void buttonShowCart_Click(object sender, EventArgs e)
        {

            this.Hide();
            var formCart = new FormCart(this, Global.CartTable);
            formCart.ShowDialog();
        }

        // Update database rows
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewTest.CurrentCell == null)
            {
                MessageBox.Show("Wybierz rekord do aktualizacji");
            }
            else
            {

                int index = dataGridViewTest.CurrentCell.RowIndex;
                DataRow row = Global.CartTable.NewRow();
                row = (((DataRowView)dataGridViewTest.Rows[index].DataBoundItem).Row);
                Global.RecordTable.ImportRow(row);


                this.Hide();
                var formRecord = new FormRecord(this, "Update", Global.RecordTable);
                formRecord.ShowDialog();
            }
        }

        // Add database rows
        private void buttonAddRecord_Click(object sender, EventArgs e)
        {

            this.Hide();
            var formRecord = new FormRecord(this, "Add", Global.RecordTable);
            formRecord.ShowDialog();
        }

        // Add borrowers
        private void buttonAddBorrower_Click(object sender, EventArgs e)
        {

            this.Hide();
            var formAddBorrower = new FormAddBorrower(this);
            formAddBorrower.ShowDialog();
        }

        // Delete book from database
        private void buttonDeleteRecord_Click(object sender, EventArgs e)
        {
            if (dataGridViewTest.CurrentCell == null)
            {
                MessageBox.Show("Wyszukaj rekord a następnie go zaznacz");
            }
            else
            {
                int rowIndex = dataGridViewTest.CurrentCell.RowIndex;
                string sqlQuery, columnName, columnValue, sqlDeleteQuery;

                columnValue = dataGridViewTest.Rows[rowIndex].Cells[0].Value.ToString();
                columnName = dataGridViewTest.Columns[0].Name.ToString();
                sqlQuery = columnName + "='" + columnValue + "'";

                MessageBox.Show(sqlQuery);

                SqlConnection cnn = new SqlConnection(dbCredentials.ConnectionString);
                cnn.Open();
                //sqlQuery = "select * from Person.EmailAddress where (" + sqlQuery + ");";
                //sqlQuery = "select *  from dbo.BOOKS where (" + sqlQuery + ");";
                sqlDeleteQuery = "Delete from dbo.BOOKS where (" + sqlQuery + ");";

                SqlCommand command;
                command = new SqlCommand(sqlDeleteQuery, cnn);
                SqlDataReader dataReader = command.ExecuteReader();

                MessageBox.Show("Usunięto rekord. Aktualizacja listy");
                dataGridViewTest.Rows.Remove(dataGridViewTest.Rows[rowIndex]);

                command.Dispose();
                cnn.Close();
                refreshRowCount();




            }
        }

        // Management of book borrows
        private void buttonBorrowManagement_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formRecord = new FormRecord(this, "Borrow", Global.RecordTable);
            formRecord.ShowDialog();

        }

        // Management of book returns
        private void buttonReturnManagement_Click(object sender, EventArgs e)
        {

            this.Hide();
            var formRecord = new FormRecord(this, "Return", Global.RecordTable);
            formRecord.ShowDialog();
        }

    }
}

