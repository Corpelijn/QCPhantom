using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCAnalyser.Data.Query
{
    public sealed class Identifier
    {
        public static readonly Identifier EQUALS_TO = new Identifier(EIdentifier.EQUALS_TO);
        public static readonly Identifier NOT_EQUALS_TO = new Identifier(EIdentifier.NOT_EQUALS_TO);
        public static readonly Identifier BIGGER_THAN = new Identifier(EIdentifier.BIGGER_THAN);
        public static readonly Identifier SMALLER_THAN = new Identifier(EIdentifier.SMALLER_THAN);
        public static readonly Identifier BIGGER_OR_EQUAL = new Identifier(EIdentifier.BIGGER_OR_EQUAL);
        public static readonly Identifier SMALLER_OR_EQUAL = new Identifier(EIdentifier.SMALLER_OR_EQUAL);
        public static readonly Identifier STARTS_WITH = new Identifier(EIdentifier.STARTS_WITH);
        public static readonly Identifier ENDS_WITH = new Identifier(EIdentifier.ENDS_WITH);
        public static readonly Identifier CONTAINS = new Identifier(EIdentifier.CONTAINS);

        #region "Attributes"

        private EIdentifier identifier;

        #endregion

        #region "Constructors"

        /// <summary>
        /// Creates a new instance of the Identifier class. Only for internal use
        /// </summary>
        /// <param name="identifier"></param>
        private Identifier(EIdentifier identifier)
        {
            this.identifier = identifier;
        }

        private Identifier(string identifier)
        {
            switch (identifier.ToUpper())
            {
                case "=":
                case "==":
                    this.identifier = EIdentifier.EQUALS_TO;
                    break;
                case "!=":
                case "<>":
                    this.identifier = EIdentifier.NOT_EQUALS_TO;
                    break;
                case ">":
                    this.identifier = EIdentifier.BIGGER_THAN;
                    break;
                case "<":
                    this.identifier = EIdentifier.SMALLER_THAN;
                    break;
                case ">=":
                    this.identifier = EIdentifier.BIGGER_OR_EQUAL;
                    break;
                case "<=":
                    this.identifier = EIdentifier.SMALLER_OR_EQUAL;
                    break;
                case "STARTSWITH":
                case "SW":
                    this.identifier = EIdentifier.STARTS_WITH;
                    break;
                case "ENDSWITH":
                case "EW":
                    this.identifier = EIdentifier.ENDS_WITH;
                    break;
                case "CONTAINS":
                case "CON":
                    this.identifier = EIdentifier.CONTAINS;
                    break;
            }
        }

        #endregion

        #region "Properties"



        #endregion

        #region "Methods"



        #endregion

        #region "Static Methods"

        public static Identifier GetByOperator(string operators)
        {
            return new Identifier(operators);
        }

        public static implicit operator Identifier(EIdentifier i)
        {
            return new Identifier(i);
        }

        public static implicit operator EIdentifier(Identifier i)
        {
            return i.identifier;
        }

        #endregion

        #region "Inherited Methods"



        #endregion
    }
}
