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
      /// <summary>
      /// Contains a list of all contacts
      /// </summary>
        private Project _project = new Project();

        private List<Contact> _contacts = new List<Contact>();

        public MainForm()
        {
            InitializeComponent();
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

        private void AddContact()
        {
            //TODO: зачем в методе аргументы события? (+)
            var addContact = new ContactForm();
            addContact.ShowDialog();
            if (addContact.DialogResult == DialogResult.OK)
            {
                _project.Contacts.Add(addContact.Contact);
                AllContactsListBox.Items.Add(addContact.Contact.Surname);
                SaveToFile();
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddContact();
            SearchContact();
        }

        private void RemoveContact()
        {
            //TODO: зачем в методе аргументы? (+)
            var selectedIndex = AllContactsListBox.SelectedIndex;
            if (selectedIndex != -1)
            {
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
}
            else
            {
                //TODO: часть сообщений на русском, часть на английском. Сделать единообразно (+)
                MessageBox.Show("Select a contact from the list", "Warning", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            RemoveContact();
            SearchContact();
        }

        private void EditContact()
        { //TODO: зачем сюда передаются сендер и аргументы события? Это аргументы обработчиков, а это должен быть обычный метод (+)
            var selectedIndex = AllContactsListBox.SelectedIndex;
            if (selectedIndex != -1)
            {
                var editContact = new ContactForm();
                var selectedContact = _contacts[selectedIndex];
                editContact.Contact = selectedContact;
                editContact.ShowDialog();
                if (editContact.DialogResult == DialogResult.OK)
                {
                    AllContactsListBox.Items.RemoveAt(selectedIndex);
                    _project.Contacts.Remove(selectedContact);
                    _project.Contacts.Insert(selectedIndex, editContact.Contact);
                    AllContactsListBox.Items.Insert(selectedIndex, editContact.Contact.Surname);
                }
            }
            else
            {
                MessageBox.Show("Select a contact from the list", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            EditContact();
            SearchContact();
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
            AddContact();
            SearchContact();
        }

        private void EditContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditContact();
            SearchContact();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveContact();
            SearchContact();
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
            SaveToFile();
        }

        private void SaveToFile()
        {
            ProjectManager.WriteToFile(_project);
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
        }

        private void SearchContact()
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

        private void UpdateListBox()
        {
            AllContactsListBox.Items.Clear();
            foreach (var i in _contacts)
            {
                AllContactsListBox.Items.Add(i.Surname);
            }
        }

        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            SearchContact();
        }
    }
    //TODO: кнопки с пиктограммами слишком большие, картинка для пиктограмм не на прозрачном фоне + видно какую белую рамку (+)
    //TODO: форму всё еще нельзя растянуть на весь экран (+)
}
