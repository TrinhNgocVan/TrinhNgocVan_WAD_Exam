using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using t2004_1.Context;
using t2004_1.Models;

namespace t2004_1.Controllers
{
    public class ExamController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Exam
        public ActionResult Index()
        {
            var exams = db.exams.Include(e => e.ClassRoom).Include(e => e.ExamSubject).Include(e => e.Faculty);
            return View(exams.ToList());
        }

        // GET: Exam/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // GET: Exam/Create
        public ActionResult Create()
        {
            ViewBag.ClassroomId = new SelectList(db.classRooms, "Id", "ClassroomName");
            ViewBag.ExamSubjectId = new SelectList(db.examsubjects, "Id", "ExamSubjectName");
            ViewBag.FacultyId = new SelectList(db.facultys, "Id", "facultyName");
            return View();
        }

        // POST: Exam/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ExamSubjectId,FacultyId,ClassroomId,StartTime,ExamDate,Status,Duration")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.exams.Add(exam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassroomId = new SelectList(db.classRooms, "Id", "ClassroomName", exam.ClassroomId);
            ViewBag.ExamSubjectId = new SelectList(db.examsubjects, "Id", "ExamSubjectName", exam.ExamSubjectId);
            ViewBag.FacultyId = new SelectList(db.facultys, "Id", "facultyName", exam.FacultyId);
            return View(exam);
        }

        // GET: Exam/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassroomId = new SelectList(db.classRooms, "Id", "ClassroomName", exam.ClassroomId);
            ViewBag.ExamSubjectId = new SelectList(db.examsubjects, "Id", "ExamSubjectName", exam.ExamSubjectId);
            ViewBag.FacultyId = new SelectList(db.facultys, "Id", "facultyName", exam.FacultyId);
            return View(exam);
        }
        public ActionResult StartExam(int? id)
        {
            Exam exam = db.exams.Find(id);
            db.exams.Remove(exam);
            db.SaveChanges();
            exam.Status = 1;
            db.exams.Add(exam);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EndExam(int? id)
        {
            Exam exam = db.exams.Find(id);
            db.exams.Remove(exam);
            db.SaveChanges();
            exam.Status = 2;
            db.exams.Add(exam);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Exam/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ExamSubjectId,FacultyId,ClassroomId,StartTime,ExamDate,Status,Duration")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassroomId = new SelectList(db.classRooms, "Id", "ClassroomName", exam.ClassroomId);
            ViewBag.ExamSubjectId = new SelectList(db.examsubjects, "Id", "ExamSubjectName", exam.ExamSubjectId);
            ViewBag.FacultyId = new SelectList(db.facultys, "Id", "facultyName", exam.FacultyId);
            return View(exam);
        }

        // GET: Exam/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // POST: Exam/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exam exam = db.exams.Find(id);
            db.exams.Remove(exam);
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
