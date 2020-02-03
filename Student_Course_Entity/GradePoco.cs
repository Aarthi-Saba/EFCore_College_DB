using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Student_Course_Entity
{
    [Table("Student Grades")]
    public class GradePoco
    {
        [Key]
        public Guid GradeId { get; set; }
        public Guid Student { get; set; }
        public Guid Course { get; set; }
        [Column("Individual Score")]
        public decimal SubScore { get; set; }
        public decimal MaxScore { get; set; }
       

        public virtual StudentPoco GradeToStudent { get; set; }
        public virtual CoursePoco GradeToCourse { get; set; }
    }
}
