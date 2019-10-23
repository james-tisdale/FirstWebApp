using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using FirstWebApp.Models;

namespace FirstWebApp
{
    public class EmployeeRepository
    {
        private string connectionString = "Server=localhost;Database=bestbuy;uid=root;Pwd=password";

        public List<Employee> GetAllEmployees()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Employees;";

            using(conn)
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                List<Employee> allEmployees = new List<Employee>();

                while(reader.Read() == true)
                {
                    Employee currentEmployee = new Employee();
                    try
                    {
                        currentEmployee.EmployeeID = reader.GetInt32("EmployeeID");  //emp ID
                    }
                    catch (System.Data.SqlTypes.SqlNullValueException)
                    {
                        currentEmployee.EmployeeID = 999999;
                    }

                    try
                    {
                        currentEmployee.FirstName = reader.GetString("FirstName");  //FirstName
                    }
                    catch (System.Data.SqlTypes.SqlNullValueException)
                    {
                        currentEmployee.FirstName = "null";
                    }

                    try
                    {
                        currentEmployee.LastName = reader.GetString("LastName");  //Last Name
                    }
                    catch (System.Data.SqlTypes.SqlNullValueException)
                    {
                        currentEmployee.LastName = "null";
                    }

                    try
                    {
                        currentEmployee.MiddleInitial = reader.GetString("MiddleInitial");  //MidInitial
                    }
                    catch (System.Data.SqlTypes.SqlNullValueException)
                    {
                        currentEmployee.MiddleInitial = "null";
                    }

                    try
                    {
                        currentEmployee.DateOfBirth = reader.GetString("DateOfBirth");  //DateOfBirth
                    }
                    catch (System.Data.SqlTypes.SqlNullValueException)
                    {
                        currentEmployee.DateOfBirth = "null";
                    }

                    try
                    {
                        currentEmployee.EmailAddress = reader.GetString("EmailAddress");  //email
                    }
                    catch (System.Data.SqlTypes.SqlNullValueException)
                    {
                        currentEmployee.EmailAddress = "null";
                    }

                    try
                    {
                        currentEmployee.PhoneNumber = reader.GetString("PhoneNumber");  //phone Number
                    }
                    catch (System.Data.SqlTypes.SqlNullValueException)
                    {
                        currentEmployee.PhoneNumber = "null";
                    }

                    try
                    {
                        currentEmployee.Title = reader.GetString("Title");  //title
                    }
                    catch (System.Data.SqlTypes.SqlNullValueException)
                    {
                        currentEmployee.Title = "null";
                    }

                    allEmployees.Add(currentEmployee);

                }

                return allEmployees;
            }


        }

    }
}
