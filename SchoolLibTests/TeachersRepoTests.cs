using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLib.Tests
{
    [TestClass()]
    public class TeachersRepoTests
    {
        [TestMethod()]
        public void GetTest() // 

        {
            //Arrange
            var c = new TeachersRepo();
            //Act
            var teachers = c.Get();
            //Assert
            Assert.AreEqual(3, teachers.Count);
            Assert.AreEqual("John Doe", teachers[0].Name);
            Assert.AreEqual("Jane Doe", teachers[1].Name);
            Assert.AreEqual("Jack Doe", teachers[2].Name);

        }


        [TestMethod()]
        public void AddTest() // add new teacher test 
        {
            //Arrange
            var c = new TeachersRepo();
            //Act
            var teacher = new Teacher(0, "John Doe", "Math", "Math teacher");
            c.Add(teacher);
            //Assert
            Assert.AreEqual(4, c.Get().Count);
            Assert.AreEqual(4, c.Get()[3].Id);
            Assert.AreEqual("John Doe", c.Get()[3].Name);
            Assert.AreEqual("Math", c.Get()[3].Subject);
            Assert.AreEqual("Math teacher", c.Get()[3].Description);
           //Assert.AreEqual("Name: John Doe, Subject: Math, Description: Math teacher, Id: 1", c.Get()[3].ToString());
        }


        [TestMethod]
        public void RemoveTest() // remove a teacher from the list
        {
            //Arrange
            var c = new TeachersRepo();
            //Act
            c.Remove(2);
            //Assert
            Assert.AreEqual(2, c.Get().Count);
            Assert.AreEqual(1, c.Get()[0].Id);
            Assert.AreEqual(3, c.Get()[1].Id);
            Assert.ThrowsException<ArgumentException>(() => c.Remove(4));

        }

        [TestMethod]
        public void ToStringTeacherClassTest() // tests tostring of teacher class 
        {
        }


        [TestMethod]
        public void UpdateTest() // update a teacher in the list
        {
            var c = new TeachersRepo();
            c.Update(2, new Teacher(2, "Janee Doe", "English", "English teacher"));
            Assert.AreEqual(3, c.Get().Count);
            Assert.AreEqual(2, c.Get()[1].Id);
            Assert.AreEqual("Janee Doe", c.Get()[1].Name);
            Assert.AreEqual("English", c.Get()[1].Subject);
            Assert.AreEqual("English teacher", c.Get()[1].Description);
           // Assert.ThrowsException<ArgumentException>(() => c.Update(422, teacher));

        }

        [TestMethod]
        public void GetByIdTest() // get a teacher by id
        {
            //arrange
            TeachersRepo c = new TeachersRepo();
            //act
            Teacher? teacher = c.GetById(2);
            //assert
            Assert.AreEqual(3, c.Get().Count);
            Assert.AreEqual(2, c.Get()[1].Id);
            Assert.AreEqual("Jane Doe", c.Get()[1].Name);
            Assert.AreEqual("English", c.Get()[1].Subject);
            Assert.AreEqual("English teacher", c.Get()[1].Description);
           //Assert.ThrowsException<ArgumentException>(() => c.GetById(4,teacher));
        }

  
    }   

}   