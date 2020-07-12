using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace ContactsApp
{
    /// <summary>
    /// Class that stores a method for saving the Project object in 
    /// file and method for loading the project from a file.
    /// </summary>
    public static class ProjectManager
    {
        /// <summary>
        /// Saves the object <see cref="Project"/> to a file.
        /// </summary>
        /// <param name="contact">All contact information.</param> //TODO: имя параметра в комментарии и имя локальной переменной - исправить
        static public void WriteToFile(Project contacts, string path) //TODO: по RSDN правильнее писать public static, а не static public
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, contacts);
            }
        }
        /// <summary>
        /// Reads information about the object <see cref="Project"/>
        /// from a file.
        /// </summary>
        static public Project ReadFromFile(string path) //TODO: см. выше
        {
            //TODO: неправильное название переменной - это не контакты (коллекция), а это проект
            Project contacts = null;
            if (File.Exists(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                using (StreamReader sr = new StreamReader(path))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    try
                    {
                        contacts = ((Project)serializer.Deserialize<Project>(reader));
                    }
                    catch
                    {
                        contacts = new Project();
                        return contacts;
                    }
                }
                return contacts;
            }
            else
            {
                //TODO: почему исключение? При первой установке программы файла с контактами не будет - а из-за исключения этот файл никогда и не создастся. То есть у нового пользователя программа ВСЕГДА будет падать при запуске
                throw new ArgumentException(path + " фаил поврежден");
            }
        }
    }
}
