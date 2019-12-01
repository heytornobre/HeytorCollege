using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HeytorCollege.DAL;
using HeytorCollege.Models;
using HeytorCollege.ViewModels;

namespace HeytorCollege.Controllers
{
    public class CourseController : Controller
    {
        private CollegeContext db = new CollegeContext();

        // GET: Course
        public ActionResult Index()
        {
            var courses = db.Courses;
            return View(courses.ToList());
        }

        // GET: Course/Details/5
        public ActionResult Details(int? id)
        {
            var subjects = db.Subjects.Include(i => i.Enrollments).Include(i => i.Teacher);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            CourseDetailData viewModel = new CourseDetailData() { Course = course };

            var relatedSubjects = db.Subjects.Where(s => s.CourseID == id);
            var relatedTeachers = relatedSubjects.Select(s => s.Teacher).Distinct();
            var relatedEnrollmentsGroups = relatedSubjects.Select(s => s.Enrollments).Distinct();
            var relatedEnrollments = relatedSubjects.SelectMany(s => s.Enrollments).Distinct();
            var enrollmentIDs = relatedEnrollmentsGroups.SelectMany(s => s.Select(e => e.EnrollmentID)).Distinct();
            var relatedStudents = relatedEnrollments.Select(e => e.Student).Distinct();

            viewModel.TeachersCount = relatedTeachers.Count();
            viewModel.StudentsCount = relatedStudents.Count();
            viewModel.AverageGrade = relatedEnrollments.Select(e => e.Grade).Average();

            return View(viewModel);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseID,Title")] Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Courses.Add(course);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException ex)
            {
                string message = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
                if (db.Courses.Find(course.CourseID) != null) message = "This ID is already taken, please try a different one!";
                ModelState.AddModelError("", message);
            }
            return View(course);
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Course/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseID,Title")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public ActionResult About()
        //{
        //    var courses = db.Courses;
        //    var subjects = db.Subjects;
        //    var students = db.Students;
        //    var enrollments = db.Enrollments;

        //    IQueryable<Subject> relatedSubjects;
        //    IQueryable<Enrollment> relatedEnrollments;
        //    IQueryable<Student> relatedStudents;
        //    foreach (var course in courses)
        //    {
        //        relatedSubjects = subjects.Where(s => s.CourseID == course.CourseID);
        //        //relatedEnrollments = relatedSubjects.Select(s => s.Enrollments);
        //    }

        //    IQueryable<CourseIndexData> data = 
        //        from course in courses
        //        select new CourseIndexData()
        //        {
        //            Course = course
        //        };
        //    return View(data.ToList());
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
