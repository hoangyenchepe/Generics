using System;
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Responsitories;

namespace WiredBrainCoffee.StorageApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeRepository = new EmployeeRepository();
            employeeRepository.Add(new Employee { FirstName = "Susan" });
            employeeRepository.Add(new Employee { FirstName = "Phong" });
            employeeRepository.Add(new Employee { FirstName = "Yen" });
            employeeRepository.Save();

            Console.ReadLine();
        }
    }
}
