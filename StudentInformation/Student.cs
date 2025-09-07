using System;
using StudentManagementSystem.StudentInformation;

namespace StudentManagementSystem.StudentInformation
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }
        public int YearLevel { get; set; }
        public float GPA { get; set; }

        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; }
    }
}
