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

        /// <summary>
        /// Reads the stored configuration from file
        /// </summary>
        private void ReadConfigurationFile()
        {

        }

        #endregion

        #region "Static Methods"

        /// <summary>
        /// Adds a primary or secundairy datasource as a database connection
        /// </summary>
        /// <param name="publicname">The name for the data source that will be visible in the overview</param>
        /// <param name="hostname">The hostname or ip address of the database server</param>
        /// <param name="database">THe name of the database to connect to</param>
        /// <param name="username">The username of the user which can connect to the database</param>
        /// <param name="password">The password of the specified username to connect to the database</param>
        /// <param name="port">Optional: The port of the database server used to connect to the database</param>
        public static void AddDatabaseSource(string publicname, string hostname, string database, string username, string password, int port = -1)
        {
            if (GetInstance().primarySource == null)
                GetInstance().primarySource = new MySqlDatabase(publicname, hostname, port, database, username, password);
            else
                GetInstance().secundairySources.Add(new MySqlDatabase(publicname, hostname, port, database, username, password));
        }

        /// <summary>
        /// Adds a file to the secundairy data sources
        /// </summary>
        /// <param name="publicname">The name for the data source that will be visible in the overview</param>
        /// <param name="filename">The full path plus filename for the file to read the data from</param>
        public static void AddFileSource(string publicname, string filename)
        {

        }

        /// <summary>
        /// Adds a folder to the secundairy data sources
        /// </summary>
        /// <param name="publicname">The name for the data source that will be visible in the overview</param>
        /// <param name="directory">THe directory to read from</param>
        public static void AddFolderSource(string publicname, string directory)
        {

        }

        /// <summary>
        /// Executes the given query against all the known data sources
        /// </summary>
        /// <param name="query">The query that needs to be executed</param>
        /// <returns>DataTable object containing the results from all the known data sources</returns>
        public static DataTable QueryResults(DataQuery query)
        {
            // Query the primary data source
            DataTable primary = GetInstance().primarySource.ExecuteQuery(query);

            // Query all the secundairy data sources
            foreach(DataSource source in GetInstance().secundairySources)
            {
                // Merge the results of the secundairy data sources with the data from the primary source
                primary.Merge(source.ExecuteQuery(query));
            }

            return primary;
        }

        /// <summary>
        /// Creates and gets the current instance of the DataManager
        /// </summary>
        /// <returns>The current instance of the DataManager</returns>
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
