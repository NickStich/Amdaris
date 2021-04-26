using System;
using System.Data.SqlClient;

namespace ADO.NETassign
{
    public class Program
    {
        static void Main(string[] args)
        {
            var con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=ADO.NETgo;Integrated Security=True");
            string personQuery = @"CREATE TABLE person (           
                                   id INT NOT NULL,
                                   FirstName VARCHAR(45) NOT NULL,
                                   LastName VARCHAR(45) NOT NULL,
                                   car_id INT NULL,
                                   PRIMARY KEY (id))";
            string carQuery = @"CREATE TABLE car (           
                                   id INT NOT NULL,
                                   Model VARCHAR(45) NOT NULL,
                                   TotalCost INT NOT NULL,
                                   PRIMARY KEY (id))";

            var crud = new CRUDsql();
            //crud.CreateTable(con, personQuery);
            //crud.CreateTable(con, carQuery);

            var insertText = "INSERT INTO person(id,FirstName,LastName,car_id) VALUES (1,'Nicolae','Stici',1) ;";
            var insertCar = "INSERT INTO car(id, Model, TotalCost) VALUES (1,'Ford Mustang',32500), (2,'Porche 911',64300),(3,'Tesla Model S',48000);";
            //crud.InsertTable(con, insertText);
            //crud.InsertTable(con,insertCar);

            var selectText = "Select * from person";
            //crud.SelectTable(con,selectText);

            var updateCar = "UPDATE car set TotalCost = 100000 where Model like '%Porche%'";
            //crud.Update(con, updateCar);

            var deleteCar = "DELETE car where Model like '%Tesla%'";
            crud.Delete(con, deleteCar);
        }
    }
}
