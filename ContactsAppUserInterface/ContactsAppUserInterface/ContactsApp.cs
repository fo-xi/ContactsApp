using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUserInterface
{
    public partial class MainForm : Form
    {
        private Project _project = new Project();
        public MainForm()
        {
            InitializeComponent();
        }

        private void ContactsAppAddButton_Click(object sender, EventArgs e)
        {
            var addContact = new AddEditContact();
            addContact.ShowDialog();
            if (addContact.Contact == null)
            {
                MessageBox.Show("Контакт не создан", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                _project.Contacts.Add(addContact.Contact);
                ContactsAppAllContactsListBox.Items.Add
                    (addContact.Contact.Surname);
                SaveToFile(sender, e);
            }
        }

        private void ContactsAppAllContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = ContactsAppAllContactsListBox.SelectedIndex;
            if (selectedIndex != -1)
            {
                ContactsAppSurnameTextBox.Text = _project.Contacts[selectedIndex].Surname;
                ContactsAppNameTextBox.Text = _project.Contacts[selectedIndex].Name;
                ContactsAppBirthdayDateTimePicker.Value = _project.Contacts[selectedIndex].DateBirth;
                ContactsAppPhoneTextBox.Text = _project.Contacts[selectedIndex].Number.Number;
                ContactsAppEmailTextBox.Text = _project.Contacts[selectedIndex].Email;
                ContactsAppVkIDTextBox.Text = _project.Contacts[selectedIndex].VKID;
            }
        }
        private void ContactsAppRemoveButton_Click(object sender, EventArgs e)
        {
            var selectedIndex = ContactsAppAllContactsListBox.SelectedIndex;
            if (selectedIndex != -1)
            {
                DialogResult result = MessageBox.Show("Do you really want to remove this contact?"
                    , "Remove contact", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    _project.Contacts.Remove(_project.Contacts[selectedIndex]);
                    ContactsAppAllContactsListBox.Items.RemoveAt(selectedIndex);
                    ContactsAppSurnameTextBox.Clear();
                    ContactsAppNameTextBox.Clear();
                    ContactsAppPhoneTextBox.Clear();
                    ContactsAppEmailTextBox.Clear();
                    ContactsAppVkIDTextBox.Clear();
                    SaveToFile(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Ничего не выбрано", "Warning", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ContactsAppEditButton_Click(object sender, EventArgs e)
        {
            var selectedIndex = ContactsAppAllContactsListBox.SelectedIndex;
            if (selectedIndex != -1)
            {
                var editContact = new AddEditContact();
                editContact.Contact = _project.Contacts[selectedIndex];
                editContact.ShowDialog();
                ContactsAppAllContactsListBox.Items.RemoveAt(selectedIndex);
                _project.Contacts.Remove(_project.Contacts[selectedIndex]);
                _project.Contacts.Insert(selectedIndex, editContact.Contact);
                ContactsAppAllContactsListBox.Items.Insert(selectedIndex, editContact.Contact);
            }
            else
            {
                MessageBox.Show("Ничего не выбрано", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var about = new About();
            about.ShowDialog();
        }
        private void FileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void AddContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContactsAppAddButton_Click(sender, e);
        }
        private void EditContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContactsAppEditButton_Click(sender, e);
        }
        private void DeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContactsAppRemoveButton_Click(sender, e);
        }
        protected override bool ProcessCmdKey(ref Message message, Keys keys)
        {
            switch (keys)
            {
                case (Keys.F1):
                    {
                        var about = new About();
                        about.ShowDialog();
                        return true;
                    }
                case ((Keys.Alt)|(Keys.F4)):
                    {
                        this.Close();
                        return true;
                    }
            }
            return base.ProcessCmdKey(ref message, keys);
        }
        private void ContactsApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveToFile(sender, e);
        }
        private void SaveToFile(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.ShowDialog();
            string filename = dialog.FileName;
            ProjectManager.WriteToFile(_project, filename);
        }
    }
}
