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

        public DataQuery()
        {
            wheres = new List<QueryRule>();
            fields = new List<string>();
            tables = new List<string>();
        }

        #endregion

        #region "Properties"

        public string[] Tables
        {
            get { return tables.ToArray(); }
        }

        public string[] Fields
        {
            get { return fields.ToArray(); }
        }

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
        /// <returns></returns>
        public DataQuery Select(string table, string field)
        {
            fields.Add(table + "." + field);
            if(!tables.Contains(table))
                tables.Add(table);

            return this;
        }

        public DataQuery Where(string table, string field, Identifier identifier, object condition)
        {
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
