using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SaeedClinick.Data;

namespace SaeedClinick.Controllers
{
    public class PatientController : Controller
    {
        private clinickEntities db = new clinickEntities();

        // GET: Patient
        //public ActionResult Index()
        //{
        //    return View(db.PatientDatas.ToList());
        //}
        public ActionResult Index(string searchstring, string designation)
        {
            List<PatientData> PatientList = new List<PatientData>();
            if(searchstring ==null || searchstring == "")
            {
                PatientList = db.PatientDatas.ToList();
            }
            else
            {
                PatientList = db.PatientDatas.Where(x => x.Name.Contains(searchstring) == true).ToList();
            }
            
            return View(PatientList);
        }

        // GET: Patient/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientData patientData = db.PatientDatas.Find(id);
            if (patientData == null)
            {
                return HttpNotFound();
            }
            return View(patientData);
        }

        // GET: Patient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patient/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Age,FileNum,TelephoneNum,Address,Marrid,RH,LMB,EDD,GPA,Others,MedicalHistory,SurgicalHistory")] PatientData patientData)
        {
            if (ModelState.IsValid)
            {
                db.PatientDatas.Add(patientData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patientData);
        }

        // GET: Patient/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientData patientData = db.PatientDatas.Find(id);
            if (patientData == null)
            {
                return HttpNotFound();
            }
            return View(patientData);
        }

        // POST: Patient/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Age,FileNum,TelephoneNum,Address,Marrid,RH,LMB,EDD,GPA,Others,MedicalHistory,SurgicalHistory")] PatientData patientData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patientData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patientData);
        }

        // GET: Patient/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientData patientData = db.PatientDatas.Find(id);
            if (patientData == null)
            {
                return HttpNotFound();
            }
            return View(patientData);
        }

        // POST: Patient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PatientData patientData = db.PatientDatas.Find(id);
            db.PatientDatas.Remove(patientData);
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
