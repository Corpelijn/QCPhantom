using Newtonsoft.Json.Linq;
using QCAnalyser.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QCPhantom.Controllers
{
    public class ResultsController : Controller
    {
        public ActionResult Index()
        {
            return View("Overview");
        }

        [HttpPost]
        public ActionResult NextExamination(int index)
        {
            Examination ex1 = new Examination()
            {
                AssessionNumber = "100254123",
                ExaminationDateTime = DateTime.Now,
                PatientId = "9154531254",
                StudyInstanceUID = "1.2.840.113845.11.1000000001785866041.20160610141523.3920428"
            };

            Random rand = new Random();

            JObject json = new JObject();
            json.Add("assessionnumber", ex1.AssessionNumber + index);
            json.Add("datetime", ex1.ExaminationDateTime.ToString("dd MMM yyyy HH:mm"));
            json.Add("studyinstance", ex1.StudyInstanceUID);
            json.Add("machine", "machine");
            json.Add("patientid", ex1.PatientId);

            int count = rand.Next(1, 10);
            json.Add("analysecount", count);

            for (int i = 0; i < count; i++)
            {
                json.Add("instanceUID" + i, i + 1);
                json.Add("detector" + i, "detector");
                json.Add("datetime" + i, DateTime.Now.ToString("dd MMM yyyy HH:mm"));
                json.Add("status" + i, "In orde");
                json.Add("resultaten" + i, "H-C-R");
            }

            return Content(json.ToString(), "application/json");

            //return Json(new { datetime = ex1.ExaminationDateTime.ToString("dd MMM yyyy HH:mm"), assessionnumber = ex1.AssessionNumber, studyinstance = ex1.StudyInstanceUID, machine = "machine", patientid = ex1.PatientId, analysecount = rand.Next(1, 5) });
        }

        [HttpPost]
        public ActionResult NextAnalyse(string pacs, int index)
        {
            return Json(new { });
        }
    }
}