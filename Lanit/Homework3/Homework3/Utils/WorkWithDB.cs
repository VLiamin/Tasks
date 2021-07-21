using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3.Utils
{

    /// <summary>
    /// Class that works with T-SQL
    /// </summary>
    public class WorkWithDB
    {
        private SqlConnection sqlConn;
        private static string rep = Environment.NewLine;
        private Print print;

        public WorkWithDB(SqlConnection sqlConn)
        {
            this.sqlConn = sqlConn;
            print = new Print();
        }

        /// <summary>
        /// Method that prints all tables
        /// </summary>
        public void ShowTables()
        {
            var query = "select * from Cars";
            print.PrintResult($"{rep}     Cars{rep}Id | Firm |  Model | Country |{rep}");
            ShowTheTable(query, 4);

            query = "select * from Taxis";
            print.PrintResult($"{rep}     Taxis{rep}Id | Name |  Phone | CarsNumber |{rep}");
            ShowTheTable(query, 4);

            query = "select * from TaxisAndCars";
            print.PrintResult($"{rep}     TaxisAndCars{rep}TaxisId | CarsId |{rep}");
            ShowTheTable(query, 2);

            query = "select * from Routes";
            print.PrintResult($"{rep}     Routes{rep}Id | Length |  Cost | DrevirId |{rep}");
            ShowTheTable(query, 4);

            query = "select * from Drivers";
            print.PrintResult($"{rep}     Drivers{rep}Id | Name |  Car |{rep}");
            ShowTheTable(query, 3);

        }

        private void ShowTheTable(string query, int number)
        {
            var sqlCommand = new SqlCommand(query, sqlConn);
            using var reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                for (int i = 0; i < number; i++)
                {
                    print.PrintResult(reader[i] + "  |  ");
                }
                print.PrintInformation("");
            }
            print.PrintInformation("");
        }

        /// <summary>
        /// Method that works with tables of database
        /// </summary>
        /// <param name="table"> Name of the table</param>
        public void WorkWithTables(string table)
        {
            print.PrintInformation($"{rep}1 - Insert to table{rep}2 - Update table{rep}3 - Delete from table");
            print.PrintQuestion("Value: ");
            string value = print.ReadAnswer();
            string query = "";
            try
            {
                switch (value)
                {
                    case "1":
                        query = InsetToTable(table);
                        break;
                    case "2":
                        query = UpdateTable(table);
                        break;
                    case "3":
                        query = DeleteFromTable(table);
                        break;
                    default:
                        break;
                }

                DoQuery(query);
            } 
            catch (Exception e)
            {
                print.PrintError(e.Message);
            }

        }

        private string InsetToTable(string table)
        {
            switch (table)
            {
                case "Cars":
                    print.PrintQuestion("Firm: ");
                    string firm = print.ReadAnswer();
                    print.PrintQuestion("Model: ");
                    string model = print.ReadAnswer();
                    print.PrintQuestion("Country: ");
                    string country = print.ReadAnswer();
                    return $"Insert Cars(Firm, Model, Country) values ('{firm}', '{model}', '{country}')";
                case "Drivers":
                    print.PrintQuestion("Name: ");
                    string name = print.ReadAnswer();
                    print.PrintQuestion("Car: ");
                    string car = print.ReadAnswer();
                    return $"Insert Drivers(Name, Car) values ('{name}', '{car}')";
                case "Routes":
                    print.PrintQuestion("Length: ");
                    int length = int.Parse(print.ReadAnswer());
                    print.PrintQuestion("Cost: ");
                    int cost = int.Parse(print.ReadAnswer());
                    print.PrintQuestion("DriverId: ");
                    int driverId = int.Parse(print.ReadAnswer());
                    return $"Insert Routes(Length, Cost, DriverId) values ({length}, {cost}, {driverId})";
                case "Taxis":
                    print.PrintQuestion("Name: ");
                    name = print.ReadAnswer();
                    print.PrintQuestion("Phone: ");
                    string phone = print.ReadAnswer();
                    print.PrintQuestion("CarsNumber: ");
                    int carsNumber = int.Parse(print.ReadAnswer());
                    return $"Insert Taxis(Name, Phone, CarsNumber) values ('{name}', '{phone}', {carsNumber})";
                case "TaxisAndCars":
                    print.PrintQuestion("IdTaxi: ");
                    int taxiId = int.Parse(print.ReadAnswer());
                    print.PrintQuestion("IdCar: ");
                    int carId = int.Parse(print.ReadAnswer());
                    return $"Insert TaxisAndCars(IdTaxi, IdCar) values ({taxiId}, {carId})";
                default:
                    return "";
            }

        }

        private string UpdateTable(string table)
        {
            print.PrintQuestion($"{rep}Id of value: ");
            int Id = int.Parse(print.ReadAnswer());

            switch (table)
            {
                case "Cars":

                    print.PrintInformation($"{rep}Firm{rep}Model{rep}Country");
                    print.PrintQuestion("Name: ");
                    string name = print.ReadAnswer();
                    print.PrintQuestion("New value: ");
                    string newValue = print.ReadAnswer();
                    return $"update {table} set {name} = '{newValue}' where Id = {Id}";
                case "Drivers":
                    print.PrintInformation($"{rep}Name{rep}Car{rep}RouteId");
                    print.PrintQuestion("Name: ");
                    name = print.ReadAnswer();
                    print.PrintQuestion("New value: ");
                    newValue = print.ReadAnswer();
                    return $"update {table} set {name} = '{newValue}' where Id = {Id}";
                case "Routes":
                    print.PrintInformation($"{rep}Length{rep}Cost{rep}DriverId");
                    print.PrintQuestion("Name: ");
                    name = print.ReadAnswer();
                    print.PrintQuestion("New value: ");
                    int newValue2 = int.Parse(print.ReadAnswer());
                    return $"update {table} set {name} = {newValue2} where Id = {Id}";
                case "Taxis":
                    print.PrintInformation($"{rep}Name{rep}Phone{rep}CarsNumber");
                    print.PrintQuestion("Name: ");
                    name = print.ReadAnswer();
                    print.PrintQuestion("New value: ");
                    newValue = print.ReadAnswer();
                    if (name.Equals("CarsNumber"))
                    {
                        int number = int.Parse(newValue);
                        return $"update {table} set {name} = {number} where Id = {Id}";
                    }
                    return $"update {table} set {name} = '{newValue}' where Id = {Id}";
                case "TaxisAndCars":
                    print.PrintInformation($"{rep}IdTaxi{rep}IdCar");
                    print.PrintQuestion("Name: ");
                    name = print.ReadAnswer();
                    print.PrintQuestion("New value: ");
                    newValue2 = int.Parse(print.ReadAnswer());
                    return $"update {table} set {name} = {newValue2} where Id = {Id}";
                default:
                    return "";
            }
        }

        private string DeleteFromTable(string table)
        {
            print.PrintQuestion($"{rep}Id of value: ");
            int Id = int.Parse(print.ReadAnswer());
            return $"Delete from {table} where id = {Id}";
        }

        private void DoQuery(string query)
        {
            var sqlCommand = new SqlCommand(query, sqlConn);
            sqlCommand.ExecuteNonQuery();
        }
    }
}
