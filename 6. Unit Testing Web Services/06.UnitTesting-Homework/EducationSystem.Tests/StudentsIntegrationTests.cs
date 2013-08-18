using System;
using System.Net.Http;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using System.Linq;
using System.Collections.Generic;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using System.Web.Http.Controllers;
using EducationSystem.Repositories;
using EducationSystem.Models;
using EducationSystem.WebAPI.Models;
using EducationSystem.WebAPI.Controllers;
using Places.Services.IntergrationTests;
using System.Net;
using EducationSystem.Data;

namespace EducationSystem.Tests
{
    [TestClass]
    public class StudentsIntegrationTests
    {
        [TestMethod]
        public void GetAll_ShouldReturnStatusCode200AndNotNullContent()
        {
            var repository = new DbRepository<Student>(new EducationSystemContext());

            var server = new InMemoryHttpServer<Student>("http://localhost/",
                repository);

            var response = server.CreateGetRequest("api/students");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void GetById_ShouldReturnStatusCode200AndNotNullSingleRecord()
        {
            var repository = new DbRepository<Student>(new EducationSystemContext());

            var server = new InMemoryHttpServer<Student>("http://localhost/",
                repository);

            var response = server.CreateGetRequest("api/students/1");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void PostCategory_ValidStudent_ShouldReturnStatusCode201()
        {
            var mockRepository = Mock.Create<IRepository<Student>>();

            var server =
                new InMemoryHttpServer<Student>("http://localhost/", mockRepository);

            var studentModel = new StudentModel()
            {
                Age = 12,
                FirstName = "Kiro",
                LastName = "Skalata",
                Grade = 5
            };

            var response = server.CreatePostRequest("api/students",
                studentModel);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [TestMethod]
        public void GetSpecial_ShouldReturnStatusCode200AndNotNullSingleRecord()
        {
            var mockRepository = Mock.Create<IRepository<Student>>();

            var server =
                new InMemoryHttpServer<Student>("http://localhost/", mockRepository);

            List<Mark> marks = new List<Mark>();
            marks.Add(new Mark() { Subject = "Bienestruba", Value = 5 });

            var studentToAdd = new Student()
            {
                StudentID = 1,
                Age = 12,
                FirstName = "Kiro",
                LastName = "Skalata",
                Grade = 5,
                School = new School() { Name = "Malki mutri - middle school" },
                Marks = marks
            };

            List<Student> studentEntities = new List<Student>();
            studentEntities.Add(studentToAdd);
            
            Mock.Arrange(() => mockRepository.GetAll()).Returns(studentEntities.AsQueryable());

            var response = server.CreateGetRequest("api/students?subject=\"Bienestruba\"&value=5");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }
    }
}
