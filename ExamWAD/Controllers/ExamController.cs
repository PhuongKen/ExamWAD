using ExamWAD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamWAD.Controllers
{
    public class ExamController : Controller
    {
        ExamWADEntities db = new ExamWADEntities();
        // GET: Exam
        public ActionResult Index()
        {
            return View(db.Exams.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Exam exam)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    exam.Status = 1;
                    db.Exams.Add(exam);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(exam);
            }
            catch
            {
                return View();
            }
        }
    }
}