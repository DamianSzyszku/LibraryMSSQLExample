
namespace LibraryMSSQLExample
{
    partial class FormRecord
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dataGridViewRecordManagement = new System.Windows.Forms.DataGridView();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonAcceptBorrow = new System.Windows.Forms.Button();
            this.buttonRejectBorrow = new System.Windows.Forms.Button();
            this.buttonAcceptReturn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecordManagement)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCancel.Location = new System.Drawing.Point(627, 342);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(161, 96);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Powrót";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // dataGridViewRecordManagement
            // 
            this.dataGridViewRecordManagement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRecordManagement.Location = new System.Drawing.Point(42, 40);
            this.dataGridViewRecordManagement.Name = "dataGridViewRecordManagement";
            this.dataGridViewRecordManagement.RowHeadersWidth = 51;
            this.dataGridViewRecordManagement.RowTemplate.Height = 29;
            this.dataGridViewRecordManagement.Size = new System.Drawing.Size(746, 139);
            this.dataGridViewRecordManagement.TabIndex = 2;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(42, 201);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(155, 43);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "Dodaj";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(42, 201);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(155, 43);
            this.buttonUpdate.TabIndex = 4;
            this.buttonUpdate.Text = "Aktualizuj";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            // 
            // buttonAcceptBorrow
            // 
            this.buttonAcceptBorrow.Location = new System.Drawing.Point(42, 201);
            this.buttonAcceptBorrow.Name = "buttonAcceptBorrow";
            this.buttonAcceptBorrow.Size = new System.Drawing.Size(155, 43);
            this.buttonAcceptBorrow.TabIndex = 5;
            this.buttonAcceptBorrow.Text = "Akceptuj";
            this.buttonAcceptBorrow.UseVisualStyleBackColor = true;
            this.buttonAcceptBorrow.Click += new System.EventHandler(this.buttonAcceptBorrow_Click);
            // 
            // buttonRejectBorrow
            // 
            this.buttonRejectBorrow.Location = new System.Drawing.Point(42, 264);
            this.buttonRejectBorrow.Name = "buttonRejectBorrow";
            this.buttonRejectBorrow.Size = new System.Drawing.Size(155, 43);
            this.buttonRejectBorrow.TabIndex = 6;
            this.buttonRejectBorrow.Text = "Odrzuć";
            this.buttonRejectBorrow.UseVisualStyleBackColor = true;
            this.buttonRejectBorrow.Click += new System.EventHandler(this.buttonRejectBorrow_Click);
            // 
            // buttonAcceptReturn
            // 
            this.buttonAcceptReturn.Location = new System.Drawing.Point(42, 201);
            this.buttonAcceptReturn.Name = "buttonAcceptReturn";
            this.buttonAcceptReturn.Size = new System.Drawing.Size(155, 43);
            this.buttonAcceptReturn.TabIndex = 7;
            this.buttonAcceptReturn.Text = "Akceptuj zwrot";
            this.buttonAcceptReturn.UseVisualStyleBackColor = true;
            // 
            // FormRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonAcceptReturn);
            this.Controls.Add(this.buttonRejectBorrow);
            this.Controls.Add(this.buttonAcceptBorrow);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.dataGridViewRecordManagement);
            this.Controls.Add(this.buttonCancel);
            this.Name = "FormRecord";
            this.Text = "FormRecord";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecordManagement)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.DataGridView dataGridViewRecordManagement;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonAcceptBorrow;
        private System.Windows.Forms.Button buttonRejectBorrow;
        private System.Windows.Forms.Button buttonAcceptReturn;
    }
}