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
    }
}
