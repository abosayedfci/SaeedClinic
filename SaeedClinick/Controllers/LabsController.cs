using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SaeedClinick.Data;

namespace SaeedClinick.Controllers
{
    public class LabsController : Controller
    {
        private clinickEntities db = new clinickEntities();
        // GET: Labs
        public ActionResult Index()
        {
            return View();
        }

        //[Route("getTreatmentList")]
        //[HttpGet]
        //public JsonResult getTreatmentList()
        //{
        //    IList<LK_Treatment> TreatmentList = new List<LK_Treatment>();

        //    TreatmentList = db.LK_Treatment.ToList();

        //    return Json(new { TreatmentList = TreatmentList }, JsonRequestBehavior.AllowGet);
        //}
        [Route("NewTreatment/{NewTreatmentTitle}")]
        [HttpPost]
        public JsonResult AddTreatment(string NewTreatmentTitle)
        {
            if (NewTreatmentTitle != null && db.LK_Treatment.Where(ss => ss.TreatmentTitle == NewTreatmentTitle).Count() == 0)
            {
                LK_Treatment obj = new LK_Treatment();
                obj.TreatmentTitle = NewTreatmentTitle;
                db.LK_Treatment.Add(obj);
                db.SaveChanges();
                return getLookupList();
            }
            else
            {
                return Json("error");
            }
        }
        //[Route("getUSList")]
        //[HttpGet]
        //public JsonResult getUSList()
        //{
        //    IList<LK_US> USList = new List<LK_US>();

        //    USList = db.LK_US.ToList();

        //    return Json(new { USList = USList }, JsonRequestBehavior.AllowGet);
        //}
        [HttpGet]
        public JsonResult NewUS(string NewUSTitle)
        {
            if (NewUSTitle != null && db.LK_US.Where(ss => ss.UsTitle == NewUSTitle).Count() == 0)
            {
                LK_US obj = new LK_US();
                obj.UsTitle = NewUSTitle;
                db.LK_US.Add(obj);
                db.SaveChanges();
                return getLookupList();
            }
            else
            {
                return Json("error");
            }
        }

        [Route("getLookupList")]
        [HttpGet]
        public JsonResult getLookupList()
        {
            var List = new
            {
                LabsList = db.LK_Labs.Select(x => new
                {
                    x.Id,
                    x.LabTitle
                }),
                TreatmentList = db.LK_Treatment.Select(x => new
                {
                    x.Id,
                    x.TreatmentTitle
                }),
                USList = db.LK_US.Select(x => new
                {
                    x.Id,
                    x.UsTitle
                })
            };

            return Json( List, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
         public JsonResult NewLab(string NewlabTitle)
        {
            if (NewlabTitle != null && db.LK_Labs.Where(ss => ss.LabTitle == NewlabTitle).Count() == 0)
            {
                LK_Labs obj = new LK_Labs();
                obj.LabTitle = NewlabTitle;
                db.LK_Labs.Add(obj);
                db.SaveChanges();
                return getLookupList();
            }
           else
            {
                return Json("error");
            }
        }
    }
}