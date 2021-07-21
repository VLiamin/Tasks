using Homework3.Utils;
using System;
using System.Data.SqlClient;

namespace Homework3
{
    class Program
    {
        private static string rep = Environment.NewLine;

        static void Main(string[] args)
        {
            Print print = new Print();
            
            Program program = new Program();            
            using var sqlConn = new SqlConnection("Server=LAPTOP-QQUBGIB1\\SQLEXPRESS01;Database=Homework3;Trusted_Connection=True;");
            WorkWithDB workWithDB = new WorkWithDB(sqlConn);

            sqlConn.Open();

            program.createTable(NamesOfTables.Name1, sqlConn);
            program.createTable(NamesOfTables.Name2, sqlConn);
            program.createTable(NamesOfTables.Name3, sqlConn);
            program.createTable(NamesOfTables.Name4, sqlConn);
            program.createTable(NamesOfTables.Name5, sqlConn);

            while (true)
            {
                print.PrintInformation($@"Show tables?(Y/N)");
                print.PrintQuestion("Answer: ");

                if (print.ReadAnswer().Equals("Y"))
                {
                    workWithDB.ShowTables();
                }

                print.PrintInformation($@"{rep}1 - Work with Cars{rep}2 - Work with Taxis{rep}3 - Work with CarsAndTaxis
4 - Work with Routes{rep}5 - Work with Drivers{rep}6 - Exit");
                print.PrintQuestion("Value: ");
                string value = print.ReadAnswer();
                switch (value)
                {
                    case "1":
                        workWithDB.WorkWithTables("Cars");
                        break;
                    case "2":
                        workWithDB.WorkWithTables("Taxis");
                        break;
                    case "3":
                        workWithDB.WorkWithTables("TaxisAndCars");
                        break;
                    case "4":
                        workWithDB.WorkWithTables("Routes");
                        break;
                    case "5":
                        workWithDB.WorkWithTables("Drivers");
                        break;
                    case "6":
                        sqlConn.Close();
                        return;
                    default:
                        break;
                }
            }
        }

        public void createTable(string query, SqlConnection sqlConn)
        {
            try
            {
                var sqlCommand = new SqlCommand(query, sqlConn);
                sqlCommand.ExecuteNonQuery();
            }
            catch
            { }
        }
    }
}
