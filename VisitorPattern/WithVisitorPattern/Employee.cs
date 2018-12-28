using System.Collections.Generic;

namespace WithVisitorPattern
{
    #region Employee
    public class Employee : ISalary
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
        public List<ISalary> Salaries = new List<ISalary>();

        public void Accept(IVisitor visitor)
        {
            foreach (ISalary salary in Salaries)
            {
                salary.Accept(visitor);
            }
        }
    }

    #endregion
}