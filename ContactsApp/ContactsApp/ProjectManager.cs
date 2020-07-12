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
        private static string _path = Environment.GetFolderPath
        (Environment.SpecialFolder.ApplicationData) + "\\ContactsApp\\Contacts.txt";

        /// <summary>
        /// Saves the object <see cref="Project"/> to a file.
        /// </summary>
        /// <param name="project">All contact information.</param> //TODO: имя параметра в комментарии и имя локальной переменной - исправить (+)
        public static void WriteToFile(Project project) //TODO: по RSDN правильнее писать public static, а не static public (+)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(_path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, project);
            }
        }

        /// <summary>
        /// Reads information about the object <see cref="Project"/>
        /// from a file.
        /// </summary>
        /// <param name="path">File path.</param>
        public static Project ReadFromFile() //TODO: см. выше
        {
            //TODO: неправильное название переменной - это не контакты (коллекция), а это проект (+)
            Project project = null;
            if (File.Exists(_path))
            {
                JsonSerializer serializer = new JsonSerializer();
                using (StreamReader sr = new StreamReader(_path))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    try
                    {
                        project = ((Project)serializer.Deserialize<Project>(reader));
                    }
                    catch
                    {
                        project = new Project();
                        return project;
                    }
                }
            }
            else
            {
                //TODO: почему исключение? При первой установке программы файла с контактами не будет - а из-за исключения этот файл никогда и не создастся. То есть у нового пользователя программа ВСЕГДА будет падать при запуске (+)
                Console.WriteLine(_path + " not exist");
            }
            return project;
        }
    }
}
