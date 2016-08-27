using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCAnalyser.Data.Query
{
    public class DataRow
    {
        #region "Attributes"

        private string[] fields;
        private object[] data;

        #endregion

        #region "Constructors"

        /// <summary>
        /// Creates a new instance of a DataRow
        /// </summary>
        /// <param name="fields">The fields that are in this DataRow object</param>
        /// <param name="data">The actual data of the DataRow</param>
        public DataRow(string[] fields, object[] data)
        {
            this.fields = fields;
            this.data = data;
        }

        #endregion

        #region "Properties"

        #endregion

        #region "Methods"

        /// <summary>
        /// Gets the name of a field in the DataRow
        /// </summary>
        /// <param name="index">The index of the field to get</param>
        /// <returns>The name of the field as string</returns>
        public string GetField(int index)
        {
            return fields[index];
        }

        /// <summary>
        /// Gets the data from the field at the given index
        /// </summary>
        /// <param name="index">The index of the field the data needs to be fetched from</param>
        /// <returns>The data from the given field index</returns>
        public object GetData(int index)
        {
            return data[index];
        }

        /// <summary>
        /// Gets the amount of fields in the DataRow
        /// </summary>
        /// <returns>The amount of field</returns>
        public int GetFieldCount()
        {
            return fields.Length;
        }

        /// <summary>
        /// Gets the data from the given field
        /// </summary>
        /// <param name="field">The name of the field to get the data from</param>
        /// <returns>The data from the given field</returns>
        public object GetData(string field)
        {
            // Find the index of the given fieldname
            int index = -1;
            for (int i = 0; i < fields.Length; i++)
            {
                if (fields[i].ToLower().EndsWith(field.ToLower()))
                {
                    // Store the index
                    index = i;
                }
            }

            // Check if the field was found
            if (index == -1)
                return null;

            // Return the data at the given index
            return data[index];
        }

        #endregion

        #region "Static Methods"
        #endregion

        #region "Inherited Methods"
        #endregion
    }
}
