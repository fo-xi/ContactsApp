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

        public MainForm()
        {
            InitializeComponent();
        }

        private void AllContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = AllContactsListBox.SelectedIndex;
            if (selectedIndex == -1) return;
            SurnameTextBox.Text = _project.Contacts[selectedIndex].Surname;
            NameTextBox.Text = _project.Contacts[selectedIndex].Name;
            BirthdayDateTimePicker.Value = _project.Contacts[selectedIndex].DateBirth;
            PhoneTextBox.Text = _project.Contacts[selectedIndex].Number.Number;
            EmailTextBox.Text = _project.Contacts[selectedIndex].Email;
            VkIDTextBox.Text = _project.Contacts[selectedIndex].VKID;
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
                    _project.Contacts.Remove(_project.Contacts[selectedIndex]);
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
        }

        private void EditContact()
        { //TODO: зачем сюда передаются сендер и аргументы события? Это аргументы обработчиков, а это должен быть обычный метод (+)
            var selectedIndex = AllContactsListBox.SelectedIndex;
            if (selectedIndex != -1)
            {
                var editContact = new ContactForm();
                editContact.Contact = _project.Contacts[selectedIndex];
                editContact.ShowDialog();
                if (editContact.DialogResult == DialogResult.OK)
                {
                    AllContactsListBox.Items.RemoveAt(selectedIndex);
                    _project.Contacts.Remove(_project.Contacts[selectedIndex]);
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
        }

        private void EditContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditContact();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveContact();
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
        }
    }
    //TODO: кнопки с пиктограммами слишком большие, картинка для пиктограмм не на прозрачном фоне + видно какую белую рамку (+)
    //TODO: форму всё еще нельзя растянуть на весь экран (+)
}
