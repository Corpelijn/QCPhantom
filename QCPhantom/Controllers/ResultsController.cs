using Newtonsoft.Json.Linq;
using QCAnalyser.Data.Query;
using QCAnalyser.Domain;
using System;
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
        public ActionResult NextStudy(int index)
        {
            Random rand = new Random();

            JObject json = new JObject();

            int studycount = index == 0 ? 10 : 5;

            json.Add("studycount", studycount);
            for (int j = 0; j < studycount; j++)
            {
                Study study = new Study()
                {
                    AssessionNumber = (100254123 + j + index + (studycount == 5 ? -1 : 0)).ToString(),
                    ExaminationDateTime = DateTime.Now,
                    PatientId = "9154531254",
                    StudyInstanceUID = "1.2.840.113845.11.1000000001785866041.20160610141523.3920428"
                };

                JObject studyInfo = new JObject();
                studyInfo.Add("assessionnumber", study.AssessionNumber);
                studyInfo.Add("datetime", study.ExaminationDateTime.ToString("dd MMM yyyy HH:mm"));
                studyInfo.Add("studyinstance", study.StudyInstanceUID);
                studyInfo.Add("machine", "machine");
                studyInfo.Add("patientid", study.PatientId);

                int count = rand.Next(1, 10);
                studyInfo.Add("imagecount", count);

                for (int i = 0; i < count; i++)
                {
                    JObject imageInfo = new JObject();
                    imageInfo.Add("instanceUID", i + 1);
                    imageInfo.Add("detector", "detector");
                    imageInfo.Add("datetime", DateTime.Now.ToString("dd MMM yyyy HH:mm"));
                    imageInfo.Add("status", "In orde");
                    imageInfo.Add("resultaten", "H-C-R");
                    studyInfo.Add(new JProperty("image" + i, imageInfo));
                }

                json.Add(new JProperty("study" + j, studyInfo));
            }

            if(studycount == 5)
                json.Add("nomorestudies", true);

            //System.IO.File.WriteAllText("D:\\temp.json", json.ToString());

            return Content(json.ToString(), "application/json");

            //return Json(new { datetime = ex1.ExaminationDateTime.ToString("dd MMM yyyy HH:mm"), assessionnumber = ex1.AssessionNumber, studyinstance = ex1.StudyInstanceUID, machine = "machine", patientid = ex1.PatientId, analysecount = rand.Next(1, 5) });
        }

        [HttpPost]
        public ActionResult GetStudies(string filter)
        {
            DataQuery.FromBase64String(filter);

            Random rand = new Random();

            JObject json = new JObject();

            int studycount = 100;

            json.Add("studycount", studycount);
            for (int j = 0; j < studycount; j++)
            {
                Study study = new Study()
                {
                    AssessionNumber = (100254123 + j).ToString(),
                    ExaminationDateTime = DateTime.Now,
                    PatientId = "9154531254",
                    StudyInstanceUID = "1.2.840.113845.11.1000000001785866041.20160610141523.3920428"
                };

                JObject studyInfo = new JObject();
                studyInfo.Add("assessionnumber", study.AssessionNumber);
                studyInfo.Add("datetime", study.ExaminationDateTime.ToString("dd MMM yyyy HH:mm"));
                studyInfo.Add("studyinstance", study.StudyInstanceUID);
                studyInfo.Add("machine", "machine");
                studyInfo.Add("patientid", study.PatientId);

                int count = rand.Next(1, 10);
                studyInfo.Add("imagecount", count);

                for (int i = 0; i < count; i++)
                {
                    JObject imageInfo = new JObject();
                    imageInfo.Add("instanceUID", i + 1);
                    imageInfo.Add("detector", "detector");
                    imageInfo.Add("datetime", DateTime.Now.ToString("dd MMM yyyy HH:mm"));
                    imageInfo.Add("status", "In orde");
                    imageInfo.Add("resultaten", "H-C-R");
                    studyInfo.Add(new JProperty("image" + i, imageInfo));
                }

                json.Add(new JProperty("study" + j, studyInfo));
            }

            //if (studycount == 5)
            //    json.Add("nomorestudies", true);

            return Content(json.ToString(), "application/json");
        }

        [HttpPost]
        public ActionResult NextAnalyse(string pacs, int index)
        {
            return Json(new { });
        }
    }
}