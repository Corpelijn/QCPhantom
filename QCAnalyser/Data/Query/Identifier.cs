using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCAnalyser.Data.Query
{
    public sealed class Identifier
    {
        public static readonly Identifier EQUALS_TO = new Identifier("=");
        public static readonly Identifier NOT_EQUALS_TO = new Identifier("!=");
        public static readonly Identifier BIGGER_THAN = new Identifier(">");
        public static readonly Identifier SMALLER_THAN = new Identifier("<");
        public static readonly Identifier BIGGER_OR_EQUAL = new Identifier(">=");
        public static readonly Identifier SMALLER_OR_EQUAL = new Identifier("<=");
        public static readonly Identifier STARTS_WITH = new Identifier("like _%");
        public static readonly Identifier ENDS_WITH = new Identifier("like %_");
        public static readonly Identifier CONTAINS = new Identifier("like %_%");

        #region "Attributes"

        private string identifier;

        #endregion

        #region "Constructors"

        /// <summary>
        /// Creates a new instance of the Identifier class. Only for internal use
        /// </summary>
        /// <param name="identifier"></param>
        private Identifier(string identifier)
        {
            this.identifier = identifier;
        }

        #endregion

        #region "Properties"
        #endregion

        #region "Methods"
        #endregion

        #region "Static Methods"
        #endregion

        #region "Inherited Methods"

        public override string ToString()
        {
            return identifier;
        }

        #endregion
    }
}
