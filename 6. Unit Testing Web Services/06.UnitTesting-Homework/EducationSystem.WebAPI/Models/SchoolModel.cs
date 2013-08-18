using EducationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace EducationSystem.WebAPI.Models
{
    public class SchoolModel : SchoolDetails
    {
        private ICollection<Student> students;

        public SchoolModel()
        {
            this.students = new HashSet<Student>();
        }

        public static SchoolModel FromSchoolToSchoolModel(School x)
        {
            return new SchoolModel
            {
                Location = x.Location,
                Name = x.Location,
                students = x.Students
            };
        }

        public static Expression<Func<School, SchoolModel>> ToStudentModel
        {
            get
            {
                return x => new SchoolModel
                {
                    Location = x.Location,
                    Name = x.Location,
                    students = x.Students
                };
            }
        }

        public School CreateSchool()
        {
            return new School
            {
                Location = this.Location,
                Name = this.Location,
                Students = this.students
            };
        }
    }
}