using System;
using System.Globalization;

namespace VisitorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ExecutionWithoutVisitorPattern();

            ExecutionWithVisitorPattern();
        }

        private static void ExecutionWithVisitorPattern()
        {

            WithVisitorPattern.Employee emp = new WithVisitorPattern.Employee
                {
                    EmployeeId = "XYZ1001",
                    EmployeeName = "Banketeshvar Narayan Sharma"
                };
                AddDataForEmployee(emp);
                var netAnnualEarningVisitor = new WithVisitorPattern.NetAnnualEarningVisitor();
                var annualTaxableAmount = new WithVisitorPattern.TaxableAmountVisitor();
                emp.Accept(netAnnualEarningVisitor);
                emp.Accept(annualTaxableAmount);
                Console.WriteLine("Annual Net Earning Amount : {0}", netAnnualEarningVisitor.NetEarningoftheYear);
                Console.WriteLine("Annual Taxable Amount : {0}", annualTaxableAmount.TaxableAmount);
                Console.ReadKey();
            }

        private static void AddDataForEmployee(WithVisitorPattern.Employee emp)
            {
                for (int i = 1; i <= 12; i++)
                {
                    emp.Salaries.Add(new WithVisitorPattern.MonthlySalary_Earning
                    {
                        MonthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(i),
                        BasicSalary = 120000,
                        HRAExemption = 50000,
                        ConveyanceAllowance = 1600,
                        PersonalAllowance = 45000,
                        MedicalAllowance = 1500,
                        TelephoneBill = 2500,
                        FoodCard_Bill = 3000,
                        OtherBills = 35000
                    });
                    emp.Salaries.Add(new WithVisitorPattern.MonthlySalary_Deduction
                    {
                        MonthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(i),
                        ProvidentFund_EmployeeContribution = 8000,
                        ProvidentFund_EmployerContribution = 8000,
                        OtherDeduction = 700,
                        ProfessionTax = 200,
                        TDS = 15000
                    });
                    emp.Salaries.Add(new WithVisitorPattern.MonthlyExpense
                    {
                        MonthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(1),
                        MonthlyRent = 10000
                    });
                }
                emp.Salaries.Add(new WithVisitorPattern.AnnualInvestment
                {
                    InvestmentDetails = "MediclaimPolicy",
                    InvestmentAmmount = 15000
                });
                emp.Salaries.Add(new WithVisitorPattern.AnnualInvestment
                {
                    InvestmentDetails = "MediclaimPolicyforParents",
                    InvestmentAmmount = 25000
                });
                emp.Salaries.Add(new WithVisitorPattern.AnnualInvestment
                {
                    InvestmentDetails = "HouseLoan",
                    InvestmentAmmount = 0.0
                });
                emp.Salaries.Add(new WithVisitorPattern.AnnualInvestment
                {
                    InvestmentDetails = "EducationLoan",
                    InvestmentAmmount = 0.0
                });
                emp.Salaries.Add(new WithVisitorPattern.AnnualInvestment
                {
                    InvestmentDetails = "OtherInvestment",
                    InvestmentAmmount = 5000
                });
                emp.Salaries.Add(new WithVisitorPattern.AnnualInvestment
                {
                    InvestmentDetails = "RGESS",
                    InvestmentAmmount = 5500
                });
                emp.Salaries.Add(new WithVisitorPattern.AnnualInvestment
                {
                    InvestmentDetails = "Section80Cn80CCD_ExceptPF",
                    InvestmentAmmount = 100000
                });
            }
        
        private static void ExecutionWithoutVisitorPattern()
        {

            WithoutVisitorPattern.Employee emp = new WithoutVisitorPattern.Employee
            {
                EmployeeId = "XYZ1001",
                EmployeeName = "Banketeshvar Narayan"
            };
            AddDataForEmployee(emp);

            double NetEarningoftheYear = 0.0;
            foreach (var monthlySalary_Earning in emp.MonthlySalary_Earnings)
            {
                NetEarningoftheYear += (monthlySalary_Earning.BasicSalary + monthlySalary_Earning.ConveyanceAllowance + monthlySalary_Earning.FoodCard_Bill + monthlySalary_Earning.HRAExemption + monthlySalary_Earning.MedicalAllowance + monthlySalary_Earning.OtherBills + monthlySalary_Earning.PersonalAllowance + monthlySalary_Earning.TelephoneBill);
            }
            foreach (var monthlySalary_Deduction in emp.MonthlySalary_Deductions)
            {
                NetEarningoftheYear -= (monthlySalary_Deduction.ProvidentFund_EmployeeContribution + monthlySalary_Deduction.ProvidentFund_EmployerContribution + monthlySalary_Deduction.ProfessionTax + monthlySalary_Deduction.OtherDeduction);
            }
  
            double TaxableAmount = 0.0;
            foreach (var monthlySalary_Earning in emp.MonthlySalary_Earnings)
            {
                TaxableAmount += (monthlySalary_Earning.BasicSalary + monthlySalary_Earning.HRAExemption + monthlySalary_Earning.MedicalAllowance + monthlySalary_Earning.PersonalAllowance);
            }
            foreach (var monthlySalary_Deduction in emp.MonthlySalary_Deductions)
            {
                TaxableAmount -= (monthlySalary_Deduction.ProvidentFund_EmployeeContribution + monthlySalary_Deduction.ProvidentFund_EmployerContribution + monthlySalary_Deduction.ProfessionTax + monthlySalary_Deduction.OtherDeduction);
            }
            foreach (var monthlyExpense in emp.MonthlyExpenses)
            {
                TaxableAmount -= monthlyExpense.MonthlyRent;
            }
            foreach (var annualInvestment in emp.AnnualInvestments)
            {
                TaxableAmount -= annualInvestment.InvestmentAmmount;
            }


            Console.WriteLine("Annual Net Earning Amount : {0}", NetEarningoftheYear);
            Console.WriteLine("Annual Taxable Amount : {0}", TaxableAmount);
        }

        private static void AddDataForEmployee(WithoutVisitorPattern.Employee emp)
        {
            for (int i = 1; i <= 12; i++)
            {
                emp.MonthlySalary_Earnings.Add(new WithoutVisitorPattern.MonthlySalary_Earning
                {
                    MonthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(i),
                    BasicSalary = 120000,
                    HRAExemption = 50000,
                    ConveyanceAllowance = 1600,
                    PersonalAllowance = 45000,
                    MedicalAllowance = 1500,
                    TelephoneBill = 2500,
                    FoodCard_Bill = 3000,
                    OtherBills = 35000
                });
                emp.MonthlySalary_Deductions.Add(new WithoutVisitorPattern.MonthlySalary_Deduction
                {
                    MonthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(i),
                    ProvidentFund_EmployeeContribution = 8000,
                    ProvidentFund_EmployerContribution = 8000,
                    OtherDeduction = 700,
                    ProfessionTax = 200,
                    TDS = 15000
                });
                emp.MonthlyExpenses.Add(new WithoutVisitorPattern.MonthlyExpense
                {
                    MonthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(1),
                    MonthlyRent = 10000
                });
            }
            emp.AnnualInvestments.Add(new WithoutVisitorPattern.AnnualInvestment
            {
                InvestmentDetails = "MediclaimPolicy",
                InvestmentAmmount = 15000
            });
            emp.AnnualInvestments.Add(new WithoutVisitorPattern.AnnualInvestment
            {
                InvestmentDetails = "MediclaimPolicyforParents",
                InvestmentAmmount = 25000
            });
            emp.AnnualInvestments.Add(new WithoutVisitorPattern.AnnualInvestment
            {
                InvestmentDetails = "HouseLoan",
                InvestmentAmmount = 0.0
            });
            emp.AnnualInvestments.Add(new WithoutVisitorPattern.AnnualInvestment
            {
                InvestmentDetails = "EducationLoan",
                InvestmentAmmount = 0.0
            });
            emp.AnnualInvestments.Add(new WithoutVisitorPattern.AnnualInvestment
            {
                InvestmentDetails = "OtherInvestment",
                InvestmentAmmount = 5000
            });
            emp.AnnualInvestments.Add(new WithoutVisitorPattern.AnnualInvestment
            {
                InvestmentDetails = "RGESS",
                InvestmentAmmount = 5500
            });
            emp.AnnualInvestments.Add(new WithoutVisitorPattern.AnnualInvestment
            {
                InvestmentDetails = "Section80Cn80CCD_ExceptPF",
                InvestmentAmmount = 100000
            });

        }
    }
}
