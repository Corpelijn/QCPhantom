using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCAnalyser.Data.Query
{
    public enum EIdentifier
    {
        EQUALS_TO = 0,
        NOT_EQUALS_TO,
        BIGGER_THAN,
        SMALLER_THAN,
        BIGGER_OR_EQUAL,
        SMALLER_OR_EQUAL,
        STARTS_WITH,
        ENDS_WITH,
        CONTAINS
    }
}
