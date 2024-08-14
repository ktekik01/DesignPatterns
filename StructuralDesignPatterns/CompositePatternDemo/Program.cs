using System;
using System.Collections.Generic;

// Component
interface IEmployee
{
    string GetName();
    void SetName(string name);
    void Display();
}

// Leaf
class Employee : IEmployee
{
    private string name;

    public Employee(string name)
    {
        this.name = name;
    }

    public string GetName() => name;

    public void SetName(string name)
    {
        this.name = name;
    }

    public void Display()
    {
        Console.WriteLine($"Employee: {name}");
    }
}

// Composite
class Department : IEmployee
{
    private string name;
    private List<IEmployee> employees;

    public Department(string name)
    {
        this.name = name;
        this.employees = new List<IEmployee>();
    }

    public string GetName() => name;

    public void SetName(string name)
    {
        this.name = name;
    }

    public void AddEmployee(IEmployee employee)
    {
        employees.Add(employee);
    }

    public void RemoveEmployee(IEmployee employee)
    {
        employees.Remove(employee);
    }

    public void Display()
    {
        Console.WriteLine($"Department: {name}");
        foreach (var employee in employees)
        {
            employee.Display();
        }
    }
}

// Client
class Program
{
    static void Main(string[] args)
    {
        // Creating employees
        IEmployee employee1 = new Employee("John Doe");
        IEmployee employee2 = new Employee("Jane Smith");

        // Creating a department
        Department salesDepartment = new Department("Sales");
        salesDepartment.AddEmployee(employee1);
        salesDepartment.AddEmployee(employee2);

        // Nested department
        Department itDepartment = new Department("IT");
        itDepartment.AddEmployee(new Employee("Alice Brown"));
        itDepartment.AddEmployee(new Employee("Bob Johnson"));

        // Adding nested departments to the main department
        Department company = new Department("Company");
        company.AddEmployee(salesDepartment);
        company.AddEmployee(itDepartment);

        // Displaying the organizational structure
        company.Display();
    }
}
