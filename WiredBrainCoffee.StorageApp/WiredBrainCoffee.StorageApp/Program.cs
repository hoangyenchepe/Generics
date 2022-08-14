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
            AddEmployees(employeeRepository);
            GetEmployeeById(employeeRepository);

            var organizationRepository = new GenericRepository<Organization>();
            AddOrganizations(organizationRepository);

            Console.ReadLine();
        }

        private static void GetEmployeeById(GenericRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.GetById(2);
            Console.WriteLine($"Employee with Id 2: {employee.FirstName}");
        }

        private static void AddEmployees(GenericRepository<Employee> employeeRepository)
        {
            employeeRepository.Add(new Employee { FirstName = "Susan" });
            employeeRepository.Add(new Employee { FirstName = "Phong" });
            employeeRepository.Add(new Employee { FirstName = "Yen" });
            employeeRepository.Save();
        }

        private static void AddOrganizations(GenericRepository<Organization> organizationRepository)
        {
            organizationRepository.Add(new Organization { FirstName = "Susan cute" });
            organizationRepository.Add(new Organization { FirstName = "Phong bede" });
            organizationRepository.Add(new Organization { FirstName = "Yen binh thuong" });
            organizationRepository.Save();
        }
    }
}
