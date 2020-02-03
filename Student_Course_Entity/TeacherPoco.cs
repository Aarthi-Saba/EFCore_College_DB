using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Course_Entity
{
    [Table("Teachers Details")]
    public class TeacherPoco
    {
        [Key]
        [Column("Teacher Id")]
        public Guid TeacherId { get; set; }
        [Column("Teacher Name")]
        public string TeacherName { get; set; }
        public Guid Course { get; set; }
        public virtual ICollection<CoursePoco> TeacherToCourse { get; set; }
    }
}