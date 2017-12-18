using System.ComponentModel.DataAnnotations;

namespace HostelManagement_SD_Apps.Models.CoreModel
{
    public class Student
    {
        public int Id { get; set; }
        [Display(Name = "Student ID")]
        [Required]
        public string StudentID { get; set; }
        [Display(Name = "Student Name")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Department ID")]
        [Required]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        [Display(Name = "Semester ID")]
        [Required]
        public int SemesterId { get; set; }
        public virtual Semester Semester { get; set; }
        [Display(Name = "Contact No")]
        [Required]
        public string ContactNo { get; set; }
        public string Email { get; set; }
        [Display(Name = "Blood Group")]
        [Required]
        public int BloodGroupId { get; set; }
        public virtual BloodGroup BloodGroup { get; set; }
        [Required]
        public string District { get; set; }
        [Required]
        public string Thana { get; set; }
    }
}