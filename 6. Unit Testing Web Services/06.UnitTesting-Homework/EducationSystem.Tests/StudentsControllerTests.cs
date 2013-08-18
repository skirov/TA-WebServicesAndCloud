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

namespace EducationSystem.Tests
{
    [TestClass]
    public class StudentsControllerTests
    {
        private void SetupController(ApiController controller)
        {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/students");
            var route = config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            var routeData = new HttpRouteData(route);
            routeData.Values.Add("id", RouteParameter.Optional);
            routeData.Values.Add("controller", "categories");
            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            controller.Request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;
        }

        [TestMethod]
        public void Post_ShouldAddTheStudent()
        {
            var studentModel = new StudentModel()
            {
                Age = 12,
                FirstName = "Kiro",
                LastName = "Skalata",
                Grade = 5
            };

            Student newStudent = new Student()
            {
                Age = 12,
                FirstName = "Kiro",
                LastName = "Skalata",
                Grade = 5,
                School = new School() { Name = "Malki mutri - middle school" }
            };

            bool isItemAdded = false;
            var repository = Mock.Create<IRepository<Student>>();

            Mock.Arrange(() => repository.Add(Arg.IsAny<Student>()))
                .DoInstead(() => isItemAdded = true);

            var controller = new StudentsController(repository);
            SetupController(controller);

            controller.Post(studentModel);

            Assert.IsTrue(isItemAdded);
        }

        [TestMethod]
        public void GetAllStudents_ShouldReturnAllStudents()
        {
            var repository = Mock.Create<IRepository<Student>>();

            var studentToAdd = new Student()
            {
                Age = 12,
                FirstName = "Kiro",
                LastName = "Skalata",
                Grade = 5,
                School = new School() { Name = "Malki mutri - middle school" }
            };
            List<Student> studentEntities = new List<Student>();

            studentEntities.Add(studentToAdd);

            Mock.Arrange(() => repository.GetAll()).Returns(studentEntities.AsQueryable());

            var controller = new StudentsController(repository);
            SetupController(controller);

            var studentModels = controller.Get();

            Assert.IsTrue(studentModels.Count() == 1);
            Assert.AreEqual(studentToAdd.FirstName, studentModels.FirstOrDefault().FirstName);
        }

        [TestMethod]
        public void GetById_ShouldReturnSingleStudent()
        {
            var repository = Mock.Create<IRepository<Student>>();

            var studentEntity = new Student()
            {
                StudentID = 1,
                Age = 12,
                FirstName = "Kiro",
                LastName = "Skalata",
                Grade = 5,
                School = new School() { Name = "Malki mutri - middle school" }
            };

            Mock.Arrange(() => repository.GetById(1)).Returns(studentEntity);

            var controller = new StudentsController(repository);
            SetupController(controller);

            var studentModels = controller.Get(1);

            Assert.IsTrue(studentModels.StudentID == 1);
            Assert.AreEqual(studentEntity.FirstName, studentModels.FirstName);
        }

        [TestMethod]
        public void GetSpecial_ShouldReturnSingleStudent()
        {
            var repository = Mock.Create<IRepository<Student>>();

             List<Mark> marks = new List<Mark>();
             marks.Add(new Mark() { Subject = "Biene s truba", Value = 5 });

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

            Mock.Arrange(() => repository.GetAll()).Returns(studentEntities.AsQueryable());

            var controller = new StudentsController(repository);
            SetupController(controller);

            //by design the special get method searches for values > than the specified value(in out case - 4)
            var studentModels = controller.Get("Biene s truba", 4);

            Assert.IsTrue(studentModels.FirstOrDefault().StudentID == 1);
            Assert.AreEqual(studentToAdd.FirstName, studentModels.FirstOrDefault().FirstName);
        }
    }
}
