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

        private string field;
        private string table;
        private Identifier identifier;
        private object condition;

        #endregion

        #region "Constructors"

        public QueryRule(string field, string table, Identifier identifier, object condition)
        {
            this.field = field;
            this.table = table;
            this.identifier = identifier;
            this.condition = condition;
        }

        #endregion

        #region "Properties"

        public string Field
        {
            get { return field; }
        }

        public string Table
        {
            get { return table; }
        }

        public Identifier Identifier
        {
            get { return identifier; }
        }

        public object Condition
        {
            get { return condition; }
        }

        #endregion

        #region "Methods"

        public override string ToString()
        {
            return table + "." + field + identifier + condition;
        }

        #endregion

        #region "Static Methods"



        #endregion

        #region "Inherited Methods"



        #endregion
    }
}
