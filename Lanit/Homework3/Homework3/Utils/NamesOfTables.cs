using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    public class NamesOfTables
    {
        public const string Name1 = @"CREATE TABLE Taxis (
           Id      INT primary key IDENTITY(1,1),
           Name NVARCHAR (MAX)     NOT NULL,
           Phone  NVARCHAR (MAX)     NOT NULL, 
           CarsNumber int                NOT NULL,
         )";

        public const string Name2 = @"CREATE TABLE Cars (
           Id      INT primary key IDENTITY(1,1),
           Firm  NVARCHAR (MAX)     NOT NULL, 
           Model NVARCHAR (MAX)     NOT NULL, 
           Country NVARCHAR (MAX)     NOT NULL,
         )";

        public const string Name3 = @"CREATE TABLE TaxisAndCars (
           IdTaxi      INT references Taxis (Id),
           IdCar  INT references Cars (Id), 
         )";

        public const string Name4 = @"CREATE TABLE Routes (
           Id      INT primary key IDENTITY(1,1),
           Length INT,
           Cost INT                NOT NULL,
           DriverId  INT     NOT NULL UNIQUE, 
         )";

        public const string Name5 = @"CREATE TABLE Drivers (
           Id      INT primary key IDENTITY(1,1),
           Name NVARCHAR (MAX)     NOT NULL,
           Car  NVARCHAR (MAX)     NOT NULL, 
         )";
    }
}
