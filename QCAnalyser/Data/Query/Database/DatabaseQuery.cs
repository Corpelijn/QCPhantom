using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCAnalyser.Data.Query.Database
{
    public class DatabaseQuery : IEnumerable
    {
        #region "Fields"

        private DataQuery query;
        private List<DatabaseParameter> parameters;
        private StringBuilder sb;

        #endregion

        #region "Constructors"

        public DatabaseQuery(DataQuery query)
        {
            this.query = query;
            parameters = new List<DatabaseParameter>();
        }

        #endregion

        #region "Properties"

        public string Query
        {
            get { return sb.ToString(); }
        }

        #endregion

        #region "Methods"

        public void Build()
        {
            sb = new StringBuilder();
            sb.Append("SELECT ");

            AddFields();

            sb.Append(" FROM ");

            AddTables();

            AddJoins();

            AddWheres();
        }

        private void AddFields()
        {
            if (query.Selects.Length == 0)
                sb.Append("*");
            else
            {
                foreach (string column in query.Selects)
                {
                    if (column.Contains(" "))
                        sb.Append("`");
                    sb.Append(column);
                    if (column.Contains(" "))
                        sb.Append("`");

                    sb.Append(",");
                }

                sb.Remove(sb.Length - 1, 1);
            }
        }

        private void AddTables()
        {
            foreach (string table in query.Tables)
            {
                sb.Append(table).Append(",");
            }

            sb.Remove(sb.Length - 1, 1);
        }

        private void AddJoins()
        {
            foreach(JoinData join in query.Joins)
            {
                sb.Append(" JOIN ");
                sb.Append(join.Table2);
                sb.Append(" ON ");
                sb.Append(join.Table1).Append(".").Append(join.Column1);
                sb.Append("=");
                sb.Append(join.Table2).Append(".").Append(join.Column2);
            }
        }

        private void AddWheres()
        {

        }

        #endregion

        #region "Abstract/Virtual Methods"

        public IEnumerator GetEnumerator()
        {
            foreach (DatabaseParameter parameter in parameters)
            {
                yield return parameter;
            }
        }

        #endregion

        #region "Inherited Methods"



        #endregion

        #region "Static Methods"



        #endregion

        #region "Operators"



        #endregion
    }
}
