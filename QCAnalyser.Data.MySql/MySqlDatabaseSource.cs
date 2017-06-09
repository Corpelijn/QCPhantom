using QCAnalyser.Data.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QCAnalyser.Data.Query;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace QCAnalyser.Data.Sources
{
    public class MySqlDatabaseSource : DatabaseSource
    {
        #region "Fields"

        private MySqlConnection connection;

        #endregion

        #region "Constructors"

        private MySqlDatabaseSource(string name, string host, string database, string username, string password) : base(name, host, database, username, password)
        {
            port = 3306;
        }

        private MySqlDatabaseSource(string name, string host, ushort port, string database, string username, string password) : base(name, host, port, database, username, password)
        {

        }

        #endregion

        #region "Properties"



        #endregion

        #region "Methods"

        private string CreateConnectionString()
        {
            return "Server=" + host +
                ";Port=" + port +
                ";Database=" + database +
                ";Uid=" + username +
                ";Pwd=" + password + ";";
        }

        private void InsertSqlParameter(MySqlCommand command, object value)
        {
            int index = command.CommandText.IndexOf("?");

            MySqlParameter parameter = command.CreateParameter();
            parameter.ParameterName = "@" + index;
            parameter.MySqlDbType = GetDbType(value.GetType());
            parameter.Value = value;

            command.Parameters.Add(parameter);

            command.CommandText = command.CommandText.Remove(index, 1).Insert(index, parameter.ParameterName);
        }

        private MySqlDbType GetDbType(Type type)
        {
            if (type == typeof(int))
            {
                return MySqlDbType.Int32;
            }
            else if (type == typeof(string))
            {
                return MySqlDbType.String;
            }
            else if (type == typeof(bool))
            {
                return MySqlDbType.Int32;
            }
            return MySqlDbType.Blob;
        }

        #endregion

        #region "Abstract/Virtual Methods"



        #endregion

        #region "Inherited Methods"

        public override void AddData(object value)
        {
            throw new NotImplementedException();
        }

        public override void Close()
        {
            connection.Close();
            connection = null;
        }

        public override ResultTable ExecuteQuery(string query, params object[] values)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = query;

            foreach (object value in values)
            {
                InsertSqlParameter(command, value);
            }

            ResultTable table = new ResultTable(command.ExecuteReader(), this);
            command.Dispose();

            return table;
        }

        public override void Open()
        {
            if (connection == null)
            {
                connection = new MySqlConnection(CreateConnectionString());
                connection.Open();
            }
            else
                Close();
        }

        public override void RemoveData(object value)
        {
            throw new NotImplementedException();
        }

        public override void UpdateData(object value)
        {
            throw new NotImplementedException();
        }

        public override ResultTable ExecuteQuery(DataQuery query)
        {
            MySqlCommand command = connection.CreateCommand();
            GenerateQueryCommand(query, command);

            ResultTable table = new ResultTable(command.ExecuteReader(), this);
            command.Dispose();

            Console.WriteLine(command.CommandText);

            return table;
        }

        protected override void GenerateQueryCommand(DataQuery query, DbCommand command)
        {
            Query.Database.DatabaseQuery dbQuery = new Query.Database.DatabaseQuery(query);
            MySqlCommand mySqlCommand = command as MySqlCommand;

            dbQuery.Build();

            mySqlCommand.CommandText = dbQuery.Query;

            foreach (Query.Database.DatabaseParameter dbParam in dbQuery)
            {
                MySqlParameter parameter = mySqlCommand.CreateParameter();
                parameter.ParameterName = dbParam.Name;
                parameter.MySqlDbType = GetDbType(dbParam.Type);
                parameter.Value = dbParam.Value;
            }
        }

        #endregion

        #region "Static Methods"

        public static MySqlDatabaseSource Create(string name, string host, string database, string username, string password)
        {
            return new MySqlDatabaseSource(name, host, database, username, password);
        }

        public static MySqlDatabaseSource Create(string name, string host, ushort port, string database, string username, string password)
        {
            return new MySqlDatabaseSource(name, host, port, database, username, password);
        }

        #endregion

        #region "Operators"



        #endregion
    }
}
