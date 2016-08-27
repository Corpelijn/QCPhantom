using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QCAnalyser.Data.Query;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data.Common;

namespace QCAnalyser.Data.Database
{
    class MySqlDatabase : DatabaseSource
    {
        #region "Attributes"

        private string connectionString;

        #endregion

        #region "Constructors"

        /// <summary>
        /// Creates a new instance of a database data source. This class supports MySql databases
        /// </summary>
        /// <param name="publicname">The name of the data source visible in the overview</param>
        /// <param name="hostname">The hostname or ip address of the database server</param>
        /// <param name="port">The port of the server to connect to. If this value is -1 the default port will be used</param>
        /// <param name="database">The name of the database to connect to</param>
        /// <param name="username">The username of the user to connect to the given database</param>
        /// <param name="password">The password corresponding with the given username</param>
        public MySqlDatabase(string publicname, string hostname, int port, string database, string username, string password) : base(publicname, hostname, port, database, username, password)
        {
            // Create the connection string
            connectionString = "SERVER=" + hostname + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
        }

        #endregion

        #region "Properties"



        #endregion

        #region "Methods"



        #endregion

        #region "Static Methods"



        #endregion

        #region "Inherited Methods"

        public override DataTable ExecuteQuery(DataQuery query)
        {
            // Create a DataTable object to store the results in
            DataTable table;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Open the database connection
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    // Create a command to execute from the given DataQuery object
                    command.CommandText = "select " + string.Join(",", query.Fields) + " from " + string.Join(",", query.Tables) + " where " + string.Join(" AND ", (object[])query.Rules);
                    // Execute the query against the database. Tell the database to return table information as well
                    DbDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.KeyInfo);
                    // Create a new instance of a DataTable object and store the results of the query into it
                    table = new DataTable(reader, this);
                }
            }

            // Return the DataTable object
            return table;
        }

        #endregion
    }
}
