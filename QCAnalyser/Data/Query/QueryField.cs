using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCAnalyser.Data.Query
{
    public class QueryField
    {
        #region "Fields"

        private string table;
        private string field;

        #endregion

        #region "Constructors"

        public QueryField(string table, string field)
        {
            this.table = table;
            this.field = field;
        }

        #endregion

        #region "Properties"

        public string Table
        {
            get { return table; }
        }

        public string Field
        {
            get { return field; }
        }

        #endregion

        #region "Methods"



        #endregion

        #region "Abstract/Virtual Methods"



        #endregion

        #region "Inherited Methods"

        public override string ToString()
        {
            return table + "." + field;
        }

        #endregion

        #region "Static Methods"



        #endregion

        #region "Operators"



        #endregion
    }
}
