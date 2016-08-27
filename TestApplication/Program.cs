using QCAnalyser.Data;
using QCAnalyser.Data.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            DataManager.AddDatabaseSource("TestDB", "localhost", "qcphantom", "root", "");
            DataTable table = DataManager.QueryResults(new DataQuery()
                .Select("test", "id")
                .Select("test", "data")
                .Where("test", "data", Identifier.NOT_EQUALS_TO, 0)
                );

            foreach(string field in table.Fields)
            {
                Console.Write(field + "\t");
            }
            Console.WriteLine();
            foreach (DataRow row in table)
            {
                Console.WriteLine(row.GetData(0) + "\t\t" + row.GetData(1) + "\t\t\t" + ((DataSource)row.GetData(2)).Name);
            }

            Console.ReadKey();
        }
    }
}
