using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Course_Entity
{
    [Table("Course Details")]
    public class CoursePoco
    {
        [Key]
        public Guid CourseId { get; set; }

        [Column("Course Name")]
        public string CourseName { get; set; }
        public Guid TeacherId { get; set; }

        public virtual ICollection<StudentPoco> CourseToStudent { get; set; }
        public virtual TeacherPoco CourseToTeacher { get; set; }
        public virtual ICollection<GradePoco> CourseToGrade { get; set; }

    }
}