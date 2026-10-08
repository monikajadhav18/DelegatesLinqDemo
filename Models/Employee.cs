namespace DelegatesLinqDemo.Models;

public class Employee
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Department { get; set; }

    public decimal Salary { get; set; }

    public bool IsActive { get; set; }

    public Employee(
        int id,
        string name,
        string department,
        decimal salary,
        bool isActive)
    {
        Id = id;
        Name = name;
        Department = department;
        Salary = salary;
        IsActive = isActive;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Name: {Name}, Department: {Department}, Salary: ₹{Salary}, Active: {IsActive}";
    }
}