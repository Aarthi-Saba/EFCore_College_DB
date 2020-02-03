using System;
using System.Collections.Generic;

namespace Student_Course_Entity
{
    public class Program
    {
        static void Main()
        {
            TeacherPoco[] tp = {new TeacherPoco { TeacherId = Guid.NewGuid(), TeacherName = "Sally Jones" },
                                new TeacherPoco { TeacherId = Guid.NewGuid(), TeacherName = "Peter Paul" },
                                new TeacherPoco { TeacherId = Guid.NewGuid(), TeacherName = "Lowry Gill"},
                                new TeacherPoco { TeacherId = Guid.NewGuid(), TeacherName = "James Smith" } };

            Crud<TeacherPoco> crud = new Crud<TeacherPoco>();
            crud.Add(tp);

            StudentPoco[] sp = {
                new StudentPoco { StudentId = Guid.NewGuid(), Name = "Laksh" },
                new StudentPoco { StudentId = Guid.NewGuid(), Name = "Tom" },
                new StudentPoco { StudentId = Guid.NewGuid(), Name = "Richard" },
                new StudentPoco { StudentId = Guid.NewGuid(), Name = "Clarie" },
                new StudentPoco { StudentId = Guid.NewGuid(), Name = "Rose" }};
            Crud<StudentPoco> crudsp = new Crud<StudentPoco>();
            crudsp.Add(sp);

            CoursePoco[] cp = {new CoursePoco { CourseId = Guid.NewGuid(), CourseName = "Science",TeacherId=tp[0].TeacherId},
                               new CoursePoco { CourseId = Guid.NewGuid(), CourseName = "Maths", TeacherId=tp[1].TeacherId},
                               new CoursePoco { CourseId = Guid.NewGuid(), CourseName = "English", TeacherId=tp[0].TeacherId},
                               new CoursePoco { CourseId = Guid.NewGuid(), CourseName="French", TeacherId=tp[2].TeacherId},
                               new CoursePoco { CourseId = Guid.NewGuid(), CourseName="History", TeacherId=tp[3].TeacherId} };
            Crud<CoursePoco> crudcp = new Crud<CoursePoco>();
            crudcp.Add(cp);

            GradePoco[] gp = {
                new GradePoco { GradeId = Guid.NewGuid(), Student = sp[0].StudentId, Course = cp[0].CourseId, SubScore = 80, MaxScore = 100 },
                new GradePoco { GradeId = Guid.NewGuid(), Student = sp[0].StudentId, Course = cp[1].CourseId, SubScore = 70, MaxScore = 100 },
                new GradePoco { GradeId = Guid.NewGuid(), Student = sp[0].StudentId, Course = cp[2].CourseId, SubScore = 82, MaxScore = 100 },
                new GradePoco { GradeId = Guid.NewGuid(), Student = sp[0].StudentId, Course = cp[3].CourseId, SubScore = 76, MaxScore = 100 },
                new GradePoco { GradeId = Guid.NewGuid(), Student = sp[0].StudentId, Course = cp[4].CourseId, SubScore = 68, MaxScore = 100 },
                new GradePoco { GradeId = Guid.NewGuid(), Student = sp[1].StudentId, Course = cp[0].CourseId, SubScore = 60, MaxScore = 100 },
                new GradePoco { GradeId = Guid.NewGuid(), Student = sp[1].StudentId, Course = cp[1].CourseId, SubScore = 50, MaxScore = 100 },
                new GradePoco { GradeId = Guid.NewGuid(), Student = sp[1].StudentId, Course = cp[2].CourseId, SubScore = 66, MaxScore = 100 },
                new GradePoco { GradeId = Guid.NewGuid(), Student = sp[1].StudentId, Course = cp[3].CourseId, SubScore = 73, MaxScore = 100 },
                new GradePoco { GradeId = Guid.NewGuid(), Student = sp[1].StudentId, Course = cp[4].CourseId, SubScore = 62, MaxScore = 100 },
                new GradePoco { GradeId = Guid.NewGuid(), Student = sp[2].StudentId, Course = cp[0].CourseId, SubScore = 90, MaxScore = 100 },
                new GradePoco { GradeId = Guid.NewGuid(), Student = sp[2].StudentId, Course = cp[1].CourseId, SubScore = 80, MaxScore = 100 },
                new GradePoco { GradeId = Guid.NewGuid(), Student = sp[2].StudentId, Course = cp[2].CourseId, SubScore = 62, MaxScore = 100 },
                new GradePoco { GradeId = Guid.NewGuid(), Student = sp[2].StudentId, Course = cp[3].CourseId, SubScore = 96, MaxScore = 100 },
                new GradePoco { GradeId = Guid.NewGuid(), Student = sp[2].StudentId, Course = cp[4].CourseId, SubScore = 88, MaxScore = 100 },
                new GradePoco { GradeId = Guid.NewGuid(), Student = sp[3].StudentId, Course = cp[0].CourseId, SubScore = 50, MaxScore = 100 },
                new GradePoco { GradeId = Guid.NewGuid(), Student = sp[3].StudentId, Course = cp[1].CourseId, SubScore = 60, MaxScore = 100 },
                new GradePoco { GradeId = Guid.NewGuid(), Student = sp[3].StudentId, Course = cp[2].CourseId, SubScore = 52, MaxScore = 100 },
                new GradePoco { GradeId = Guid.NewGuid(), Student = sp[3].StudentId, Course = cp[3].CourseId, SubScore = 66, MaxScore = 100 },
                new GradePoco { GradeId = Guid.NewGuid(), Student = sp[3].StudentId, Course = cp[4].CourseId, SubScore = 68, MaxScore = 100 },
                new GradePoco { GradeId = Guid.NewGuid(), Student = sp[4].StudentId, Course = cp[0].CourseId, SubScore = 40, MaxScore = 100 },
                new GradePoco { GradeId = Guid.NewGuid(), Student = sp[4].StudentId, Course = cp[1].CourseId, SubScore = 40, MaxScore = 100 },
                new GradePoco { GradeId = Guid.NewGuid(), Student = sp[4].StudentId, Course = cp[2].CourseId, SubScore = 52, MaxScore = 100 },
                new GradePoco { GradeId = Guid.NewGuid(), Student = sp[4].StudentId, Course = cp[3].CourseId, SubScore = 66, MaxScore = 100 },
                new GradePoco { GradeId = Guid.NewGuid(), Student = sp[4].StudentId, Course = cp[4].CourseId, SubScore = 48, MaxScore = 100 }
            };
            Crud<GradePoco> crudgp = new Crud<GradePoco>();
            crudgp.Add(gp);

            IList<GradePoco> gradelist = crudgp.GetAll(g => g.Student == sp[0].StudentId);
            Console.WriteLine($"Mark scored by {sp[0].Name} are :");
            int count = 1;
            foreach (var poco in gradelist)
            {
                Console.WriteLine($" Course {count} : {poco.SubScore}");
            }

            new Crud<GradePoco>().GetAverageScore(cp[0].CourseId);

            StudentPoco studentoutput = crudsp.GetSingle(s => s.StudentId == sp[1].StudentId);
            Console.WriteLine($"Id of {studentoutput.Name} : ID-{studentoutput.StudentId}");
            TeacherPoco teacheroutput = crud.GetSingle(t => t.TeacherName == "James Smith");
            Console.WriteLine($"Teacher id for {teacheroutput.TeacherName} is {teacheroutput.TeacherId}");
        }
    }
}
