using HeytorCollege.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeytorCollege.DAL
{
    public class CollegeInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CollegeContext>
    {
        protected override void Seed(CollegeContext context)
        {
            var students = new List<Student>
            {
            new Student{Name="Carson Alexander",Birthday=DateTime.Parse("2005-09-01")},
            new Student{Name="Meredith Alonso",Birthday=DateTime.Parse("2002-09-01")},
            new Student{Name="Arturo Anand",Birthday=DateTime.Parse("2003-09-01")},
            new Student{Name="Gytis Barzdukas",Birthday=DateTime.Parse("2002-09-01")},
            new Student{Name="Yan Li",Birthday=DateTime.Parse("2002-09-01")},
            new Student{Name="Peggy Justice",Birthday=DateTime.Parse("2001-09-01")},
            new Student{Name="Laura Norman",Birthday=DateTime.Parse("2003-09-01")},
            new Student{Name="Nino Olivetto",Birthday=DateTime.Parse("2005-09-01")}
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var teachers = new List<Teacher>
            {
            new Teacher{Name="Carla Chemistry",Birthday=DateTime.Parse("1965-09-01"),Salary=2000},
            new Teacher{Name="Marcel Microeconomics",Birthday=DateTime.Parse("1965-09-01"),Salary=2000},
            new Teacher{Name="Michael Macroeconomics",Birthday=DateTime.Parse("1965-09-01"),Salary=2000},
            new Teacher{Name="Christian Calculus",Birthday=DateTime.Parse("1965-09-01"),Salary=2000},
            new Teacher{Name="Thomas Trigonometry",Birthday=DateTime.Parse("1965-09-01"),Salary=2000},
            new Teacher{Name="Cisco Composition",Birthday=DateTime.Parse("1965-09-01"),Salary=2000},
            new Teacher{Name="Laura Literature",Birthday=DateTime.Parse("1965-09-01"),Salary=2000}
            };
            teachers.ForEach(s => context.Teachers.Add(s));
            context.SaveChanges();

            var Courses = new List<Course>
            {
            new Course{CourseID=1,Title="Chemistry",},
            new Course{CourseID=4,Title="Economy",},
            new Course{CourseID=3,Title="Mathematic",},
            new Course{CourseID=2,Title="Art",},
            };
            Courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();

            var subjects = new List<Subject>
            {
            new Subject{SubjectID=1050,Title="Chemistry",CourseID=1,
                TeacherID = teachers.Single(i=>i.Name.Contains("Chemistry")).ID},
            new Subject{SubjectID=4022,Title="Microeconomics",CourseID=4,
                TeacherID = teachers.Single(i=>i.Name.Contains("Microeconomics")).ID},
            new Subject{SubjectID=4041,Title="Macroeconomics",CourseID=4,
                TeacherID = teachers.Single(i=>i.Name.Contains("Macroeconomics")).ID},
            new Subject{SubjectID=1045,Title="Calculus",CourseID=3,
                TeacherID = teachers.Single(i=>i.Name.Contains("Calculus")).ID},
            new Subject{SubjectID=3141,Title="Trigonometry",CourseID=3,
                TeacherID = teachers.Single(i=>i.Name.Contains("Trigonometry")).ID},
            new Subject{SubjectID=2021,Title="Composition",CourseID=2,
                TeacherID = teachers.Single(i=>i.Name.Contains("Composition")).ID},
            new Subject{SubjectID=2042,Title="Literature",CourseID=2,
                TeacherID = teachers.Single(i=>i.Name.Contains("Literature")).ID}
            };
            subjects.ForEach(s => context.Subjects.Add(s));
            context.SaveChanges();


            var enrollments = new List<Enrollment>
            {
            new Enrollment{StudentID=1,SubjectID=1050,Grade=10},
            new Enrollment{StudentID=1,SubjectID=4022,Grade=7},
            new Enrollment{StudentID=1,SubjectID=4041,Grade=8.5},
            new Enrollment{StudentID=2,SubjectID=1045,Grade=8.5},
            new Enrollment{StudentID=2,SubjectID=3141,Grade=4},
            new Enrollment{StudentID=2,SubjectID=2021,Grade=4},
            new Enrollment{StudentID=3,SubjectID=1050},
            new Enrollment{StudentID=4,SubjectID=1050,},
            new Enrollment{StudentID=4,SubjectID=4022,Grade=4},
            new Enrollment{StudentID=5,SubjectID=4041,Grade=7},
            new Enrollment{StudentID=6,SubjectID=1045},
            new Enrollment{StudentID=7,SubjectID=3141,Grade=10},
            };
            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();
        }
    }
}