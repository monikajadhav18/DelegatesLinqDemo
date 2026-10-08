using DelegatesLinqDemo.Models;
using DelegatesLinqDemo.Services;

// ======================================================
// CREATE EMPLOYEES
// ======================================================

List<Employee> employees = new List<Employee>
{
    new Employee(1, "Monika", "IT", 65000, true),
    new Employee(2, "Rahul", "HR", 45000, true),
    new Employee(3, "Priya", "IT", 75000, true),
    new Employee(4, "Amit", "Finance", 55000, false),
    new Employee(5, "Sneha", "IT", 50000, true),
    new Employee(6, "Karan", "HR", 40000, false)
};


// ======================================================
// 1. ACTION
// ======================================================

Console.WriteLine("===== ACTION =====");

Action<Employee> printEmployee = employee =>
{
    Console.WriteLine($"Employee: {employee.Name}");
};

printEmployee(employees[0]);


// ======================================================
// 2. FUNC
// ======================================================

Console.WriteLine();
Console.WriteLine("===== FUNC =====");

Func<Employee, decimal> getSalary = employee =>
{
    return employee.Salary;
};

decimal salary = getSalary(employees[0]);

Console.WriteLine($"Salary: ₹{salary}");


// ======================================================
// 3. PREDICATE
// ======================================================

Console.WriteLine();
Console.WriteLine("===== PREDICATE =====");

Predicate<Employee> isActive = employee =>
{
    return employee.IsActive;
};

bool activeStatus = isActive(employees[0]);

Console.WriteLine(
    $"{employees[0].Name} Active: {activeStatus}"
);


// ======================================================
// 4. CALLBACK
// ======================================================

Console.WriteLine();
Console.WriteLine("===== CALLBACK =====");

EmployeeService employeeService = new EmployeeService();

employeeService.ProcessEmployee(
    employees[1],
    employee =>
    {
        Console.WriteLine(
            $"Callback executed for: {employee.Name}"
        );
    }
);


// ======================================================
// 5. EVENT
// ======================================================

Console.WriteLine();
Console.WriteLine("===== EVENT =====");

employeeService.EmployeeProcessed += employee =>
{
    Console.WriteLine(
        $"Event received: {employee.Name} was processed."
    );
};

employeeService.ProcessEmployee(
    employees[2],
    employee =>
    {
        Console.WriteLine(
            $"Processing callback: {employee.Name}"
        );
    }
);


// ======================================================
// 6. WHERE - ACTIVE EMPLOYEES
// ======================================================

Console.WriteLine();
Console.WriteLine("===== WHERE - ACTIVE EMPLOYEES =====");

var activeEmployees = employees
    .Where(employee => employee.IsActive);

foreach (Employee employee in activeEmployees)
{
    Console.WriteLine(employee);
}


// ======================================================
// 7. WHERE - SALARY GREATER THAN 50000
// ======================================================

Console.WriteLine();
Console.WriteLine("===== WHERE - SALARY > 50000 =====");

var highSalaryEmployees = employees
    .Where(employee => employee.Salary > 50000);

foreach (Employee employee in highSalaryEmployees)
{
    Console.WriteLine(employee);
}


// ======================================================
// 8. SELECT - EMPLOYEE NAMES
// ======================================================

Console.WriteLine();
Console.WriteLine("===== SELECT - EMPLOYEE NAMES =====");

var employeeNames = employees
    .Select(employee => employee.Name);

foreach (string name in employeeNames)
{
    Console.WriteLine(name);
}


// ======================================================
// 9. ORDERBY - SALARY ASCENDING
// ======================================================

Console.WriteLine();
Console.WriteLine("===== ORDER BY SALARY =====");

var employeesBySalary = employees
    .OrderBy(employee => employee.Salary);

foreach (Employee employee in employeesBySalary)
{
    Console.WriteLine(employee);
}


// ======================================================
// 10. ORDERBY + THENBY
// ======================================================

Console.WriteLine();
Console.WriteLine("===== ORDER BY DEPARTMENT + THEN BY SALARY =====");

var sortedEmployees = employees
    .OrderBy(employee => employee.Department)
    .ThenByDescending(employee => employee.Salary);

foreach (Employee employee in sortedEmployees)
{
    Console.WriteLine(employee);
}


// ======================================================
// 11. FIRST
// ======================================================

Console.WriteLine();
Console.WriteLine("===== FIRST =====");

Employee firstEmployee = employees.First();

Console.WriteLine(firstEmployee);


// ======================================================
// 12. FIRSTORDEFAULT
// ======================================================

Console.WriteLine();
Console.WriteLine("===== FIRST OR DEFAULT =====");

Employee? employeeNotFound =
    employees.FirstOrDefault(employee => employee.Id == 999);

if (employeeNotFound == null)
{
    Console.WriteLine("Employee not found.");
}
else
{
    Console.WriteLine(employeeNotFound);
}


// ======================================================
// 13. SINGLE
// ======================================================

Console.WriteLine();
Console.WriteLine("===== SINGLE =====");

Employee singleEmployee =
    employees.Single(employee => employee.Id == 1);

Console.WriteLine(singleEmployee);


// ======================================================
// 14. ANY
// ======================================================

Console.WriteLine();
Console.WriteLine("===== ANY =====");

bool hasInactiveEmployees =
    employees.Any(employee => !employee.IsActive);

Console.WriteLine(
    $"Has inactive employees: {hasInactiveEmployees}"
);


// ======================================================
// 15. ALL
// ======================================================

Console.WriteLine();
Console.WriteLine("===== ALL =====");

bool allEmployeesAbove20000 =
    employees.All(employee => employee.Salary > 20000);

Console.WriteLine(
    $"All employees earn above ₹20000: {allEmployeesAbove20000}"
);


// ======================================================
// 16. COUNT
// ======================================================

Console.WriteLine();
Console.WriteLine("===== COUNT =====");

int itEmployeeCount =
    employees.Count(employee => employee.Department == "IT");

Console.WriteLine(
    $"IT employees: {itEmployeeCount}"
);


// ======================================================
// 17. COMBINED LINQ QUERY
// ======================================================

Console.WriteLine();
Console.WriteLine("===== COMBINED LINQ QUERY =====");

var result = employees
    .Where(employee =>
        employee.IsActive &&
        employee.Department == "IT" &&
        employee.Salary > 50000)
    .OrderByDescending(employee => employee.Salary)
    .Select(employee => employee.Name);

foreach (string name in result)
{
    Console.WriteLine(name);
}