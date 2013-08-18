using EducationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace EducationSystem.WebAPI.Models
{
    public class StudentModel : StudentDetails
    {
        private ICollection<Mark> marks;
        private SchoolModel school;

        public StudentModel()
        {
            this.marks = new HashSet<Mark>();
            this.school = new SchoolModel();
        }

        public SchoolModel School { get; set; }

        public ICollection<Mark> Marks
        {
            get
            {
                return this.marks;
            }

            set
            {
                this.marks = value;
            }
        }

        public Student CreateStudent()
        {
            return new Student
            {
                StudentID = this.StudentID,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Age = this.Age,
                Grade = this.Grade,
                Marks = this.Marks
            };
        }

        public static Expression<Func<Student, StudentModel>> ToStudentModel
        {
            get
            {
                return x => new StudentModel
                {
                    StudentID = x.StudentID,
                    School = new SchoolModel() { Location = x.School.Location, Name = x.School.Name },
                    Marks = x.Marks,
                    LastName = x.LastName,
                    Grade = x.Grade,
                    FirstName = x.FirstName,
                    Age = x.Age
                };
            }
        }

        public static StudentModel FromStudentToStudentModel(Student x)
        {
            return new StudentModel
            {
                StudentID = x.StudentID,
                School = new SchoolModel() { Location = x.School.Location, Name = x.School.Name },
                Marks = x.Marks,
                LastName = x.LastName,
                Grade = x.Grade,
                FirstName = x.FirstName,
                Age = x.Age
            };
        }
    }
}