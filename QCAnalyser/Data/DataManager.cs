using QCAnalyser.Data.Database;
using QCAnalyser.Data.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCAnalyser.Data
{
    public class DataManager
    {
        #region "Attributes"

        private DataSource primarySource;
        private List<DataSource> secundairySources;

        private static DataManager instance;

        #endregion

        #region "Constructors"

        /// <summary>
        /// Creates a new instance of the DataManager. Only for internal use
        /// </summary>
        private DataManager()
        {
            secundairySources = new List<DataSource>();

            ReadConfigurationFile();
        }

        #endregion

        #region "Properties"



        #endregion

        #region "Methods"

        private void ReadConfigurationFile()
        {

        }

        #endregion

        #region "Static Methods"

        public static void AddDatabaseSource(string publicname, string hostname, string database, string username, string password, int port = -1)
        {
            if (GetInstance().primarySource == null)
                GetInstance().primarySource = new MySqlDatabase(publicname, hostname, port, database, username, password);
            else
                GetInstance().secundairySources.Add(new MySqlDatabase(publicname, hostname, port, database, username, password));
        }

        public static void AddFileSource(string publicname, string filename)
        {

        }

        public static void AddFolderSource(string publicname, string directory)
        {

        }

        public static DataTable QueryResults(DataQuery query)
        {
            return GetInstance().primarySource.ExecuteQuery(query);
        }

        private static DataManager GetInstance()
        {
            if (instance == null)
            {
                instance = new DataManager();
            }

            return instance;
        }

        #endregion

        #region "Inherited Methods"



        #endregion
    }
}
