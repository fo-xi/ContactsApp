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
    {//TODO:  что с табуляцией? (+)
        /// <summary>
        /// Contains a list of all contacts
        /// </summary>
        private Project _project = new Project();
        //TODO: xml (+)
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

        //TODO: сначала сделать приватные методы, затем все обработчики (+) //TODO: методам добавить xml (+)
        /// <summary>
        /// Adds contact information to the list and ListBox.
        /// </summary>
        private void AddContact()
        { //TODO: неправильное название переменной (+)
            var contact = new ContactForm();
            contact.ShowDialog();
            if (contact.DialogResult == DialogResult.OK)
            {
                _project.Contacts.Add(contact.Contact);
                AllContactsListBox.Items.Add(contact.Contact.Surname);
                SaveToFile();
            }
            SortingFoundContacts();
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
                //TODO: именование переменной (+)
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
            }
            else
            { //TODO: лучше инвертировать условие, сначала дать сообщение и выход из метода (+)
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
        }
        //TODO: название говорит, что ищется один контакт, но метод делает совершенно другое. Переименовать (+)
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

        private void AllContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = AllContactsListBox.SelectedIndex;
            if (selectedIndex == -1) return;
            SurnameTextBox.Text = _contacts[selectedIndex].Surname;
            NameTextBox.Text = _contacts[selectedIndex].Name;
            BirthdayDateTimePicker.Value = _contacts[selectedIndex].DateBirth;
            PhoneTextBox.Text = _contacts[selectedIndex].Number.Number;
            EmailTextBox.Text = _contacts[selectedIndex].Email;
            VkIDTextBox.Text = _contacts[selectedIndex].VKID;
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
            //TODO: если метод обязательно вызывается после Add(), Edit(), Remove(), то почему его не вызывать прямо в этих методах? (+)
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
