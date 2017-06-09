using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCAnalyser.Data.Query
{
    public class JoinData
    {
        #region "Fields"

        private string table1;
        private string table2;
        private string column1;
        private string column2;

        #endregion

        #region "Constructors"

        public JoinData(string table1, string column1, string table2, string column2)
        {
            this.table1 = table1;
            this.column1 = column1;
            this.table2 = table2;
            this.column2 = column2;
        }

        #endregion

        #region "Properties"

        public string Table1
        {
            get { return table1; }
        }

        public string Column1
        {
            get { return column1; }
        }

        public string Table2
        {
            get { return table2; }
        }

        public string Column2
        {
            get { return column2; }
        }

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
