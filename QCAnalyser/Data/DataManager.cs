using QCAnalyser.Data.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCAnalyser.Data
{
    public class DataManager
    {
        #region "Fields"

        private int primarySource;
        private List<DataSource> sources;

        #endregion

        #region "Constructors"

        private DataManager()
        {
            primarySource = -1;
            sources = new List<DataSource>();
        }

        #endregion

        #region "Singleton"

        private static DataManager instance;

        private static DataManager INSTANCE
        {
            get
            {
                if (instance == null)
                    instance = new DataManager();
                return instance;
            }
        }

        #endregion

        #region "Properties"

        public static DataSource PrimarySource
        {
            get { return INSTANCE.sources[INSTANCE.primarySource]; }
        }

        #endregion

        #region "Methods"



        #endregion

        #region "Abstract/Virtual Methods"



        #endregion

        #region "Inherited Methods"



        #endregion

        #region "Static Methods"

        public static void AddDataSource(DataSource source)
        {
            INSTANCE.sources.Add(source);
            if (INSTANCE.sources.Count == 1)
                INSTANCE.primarySource = 0;
        }

        #endregion

        #region "Operators"



        #endregion
    }
}
