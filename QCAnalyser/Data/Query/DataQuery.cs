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

        private List<QueryField> fields;
        private List<QueryRule> wheres;

        #endregion

        #region "Constructors"

        /// <summary>
        /// Creates a new instance of a DataQuery object
        /// </summary>
        public DataQuery()
        {
            fields = new List<QueryField>();
            wheres = new List<QueryRule>();
        }

        #endregion

        #region "Properties"

        /// <summary>
        /// Gets the fields used for this query
        /// </summary>
        public QueryField[] Fields
        {
            get { return fields.ToArray(); }
        }

        public string[] Tables
        {
            get { return fields.Select(f => f.Table).Distinct().ToArray(); }
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
        /// <returns>The current DataQuery object</returns>
        public DataQuery Select(QueryField field)
        {
            // Add the field to the list
            fields.Add(field);

            return this;
        }

        public DataQuery Select(string table, string field)
        {
            fields.Add(new QueryField(table, field));

            return this;
        }

        /// <summary>
        /// Adds a where clause to the query
        /// </summary>
        /// <param name="field">The name of the field that needs to be queried</param>
        /// <param name="identifier">A identifier to check the where clause of the query</param>
        /// <param name="condition">A condition to check the field against</param>
        /// <returns>The current DataQuery object</returns>
        public DataQuery Where(QueryField field, Identifier identifier, object condition)
        {
            // Create a new QueryRule and add it to the list
            wheres.Add(new QueryRule(field, identifier, condition));

            return this;
        }

        public DataQuery Where(string table, string field, Identifier identifier, object condition)
        {
            wheres.Add(new QueryRule(new QueryField(table, field), identifier, condition));

            return this;
        }

        #endregion

        #region "Static Methods"

        /// <summary>
        /// Creates a new DataQuery object from a base64 string
        /// </summary>
        /// <param name="base64">The base64 string to create the DataQuery object from</param>
        /// <returns>The base64 query as DataQuery</returns>
        public static DataQuery FromBase64String(string base64)
        {
            // Decode the base64 to a string
            string query = Encoding.ASCII.GetString(Convert.FromBase64String(base64));

            // Loop through the query string and define the new DataQuery object
            DataQuery newQuery = new DataQuery();
            while (query.Length > 0)
            {
                // Split the values
                string[] values = query.Split(new char[] { '»' });
                if (values.Length < 3)
                    throw new FormatException("The query contains an invalid format");

                // Find the values we need
                string table = values[0];
                string field = values[1];
                string identifier = values[2];
                string value = values[3];

                // Get the identifier
                Identifier iIdentifier = Identifier.GetByOperator(identifier);

                // Add the query to the DataQuery object
                newQuery.Where(new QueryField(table, field), iIdentifier, value);
            }

            // Return the new build query
            return newQuery;
        }

        #endregion

        #region "Inherited Methods"



        #endregion
    }
}
