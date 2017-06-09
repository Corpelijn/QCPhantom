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
            ResultTable queryResult = DataManager.PrimarySource.ExecuteQuery(new DataQuery()
                .From("Machine")
                );

            List<Machine> machines = new List<Machine>();

            foreach (ResultRow row in queryResult)
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