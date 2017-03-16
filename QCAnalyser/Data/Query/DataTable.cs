using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCAnalyser.Data.Query
{
    public class DataTable : IEnumerable
    {
        #region "Attributes"

        private string[] fields;
        private List<object[]> data;

        #endregion

        #region "Constructors"

        /// <summary>
        /// Creates a new instance of a DataTable object
        /// </summary>
        /// <param name="reader">A DbDataReader object containing data from an executed query against a database</param>
        /// <param name="source">The data source that provided the data in the DbDataReader</param>
        public DataTable(DbDataReader reader, DataSource source)
        {
            ReadDataReader(reader, source);
        }

        #endregion

        #region "Properties"

        /// <summary>
        /// Gets the fields in the DataTable
        /// </summary>
        public string[] Fields
        {
            get { return fields.ToArray(); }
        }

        #endregion

        #region "Methods"

        /// <summary>
        /// Merges the data from current DataTable with an other DataTable object
        /// </summary>
        /// <param name="table">The DataTable object to merge the current DataTable with</param>
        /// <returns>A DataTable object with the added data from the other DataTable</returns>
        public DataTable Merge(DataTable table)
        {
            // Check if the tables to merge are not the same
            if (this == table)
                return this;

            // Check if the given table has the same columns as the current table
#warning "Does it check the address space on RAM or the content of the list?"
            if (fields != table.fields)
                return this;

            // Add the data from he given table to the current table
            this.data.AddRange(table.data);

            return this;
        }

        /// <summary>
        /// Reads the data from the given DataReader and stores it into the table. Added is the source of the data
        /// </summary>
        /// <param name="reader">The DataReader from which the results can be read</param>
        /// <param name="source">The DataSource from where the data is coming from. This is needed for adding the origin of the data</param>
        private void ReadDataReader(DbDataReader reader, DataSource source)
        {
            // Convert the DataReader to a schema table
            System.Data.DataTable dt = reader.GetSchemaTable();

            // Read the amount of fields from the schema table. Add one extra for the DataSource
            fields = new string[reader.FieldCount + 1];
            // Read the names of the fields from the schema table
            for (int i = 0; i < fields.Length - 1; i++)
            {
                fields[i] = dt.TableName + "." + reader.GetName(i);
            }
            // Set the last field to DataSource
            fields[fields.Length - 1] = "DataSource";

            // Get rid of the schema table (we don't need it anymore)
            dt.Dispose();

            data = new List<object[]>();
            while (reader.Read())
            {
                // Read the data for each row/record in the DataReader
                List<object> dat = new List<object>();
                for (int i = 0; i < fields.Length -1; i++)
                {
                    dat.Add(reader.GetValue(i));
                }
                // Add an extra value for the DataSource
                dat.Add(source);

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
            for(int i = 0; i<data.Count; i++)
            {
                yield return new DataRow(fields, data[i]);
            }
        }

        #endregion
    }
}
