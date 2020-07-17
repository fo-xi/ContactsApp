using System;
using System.Collections.Generic;
using System.Text;
using ContactsApp;
using NUnit.Framework;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;


namespace UnitTesting
{
    class ProjectManagerTest
    {
        public static readonly string path =
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Data.txt";

        //TODO: почему название папки ReferencePath?
        public static readonly string referencePath =
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\ReferencePath\\Data.txt";

        public static readonly string incorrectData =
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\ReferencePath\\IncorrectData.txt";

        [Test(Description = "A test writing to a file")]
        public void TestWriteToFile_WithCreatedFile()
        {
            ProjectManager.Path = path;
            if (File.Exists(ProjectManager.Path))
            {
                File.Delete(ProjectManager.Path);
            }
            File.Create(ProjectManager.Path).Close();
            //TODO: зачем такие сложности? Надо просто сериализовать объект проекта с тестовыми данными, а затем загрузить в виде строки эталонный файл и созданный файл. Десериализации здесь точно быть не должно
            var expectedString = File.ReadAllText(referencePath);
            var expectedProject = JsonConvert.DeserializeObject<Project>(expectedString);
            ProjectManager.WriteToFile(expectedProject);
            var actualString = File.ReadAllText(ProjectManager.Path);
            Assert.AreEqual(expectedString, actualString,
                "An exception may occur if the file cannot be saved");
        }

        [Test(Description = "A positive test reading from a file")]
        public void TestReadFromFile_CorrectData()
        {
            ProjectManager.Path = path;
            if (File.Exists(ProjectManager.Path))
            {
                File.Delete(ProjectManager.Path);
            }
            File.Create(ProjectManager.Path).Close();
            var expected = File.ReadAllText(referencePath);
            File.WriteAllText(ProjectManager.Path, expected);
            //TODO: неправильно использовать сериализацию при тестировании десериализации. Надо сравнивать данные в объектах Project (+)
            var actual = File.ReadAllText(ProjectManager.Path);
            Assert.AreEqual(expected, actual, "Different file contents");
        }

        [Test(Description = "A negative test reading from a file")]
        public void TestReadFromFile_IncorrectData()
        {
            //TODO: неправильно вызывать сериализацию. Надо загружать файл и сравнивать сами объекты Project
            var expected = JsonConvert.SerializeObject(new Project());
            ProjectManager.Path = incorrectData;

            var actual = JsonConvert.SerializeObject(ProjectManager.ReadFromFile());
            Assert.AreEqual(expected, actual, "Different file contents");
        }

        [Test(Description = "A test reading to a nonexistent file path")]
        public void TestReadFromFile_NonexistentFilePath()
        {
            //TODO: несуществующий путь тоже в переменные
            var testData = "..\nkbrnb\fbk.txt"; //TODO: если слэши обозначают подпапки, то они указаны не правильно - нужны двойные слэши
            ProjectManager.Path = testData;
            //TODO: неправильно здесь использовать сериализацию
            var expected = JsonConvert.SerializeObject(new Project());
            var actual = JsonConvert.SerializeObject(ProjectManager.ReadFromFile());
            Assert.AreEqual(expected, actual,
                "An exception may occur if the path does not exist");
        }
    }
}
