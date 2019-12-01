using HeytorCollege.DAL;
using HeytorCollege.Models;
using HeytorCollege.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace HeytorCollege.Controllers
{
    public class HomeController : Controller
    {
        private CollegeContext db = new CollegeContext();

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult About()
        {
            IQueryable<BirthdayDateGroup> data = from student in db.Students
                                                   group student by student.Birthday into dateGroup
                                                   select new BirthdayDateGroup()
                                                   {
                                                       Birthday = dateGroup.Key,
                                                       StudentCount = dateGroup.Count()
                                                   };
            return View(data.ToList());
        }
        
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}