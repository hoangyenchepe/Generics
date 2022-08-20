using System;
using WiredBrainCoffee.StorageApp.Data;
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Responsitories;

namespace WiredBrainCoffee.StorageApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext());
            AddEmployees(employeeRepository);
            AddManagers(employeeRepository);
            GetEmployeeById(employeeRepository);
            WriteAlltoConsole(employeeRepository);

            var organizationRepository = new ListRepository<Organization>();
            AddOrganizations(organizationRepository);
            WriteAlltoConsole(organizationRepository);

            Console.ReadLine();
        }

        private static void AddManagers(IWriteRepository<Manager> managerRepository)
        {
            managerRepository.Add(new Manager { FirstName = "Manager 1" });
            managerRepository.Add(new Manager { FirstName = "Manager 2" });
            managerRepository.Add(new Manager { FirstName = "Manager 3" });
            managerRepository.Save();
        }

        private static void WriteAlltoConsole(IReadRepository<IEntityBase> employeeRepository)
        {
            var items = employeeRepository.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        private static void GetEmployeeById(IRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.GetById(2);
            Console.WriteLine($"Employee with Id 2: {employee.FirstName}");
        }

        private static void AddEmployees(IRepository<Employee> employeeRepository)
        {
            employeeRepository.Add(new Employee { FirstName = "Susan" });
            employeeRepository.Add(new Employee { FirstName = "Phong" });
            employeeRepository.Add(new Employee { FirstName = "Yen" });
            employeeRepository.Save();
        }

        private static void AddOrganizations(IRepository<Organization> organizationRepository)
        {
            organizationRepository.Add(new Organization { FirstName = "Susan cute" });
            organizationRepository.Add(new Organization { FirstName = "Phong bede" });
            organizationRepository.Add(new Organization { FirstName = "Yen binh thuong" });
            organizationRepository.Save();
        }
    }
}
