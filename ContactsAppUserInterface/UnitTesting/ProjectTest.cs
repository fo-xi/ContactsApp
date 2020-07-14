using System;
using System.Collections.Generic;
using System.Text;
using ContactsApp;
using NUnit.Framework;

namespace UnitTesting
{
    class ProjectTest
    {
        [Test(Description = "Positive test of the getter Contacts")]
        public void TestContactsGet_CorrectValue()
        {
            var project = new Project();
            var expected = new List<Contact>()
            {
                new Contact ("Ilya", "Bogdanov", new PhoneNumber("71234567891"),
                new DateTime(2013, 6, 7), "tryfe@gmail.com", "795566"),
                new Contact ("Elena", "Romanova", new PhoneNumber("71233557791"),
                new DateTime(2011, 3, 8), "gbf@yandex.com", "807463"),
            };
            project.Contacts = expected;
            var actual = project.Contacts;
            Assert.AreEqual(expected, actual, "The Contacts getter " +
                "returns an incorrect list");
        }

        [Test(Description = "Positive test of the setter Contacts")]
        public void TestContactsSet_CorrectValue()
        {
            var project = new Project();
            var expected = new List<Contact>()
            {
                new Contact ("Ilya", "Bogdanov", new PhoneNumber("71234567891"),
                new DateTime(2013, 6, 7), "tryfe@gmail.com", "795566"),
                new Contact ("Elena", "Romanova", new PhoneNumber("71233557791"),
                new DateTime(2011, 3, 8), "gbf@yandex.com", "807463"),
            };
            Assert.DoesNotThrow(() =>
            {
                project.Contacts = expected;
            }, "The PhoneNumber setter accepts the correct phone number");
        }
    }
}
