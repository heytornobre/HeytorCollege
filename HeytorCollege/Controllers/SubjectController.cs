using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HeytorCollege.DAL;
using HeytorCollege.Models;
using HeytorCollege.ViewModels;

namespace HeytorCollege.Controllers
{
    public class SubjectController : Controller
    {
        private CollegeContext db = new CollegeContext();

        // GET: Subject
        public ActionResult Index()
        {
            var subjects = db.Subjects.Include(s => s.Course).Include(s => s.Teacher);
            return View(subjects.ToList());
        }

        // GET: Subject/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // GET: Subject/Create
        public ActionResult Create()
        {
            PopulateDropDownLists();
            return View();
        }

        // POST: Subject/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubjectID,Title,CourseID,TeacherID")] Subject subject)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Subjects.Add(subject);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            catch (DataException)
            {
                string message = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
                if (db.Subjects.Find(subject.SubjectID) != null) message = "This ID is already taken, please try a different one!";
                ModelState.AddModelError("", message);
            }
            PopulateDropDownLists(subject.CourseID, subject.TeacherID);
            return View(subject);
        }

        // GET: Subject/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            PopulateDropDownLists(subject.CourseID, subject.TeacherID);
            return View(subject);
        }

        // POST: Subject/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var subjectToUpdate = db.Subjects.Find(id);
            if (TryUpdateModel(subjectToUpdate, "", new string[] { "Title", "CourseID", "TeacherID" }))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            PopulateDropDownLists(subjectToUpdate.CourseID, subjectToUpdate.TeacherID);
            return View(subjectToUpdate);
        }

        private void PopulateDropDownLists(object selectedCourse = null, object selectedTeacher = null)
        {
            ViewBag.CourseID = new SelectList(db.Courses.OrderBy(i => i.Title), "CourseID", "Title", selectedCourse);
            ViewBag.TeacherID = new SelectList(db.Teachers.OrderBy(i => i.Name), "ID", "Name", selectedTeacher);
        }

        // GET: Subject/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Subject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subject subject = db.Subjects.Find(id);
            db.Subjects.Remove(subject);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
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
