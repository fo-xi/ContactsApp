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
//TODO: в репозитории два решения sln. Должно быть только одно решение. В корневой папке должен лежать sln по имени приложения, там же две папки с проектами
//TODO: головной проект пользовательского интерфейса правильнее называть по названию приложения без добавления UI или UserInterface. Приставка UserInterface слишком длинная для практичного использования
namespace ContactsAppUserInterface
{
    public partial class MainForm : Form
    { //TODO: xml (+) //TODO: одна пустая строка между членами класса (+)
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
            if (selectedIndex == -1) return;//TODO: лучше инвертировать условие для уменьшения вложенности
            SurnameTextBox.Text = _project.Contacts[selectedIndex].Surname;
            NameTextBox.Text = _project.Contacts[selectedIndex].Name;
            BirthdayDateTimePicker.Value = _project.Contacts[selectedIndex].DateBirth;
            PhoneTextBox.Text = _project.Contacts[selectedIndex].Number.Number;
            EmailTextBox.Text = _project.Contacts[selectedIndex].Email;
            VkIDTextBox.Text = _project.Contacts[selectedIndex].VKID;
        }

        private void AddContact(object sender, EventArgs e)
        {
            var addContact = new ContactForm();
            addContact.ShowDialog();
            if (addContact.Contact != null) //TODO: в первую очередь надо проверять DialogResult, а не просто свойство на null
            { //TODO: сообщение будет показываться каждый раз, когда пользователь закроет окно создания кнопкой Cancel - он и так знает, что нажал отмену, но почему-то ему дополнительно сообщают месседжбоксом. Лишние месседжбоксы раздражают пользователя, убрать (+)
                _project.Contacts.Add(addContact.Contact);
                AllContactsListBox.Items.Add
                    (addContact.Contact.Surname);
                SaveToFile(sender, e);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddContact(sender, e);
        }

        private void RemoveContact(object sender, EventArgs e)
        {
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
                    SaveToFile(sender, e);
                }
}
            else
            {
                //TODO: сообщение для пользователя правильно строить таким образом: Что пошло не так. Что нужно сделать. (+)
                //TODO: Говорить "ничего" не правильно, надо говорить, что именно было не выбрано - Контакт в списке. (+)
                MessageBox.Show("Выберите контакт из списка", "Warning", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            RemoveContact(sender, e);
        }

        private void EditContact(object sender, EventArgs e)
        {
            var selectedIndex = AllContactsListBox.SelectedIndex;
            if (selectedIndex != -1)
            {
                var editContact = new ContactForm();
                editContact.Contact = _project.Contacts[selectedIndex];
                editContact.ShowDialog(); //TODO: нужна проверка DialogResult
                AllContactsListBox.Items.RemoveAt(selectedIndex);
                _project.Contacts.Remove(_project.Contacts[selectedIndex]);
                _project.Contacts.Insert(selectedIndex, editContact.Contact);
                AllContactsListBox.Items.Insert(selectedIndex, editContact.Contact.Surname);
            }
            else
            {
                //TODO: см. выше (+)
                MessageBox.Show("Выберите контакт из списка", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            EditContact(sender, e);
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
            //TODO: вызывать обработчики напрямую неправильно. Надо сделать метод AddContact() и вызывать его в другом обработчике (+)
            AddContact(sender, e);
        }

        private void EditContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: см. выше (+)
            EditContact(sender, e);
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: см. выше (+)
            RemoveContact(sender, e);
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
            //TODO: путь до файла должен храниться в открытом свойстве менеджера проектов. Главная форма должна забирать значение свойства из менеджера проекта и передавать в метод менеджера проекта. (+)
            //TODO: грам.ошибка в названии папки (+)
            //TODO: название папки и файла должны быть констанстами в менеджере, а не писаться каждый раз вручную (+)
            ProjectManager.WriteToFile(_project);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //TODO: см. выше (+)
            //TODO: см. выше (+)
            //TODO: дублирование имени файла - учитывая, что есть грамматическая ошибка, лучше вынести в константу внутрь менеджера, чтобы можно было безопасно менять название файла (+)
            _project = ProjectManager.ReadFromFile();
            foreach (var n in _project.Contacts)
            {
                AllContactsListBox.Items.Add(n.Surname);
            }
        }
    }
    //TODO: почему для формы запрещено растяжение? (+)
    //TODO: крайне странное использование тейбллайаута на форме - почему-то это несколько отдельно стоящих таблиц. Обычно делается одна главная таблица на всю форму, в ячейках которой при необходимости хранятся другие таблицы (+)
    //TODO: верстка не совпадает с макетом - нет кнопок в виде пиктограмм, не стандартные расстояния между элементами (например, между первым и вторым столбцом), зачем-то измененные размеры шрифта в лейблах (+)
}
