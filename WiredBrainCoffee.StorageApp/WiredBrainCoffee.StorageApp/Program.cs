using System;
using WiredBrainCoffee.StorageApp.Data;
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Repositories;
using WiredBrainCoffee.StorageApp.Responsitories;

namespace WiredBrainCoffee.StorageApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext());
            employeeRepository.ItemAdded += EmployeeRepository_ItemAdded;
            AddEmployees(employeeRepository);
            AddManagers(employeeRepository);
            GetEmployeeById(employeeRepository);
            WriteAlltoConsole(employeeRepository);

            var organizationRepository = new ListRepository<Organization>();
            AddOrganizations(organizationRepository);
            WriteAlltoConsole(organizationRepository);

            Console.ReadLine();
        }

        private static void EmployeeRepository_ItemAdded(object? sender, Employee e)
        {
            Console.WriteLine($"Employee added => {e.FirstName}");
        }
       
        private static void AddManagers(IWriteRepository<Manager> managerRepository)
        {
            var saraManager = new Manager { FirstName = "Manager 1" };
            var saraManagerCopy = saraManager.Copy();
            managerRepository.Add(saraManager);
            if (saraManagerCopy is not null)
            {
                saraManagerCopy.FirstName += "_Copy";
                managerRepository.Add(saraManagerCopy);
            }

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
            var employees = new[]
            {
                new Employee { FirstName = "Susan" },
                new Employee { FirstName = "Phong" },
                new Employee { FirstName = "Yen" }
            };

            employeeRepository.AddBatch(employees);
        }

        private static void AddOrganizations(IRepository<Organization> organizationRepository)
        {
            var organizations = new[]
            {
                new Organization { FirstName ="Susan cute"},
                new Organization { FirstName = "Phong bede" }
            };

            RepositoryExtensions.AddBatch(organizationRepository, organizations);
        }
    }
}
