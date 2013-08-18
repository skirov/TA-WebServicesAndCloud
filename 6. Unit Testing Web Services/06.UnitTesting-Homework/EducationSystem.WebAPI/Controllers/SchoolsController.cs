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
using System.Web;
using System.Web.Http;

namespace EducationSystem.WebAPI.Controllers
{
    public class SchoolsController : ApiController
    {
        private readonly IRepository<School> data;

        public SchoolsController(IRepository<School> data)
        {
            this.data = data;
        }

        public SchoolsController()
        {
            this.data = new DbRepository<School>(new EducationSystemContext());
        }

        public IQueryable<SchoolModel> Get()
        {
            var posts = this.data.GetAll().Select(SchoolModel.ToStudentModel);
            return posts;
        }

        public SchoolModel Get(int id)
        {
            var posts = SchoolModel.FromSchoolToSchoolModel(this.data.GetById(id));
            return posts;
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]SchoolModel schoolModel)
        {
            var school = schoolModel.CreateSchool();
            this.data.Add(school);

            var message = this.Request.CreateResponse(HttpStatusCode.Created);
            message.Headers.Location = new Uri(this.Request.RequestUri + school.SchoolId.ToString(CultureInfo.InvariantCulture));
            return message;
        }
    }
}