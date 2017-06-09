using QCAnalyser.Data;
using QCAnalyser.Data.Query;
using QCAnalyser.Data.Sources;
using QCAnalyser.DICOM;
using QCAnalyser.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            DataManager.AddDataSource(MySqlDatabaseSource.Create("TestDB", "localhost", "qcphantom", "root", ""));
            DataSource source = DataManager.PrimarySource;
            source.Open();

            //Machine.ReadAll();

            Console.WriteLine("===== DataQuery =====");
            ResultTable table = source.ExecuteQuery(new DataQuery()
                .Join("study", "id", "image", "study_id")
                .Where("study", "id", QueryIdentifier.Equals, 2));

            foreach (ResultRow row in table)
            {
                for (int i = 0; i < row.ColumnCount; i++)
                {
                    Console.Write(row.GetData(row.GetColumn(i)) + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n\n===== SelectInstruction =====");
            table = source.ExecuteQuery("select * from study where study.id=?", 2);

            foreach (ResultRow row in table)
            {
                for (int i = 0; i < row.ColumnCount; i++)
                {
                    Console.Write(row.GetData(row.GetColumn(i)) + "\t");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
