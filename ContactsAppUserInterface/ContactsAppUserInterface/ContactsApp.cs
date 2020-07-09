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
    public partial class ContactsApp : Form
    {
        private Project _project = new Project();
        public ContactsApp()
        {
            InitializeComponent();
        }

        private void ContactsAppAddButton_Click(object sender, EventArgs e)
        {
            var addContact = new AddEditContact();
            addContact.ShowDialog();
            _project.Contacts.Add(addContact.Contact);
            var surname = addContact.Contact.Surname;
            var name = addContact.Contact.Name;
            ContactsAppAllContactsListBox.Items.Add(surname + " " + name);
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
                _project.Contacts.Remove(_project.Contacts[selectedIndex]);
                ContactsAppAllContactsListBox.Items.RemoveAt(selectedIndex);
                ContactsAppSurnameTextBox.Clear();
                ContactsAppNameTextBox.Clear();
                ContactsAppPhoneTextBox.Clear();
                ContactsAppEmailTextBox.Clear();
                ContactsAppVkIDTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Ничего не выбрано", "Warning", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ContactsAppEditButton_Click(object sender, EventArgs e)
        {

        }
    }
}
