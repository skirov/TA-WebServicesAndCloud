namespace EducationSystem.Data
{
    using EducationSystem.Models;
    using System;
    using System.Data.Entity;

    public class EducationSystemContext : DbContext
    {
        public EducationSystemContext()
            : base("EducationSystemDb")
        {
        }

        public DbSet<Mark> Marks { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
