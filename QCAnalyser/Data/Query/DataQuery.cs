using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCAnalyser.Data.Query
{
    public class DataQuery
    {
        #region "Attributes"

        private List<string> fields;
        private List<string> tables;
        private List<QueryRule> wheres;

        #endregion

        #region "Constructors"

        /// <summary>
        /// Creates a new instance of a DataQuery object
        /// </summary>
        public DataQuery()
        {
            wheres = new List<QueryRule>();
            fields = new List<string>();
            tables = new List<string>();
        }

        #endregion

        #region "Properties"

        /// <summary>
        /// Gets the tables used for this query
        /// </summary>
        public string[] Tables
        {
            get { return tables.ToArray(); }
        }

        /// <summary>
        /// Gets the fields used for this query
        /// </summary>
        public string[] Fields
        {
            get { return fields.ToArray(); }
        }

        /// <summary>
        /// Gets the where clauses used for this query
        /// </summary>
        public QueryRule[] Rules
        {
            get { return wheres.ToArray(); }
        }

        #endregion

        #region "Methods"

        /// <summary>
        /// Adds a field to the query results
        /// </summary>
        /// <param name="field">The name of the field</param>
        /// <param name="table">The table of which the field is part of</param>
        /// <returns>The current DataQuery object</returns>
        public DataQuery Select(string table, string field)
        {
            // Add the field to the list in the format: "table.field"
            fields.Add(table + "." + field);

            // Check if the table already exist in the list of tables. Otherwise add it to the list
            if(!tables.Contains(table))
                tables.Add(table);

            return this;
        }

        /// <summary>
        /// Adds a where clause to the query
        /// </summary>
        /// <param name="table">The table of the field that needs to be queried</param>
        /// <param name="field">The name of the field that needs to be queried</param>
        /// <param name="identifier">A identifier to check the where clause of the query</param>
        /// <param name="condition">A condition to check the field against</param>
        /// <returns>The current DataQuery object</returns>
        public DataQuery Where(string table, string field, Identifier identifier, object condition)
        {
            // Create a new QueryRule and add it to the list
            wheres.Add(new QueryRule(field, table, identifier, condition));

            return this;
        }

        #endregion

        #region "Static Methods"



        #endregion

        #region "Inherited Methods"



        #endregion
    }
}
