namespace EducationSystem.Models
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        private ICollection<Mark> marks;

        public Student()
        {
            this.marks = new HashSet<Mark>();
        }

        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte Age { get; set; }
        public byte Grade { get; set; }
        public virtual School School { get; set; }

        public virtual ICollection<Mark> Marks 
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
    }
}
