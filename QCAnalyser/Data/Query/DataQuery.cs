using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCAnalyser.Data.Query
{
    public class DataQuery
    {
        #region "Fields"

        private List<string> selectColumns;
        private List<string> tables;
        private List<JoinData> joins;
        private List<WhereData> wheres;

        private int whereIndex;

        #endregion

        #region "Constructors"

        public DataQuery()
        {
            selectColumns = new List<string>();
            tables = new List<string>();
            joins = new List<JoinData>();
            wheres = new List<WhereData>();

            whereIndex = 0;
        }

        #endregion

        #region "Properties"

        public string[] Selects
        {
            get { return selectColumns.ToArray(); }
        }

        public string[] Tables
        {
            get { return tables.ToArray(); }
        }

        public JoinData[] Joins
        {
            get { return joins.ToArray(); }
        }

        public WhereData[] Wheres
        {
            get { return wheres.ToArray(); }
        }

        #endregion

        #region "Methods"

        public DataQuery Select(string table, string column)
        {
            // Check and add the table to the list
            From(table);

            if (!selectColumns.Contains(table + "." + column))
                selectColumns.Add(table + "." + column);

            return this;
        }

        public DataQuery Select(string column)
        {
            if (!selectColumns.Contains(column))
                selectColumns.Add(column);

            return this;
        }

        public DataQuery From(string table)
        {
            if (!tables.Contains(table))
                tables.Add(table);

            return this;
        }

        public DataQuery Join(string tableA, string columnA, string tableB, string columnB)
        {
            if (!tables.Contains(tableA))
                tables.Add(tableA);

            joins.Add(new JoinData(tableA, columnA, tableB, columnB));
            return this;
        }

        public DataQuery ParenthesisOpen()
        {
            wheres.Add(new WhereData(NextWhereIndex(), "("));
            return this;
        }

        public DataQuery ParenthesisClose()
        {
            wheres.Add(new WhereData(NextWhereIndex(), ")"));
            return this;
        }

        public DataQuery Where(string table, string column, QueryIdentifier identifier, object compareTo)
        {
            whereIndex = NextWhereIndex();
            return this;
        }

        public DataQuery And(string table, string column, QueryIdentifier identifier, object compareTo)
        {
            whereIndex = NextWhereIndex();
            return this;
        }

        public DataQuery Or(string table, string column, QueryIdentifier identifier, object compareTo)
        {
            whereIndex = NextWhereIndex();
            return this;
        }

        private int NextWhereIndex()
        {
            int result = whereIndex;
            whereIndex++;
            return result;
        }

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
