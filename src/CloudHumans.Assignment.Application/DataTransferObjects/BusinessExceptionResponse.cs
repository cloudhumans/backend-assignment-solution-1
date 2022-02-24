namespace CloudHumans.Assignment.Application.DataTransferObjects
{
    public class BusinessExceptionResponse
    {
        public BusinessExceptionResponse(int code, string message)
        {
            this.Code = code;
            this.Message = message;
        }

        public int Code { get; }
        public string Message { get; }
    }
}