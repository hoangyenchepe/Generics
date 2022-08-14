using System;
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Responsitories;

namespace WiredBrainCoffee.StorageApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeRepository = new GenericRepository<Employee>();
            employeeRepository.Add(new Employee { FirstName = "Susan" });
            employeeRepository.Add(new Employee { FirstName = "Phong" });
            employeeRepository.Add(new Employee { FirstName = "Yen" });
            employeeRepository.Save();

            var organizationRepository = new GenericRepository<Organization>();
            organizationRepository.Add(new Organization { FirstName = "Susan cute" });
            organizationRepository.Add(new Organization { FirstName = "Phong bede" });
            organizationRepository.Add(new Organization { FirstName = "Yen binh thuong" });
            organizationRepository.Save();

            Console.ReadLine();
        }
    }
}
