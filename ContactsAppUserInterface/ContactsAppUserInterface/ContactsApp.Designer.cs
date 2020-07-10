namespace ContactsAppUserInterface
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addContactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editContactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContactsAppSurnameTextBox = new System.Windows.Forms.TextBox();
            this.ContactsAppNameTextBox = new System.Windows.Forms.TextBox();
            this.ContactsAppPhoneTextBox = new System.Windows.Forms.TextBox();
            this.ContactsAppEmailTextBox = new System.Windows.Forms.TextBox();
            this.ContactsAppVkIDTextBox = new System.Windows.Forms.TextBox();
            this.ContactsAppSurnameLabel = new System.Windows.Forms.Label();
            this.ContactsAppNameLabel = new System.Windows.Forms.Label();
            this.ContactsAppEmailLabel = new System.Windows.Forms.Label();
            this.ContactsAppBirthdaylabel = new System.Windows.Forms.Label();
            this.ContactsAppPhonrLabel = new System.Windows.Forms.Label();
            this.ContactsAppVkIDLabel = new System.Windows.Forms.Label();
            this.ContactsAppBirthdayDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ContactsAppAddButton = new System.Windows.Forms.Button();
            this.ContactsAppEditButton = new System.Windows.Forms.Button();
            this.ContactsAppRemoveButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ContactsAppAllContactsListBox = new System.Windows.Forms.ListBox();
            this.ContactsAppFindlabel = new System.Windows.Forms.Label();
            this.ContactsAppFindTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(804, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "FileEditHelp";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.FileToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addContactToolStripMenuItem,
            this.editContactToolStripMenuItem,
            this.deToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // addContactToolStripMenuItem
            // 
            this.addContactToolStripMenuItem.Name = "addContactToolStripMenuItem";
            this.addContactToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.addContactToolStripMenuItem.Text = "Add Contact";
            this.addContactToolStripMenuItem.Click += new System.EventHandler(this.AddContactToolStripMenuItem_Click);
            // 
            // editContactToolStripMenuItem
            // 
            this.editContactToolStripMenuItem.Name = "editContactToolStripMenuItem";
            this.editContactToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.editContactToolStripMenuItem.Text = "Edit Contact";
            this.editContactToolStripMenuItem.Click += new System.EventHandler(this.EditContactToolStripMenuItem_Click);
            // 
            // deToolStripMenuItem
            // 
            this.deToolStripMenuItem.Name = "deToolStripMenuItem";
            this.deToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.deToolStripMenuItem.Text = "Remove Contact";
            this.deToolStripMenuItem.Click += new System.EventHandler(this.DeToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.HelpToolStripMenuItem_Click);
            // 
            // ContactsAppSurnameTextBox
            // 
            this.ContactsAppSurnameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ContactsAppSurnameTextBox.Location = new System.Drawing.Point(81, 5);
            this.ContactsAppSurnameTextBox.Name = "ContactsAppSurnameTextBox";
            this.ContactsAppSurnameTextBox.Size = new System.Drawing.Size(345, 20);
            this.ContactsAppSurnameTextBox.TabIndex = 1;
            // 
            // ContactsAppNameTextBox
            // 
            this.ContactsAppNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ContactsAppNameTextBox.Location = new System.Drawing.Point(81, 35);
            this.ContactsAppNameTextBox.Name = "ContactsAppNameTextBox";
            this.ContactsAppNameTextBox.Size = new System.Drawing.Size(345, 20);
            this.ContactsAppNameTextBox.TabIndex = 2;
            // 
            // ContactsAppPhoneTextBox
            // 
            this.ContactsAppPhoneTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ContactsAppPhoneTextBox.Location = new System.Drawing.Point(81, 95);
            this.ContactsAppPhoneTextBox.Name = "ContactsAppPhoneTextBox";
            this.ContactsAppPhoneTextBox.Size = new System.Drawing.Size(345, 20);
            this.ContactsAppPhoneTextBox.TabIndex = 3;
            // 
            // ContactsAppEmailTextBox
            // 
            this.ContactsAppEmailTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ContactsAppEmailTextBox.Location = new System.Drawing.Point(81, 125);
            this.ContactsAppEmailTextBox.Name = "ContactsAppEmailTextBox";
            this.ContactsAppEmailTextBox.Size = new System.Drawing.Size(345, 20);
            this.ContactsAppEmailTextBox.TabIndex = 5;
            // 
            // ContactsAppVkIDTextBox
            // 
            this.ContactsAppVkIDTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ContactsAppVkIDTextBox.Location = new System.Drawing.Point(81, 157);
            this.ContactsAppVkIDTextBox.Name = "ContactsAppVkIDTextBox";
            this.ContactsAppVkIDTextBox.Size = new System.Drawing.Size(345, 20);
            this.ContactsAppVkIDTextBox.TabIndex = 6;
            // 
            // ContactsAppSurnameLabel
            // 
            this.ContactsAppSurnameLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ContactsAppSurnameLabel.AutoSize = true;
            this.ContactsAppSurnameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ContactsAppSurnameLabel.Location = new System.Drawing.Point(6, 6);
            this.ContactsAppSurnameLabel.Name = "ContactsAppSurnameLabel";
            this.ContactsAppSurnameLabel.Size = new System.Drawing.Size(69, 17);
            this.ContactsAppSurnameLabel.TabIndex = 7;
            this.ContactsAppSurnameLabel.Text = "Surname:";
            // 
            // ContactsAppNameLabel
            // 
            this.ContactsAppNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ContactsAppNameLabel.AutoSize = true;
            this.ContactsAppNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ContactsAppNameLabel.Location = new System.Drawing.Point(26, 36);
            this.ContactsAppNameLabel.Name = "ContactsAppNameLabel";
            this.ContactsAppNameLabel.Size = new System.Drawing.Size(49, 17);
            this.ContactsAppNameLabel.TabIndex = 8;
            this.ContactsAppNameLabel.Text = "Name:";
            // 
            // ContactsAppEmailLabel
            // 
            this.ContactsAppEmailLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ContactsAppEmailLabel.AutoSize = true;
            this.ContactsAppEmailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ContactsAppEmailLabel.Location = new System.Drawing.Point(25, 126);
            this.ContactsAppEmailLabel.Name = "ContactsAppEmailLabel";
            this.ContactsAppEmailLabel.Size = new System.Drawing.Size(50, 17);
            this.ContactsAppEmailLabel.TabIndex = 9;
            this.ContactsAppEmailLabel.Text = "e-mail:";
            // 
            // ContactsAppBirthdaylabel
            // 
            this.ContactsAppBirthdaylabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ContactsAppBirthdaylabel.AutoSize = true;
            this.ContactsAppBirthdaylabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ContactsAppBirthdaylabel.Location = new System.Drawing.Point(11, 66);
            this.ContactsAppBirthdaylabel.Name = "ContactsAppBirthdaylabel";
            this.ContactsAppBirthdaylabel.Size = new System.Drawing.Size(64, 17);
            this.ContactsAppBirthdaylabel.TabIndex = 10;
            this.ContactsAppBirthdaylabel.Text = "Birthday:";
            // 
            // ContactsAppPhonrLabel
            // 
            this.ContactsAppPhonrLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ContactsAppPhonrLabel.AutoSize = true;
            this.ContactsAppPhonrLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ContactsAppPhonrLabel.Location = new System.Drawing.Point(22, 96);
            this.ContactsAppPhonrLabel.Name = "ContactsAppPhonrLabel";
            this.ContactsAppPhonrLabel.Size = new System.Drawing.Size(53, 17);
            this.ContactsAppPhonrLabel.TabIndex = 11;
            this.ContactsAppPhonrLabel.Text = "Phone:";
            // 
            // ContactsAppVkIDLabel
            // 
            this.ContactsAppVkIDLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ContactsAppVkIDLabel.AutoSize = true;
            this.ContactsAppVkIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ContactsAppVkIDLabel.Location = new System.Drawing.Point(19, 158);
            this.ContactsAppVkIDLabel.Name = "ContactsAppVkIDLabel";
            this.ContactsAppVkIDLabel.Size = new System.Drawing.Size(56, 17);
            this.ContactsAppVkIDLabel.TabIndex = 12;
            this.ContactsAppVkIDLabel.Text = "vk.com:";
            // 
            // ContactsAppBirthdayDateTimePicker
            // 
            this.ContactsAppBirthdayDateTimePicker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ContactsAppBirthdayDateTimePicker.Location = new System.Drawing.Point(81, 65);
            this.ContactsAppBirthdayDateTimePicker.Name = "ContactsAppBirthdayDateTimePicker";
            this.ContactsAppBirthdayDateTimePicker.Size = new System.Drawing.Size(147, 20);
            this.ContactsAppBirthdayDateTimePicker.TabIndex = 15;
            // 
            // ContactsAppAddButton
            // 
            this.ContactsAppAddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ContactsAppAddButton.Location = new System.Drawing.Point(3, 3);
            this.ContactsAppAddButton.Name = "ContactsAppAddButton";
            this.ContactsAppAddButton.Size = new System.Drawing.Size(70, 23);
            this.ContactsAppAddButton.TabIndex = 18;
            this.ContactsAppAddButton.Text = "Add";
            this.ContactsAppAddButton.UseVisualStyleBackColor = true;
            this.ContactsAppAddButton.Click += new System.EventHandler(this.ContactsAppAddButton_Click);
            // 
            // ContactsAppEditButton
            // 
            this.ContactsAppEditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ContactsAppEditButton.Location = new System.Drawing.Point(79, 3);
            this.ContactsAppEditButton.Name = "ContactsAppEditButton";
            this.ContactsAppEditButton.Size = new System.Drawing.Size(70, 23);
            this.ContactsAppEditButton.TabIndex = 19;
            this.ContactsAppEditButton.Text = "Edit";
            this.ContactsAppEditButton.UseVisualStyleBackColor = true;
            this.ContactsAppEditButton.Click += new System.EventHandler(this.ContactsAppEditButton_Click);
            // 
            // ContactsAppRemoveButton
            // 
            this.ContactsAppRemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ContactsAppRemoveButton.Location = new System.Drawing.Point(155, 3);
            this.ContactsAppRemoveButton.Name = "ContactsAppRemoveButton";
            this.ContactsAppRemoveButton.Size = new System.Drawing.Size(72, 23);
            this.ContactsAppRemoveButton.TabIndex = 20;
            this.ContactsAppRemoveButton.Text = "Remove";
            this.ContactsAppRemoveButton.UseVisualStyleBackColor = true;
            this.ContactsAppRemoveButton.Click += new System.EventHandler(this.ContactsAppRemoveButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.35294F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.64706F));
            this.tableLayoutPanel1.Controls.Add(this.ContactsAppNameLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ContactsAppNameTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ContactsAppBirthdaylabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ContactsAppBirthdayDateTimePicker, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.ContactsAppPhonrLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.ContactsAppPhoneTextBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.ContactsAppVkIDTextBox, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.ContactsAppVkIDLabel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.ContactsAppEmailTextBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.ContactsAppSurnameTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ContactsAppEmailLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.ContactsAppSurnameLabel, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(363, 44);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(429, 184);
            this.tableLayoutPanel1.TabIndex = 21;
            // 
            // ContactsAppAllContactsListBox
            // 
            this.ContactsAppAllContactsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ContactsAppAllContactsListBox.FormattingEnabled = true;
            this.ContactsAppAllContactsListBox.Location = new System.Drawing.Point(3, 3);
            this.ContactsAppAllContactsListBox.Name = "ContactsAppAllContactsListBox";
            this.ContactsAppAllContactsListBox.ScrollAlwaysVisible = true;
            this.ContactsAppAllContactsListBox.Size = new System.Drawing.Size(298, 316);
            this.ContactsAppAllContactsListBox.TabIndex = 17;
            this.ContactsAppAllContactsListBox.SelectedIndexChanged += new System.EventHandler(this.ContactsAppAllContactsListBox_SelectedIndexChanged);
            // 
            // ContactsAppFindlabel
            // 
            this.ContactsAppFindlabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ContactsAppFindlabel.AutoSize = true;
            this.ContactsAppFindlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ContactsAppFindlabel.Location = new System.Drawing.Point(3, 7);
            this.ContactsAppFindlabel.Name = "ContactsAppFindlabel";
            this.ContactsAppFindlabel.Size = new System.Drawing.Size(39, 17);
            this.ContactsAppFindlabel.TabIndex = 16;
            this.ContactsAppFindlabel.Text = "Find:";
            // 
            // ContactsAppFindTextBox
            // 
            this.ContactsAppFindTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ContactsAppFindTextBox.Location = new System.Drawing.Point(49, 5);
            this.ContactsAppFindTextBox.Name = "ContactsAppFindTextBox";
            this.ContactsAppFindTextBox.Size = new System.Drawing.Size(252, 20);
            this.ContactsAppFindTextBox.TabIndex = 13;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.13158F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.86842F));
            this.tableLayoutPanel2.Controls.Add(this.ContactsAppFindlabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ContactsAppFindTextBox, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 44);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(304, 31);
            this.tableLayoutPanel2.TabIndex = 22;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.ContactsAppAllContactsListBox, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(12, 81);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(304, 324);
            this.tableLayoutPanel3.TabIndex = 23;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Controls.Add(this.ContactsAppAddButton, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.ContactsAppEditButton, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.ContactsAppRemoveButton, 2, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(12, 411);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(230, 29);
            this.tableLayoutPanel4.TabIndex = 24;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 452);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(820, 490);
            this.MinimumSize = new System.Drawing.Size(820, 490);
            this.Name = "MainForm";
            this.Text = "ContactsApp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ContactsApp_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TextBox ContactsAppSurnameTextBox;
        private System.Windows.Forms.TextBox ContactsAppNameTextBox;
        private System.Windows.Forms.TextBox ContactsAppPhoneTextBox;
        private System.Windows.Forms.TextBox ContactsAppEmailTextBox;
        private System.Windows.Forms.TextBox ContactsAppVkIDTextBox;
        private System.Windows.Forms.Label ContactsAppSurnameLabel;
        private System.Windows.Forms.Label ContactsAppNameLabel;
        private System.Windows.Forms.Label ContactsAppEmailLabel;
        private System.Windows.Forms.Label ContactsAppBirthdaylabel;
        private System.Windows.Forms.Label ContactsAppPhonrLabel;
        private System.Windows.Forms.Label ContactsAppVkIDLabel;
        private System.Windows.Forms.DateTimePicker ContactsAppBirthdayDateTimePicker;
        private System.Windows.Forms.Button ContactsAppAddButton;
        private System.Windows.Forms.Button ContactsAppEditButton;
        private System.Windows.Forms.Button ContactsAppRemoveButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox ContactsAppAllContactsListBox;
        private System.Windows.Forms.Label ContactsAppFindlabel;
        private System.Windows.Forms.TextBox ContactsAppFindTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ToolStripMenuItem addContactToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editContactToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deToolStripMenuItem;
    }
}

