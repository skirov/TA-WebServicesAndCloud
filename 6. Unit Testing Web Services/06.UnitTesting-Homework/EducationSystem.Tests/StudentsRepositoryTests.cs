using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EducationSystem.Repositories;
using EducationSystem.Models;
using EducationSystem.Data;
using System.Data.Entity;
using System.Collections;
using System.Transactions;
using System.Collections.Generic;
using System.Linq;

namespace EducationSystem.Tests
{
    [TestClass]
    public class StudentsRepositoryTests
    {
        public DbContext dbContext { get; set; }

        static Random rand = new Random();

        public IRepository<Student> categoriesRepository { get; set; }

        private static TransactionScope tranScope;

        public StudentsRepositoryTests()
        {
            this.dbContext = new EducationSystemContext();
            this.categoriesRepository = new DbRepository<Student>(this.dbContext);
        }

        [TestInitialize]
        public void TestInit()
        {
            tranScope = new TransactionScope();
        }

        [TestCleanup]
        public void TestTearDown()
        {
            tranScope.Dispose();
        }

        [TestMethod]
        public void GetAll_ShouldReturnCountBiggerThan0()
        {
            IList<Student> collection = categoriesRepository.GetAll().ToList();

            Assert.IsTrue(collection.Count > 0);
        }

        [TestMethod]
        public void GetById_ShouldReturnOneRecord()
        {
            Student singleStudnet = categoriesRepository.GetById(1);

            Assert.IsTrue(singleStudnet != null);
        }

        [TestMethod]
        public void Add_ShouldAddOneRecord_TestWithCount()
        {
            int collectionBeforeAdition = categoriesRepository.GetAll().ToList().Count;

            Student newStudent = new Student()
            {
                Age = 12,
                FirstName = "Kiro",
                LastName = "Skalata",
                Grade = 5,
                School = new School() { Name = "Malki mutri - middle school" }
            };

            categoriesRepository.Add(newStudent);

            int collectionAfterAdition = dbContext.Set<Student>().Count();

            //true because if we add one record the collection before addition will be
            //smaller with one record
            Assert.IsTrue(collectionBeforeAdition == collectionAfterAdition - 1);
        }

        [TestMethod]
        public void Add_ShouldAddOneRecord_TestWithValues()
        {
            int collectionBeforeAdition = categoriesRepository.GetAll().ToList().Count;

            Student newStudent = new Student()
            {
                Age = 12,
                FirstName = "Kiro",
                LastName = "Skalata",
                Grade = 5,
                School = new School() { Name = "Malki mutri - middle school" }
            };

            categoriesRepository.Add(newStudent);

            Student theCurrentlyAddedStudent = dbContext.Set<Student>().Find(newStudent.StudentID);

            Assert.IsNotNull(theCurrentlyAddedStudent);
            Assert.AreEqual(theCurrentlyAddedStudent.FirstName, "Kiro");
        }
    }
}
