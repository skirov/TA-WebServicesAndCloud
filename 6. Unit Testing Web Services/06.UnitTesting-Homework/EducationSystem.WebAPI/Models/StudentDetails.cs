namespace EducationSystem.WebAPI.Models
{
    using EducationSystem.Models;
    using System;

    public class StudentDetails
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte Age { get; set; }
        public byte Grade { get; set; }
    }
}