using HostelManagement_SD_Apps.Models;
using HostelManagement_SD_Apps.Models.CoreModel;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HostelManagement_SD_Apps.Controllers
{
    public class StudentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Students
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.BloodGroup).Include(s => s.Department).Include(s => s.Semester);
            return View(students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.BloodGroupId = new SelectList(db.BloodGroups, "Id", "Name");
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name");
            ViewBag.SemesterId = new SelectList(db.Semesters, "Id", "Name");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StudentID,Name,DepartmentId,SemesterId,ContactNo,Email,BloodGroupId,District,Thana")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BloodGroupId = new SelectList(db.BloodGroups, "Id", "Name", student.BloodGroupId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", student.DepartmentId);
            ViewBag.SemesterId = new SelectList(db.Semesters, "Id", "Name", student.SemesterId);
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.BloodGroupId = new SelectList(db.BloodGroups, "Id", "Name", student.BloodGroupId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", student.DepartmentId);
            ViewBag.SemesterId = new SelectList(db.Semesters, "Id", "Name", student.SemesterId);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentID,Name,DepartmentId,SemesterId,ContactNo,Email,BloodGroupId,District,Thana")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BloodGroupId = new SelectList(db.BloodGroups, "Id", "Name", student.BloodGroupId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", student.DepartmentId);
            ViewBag.SemesterId = new SelectList(db.Semesters, "Id", "Name", student.SemesterId);
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
