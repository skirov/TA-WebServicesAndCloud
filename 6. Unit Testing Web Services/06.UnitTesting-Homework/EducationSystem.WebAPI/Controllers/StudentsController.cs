using EducationSystem.Data;
using EducationSystem.Models;
using EducationSystem.Repositories;
using EducationSystem.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EducationSystem.WebAPI.Controllers
{
    public class StudentsController : ApiController
    {
        private readonly IRepository<Student> data;

        public StudentsController(IRepository<Student> data)
        {
            this.data = data;
        }

        public StudentsController()
        {
            this.data = new DbRepository<Student>(new EducationSystemContext());
        }

        public IQueryable<StudentModel> Get()
        {
            var posts = this.data.GetAll().Select(StudentModel.ToStudentModel);
            return posts;
        }

        public StudentModel Get(int id)
        {
            var posts = StudentModel.FromStudentToStudentModel(this.data.GetById(id));
            return posts;
        }

        public IQueryable<StudentModel> Get(string subject, double value)
        {
            var posts = this.data.GetAll().Where(s => s.Marks.Any(m => m.Value > value && m.Subject == subject))
                                 .Select(StudentModel.ToStudentModel);
            return posts;
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]StudentModel studentModel)
        {
            var student = studentModel.CreateStudent();
            this.data.Add(student);

            var message = this.Request.CreateResponse(HttpStatusCode.Created);
            message.Headers.Location = new Uri(this.Request.RequestUri + student.StudentID.ToString(CultureInfo.InvariantCulture));
            return message;
        }
    }
}