namespace QCAnalyser.Data.Query
{
    public sealed class QueryIdentifier
    {
        #region "Fields"

        public static readonly new QueryIdentifier Equals = new QueryIdentifier(0);
        public static readonly QueryIdentifier SmallerThan = new QueryIdentifier(-2);
        public static readonly QueryIdentifier SmallerOrEquals = new QueryIdentifier(-1);
        public static readonly QueryIdentifier BiggerThan = new QueryIdentifier(2);
        public static readonly QueryIdentifier BiggerOrEquals = new QueryIdentifier(1);

        private int value;

        #endregion

        #region "Constructors"

        private QueryIdentifier(int value)
        {
            this.value = value;
        }

        #endregion

        #region "Properties"



        #endregion

        #region "Methods"



        #endregion

        #region "Abstract/Virtual Methods"



        #endregion

        #region "Inherited Methods"

        public override string ToString()
        {
            switch (value)
            {
                case 0:
                    return "==";
                case -2:
                    return "<";
                case -1:
                    return "<=";
                case 2:
                    return ">";
                case 1:
                    return ">=";
                default:
                    return null;
            }
        }

        #endregion

        #region "Static Methods"

        public static implicit operator QueryIdentifier(string identifier)
        {
            switch (identifier)
            {
                case "==":
                case "=":
                    return Equals;
                case ">":
                    return BiggerThan;
                case ">=":
                    return BiggerOrEquals;
                case "<":
                    return SmallerThan;
                case "<=":
                    return SmallerOrEquals;
                default:
                    return null;
            }
        }

        #endregion

        #region "Operators"



        #endregion
    }
}