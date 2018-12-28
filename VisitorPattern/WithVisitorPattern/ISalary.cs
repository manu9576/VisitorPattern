namespace WithVisitorPattern
{
    public interface ISalary
    {
        void Accept(IVisitor visitor);
    }

}