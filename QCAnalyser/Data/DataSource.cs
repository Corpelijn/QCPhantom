using QCAnalyser.Data.Query;
using QCAnalyser.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCAnalyser.Data
{
    public abstract class DataSource
    {
        #region "Attributes"

        protected string name;

        #endregion

        #region "Constructors"

        /// <summary>
        /// Creates a new instance of DataSource
        /// </summary>
        /// <param name="name"></param>
        protected DataSource(string name)
        {
            this.name = name;
        }

        #endregion

        #region "Properties"

        /// <summary>
        /// Gets the name of the DataSource
        /// </summary>
        public string Name
        {
            get { return name; }
        }

        #endregion

        #region "Methods"

        public abstract DataTable ExecuteQuery(DataQuery query);
        
        #endregion

        #region "Static Methods"



        #endregion

        #region "Inherited Methods"



        #endregion
    }
}
