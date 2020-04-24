namespace AppFullStackDemo.Domain.Commands
{
    //How it Works: On Post/Put/Delete - WebApi Controller will send a DTO to Handler. Handler will check (validate), if fails, will return in
    //"BaseCommandResult" a friendly and pattern message and if there's errors, it will come on an array. If no error, will return the message
    //to be displayed on the screen. The meaning of "BaseCommandResult" is always give back a Padronized-Answer to the UI.
    public class BaseCommandResult : IBaseCommandResult
    {
        public BaseCommandResult(bool success, string message, object responseDataObj)
        {
            Success = success;
            Message = message;
            ResponseDataObj = responseDataObj;
        }

        public BaseCommandResult() { }

        public object ResponseDataObj { get; set; }

        public string Message { get; set; }

        public bool Success { get; set; }
    }
}