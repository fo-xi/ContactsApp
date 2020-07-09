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
        //TODO: при работе с файлами желательно в названия методов добавлять ToFile|ToFile - так код читаемее (+)
        /// <summary>
        /// Saves the object <see cref="Project"/> to a file.
        /// </summary>
        /// <param name="contact">All contact information.</param>
        static public void WriteToFile(Project contacts, string folder, string file)
        {
            //TODO: надо сохранять в файл не один контакт, а весь проект целиком (+)
            //TODO: при сохранении файла обычно проверки на существование не делают, а просто записывают по пути.
            //После удаления проверок появляется следующее сообщение:
            //"Не удалось найти часть пути "C:\Users\sash\AppData\Roaming\ConatctsApp\ContactsApp.txt"."
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            if (!File.Exists(folder + file))
            {
                //TODO: по-моему, метод Serialize самостоятельно создает или перезаписывает файлы, поэтому в этом методе эта проверка не нужна.
                File.Create(file);
            }
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(folder + file))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, contacts);
            }
        }
        /// <summary>
        /// Reads information about the object <see cref="Project"/>
        /// from a file.
        /// </summary>
        static public Project ReadFromFile(string folder, string file)
        {
            //TODO: надо загружать весь проект целиком (+)
            //TODO: нужно добавить проверки на существование файла и обработку исключения, если файл не может быть загружен - если что-то не так, то метод должен возвращать новый экземпляр пустого проекта (+)
            Project contacts = null;
            if (File.Exists(folder + file))
            {
                JsonSerializer serializer = new JsonSerializer();
                using (StreamReader sr = new StreamReader(folder + file))
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
                throw new ArgumentException(folder + file + " фаил поврежден");
            }
        }
    }
}
