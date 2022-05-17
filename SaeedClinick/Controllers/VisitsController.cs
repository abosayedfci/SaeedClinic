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
    [RoutePrefix("Visits")]
    public class VisitsController : Controller
    {
        private clinickEntities db = new clinickEntities();

        // GET: Visits
        [Route("Index/{PatientID}")]
        public ActionResult Index( int? PatientID)
        {
            if(PatientID !=null)
            {
                ViewBag.Patient = db.PatientDatas.Find(PatientID);
            }
            var visits = db.Visits.Include(v => v.PatientData).Include(s=> s.VisitUS ).Include(d=>d.VisitLabs).Include(x=>x.VisitTreatments);
            return View(visits.ToList().Where(x=>x.PatientID==PatientID));
        }

        // GET: Visits/Details/5
        [Route("Details/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visit visit= db.Visits.Where(d=>d.Id==id).Include(s => s.VisitUS).Include(d => d.VisitLabs).Include(x => x.VisitTreatments).SingleOrDefault();
            List<string> Labs = new List<string>();
            foreach( var item in visit.VisitLabs)
            {
                LK_Labs Lab = db.LK_Labs.Find(item.LabId);
                Labs.Add(Lab.LabTitle);
            }
            List<string> Treatments = new List<string>();
            foreach (var item in visit.VisitTreatments)
            {
                LK_Treatment Treatment = db.LK_Treatment.Find(item.TreatmentId);
                Treatments.Add(Treatment.TreatmentTitle);
               
            }
            List<string> Uss = new List<string>();
            foreach (var item in visit.VisitUS)
            {
                LK_US US = db.LK_US.Find(item.USId);
                Uss.Add(US.UsTitle);
               
            }
            visit.LK_US=Uss;
            visit.LK_Labs = Labs;
            visit.LK_Treatments = Treatments;
            if (visit == null)
            {
                return HttpNotFound();
            }
            ViewBag.Patient = visit.PatientData;
            
            ViewBag.visit = visit;
            return View(visit);
        }
        [HttpGet]
        [Route("VisitDetails/{id}")]
        public JsonResult VisitDetails(int? id)
        {
           
            Visit visit = db.Visits.Find(id);

            if (visit != null)
            {
                return Json(new { visit = visit }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return null;
            }
           
        }
        // GET: Visits/Create
        [Route("Create/{PatientId}")]
        public ActionResult Create( int? PatientId)
        {
            ViewBag.Patient = db.PatientDatas.Find(PatientId);
            ViewBag.VisitNum = db.Visits.ToList().Where(x => x.PatientID == PatientId).Count()+1;
            ViewBag.Date = new DateTime();
            return View();
        }

        
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("CreateNew")]
        [HttpPost]
        public void CreateNew( Visit visit)
        {

            if (ModelState.IsValid)
            {
                foreach(int labId in visit.Labs)
                {
                    VisitLab item = new VisitLab();
                    item.LabId = labId;
                    visit.VisitLabs.Add(item);
                }
                foreach (int TreatmentId in visit.Treatments)
                {
                    VisitTreatment item = new VisitTreatment();
                    item.TreatmentId = TreatmentId;
                    visit.VisitTreatments.Add(item);
                }
                foreach (int USId in visit.Us)
                {
                    VisitU item = new VisitU();
                    item.USId = USId;
                    visit.VisitUS.Add(item);
                }
                db.Visits.Add(visit);
                db.SaveChanges();

                // db.Visits.Add(visit);
                //   db.SaveChanges();
                // return RedirectToAction("Index");
            }

            // ViewBag.PatientID = new SelectList(db.PatientDatas, "Id", "Name", visit.PatientID);
            // return View(visit);
        }

        // GET: Visits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visit visit = db.Visits.Find(id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            ViewBag.PatientID = new SelectList(db.PatientDatas, "Id", "Name", visit.PatientID);
            return View(visit);
        }

        // POST: Visits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VisitNum,Date,NextVisitDate,BP,LL,Weight,Complain,Others,PatientID")] Visit visit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { PatientID = visit.PatientID} );
            }
            ViewBag.PatientID = new SelectList(db.PatientDatas, "Id", "Name", visit.PatientID);
            return View(visit);
        }

        // GET: Visits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visit visit = db.Visits.Find(id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            return View(visit);
        }

        // POST: Visits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Visit visit = db.Visits.Find(id);
            var deletedLabs = db.VisitLabs.Where(v => v.VisitId == id).ToList();
            foreach (var visitLab in deletedLabs)
            {
                db.VisitLabs.Remove(visitLab);
            }

            var deletedVisitTR = db.VisitTreatments.Where(v => v.VisitId == id).ToList();
            foreach (var visitTR in deletedVisitTR)
            {
                db.VisitTreatments.Remove(visitTR);
            }

            var deletedVisitUS = db.VisitUS.Where(v => v.VisitId == id).ToList();
            foreach (var visitUS in deletedVisitUS)
            {
                db.VisitUS.Remove(visitUS);
            }

            db.Visits.Remove(visit);
            db.SaveChanges();
            return RedirectToAction("Index" , new { PatientID = visit.PatientID });
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
