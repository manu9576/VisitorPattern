﻿namespace WithVisitorPattern
{
    #region MonthlySalary_Earning  

    #endregion
    #region MonthlySalary_Deduction  
    public class MonthlySalary_Deduction : ISalary
    {
        public string MonthName
        {
            get;
            set;
        }
        public double ProvidentFund_EmployeeContribution
        {
            get;
            set;
        }
        public double ProvidentFund_EmployerContribution
        {
            get;
            set;
        }
        public double ProfessionTax
        {
            get;
            set;
        }
        public double TDS
        {
            get;
            set;
        }
        public double OtherDeduction
        {
            get;
            set;
        }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    #endregion
}