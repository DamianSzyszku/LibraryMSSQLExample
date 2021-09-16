
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
            this.textBoxSearchQuery = new System.Windows.Forms.TextBox();
            this.buttonShowCart = new System.Windows.Forms.Button();
            this.buttonGetBookInfo = new System.Windows.Forms.Button();
            this.labelBookCount = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.dataGridViewTest = new System.Windows.Forms.DataGridView();
            this.panelAdministrator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTest)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBookSearch
            // 
            this.buttonBookSearch.Location = new System.Drawing.Point(800, 25);
            this.buttonBookSearch.Name = "buttonBookSearch";
            this.buttonBookSearch.Size = new System.Drawing.Size(160, 117);
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
            this.panelAdministrator.Controls.Add(this.buttonSignIn);
            this.panelAdministrator.Controls.Add(this.label1);
            this.panelAdministrator.Controls.Add(this.textBoxLogin);
            this.panelAdministrator.Controls.Add(this.textBoxPassword);
            this.panelAdministrator.Controls.Add(this.labelLogin);
            this.panelAdministrator.Controls.Add(this.labelPassword);
            this.panelAdministrator.Location = new System.Drawing.Point(916, 337);
            this.panelAdministrator.Name = "panelAdministrator";
            this.panelAdministrator.Size = new System.Drawing.Size(360, 175);
            this.panelAdministrator.TabIndex = 10;
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
            this.buttonShowCart.Location = new System.Drawing.Point(1094, 190);
            this.buttonShowCart.Name = "buttonShowCart";
            this.buttonShowCart.Size = new System.Drawing.Size(182, 102);
            this.buttonShowCart.TabIndex = 13;
            this.buttonShowCart.Text = "Koszyk";
            this.buttonShowCart.UseVisualStyleBackColor = true;
            // 
            // buttonGetBookInfo
            // 
            this.buttonGetBookInfo.Location = new System.Drawing.Point(800, 209);
            this.buttonGetBookInfo.Name = "buttonGetBookInfo";
            this.buttonGetBookInfo.Size = new System.Drawing.Size(160, 83);
            this.buttonGetBookInfo.TabIndex = 14;
            this.buttonGetBookInfo.Text = "Pełny rekord";
            this.buttonGetBookInfo.UseVisualStyleBackColor = true;
            this.buttonGetBookInfo.Click += new System.EventHandler(this.buttonGetBookInfo_Click);
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
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(1094, 25);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(182, 117);
            this.buttonConnect.TabIndex = 18;
            this.buttonConnect.Text = "Połączenie z bazą";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // dataGridViewTest
            // 
            this.dataGridViewTest.AllowUserToAddRows = false;
            this.dataGridViewTest.AllowUserToDeleteRows = false;
            this.dataGridViewTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTest.Location = new System.Drawing.Point(17, 148);
            this.dataGridViewTest.Name = "dataGridViewTest";
            this.dataGridViewTest.ReadOnly = true;
            this.dataGridViewTest.RowHeadersWidth = 51;
            this.dataGridViewTest.RowTemplate.Height = 29;
            this.dataGridViewTest.Size = new System.Drawing.Size(733, 273);
            this.dataGridViewTest.TabIndex = 19;
            // 
            // FormWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1299, 524);
            this.Controls.Add(this.dataGridViewTest);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.labelBookCount);
            this.Controls.Add(this.buttonGetBookInfo);
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
        private System.Windows.Forms.Button buttonGetBookInfo;
        private System.Windows.Forms.Label labelBookCount;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.DataGridView dataGridViewTest;
    }
}

