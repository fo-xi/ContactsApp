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
            var expected = File.ReadAllText(referencePath);
            if (File.Exists(ProjectManager.Path))
            {
                File.Delete(ProjectManager.Path);
            }
            File.Create(ProjectManager.Path).Close();
            File.WriteAllText(ProjectManager.Path, expected);
            var actual = JsonConvert.SerializeObject(ProjectManager.ReadFromFile());
            Assert.AreEqual(expected, actual, "Different file contents");
        }

        [Test(Description = "A negative test reading from a file")]
        public void TestReadFromFile_IncorrectData()
        {
            var expected = JsonConvert.SerializeObject(new Project());
            ProjectManager.Path = incorrectData;

            var actual = JsonConvert.SerializeObject(ProjectManager.ReadFromFile());
            Assert.AreEqual(expected, actual, "Different file contents");
        }

        [Test(Description = "A test reading to a nonexistent file path")]
        public void TestReadFromFile_NonexistentFilePath()
        {
            var testData = "..\nkbrnb\fbk.txt";
            ProjectManager.Path = testData;
            var expected = JsonConvert.SerializeObject(new Project());
            var actual = JsonConvert.SerializeObject(ProjectManager.ReadFromFile());
            Assert.AreEqual(expected, actual,
                "An exception may occur if the path does not exist");
        }
    }
}
