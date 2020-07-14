using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// A class containing a list of all contacts 
    /// created in the app.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Stores a list of all contacts created in the app.
        /// </summary>
        public List<Contact> Contacts { get; set; } = new List<Contact>();

        /// <summary>
		/// Sorts contacts by the first letter of their last name
		/// </summary>
        public List<Contact> SortingContacts()
        {
            var contacts = new List<Contact>();
            var sortedContacts = Contacts.OrderBy(contact => contact.Surname).ToList();
            foreach (var i in sortedContacts)
            {
                contacts.Add(i);
            }
            return contacts;
        }

        public List<Contact> SortingContacts(string substring)
        {
            var contacts = new List<Contact>();
            var sortedContacts = Contacts.OrderBy(contact => contact.Surname).ToList();
            
            foreach (var i in sortedContacts)
            {
                if ((i.Surname.Contains(substring)) || (i.Name.Contains(substring)))
                {
                    contacts.Add(i);
                }
            }
            return contacts;
        }

        public List<Contact> GetDateBirth(DateTime dateBirth)
        {
            var dateBirthContacts = new List<Contact>();

            foreach (var i in Contacts)
            {
                if ((i.DateBirth.Day == dateBirth.Day) &&
                    (i.DateBirth.Month == dateBirth.Month))
                {
                    dateBirthContacts.Add(i);
                }
            }
            return dateBirthContacts;
        }
    }
}