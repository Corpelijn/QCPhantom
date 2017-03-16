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

        /// <summary>
        /// Executes a query against the current data source. The results are returned as a DataTable object
        /// </summary>
        /// <param name="query">A DataQuery object containing the information about the query that needs to be executed</param>
        /// <returns>DataTable object containing the matching results of the query from this data source</returns>
        public abstract DataTable ExecuteQuery(DataQuery query);
        
        #endregion

        #region "Static Methods"



        #endregion

        #region "Inherited Methods"



        #endregion
    }
}
