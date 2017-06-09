using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCAnalyser.Data.Query
{
    public class WhereData
    {
        #region "Fields"

        private int index;
        private string table;
        private string column;
        private QueryIdentifier identifier;
        private object value;

        #endregion

        #region "Constructors"

        private WhereData(int index, string table, string column, QueryIdentifier identifier, object value)
        {
            this.index = index;
            this.table = table;
            this.column = column;
            this.identifier = identifier;
            this.value = value;
        }

        public WhereData(int index, string parenthesis)
        {
            this.index = index;
            this.table = parenthesis;
        }

        #endregion

        #region "Properties"



        #endregion

        #region "Methods"



        #endregion

        #region "Abstract/Virtual Methods"



        #endregion

        #region "Inherited Methods"



        #endregion

        #region "Static Methods"



        #endregion

        #region "Operators"



        #endregion
    }
}
