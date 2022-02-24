namespace CloudHumans.Assignment.Domain.ValueObjects
{
    public class BusinessException : System.Exception
    {
        public BusinessException(int code, string message) : base(message)
        {
            Code = code;
        }

        public int Code { get; }
    }
}