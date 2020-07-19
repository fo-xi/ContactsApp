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
    //TODO: после добавления нового контакта в список он отображается на правой панели но почему-то не выделен на левой панели (+)
    public partial class MainForm : Form
    {
        /// <summary>
        /// Contains a list of all contacts
        /// </summary>
        private Project _project = new Project();
        
        /// <summary>
        /// Additional list for more convenient work with contacts.
        /// </summary>
        private List<Contact> _contacts = new List<Contact>();

        public MainForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Saves contact information to a file.
        /// </summary>
        private void SaveToFile()
        {
            ProjectManager.WriteToFile(_project);
        }


        /// <summary>
        /// Adds contact information to the list and ListBox.
        /// </summary>
        private void AddContact()
        {
            var contact = new ContactForm();
            contact.ShowDialog();
            if (contact.DialogResult == DialogResult.OK)
            {
                _project.Contacts.Add(contact.Contact);
                AllContactsListBox.Items.Add(contact.Contact.Surname);
                SaveToFile();
                UpdateTextBoxes(contact.Contact);
                SortingFoundContacts();
                var selectedIndex = -1;
                for (int i = 0; i < _contacts.Count; i++)
                {
                    if (_contacts[i].Surname == contact.Contact.Surname)
                    {
                        selectedIndex = i;
                        break;
                    }
                }
                if (selectedIndex != -1)
                {
                    AllContactsListBox.SetSelected(selectedIndex, true);
                }
            }
        }
        /// <summary>
        /// Edits contact information to the list and ListBox.
        /// </summary>
        private void EditContact()
        {
            var selectedIndex = AllContactsListBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("Select a contact from the list", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                
                var contact = new ContactForm();
                var selectedContact = _contacts[selectedIndex];
                contact.Contact = selectedContact;
                contact.ShowDialog();
                if (contact.DialogResult == DialogResult.OK)
                {
                    AllContactsListBox.Items.RemoveAt(selectedIndex);
                    _project.Contacts.Remove(selectedContact);
                    _project.Contacts.Insert(selectedIndex, contact.Contact);
                    AllContactsListBox.Items.Insert(selectedIndex, contact.Contact.Surname);
                    UpdateTextBoxes(contact.Contact);
                }
                SortingFoundContacts();
            }
        }

        /// <summary>
        /// Deletes contact information in the list and ListBox.
        /// </summary>
        private void RemoveContact()
        {
            var selectedIndex = AllContactsListBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("Select a contact from the list", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
                //TODO: если после if-else нет никакой общей логики, тогда в if можно написать return, а else с лишней вложенностью убрать (+)
            }

            DialogResult result = MessageBox.Show("Do you really want to remove this contact?",
                            "Remove contact", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                var selectedContact = _contacts[selectedIndex];
                _project.Contacts.Remove(selectedContact);
                AllContactsListBox.Items.RemoveAt(selectedIndex);
                SurnameTextBox.Clear();
                NameTextBox.Clear();
                PhoneTextBox.Clear();
                EmailTextBox.Clear();
                VkIDTextBox.Clear();
                SaveToFile();
            }
            SortingFoundContacts();
        }
        
        /// <summary>
        /// Sorts the list of found contacts.
        /// </summary>
        private void SortingFoundContacts()
        {
            if (FindTextBox.Text.Length == 0)
            {
                _contacts = _project.SortingContacts();
            }
            else
            {
                _contacts = _project.SortingContacts(FindTextBox.Text);
            }
            UpdateListBox();
        }

        /// <summary>
        /// Updates contact information in the ListBox.
        /// </summary>
        private void UpdateListBox()
        {
            AllContactsListBox.Items.Clear();
            foreach (var i in _contacts)
            {
                AllContactsListBox.Items.Add(i.Surname);
            }
        }

        private void UpdateTextBoxes(Contact contact)
        {
            SurnameTextBox.Text = contact.Surname;
            NameTextBox.Text = contact.Name;
            BirthdayDateTimePicker.Value = contact.DateBirth;
            PhoneTextBox.Text = contact.Number.Number;
            EmailTextBox.Text = contact.Email;
            VkIDTextBox.Text = contact.VKID;
        }

        private void AllContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = AllContactsListBox.SelectedIndex;
            if (selectedIndex == -1) return;
            UpdateTextBoxes(_contacts[selectedIndex]);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddContact();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            RemoveContact();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            EditContact();
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var about = new AboutForm();
            about.ShowDialog();
        }

        private void FileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddContact();
        }

        private void EditContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditContact();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveContact();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveToFile();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _project = ProjectManager.ReadFromFile();
            foreach (var n in _project.Contacts)
            {
                AllContactsListBox.Items.Add(n.Surname);
            }
            _project.Contacts = _project.SortingContacts();
            _contacts = _project.Contacts;
            UpdateListBox();

            var contacts = _project.GetDateBirth(DateTime.Now);
            if (contacts.Count != 0)
            {
                foreach (var i in contacts)
                {
                    NamesBirthdayPeopleLabel.Text += i.Surname + " ";
                }
            }
        }

        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            SortingFoundContacts();
        }

        protected override bool ProcessCmdKey(ref Message message, Keys keys)
        {
            switch (keys)
            {
                case (Keys.F1):
                    {
                        var about = new AboutForm();
                        about.ShowDialog();
                        return true;
                    }
                case ((Keys.Alt) | (Keys.F4)):
                    {
                        this.Close();
                        return true;
                    }
                case (Keys.Delete):
                    {
                        RemoveContact();
                        return true;
                    }

            }
            return base.ProcessCmdKey(ref message, keys);
        }
    }
}
