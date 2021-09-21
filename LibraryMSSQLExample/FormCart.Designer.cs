
namespace LibraryMSSQLExample
{
    partial class FormCart
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
            this.buttonBack = new System.Windows.Forms.Button();
            this.dataGridViewCart = new System.Windows.Forms.DataGridView();
            this.buttonReserve = new System.Windows.Forms.Button();
            this.buttonRemoveFromCart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.maskedTextBoxAlbumNumber = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCart)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(632, 347);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(129, 73);
            this.buttonBack.TabIndex = 0;
            this.buttonBack.Text = "Powrót";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // dataGridViewCart
            // 
            this.dataGridViewCart.AllowUserToAddRows = false;
            this.dataGridViewCart.AllowUserToDeleteRows = false;
            this.dataGridViewCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCart.Location = new System.Drawing.Point(26, 29);
            this.dataGridViewCart.Name = "dataGridViewCart";
            this.dataGridViewCart.ReadOnly = true;
            this.dataGridViewCart.RowHeadersWidth = 51;
            this.dataGridViewCart.RowTemplate.Height = 29;
            this.dataGridViewCart.Size = new System.Drawing.Size(735, 182);
            this.dataGridViewCart.TabIndex = 1;
            // 
            // buttonReserve
            // 
            this.buttonReserve.Location = new System.Drawing.Point(397, 347);
            this.buttonReserve.Name = "buttonReserve";
            this.buttonReserve.Size = new System.Drawing.Size(129, 73);
            this.buttonReserve.TabIndex = 2;
            this.buttonReserve.Text = "Rezerwacja";
            this.buttonReserve.UseVisualStyleBackColor = true;
            this.buttonReserve.Click += new System.EventHandler(this.buttonReserve_Click);
            // 
            // buttonRemoveFromCart
            // 
            this.buttonRemoveFromCart.Location = new System.Drawing.Point(26, 236);
            this.buttonRemoveFromCart.Name = "buttonRemoveFromCart";
            this.buttonRemoveFromCart.Size = new System.Drawing.Size(129, 73);
            this.buttonRemoveFromCart.TabIndex = 3;
            this.buttonRemoveFromCart.Text = "Usuń z koszyka";
            this.buttonRemoveFromCart.UseVisualStyleBackColor = true;
            this.buttonRemoveFromCart.Click += new System.EventHandler(this.buttonRemoveFromCart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(363, 311);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Numer albumu:";
            // 
            // maskedTextBoxAlbumNumber
            // 
            this.maskedTextBoxAlbumNumber.Location = new System.Drawing.Point(490, 308);
            this.maskedTextBoxAlbumNumber.Mask = "000000";
            this.maskedTextBoxAlbumNumber.Name = "maskedTextBoxAlbumNumber";
            this.maskedTextBoxAlbumNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.maskedTextBoxAlbumNumber.Size = new System.Drawing.Size(70, 27);
            this.maskedTextBoxAlbumNumber.TabIndex = 6;
            this.maskedTextBoxAlbumNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maskedTextBoxAlbumNumber.ValidatingType = typeof(int);
            // 
            // FormCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.maskedTextBoxAlbumNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonRemoveFromCart);
            this.Controls.Add(this.buttonReserve);
            this.Controls.Add(this.dataGridViewCart);
            this.Controls.Add(this.buttonBack);
            this.Name = "FormCart";
            this.Text = "FormCart";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.DataGridView dataGridViewCart;
        private System.Windows.Forms.Button buttonReserve;
        private System.Windows.Forms.Button buttonRemoveFromCart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxAlbumNumber;
    }
}