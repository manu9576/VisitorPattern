using System.Collections.Generic;

namespace WithoutVisitorPattern
{
    public class Employee
    {
        public string EmployeeId
        {
            get;
            set;
        }

        public string EmployeeName
        {
            get;
            set;
        }

        public List<MonthlySalary_Earning> MonthlySalary_Earnings = new List<MonthlySalary_Earning>();

        public List<MonthlySalary_Deduction> MonthlySalary_Deductions = new List<MonthlySalary_Deduction>();

        public List<AnnualInvestment> AnnualInvestments = new List<AnnualInvestment>();

        public List<MonthlyExpense> MonthlyExpenses = new List<MonthlyExpense>();

    }
}

