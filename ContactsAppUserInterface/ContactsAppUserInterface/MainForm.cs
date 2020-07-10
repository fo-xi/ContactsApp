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

        private void AllContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = AllContactsListBox.SelectedIndex;
            if (selectedIndex != -1)
            {
                SurnameTextBox.Text = _project.Contacts[selectedIndex].Surname;
                NameTextBox.Text = _project.Contacts[selectedIndex].Name;
                BirthdayDateTimePicker.Value = _project.Contacts[selectedIndex].DateBirth;
                PhoneTextBox.Text = _project.Contacts[selectedIndex].Number.Number;
                EmailTextBox.Text = _project.Contacts[selectedIndex].Email;
                VkIDTextBox.Text = _project.Contacts[selectedIndex].VKID;
            }
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            var addContact = new ContactForm();
            addContact.ShowDialog();
            if (addContact.Contact == null)
            {
                MessageBox.Show("Контакт не создан", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                _project.Contacts.Add(addContact.Contact);
                AllContactsListBox.Items.Add
                    (addContact.Contact.Surname);
                SaveToFile(sender, e);
            }
        }
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            var selectedIndex = AllContactsListBox.SelectedIndex;
            if (selectedIndex != -1)
            {
                DialogResult result = MessageBox.Show("Do you really want to remove this contact?"
                    , "Remove contact", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    _project.Contacts.Remove(_project.Contacts[selectedIndex]);
                    AllContactsListBox.Items.RemoveAt(selectedIndex);
                    SurnameTextBox.Clear();
                    NameTextBox.Clear();
                    PhoneTextBox.Clear();
                    EmailTextBox.Clear();
                    VkIDTextBox.Clear();
                    SaveToFile(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Ничего не выбрано", "Warning", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void EditButton_Click(object sender, EventArgs e)
        {
            var selectedIndex = AllContactsListBox.SelectedIndex;
            if (selectedIndex != -1)
            {
                var editContact = new ContactForm();
                editContact.Contact = _project.Contacts[selectedIndex];
                editContact.ShowDialog();
                AllContactsListBox.Items.RemoveAt(selectedIndex);
                _project.Contacts.Remove(_project.Contacts[selectedIndex]);
                _project.Contacts.Insert(selectedIndex, editContact.Contact);
                AllContactsListBox.Items.Insert(selectedIndex, editContact.Contact.Surname);
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
            AddButton_Click(sender, e);
        }
        private void EditContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditButton_Click(sender, e);
        }
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveButton_Click(sender, e);
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
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveToFile(sender, e);
        }
        private void SaveToFile(object sender, EventArgs e)
        {
            string filename = Environment.GetFolderPath
            (Environment.SpecialFolder.ApplicationData) + "\\ConatctsApp\\Contacts.txt";
            ProjectManager.WriteToFile(_project, filename);
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            string filename = Environment.GetFolderPath
           (Environment.SpecialFolder.ApplicationData) + "\\ConatctsApp\\Contacts.txt";
            _project = ProjectManager.ReadFromFile(filename);
            foreach (var n in _project.Contacts)
            {
                AllContactsListBox.Items.Add(n.Surname);
            }
        }
    }
}
