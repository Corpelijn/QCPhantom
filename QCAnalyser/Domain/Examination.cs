using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCAnalyser.Domain
{
    public class Study
    {
        #region "Attributes"

        private DateTime examinationDateTime;
        private string assessionNumber;
        private string studyInstanceUID;
        private Machine machine;
        private string patientId;

        private Analyse[] imageAnalyses;

        #endregion

        #region "Constructors"



        #endregion

        #region "Properties"

        /// <summary>
        /// Gets the date and time the examination took place
        /// </summary>
        public DateTime ExaminationDateTime
        {
            get { return examinationDateTime; }
            set { examinationDateTime = value; }
        }

        /// <summary>
        /// Gets the assession number from PACS that is unique for this examination
        /// </summary>
        public string AssessionNumber
        {
            get { return assessionNumber; }
            set { assessionNumber = value; }
        }

        /// <summary>
        /// Gets the Study Instance UID that is unique for this examination
        /// </summary>
        public string StudyInstanceUID
        {
            get { return studyInstanceUID; }
            set { studyInstanceUID = value; }
        }

        /// <summary>
        /// Gets the machine on which the image was taken
        /// </summary>
        public Machine Machine
        {
            get { return machine; }
            set { machine = value; }
        }

        /// <summary>
        /// Gets the unique id of the patient on which the examination was stored
        /// </summary>
        public string PatientId
        {
            get { return patientId; }
            set { patientId = value; }
        }

        /// <summary>
        /// Gets the analyse results of the images in the examination
        /// </summary>
        public Analyse[] ImageAnalyses
        {
            get { return imageAnalyses; }
            set { imageAnalyses = value; }
        }

        #endregion

        #region "Methods"

        

        #endregion

        #region "Static Methods"



        #endregion

        #region "Inherited Methods"



        #endregion
    }
}
