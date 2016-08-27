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

        public MySqlDatabase(string publicname, string hostname, int port, string database, string username, string password) : base(publicname, hostname, port, database, username, password)
        {
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
            DataTable table;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "select " + string.Join(",", query.Fields) + " from " + string.Join(",", query.Tables) + " where " + string.Join(" AND ", (object[])query.Rules);
                    DbDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.KeyInfo);
                    table = new DataTable(reader, this);
                }
            }

            return table;
        }

        #endregion
    }
}
