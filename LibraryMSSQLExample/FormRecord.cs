using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LibraryMSSQLExample
{
    public partial class FormRecord : Form
    {
        private Form CallingForm = null;
        private String Mode = null;
        private DataTable RecordTable = null;
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
            }
        }
        public FormRecord()
        {
            InitializeComponent();
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {

            if (Mode.Equals("Update"))
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

        }

        private void buttonRejectBorrow_Click(object sender, EventArgs e)
        {

        }
    }
}
