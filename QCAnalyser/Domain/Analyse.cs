using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCAnalyser.Domain
{
    public class Analyse
    {
        #region "Attributes"

        private DateTime analyseDateTime;
        private Detector detector;
        private string imageInstanceUID;
        private string kvp;
        private string mas;

        #endregion

        #region "Constructors"



        #endregion

        #region "Properties"

        /// <summary>
        /// Gets the date and time when the image was analysed by QCPhantom
        /// </summary>
        public DateTime AnalyseDateTime
        {
            get { return analyseDateTime; }
            set { analyseDateTime = value; }
        }

        /// <summary>
        /// Gets the detector used when taking the image
        /// </summary>
        public Detector Detector
        {
            get { return detector; }
            set { detector = value; }
        }

        /// <summary>
        /// Gets the unique ImageInstanceUID of the image
        /// </summary>
        public string ImageInstanceUID
        {
            get { return imageInstanceUID; }
            set { imageInstanceUID = value; }
        }

        /// <summary>
        /// Gets the kVp value used when taking the image
        /// </summary>
        public string kVp
        {
            get { return kvp; }
            set { kvp = value; }
        }

        /// <summary>
        /// Gets the mAs value used when taking the image
        /// </summary>
        public string mAs
        {
            get { return mas; }
            set { mas = value; }
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
