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
    }
}