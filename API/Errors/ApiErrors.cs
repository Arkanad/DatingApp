namespace API.Errors{
    public class ApiExceptions{

        public ApiExceptions(int myProperty, string message, string details){
            MyProperty = myProperty;
            Message = message;
            Details = details;
        }
        public int MyProperty { get; set; }
        public string Message {get;set;}
        public string Details {get;set;}
    }
}