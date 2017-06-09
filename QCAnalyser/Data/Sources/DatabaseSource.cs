using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QCAnalyser.Data.Query;
using System.Data.Common;

namespace QCAnalyser.Data.Sources
{
    public abstract class DatabaseSource : DataSource
    {
        #region "Fields"

        protected string host;
        protected int port;
        protected string database;
        protected string username;
        protected string password;

        #endregion

        #region "Constructors"

        protected DatabaseSource(string name, string host, string database, string username, string password) : base(name)
        {
            this.host = host;
            this.port = 0;
            this.database = database;
            this.username = username;
            this.password = password;
        }

        protected DatabaseSource(string name, string host, ushort port, string database, string username, string password) : base(name)
        {
            this.host = host;
            this.port = port;
            this.database = database;
            this.username = username;
            this.password = password;
        }

        #endregion

        #region "Properties"



        #endregion

        #region "Methods"



        #endregion

        #region "Abstract/Virtual Methods"

        protected abstract void GenerateQueryCommand(DataQuery query, DbCommand command);

        #endregion

        #region "Inherited Methods"

        public override abstract void AddData(object value);

        public override abstract void Close();

        public override abstract ResultTable ExecuteQuery(string query, params object[] values);

        public override abstract void Open();

        public override abstract void RemoveData(object value);

        public override abstract void UpdateData(object value);

        public override abstract ResultTable ExecuteQuery(DataQuery query);

        #endregion

        #region "Static Methods"



        #endregion

        #region "Operators"



        #endregion
    }
}
