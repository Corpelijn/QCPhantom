using QCAnalyser.Data.Sources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCAnalyser.Data.Query
{
    public class ResultTable : IEnumerable
    {
        #region "Attributes"

        private string[] columns;
        private List<object[]> data;
        private DataSource source;

        #endregion

        #region "Constructors"

        /// <summary>
        /// Creates a new instance of a DataTable object
        /// </summary>
        /// <param name="reader">A DbDataReader object containing data from an executed query against a database</param>
        /// <param name="source">The data source that provided the data in the DbDataReader</param>
        public ResultTable(DbDataReader reader, DataSource source)
        {
            ParseDatabaseResults(reader);
            this.source = source;
        }

        #endregion

        #region "Properties"

        /// <summary>
        /// Gets the fields in the DataTable
        /// </summary>
        public string[] Columns
        {
            get { return columns.ToArray(); }
        }

        /// <summary>
        /// Gets the amount of rows in the ResultTable
        /// </summary>
        public int RowCount
        {
            get { return data.Count; }
        }

        /// <summary>
        /// Gets the amount of columns in the ResultTable
        /// </summary>
        public int ColumnCount
        {
            get { return columns.Length; }
        }

        /// <summary>
        /// Gets all values from the specified column
        /// </summary>
        /// <param name="column">The name of the column to read</param>
        /// <returns>An array of values from the specified column</returns>
        public object[] this[string column]
        {
            get { return GetAllDataFromColumn(column); }
        }

        /// <summary>
        /// Gets the first value from the first column of the first row
        /// </summary>
        public object FirstValue
        {
            get { return GetFirstColumnFromFirstRow(); }
        }

        /// <summary>
        /// Gets all the values from the specified row
        /// </summary>
        /// <param name="row">The index of the row to get the data from</param>
        /// <returns>An array of values from the specified row</returns>
        public object[] this[int row]
        {
            get { return GetDataFromRow(row); }
        }

        /// <summary>
        /// Gets the source the data came from
        /// </summary>
        public DataSource Source
        {
            get { return source; }
        }

        #endregion

        #region "Methods"

        /// <summary>
        /// Gets all data from the specified column
        /// </summary>
        /// <param name="column">The name of the column to get the data from</param>
        /// <returns>An array of values from the specified column</returns>
        public object[] GetAllDataFromColumn(string column)
        {
            int index = Array.IndexOf(columns, column);
            if (index == -1)
                return new string[] { };

            List<object> allData = new List<object>();
            foreach (object[] data in this.data)
            {
                allData.Add(data[index]);
            }

            return allData.ToArray();
        }

        /// <summary>
        /// Gets all data from the specifed row
        /// </summary>
        /// <param name="row">The index of the row to get the data from</param>
        /// <returns>An array of values from the specified row</returns>
        public object[] GetDataFromRow(int row)
        {
            if (data.Count == 0 || row <= data.Count)
                return new object[] { };
            return data[row];
        }

        /// <summary>
        /// Gets the results from the specified row as a ResultRow
        /// </summary>
        /// <param name="row">The index of the row to get data from</param>
        /// <returns>A ResultRow object containing the data from the row</returns>
        public ResultRow GetResultRowFromRow(int row)
        {
            if (row < 0 || row >= data.Count)
                return null;
            return new ResultRow(columns, data[row]);
        }

        /// <summary>
        /// Gets the first object from the first column in the first row
        /// </summary>
        /// <returns>The value at the first column and row</returns>
        public object GetFirstColumnFromFirstRow()
        {
            if (data.Count == 0)
                return new object[] { };
            return data[0][0];
        }

        /// <summary>
        /// Reads the data from the given DataReader and stores it into the table. Added is the source of the data
        /// </summary>
        /// <param name="reader">The DataReader from which the results can be read</param>
        /// <param name="source">The DataSource from where the data is coming from. This is needed for adding the origin of the data</param>
        private void ParseDatabaseResults(DbDataReader reader)
        {
            // Convert the DataReader to a schema table
            System.Data.DataTable dt = reader.GetSchemaTable();

            // Read the amount of fields from the schema table. Add one extra for the DataSource
            columns = new string[reader.FieldCount];
            // Read the names of the fields from the schema table
            for (int i = 0; i < columns.Length; i++)
            {
                columns[i] = dt.TableName.ToLower() + "." + reader.GetName(i).ToLower();
            }

            // Get rid of the schema table (we don't need it anymore)
            dt.Dispose();

            data = new List<object[]>();
            while (reader.Read())
            {
                // Read the data for each row/record in the DataReader
                List<object> dat = new List<object>();
                for (int i = 0; i < columns.Length; i++)
                {
                    dat.Add(reader.GetValue(i));
                }

                // Put the total into the list of data
                data.Add(dat.ToArray());
            }

            // Close and dispose the DataReader
            reader.Close();
            reader.Dispose();
        }

        #endregion

        #region "Static Methods"

        #endregion

        #region "Inherited Methods"

        /// <summary>
        /// Gets an enumerator to loop through an foreach loop
        /// </summary>
        /// <returns>An IEnumerator object containing data for the foreach loop</returns>
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < data.Count; i++)
            {
                yield return new ResultRow(columns, data[i]);
            }
        }

        #endregion
    }
}
