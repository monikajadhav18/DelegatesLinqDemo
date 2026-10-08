using DelegatesLinqDemo.Models;

namespace DelegatesLinqDemo.Services;

public class EmployeeService
{
    public event Action<Employee>? EmployeeProcessed;

    public void ProcessEmployee(
        Employee employee,
        Action<Employee> callback)
    {
        Console.WriteLine();
        Console.WriteLine("Processing employee...");

        callback(employee);

        EmployeeProcessed?.Invoke(employee);
    }
}