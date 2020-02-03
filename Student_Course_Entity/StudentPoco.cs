using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Student_Course_Entity
{
    [Table("Student Details") ]
    public class StudentPoco
    {
        [Key]
        public Guid StudentId { get; set; }

        [Column("Student Name")]
        public string Name { get; set; }
        public virtual CoursePoco StudentToCourse { get; set; }
        public virtual ICollection<GradePoco> StudentToGrade { get; set; }

    }
}
