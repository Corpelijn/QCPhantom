using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QCAnalyser.Data.Query;
using QCAnalyser.Domain;

namespace QCAnalyser.Data.Database
{
    abstract class DatabaseSource : DataSource
    {
        #region "Attributes"

        protected string hostname;
        protected int port;
        protected string database;
        protected string username;
        protected string password;

        #endregion

        #region "Constructors"

        /// <summary>
        /// Constructor for a database source
        /// </summary>
        /// <param name="publicname">The name of the DataSource. Cannot be empty or null</param>
        /// <param name="hostname">The hostname or ip address of the database server. Cannot be empty or null</param>
        /// <param name="port">Optional: The port to connect to. Default: 3306</param>
        /// <param name="database">The name of the database to connect to. Cannot be empty or null</param>
        /// <param name="username">The username to connect to the database. Cannot be empty or null</param>
        /// <param name="password">The password to connect to the database.Cannot be empty or null</param>
        protected DatabaseSource(string publicname, string hostname, int port, string database, string username, string password) : base(publicname)
        {
            this.hostname = hostname;
            this.port = port;
            this.database = database;
            this.username = username;
            this.password = password;
        }

        #endregion

        #region "Properties"

        /// <summary>
        /// Gets the hostname or ipaddress of the database server
        /// </summary>
        public string Hostname
        {
            get { return hostname; }
        }

        /// <summary>
        /// Gets the port number of the database server
        /// </summary>
        public int Port
        {
            get { return port; }
        }

        /// <summary>
        /// Gets the name of the database
        /// </summary>
        public string Database
        {
            get { return database; }
        }

        /// <summary>
        /// Gets the username needed to connect to the database
        /// </summary>
        public string Username
        {
            get { return username; }
        }

        /// <summary>
        /// Gets the password needed to connect to the database
        /// </summary>
        public string Password
        {
            get { return password; }
        }

        #endregion

        #region "Methods"



        #endregion

        #region "Static Methods"



        #endregion

        #region "Inherited Methods"

        public override abstract DataTable ExecuteQuery(DataQuery query);

        #endregion
    }
}
