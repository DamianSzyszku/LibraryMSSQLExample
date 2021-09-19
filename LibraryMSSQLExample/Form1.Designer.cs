
namespace LibraryMSSQLExample
{
    partial class FormWelcome
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonBookSearch = new System.Windows.Forms.Button();
            this.buttonSignIn = new System.Windows.Forms.Button();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelAdministrator = new System.Windows.Forms.Panel();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.textBoxSearchQuery = new System.Windows.Forms.TextBox();
            this.buttonShowCart = new System.Windows.Forms.Button();
            this.buttonAddToCart = new System.Windows.Forms.Button();
            this.labelBookCount = new System.Windows.Forms.Label();
            this.dataGridViewTest = new System.Windows.Forms.DataGridView();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonAddRecord = new System.Windows.Forms.Button();
            this.buttonDeleteRecord = new System.Windows.Forms.Button();
            this.buttonCartManagement = new System.Windows.Forms.Button();
            this.panelAdministrator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTest)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBookSearch
            // 
            this.buttonBookSearch.Location = new System.Drawing.Point(766, 86);
            this.buttonBookSearch.Name = "buttonBookSearch";
            this.buttonBookSearch.Size = new System.Drawing.Size(160, 50);
            this.buttonBookSearch.TabIndex = 1;
            this.buttonBookSearch.Text = "Szukaj";
            this.buttonBookSearch.UseVisualStyleBackColor = true;
            this.buttonBookSearch.Click += new System.EventHandler(this.buttonBookSearch_Click);
            // 
            // buttonSignIn
            // 
            this.buttonSignIn.Location = new System.Drawing.Point(206, 78);
            this.buttonSignIn.Name = "buttonSignIn";
            this.buttonSignIn.Size = new System.Drawing.Size(131, 53);
            this.buttonSignIn.TabIndex = 2;
            this.buttonSignIn.Text = "Zaloguj";
            this.buttonSignIn.UseVisualStyleBackColor = true;
            this.buttonSignIn.Click += new System.EventHandler(this.buttonSignIn_Click);
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(75, 75);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(125, 27);
            this.textBoxLogin.TabIndex = 5;
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(22, 78);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(46, 20);
            this.labelLogin.TabIndex = 6;
            this.labelLogin.Text = "Login";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(22, 111);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(47, 20);
            this.labelPassword.TabIndex = 7;
            this.labelPassword.Text = "Hasło";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(75, 108);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(125, 27);
            this.textBoxPassword.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(75, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 28);
            this.label1.TabIndex = 9;
            this.label1.Text = "Administracja biblioteką";
            // 
            // panelAdministrator
            // 
            this.panelAdministrator.Controls.Add(this.buttonLogout);
            this.panelAdministrator.Controls.Add(this.buttonSignIn);
            this.panelAdministrator.Controls.Add(this.label1);
            this.panelAdministrator.Controls.Add(this.textBoxLogin);
            this.panelAdministrator.Controls.Add(this.textBoxPassword);
            this.panelAdministrator.Controls.Add(this.labelLogin);
            this.panelAdministrator.Controls.Add(this.labelPassword);
            this.panelAdministrator.Location = new System.Drawing.Point(857, 293);
            this.panelAdministrator.Name = "panelAdministrator";
            this.panelAdministrator.Size = new System.Drawing.Size(360, 219);
            this.panelAdministrator.TabIndex = 10;
            // 
            // buttonLogout
            // 
            this.buttonLogout.Enabled = false;
            this.buttonLogout.Location = new System.Drawing.Point(206, 145);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(131, 53);
            this.buttonLogout.TabIndex = 10;
            this.buttonLogout.Text = "Wyloguj";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Visible = false;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // textBoxSearchQuery
            // 
            this.textBoxSearchQuery.Location = new System.Drawing.Point(17, 70);
            this.textBoxSearchQuery.Name = "textBoxSearchQuery";
            this.textBoxSearchQuery.PlaceholderText = "Wpisz słowo kluczowe, np. tytuł książki";
            this.textBoxSearchQuery.Size = new System.Drawing.Size(733, 27);
            this.textBoxSearchQuery.TabIndex = 11;
            // 
            // buttonShowCart
            // 
            this.buttonShowCart.Location = new System.Drawing.Point(1099, 70);
            this.buttonShowCart.Name = "buttonShowCart";
            this.buttonShowCart.Size = new System.Drawing.Size(154, 83);
            this.buttonShowCart.TabIndex = 13;
            this.buttonShowCart.Text = "Koszyk";
            this.buttonShowCart.UseVisualStyleBackColor = true;
            this.buttonShowCart.Click += new System.EventHandler(this.buttonShowCart_Click);
            // 
            // buttonAddToCart
            // 
            this.buttonAddToCart.Location = new System.Drawing.Point(766, 193);
            this.buttonAddToCart.Name = "buttonAddToCart";
            this.buttonAddToCart.Size = new System.Drawing.Size(160, 50);
            this.buttonAddToCart.TabIndex = 14;
            this.buttonAddToCart.Text = "Dodaj do koszyka";
            this.buttonAddToCart.UseVisualStyleBackColor = true;
            this.buttonAddToCart.Click += new System.EventHandler(this.buttonAddToCart_Click);
            // 
            // labelBookCount
            // 
            this.labelBookCount.AutoSize = true;
            this.labelBookCount.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelBookCount.Location = new System.Drawing.Point(220, 25);
            this.labelBookCount.Name = "labelBookCount";
            this.labelBookCount.Size = new System.Drawing.Size(178, 35);
            this.labelBookCount.TabIndex = 15;
            this.labelBookCount.Text = "W naszej bazie";
            this.labelBookCount.Visible = false;
            // 
            // dataGridViewTest
            // 
            this.dataGridViewTest.AllowUserToAddRows = false;
            this.dataGridViewTest.AllowUserToDeleteRows = false;
            this.dataGridViewTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTest.Location = new System.Drawing.Point(17, 103);
            this.dataGridViewTest.Name = "dataGridViewTest";
            this.dataGridViewTest.ReadOnly = true;
            this.dataGridViewTest.RowHeadersWidth = 51;
            this.dataGridViewTest.RowTemplate.Height = 29;
            this.dataGridViewTest.Size = new System.Drawing.Size(733, 273);
            this.dataGridViewTest.TabIndex = 19;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Enabled = false;
            this.buttonUpdate.Location = new System.Drawing.Point(98, 404);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(178, 55);
            this.buttonUpdate.TabIndex = 20;
            this.buttonUpdate.Text = "Aktualizuj rekord";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Visible = false;
            // 
            // buttonAddRecord
            // 
            this.buttonAddRecord.Enabled = false;
            this.buttonAddRecord.Location = new System.Drawing.Point(282, 404);
            this.buttonAddRecord.Name = "buttonAddRecord";
            this.buttonAddRecord.Size = new System.Drawing.Size(178, 55);
            this.buttonAddRecord.TabIndex = 21;
            this.buttonAddRecord.Text = "Dodaj rekord";
            this.buttonAddRecord.UseVisualStyleBackColor = true;
            this.buttonAddRecord.Visible = false;
            // 
            // buttonDeleteRecord
            // 
            this.buttonDeleteRecord.Enabled = false;
            this.buttonDeleteRecord.Location = new System.Drawing.Point(466, 404);
            this.buttonDeleteRecord.Name = "buttonDeleteRecord";
            this.buttonDeleteRecord.Size = new System.Drawing.Size(178, 55);
            this.buttonDeleteRecord.TabIndex = 22;
            this.buttonDeleteRecord.Text = "Usuń rekord";
            this.buttonDeleteRecord.UseVisualStyleBackColor = true;
            this.buttonDeleteRecord.Visible = false;
            this.buttonDeleteRecord.Click += new System.EventHandler(this.buttonDeleteRecord_Click);
            // 
            // buttonCartManagement
            // 
            this.buttonCartManagement.Enabled = false;
            this.buttonCartManagement.Location = new System.Drawing.Point(1099, 177);
            this.buttonCartManagement.Name = "buttonCartManagement";
            this.buttonCartManagement.Size = new System.Drawing.Size(154, 83);
            this.buttonCartManagement.TabIndex = 23;
            this.buttonCartManagement.Text = "Administracja rezerwacjami";
            this.buttonCartManagement.UseVisualStyleBackColor = true;
            this.buttonCartManagement.Visible = false;
            // 
            // FormWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1299, 524);
            this.Controls.Add(this.buttonCartManagement);
            this.Controls.Add(this.buttonDeleteRecord);
            this.Controls.Add(this.buttonAddRecord);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.dataGridViewTest);
            this.Controls.Add(this.labelBookCount);
            this.Controls.Add(this.buttonAddToCart);
            this.Controls.Add(this.buttonShowCart);
            this.Controls.Add(this.textBoxSearchQuery);
            this.Controls.Add(this.panelAdministrator);
            this.Controls.Add(this.buttonBookSearch);
            this.Name = "FormWelcome";
            this.Text = "Aplikacja biblioteczna DSz";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelAdministrator.ResumeLayout(false);
            this.panelAdministrator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonBookSearch;
        private System.Windows.Forms.Button buttonSignIn;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelAdministrator;
        private System.Windows.Forms.TextBox textBoxSearchQuery;
        private System.Windows.Forms.Button buttonShowCart;
        private System.Windows.Forms.Button buttonAddToCart;
        private System.Windows.Forms.Label labelBookCount;
        private System.Windows.Forms.DataGridView dataGridViewTest;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonAddRecord;
        private System.Windows.Forms.Button buttonDeleteRecord;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonCartManagement;
    }
}

