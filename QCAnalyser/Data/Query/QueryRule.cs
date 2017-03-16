using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCAnalyser.Data.Query
{
    public class QueryRule
    {
        #region "Attributes"

        private QueryField field;
        private Identifier identifier;
        private object condition;

        #endregion

        #region "Constructors"

        /// <summary>
        /// Creates a new instance of a query rule
        /// </summary>
        /// <param name="field">The field of the table to check</param>
        /// <param name="identifier">An identifier to apply during the check</param>
        /// <param name="condition">The condition to which the field must identify</param>
        public QueryRule(QueryField field, Identifier identifier, object condition)
        {
            this.field = field;
            this.identifier = identifier;
            this.condition = condition;
        }

        #endregion

        #region "Properties"

        public string Table
        {
            get { return field.Table ; }
        }

        /// <summary>
        /// Gets the field of the query rule
        /// </summary>
        public string Field
        {
            get { return field.Field; }
        }

        /// <summary>
        /// Gets the identifier of the query rule
        /// </summary>
        public Identifier Identifier
        {
            get { return identifier; }
        }

        /// <summary>
        /// Gets the condition fo the query rule
        /// </summary>
        public object Condition
        {
            get { return condition; }
        }

        #endregion

        #region "Methods"



        #endregion

        #region "Static Methods"



        #endregion

        #region "Inherited Methods"

        public override string ToString()
        {
            return field + " " + identifier + " " + condition;
        }

        #endregion
    }
}
