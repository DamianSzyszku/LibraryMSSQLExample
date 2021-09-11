
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
            this.listBoxSearchResult = new System.Windows.Forms.ListBox();
            this.buttonShowCart = new System.Windows.Forms.Button();
            this.buttonAddToCart = new System.Windows.Forms.Button();
            this.labelBookCount = new System.Windows.Forms.Label();
            this.textBoxBookCount = new System.Windows.Forms.TextBox();
            this.labelBookCountEnding = new System.Windows.Forms.Label();
            this.panelAdministrator.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBookSearch
            // 
            this.buttonBookSearch.Location = new System.Drawing.Point(486, 70);
            this.buttonBookSearch.Name = "buttonBookSearch";
            this.buttonBookSearch.Size = new System.Drawing.Size(131, 29);
            this.buttonBookSearch.TabIndex = 1;
            this.buttonBookSearch.Text = "Szukaj";
            this.buttonBookSearch.UseVisualStyleBackColor = true;
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
            this.panelAdministrator.Location = new System.Drawing.Point(428, 246);
            this.panelAdministrator.Name = "panelAdministrator";
            this.panelAdministrator.Size = new System.Drawing.Size(360, 175);
            this.panelAdministrator.TabIndex = 10;
            // 
            // textBoxSearchQuery
            // 
            this.textBoxSearchQuery.Location = new System.Drawing.Point(17, 70);
            this.textBoxSearchQuery.Name = "textBoxSearchQuery";
            this.textBoxSearchQuery.PlaceholderText = "Wpisz słowo kluczowe, np. tytuł książki";
            this.textBoxSearchQuery.Size = new System.Drawing.Size(439, 27);
            this.textBoxSearchQuery.TabIndex = 11;
            // 
            // listBoxSearchResult
            // 
            this.listBoxSearchResult.FormattingEnabled = true;
            this.listBoxSearchResult.ItemHeight = 20;
            this.listBoxSearchResult.Location = new System.Drawing.Point(17, 149);
            this.listBoxSearchResult.Name = "listBoxSearchResult";
            this.listBoxSearchResult.Size = new System.Drawing.Size(377, 264);
            this.listBoxSearchResult.TabIndex = 12;
            this.listBoxSearchResult.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // buttonShowCart
            // 
            this.buttonShowCart.Location = new System.Drawing.Point(428, 183);
            this.buttonShowCart.Name = "buttonShowCart";
            this.buttonShowCart.Size = new System.Drawing.Size(94, 29);
            this.buttonShowCart.TabIndex = 13;
            this.buttonShowCart.Text = "Koszyk";
            this.buttonShowCart.UseVisualStyleBackColor = true;
            // 
            // buttonAddToCart
            // 
            this.buttonAddToCart.Location = new System.Drawing.Point(428, 148);
            this.buttonAddToCart.Name = "buttonAddToCart";
            this.buttonAddToCart.Size = new System.Drawing.Size(146, 29);
            this.buttonAddToCart.TabIndex = 14;
            this.buttonAddToCart.Text = "Dodaj do koszyka";
            this.buttonAddToCart.UseVisualStyleBackColor = true;
            // 
            // labelBookCount
            // 
            this.labelBookCount.AutoSize = true;
            this.labelBookCount.Location = new System.Drawing.Point(205, 23);
            this.labelBookCount.Name = "labelBookCount";
            this.labelBookCount.Size = new System.Drawing.Size(190, 20);
            this.labelBookCount.TabIndex = 15;
            this.labelBookCount.Text = "W naszej bazie znajduje się";
            // 
            // textBoxBookCount
            // 
            this.textBoxBookCount.Enabled = false;
            this.textBoxBookCount.Location = new System.Drawing.Point(401, 20);
            this.textBoxBookCount.Name = "textBoxBookCount";
            this.textBoxBookCount.Size = new System.Drawing.Size(55, 27);
            this.textBoxBookCount.TabIndex = 16;
            this.textBoxBookCount.Text = "123123";
            // 
            // labelBookCountEnding
            // 
            this.labelBookCountEnding.AutoSize = true;
            this.labelBookCountEnding.Location = new System.Drawing.Point(462, 23);
            this.labelBookCountEnding.Name = "labelBookCountEnding";
            this.labelBookCountEnding.Size = new System.Drawing.Size(59, 20);
            this.labelBookCountEnding.TabIndex = 17;
            this.labelBookCountEnding.Text = "książek.";
            // 
            // FormWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelBookCountEnding);
            this.Controls.Add(this.textBoxBookCount);
            this.Controls.Add(this.labelBookCount);
            this.Controls.Add(this.buttonAddToCart);
            this.Controls.Add(this.buttonShowCart);
            this.Controls.Add(this.listBoxSearchResult);
            this.Controls.Add(this.textBoxSearchQuery);
            this.Controls.Add(this.panelAdministrator);
            this.Controls.Add(this.buttonBookSearch);
            this.Name = "FormWelcome";
            this.Text = "Aplikacja biblioteczna DSz";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelAdministrator.ResumeLayout(false);
            this.panelAdministrator.PerformLayout();
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
        private System.Windows.Forms.ListBox listBoxSearchResult;
        private System.Windows.Forms.Button buttonShowCart;
        private System.Windows.Forms.Button buttonAddToCart;
        private System.Windows.Forms.Label labelBookCount;
        private System.Windows.Forms.TextBox textBoxBookCount;
        private System.Windows.Forms.Label labelBookCountEnding;
    }
}

