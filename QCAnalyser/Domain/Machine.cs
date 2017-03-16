using QCAnalyser.Data;
using QCAnalyser.Data.Query;
using System;
using System.Collections.Generic;

namespace QCAnalyser.Domain
{
    public class Machine
    {
        #region "Attributes"

        private string name;

        #endregion

        #region "Constructors"

        public Machine(int id, string name)
        {
            this.name = name;
        }

        #endregion

        #region "Properties"



        #endregion

        #region "Methods"



        #endregion

        #region "Static Methods"

        public static Machine[] ReadAll()
        {
            DataTable queryResult = DataManager.QueryResults(new DataQuery()
                .Select("machine", "id")
                .Select("machine", "name")
                );

            List<Machine> machines = new List<Machine>();

            foreach (DataRow row in queryResult)
            {
                Machine m = new Machine(Convert.ToInt32(row.GetData("id")), row.GetData("name").ToString());
                machines.Add(m);
            }

            return machines.ToArray();
        }

        #endregion

        #region "Inherited Methods"



        #endregion
    }
}