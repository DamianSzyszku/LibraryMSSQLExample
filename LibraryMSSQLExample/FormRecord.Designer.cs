
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
            this.buttonAddToCart = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tableRecordPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // buttonAddToCart
            // 
            this.buttonAddToCart.Location = new System.Drawing.Point(584, 205);
            this.buttonAddToCart.Name = "buttonAddToCart";
            this.buttonAddToCart.Size = new System.Drawing.Size(102, 66);
            this.buttonAddToCart.TabIndex = 0;
            this.buttonAddToCart.Text = "Dodaj do koszyka";
            this.buttonAddToCart.UseVisualStyleBackColor = true;
            this.buttonAddToCart.Click += new System.EventHandler(this.buttonAddToCart_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(584, 121);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(102, 43);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Powrót";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableRecordPanel
            // 
            this.tableRecordPanel.ColumnCount = 2;
            this.tableRecordPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableRecordPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableRecordPanel.Location = new System.Drawing.Point(49, 121);
            this.tableRecordPanel.Name = "tableRecordPanel";
            this.tableRecordPanel.RowCount = 2;
            this.tableRecordPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableRecordPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableRecordPanel.Size = new System.Drawing.Size(250, 125);
            this.tableRecordPanel.TabIndex = 2;
            // 
            // FormRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableRecordPanel);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAddToCart);
            this.Name = "FormRecord";
            this.Text = "FormRecord";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAddToCart;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TableLayoutPanel tableRecordPanel;
    }
}