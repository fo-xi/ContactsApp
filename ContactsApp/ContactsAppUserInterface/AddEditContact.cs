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
    public partial class AddEditContact : Form
    {
        public Contact Contact { set; get; }
        public AddEditContact()
        {
            InitializeComponent();
        }
        private void AddEditContactOKButton_Click(object sender, EventArgs e)
        {
            var phoneNumber = new PhoneNumber(AddEditContactPhoneTextBox.Text);
            Contact = new Contact(AddEditContactSurnameTextBox.Text, 
                        AddEditContactNameTextBox.Text, phoneNumber,
                        AddEditContactBirthdayDateTimePicker.Value, AddEditContactEmailTextBox.Text,
                        AddEditContactVkIDTextBox.Text);

            this.Close();
        }
        private void AddEditCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DisplayIinformation(object sender, EventArgs e)
        {
            if (Contact != null)
            {
                AddEditContactSurnameTextBox.Text = Contact.Surname;
                AddEditContactNameTextBox.Text = Contact.Name;
                AddEditContactBirthdayDateTimePicker.Value = Contact.DateBirth;
                AddEditContactPhoneTextBox.Text = Contact.Number.Number;
                AddEditContactEmailTextBox.Text = Contact.Email;
                AddEditContactVkIDTextBox.Text = Contact.VKID;
            }
        }
        private void AddEditContactSurnameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Validator.AssertStringInRange(AddEditContactSurnameTextBox.Text, 0, 50);
                AddEditContactNameTextBox.BackColor = Color.White;
            }            catch            {
                AddEditContactNameTextBox.BackColor = Color.LightSalmon;
            }
        }
        private void AddEditContactNameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Validator.AssertStringInRange(AddEditContactNameTextBox.Text, 0, 50);
                AddEditContactNameTextBox.BackColor = Color.White;
            }            catch            {
                AddEditContactNameTextBox.BackColor = Color.LightSalmon;
            }
        }
        private void AddEditContactEmailTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Validator.AssertStringInRange(AddEditContactEmailTextBox.Text, 0, 50);
                AddEditContactEmailTextBox.BackColor = Color.White;
            }            catch            {
                AddEditContactEmailTextBox.BackColor = Color.LightSalmon;
            }
        }
        private void AddEditContactPhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Validator.AssertPhoneNumber(AddEditContactPhoneTextBox.Text);
                Validator.AssertStringInRange(AddEditContactPhoneTextBox.Text, 0, 11);
                AddEditContactPhoneTextBox.BackColor = Color.White;
            }
            catch
            {
                AddEditContactPhoneTextBox.BackColor = Color.LightSalmon;
            }
        }
        private void AddEditContactVkIDTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Validator.AssertStringInRange(AddEditContactVkIDTextBox.Text, 0, 50);
                AddEditContactVkIDTextBox.BackColor = Color.White;
            }            catch            {
                AddEditContactVkIDTextBox.BackColor = Color.LightSalmon;
            }
        }
    }
}
