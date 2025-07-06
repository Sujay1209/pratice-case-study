enum Department {
  HR = 'HR',
  IT = 'IT',
  Sales = 'Sales'
}

interface Employee {
  name: string;
  age: number;
  department: Department;
  baseSalary: number;
}

class SalaryManager {
  static calculateBonus(department: Department, baseSalary: number): number {
    let bonusRate = 0;
    switch (department) {
      case Department.HR:
        bonusRate = 0.10;
        break;
      case Department.IT:
        bonusRate = 0.15;
        break;
      case Department.Sales:
        bonusRate = 0.12;
        break;
    }
    return baseSalary * bonusRate;
  }

  static categorizeEmployee(netSalary: number): string {
    if (netSalary >= 80000) {
      return 'High Earner';
    } else if (netSalary >= 50000) {
      return 'Mid Earner';
    } else {
      return 'Low Earner';
    }
  }

  static displayEmployeeReport(employee: Employee): void {
    const bonus = this.calculateBonus(employee.department, employee.baseSalary);
    const netSalary = employee.baseSalary + bonus;
    const category = this.categorizeEmployee(netSalary);

    console.log(`Employee Name: ${employee.name}`);
    console.log(`Age: ${employee.age}`);
    console.log(`Department: ${employee.department}`);
    console.log(`Base Salary: ₹${employee.baseSalary}`);
    console.log(`Net Salary (with bonus): ₹${netSalary}`);
    console.log(`Category: ${category}`);
    console.log('------------------------');
  }
}

// Sample employee data
const employees: Employee[] = [
  { name: 'Ravi', age: 28, department: Department.IT, baseSalary: 60000 },
  { name: 'Priya', age: 32, department: Department.HR, baseSalary: 48000 },
  { name: 'Arjun', age: 26, department: Department.Sales, baseSalary: 85000 }
];

// Generate reports
for (const emp of employees) {
  SalaryManager.displayEmployeeReport(emp);
}
