using QCAnalyser.Data.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCAnalyser.Data.Sources
{
    public abstract class DataSource
    {
        #region "Fields"

        private string name;

        #endregion

        #region "Constructors"

        protected DataSource(string name)
        {
            this.name = name;
        }

        #endregion

        #region "Properties"

        public string Name
        {
            get { return name; }
        }

        #endregion

        #region "Methods"



        #endregion

        #region "Abstract/Virtual Methods"

        public abstract void Open();

        public abstract void Close();

        public abstract void AddData(object value);

        public abstract void UpdateData(object value);

        public abstract void RemoveData(object value);

        public abstract ResultTable ExecuteQuery(DataQuery query);

        public abstract ResultTable ExecuteQuery(string query, params object[] values);

        #endregion

        #region "Inherited Methods"

        public override string ToString()
        {
            return "DataSource { Name=" + name + ", Type=" + GetType().Name + " }";
        }

        #endregion

        #region "Static Methods"



        #endregion

        #region "Operators"



        #endregion
    }
}
