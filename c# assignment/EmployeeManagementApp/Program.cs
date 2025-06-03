using EmployeeManagementApp;

class Program
{
    static void Main(string[] args)
    {
        // Base Employee
        Employee emp1 = new Employee
        {
            EmpCode = 101,
            EmpName = "John Doe",
            Email = "john.doe@abctech.com",
            DeptName = "IT",
            Location = "New York"
        };

        // Full Time Employee
        FullTimeEmployee fte = new FullTimeEmployee { Basic = 50000 };
        fte.CalculateSalary();
        Console.WriteLine(fte.PrintEmployeeDetails(emp1));

        // Another Employee
        Employee emp2 = new Employee
        {
            EmpCode = 102,
            EmpName = "Jane Smith",
            Email = "jane.smith@abctech.com",
            DeptName = "HR",
            Location = "San Francisco"
        };

        // Part Time Employee
        PartTimeEmployee pte = new PartTimeEmployee { Basic = 20000 };
        pte.CalculateSalary();
        Console.WriteLine(pte.PrintEmployeeDetails(emp2));
    }
}
