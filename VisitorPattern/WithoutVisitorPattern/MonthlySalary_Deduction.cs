namespace WithoutVisitorPattern
{
    #endregion
    #region MonthlySalary_Earning  
    #endregion
    #region MonthlySalary_Deduction  
    public class MonthlySalary_Deduction
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
    }
    #endregion
}

