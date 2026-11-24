using System.ComponentModel.DataAnnotations;

namespace StudentManagementAPI.Models
{
    /// <summary>
    /// Represents a Student entity in the management system.
    /// </summary>
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enrollment number is required.")]
        public string EnrollmentNo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Student name is required.")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Department is required.")]
        public string Department { get; set; } = string.Empty;

        [Range(1, 8, ErrorMessage = "Semester must be between 1 and 8.")]
        public int Semester { get; set; }
    }
}
