
namespace MyCityAPIClient
{
    partial class AdminForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.addStoreButton = new System.Windows.Forms.Button();
            this.storeDataGridView = new System.Windows.Forms.DataGridView();
            this.logoutButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.storeNameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.categoryListBox = new System.Windows.Forms.ListBox();
            this.refreshButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.storeDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Admin";
            // 
            // addStoreButton
            // 
            this.addStoreButton.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addStoreButton.Location = new System.Drawing.Point(32, 98);
            this.addStoreButton.Name = "addStoreButton";
            this.addStoreButton.Size = new System.Drawing.Size(100, 29);
            this.addStoreButton.TabIndex = 1;
            this.addStoreButton.Text = "Add Store";
            this.addStoreButton.UseVisualStyleBackColor = true;
            this.addStoreButton.Click += new System.EventHandler(this.addStoreButton_Click);
            // 
            // storeDataGridView
            // 
            this.storeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.storeDataGridView.Location = new System.Drawing.Point(29, 234);
            this.storeDataGridView.Name = "storeDataGridView";
            this.storeDataGridView.RowHeadersWidth = 51;
            this.storeDataGridView.RowTemplate.Height = 24;
            this.storeDataGridView.Size = new System.Drawing.Size(748, 197);
            this.storeDataGridView.TabIndex = 2;
            this.storeDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.storeDataGridView_CellDoubleClick);
            // 
            // logoutButton
            // 
            this.logoutButton.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutButton.Location = new System.Drawing.Point(678, 12);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(99, 32);
            this.logoutButton.TabIndex = 3;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Search by Name :- ";
            // 
            // storeNameTextBox
            // 
            this.storeNameTextBox.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.storeNameTextBox.Location = new System.Drawing.Point(180, 148);
            this.storeNameTextBox.Name = "storeNameTextBox";
            this.storeNameTextBox.Size = new System.Drawing.Size(162, 28);
            this.storeNameTextBox.TabIndex = 5;
            this.storeNameTextBox.TextChanged += new System.EventHandler(this.storeNameTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "Filter by Category :-";
            // 
            // categoryListBox
            // 
            this.categoryListBox.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryListBox.FormattingEnabled = true;
            this.categoryListBox.ItemHeight = 21;
            this.categoryListBox.Location = new System.Drawing.Point(180, 194);
            this.categoryListBox.Name = "categoryListBox";
            this.categoryListBox.Size = new System.Drawing.Size(162, 25);
            this.categoryListBox.TabIndex = 7;
            this.categoryListBox.SelectedIndexChanged += new System.EventHandler(this.categoryListBox_SelectedIndexChanged);
            // 
            // refreshButton
            // 
            this.refreshButton.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshButton.Location = new System.Drawing.Point(678, 187);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(99, 32);
            this.refreshButton.TabIndex = 8;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 453);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.categoryListBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.storeNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.storeDataGridView);
            this.Controls.Add(this.addStoreButton);
            this.Controls.Add(this.label1);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.storeDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addStoreButton;
        private System.Windows.Forms.DataGridView storeDataGridView;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox storeNameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox categoryListBox;
        private System.Windows.Forms.Button refreshButton;
    }
}