namespace AppFullStackDemo.Domain.Results.User
{
    //How it Works: On Post/Put/Delete - WebApi Controller will send a DTO to Handler. Handler will check (validate), if fails, will return in
    //"BaseCommandResult" a friendly message and the erros (in a array). If Pass, Handler will give a Friendly-message back to WebApi including
    //the updated Object in "data" field. The meaning of "BaseCommandResult" is always give back a Padronized-Answer to the UI. On the "Get"
    //methods i will return a "false" and a friendly "error" message, in case of not-found the search-criteria, or the result in "data" field.
    public class GetLoggedUserResult
    {
        public GetLoggedUserResult()
        {
        }

        public GetLoggedUserResult(bool success, string message, string idUser, string nameUser, string emailAddress, string usernameOrEmail, object data)
        {
            Success = success;
            Message = message;
            IdUser = idUser;
            NameUser = nameUser;
            EmailAddress = emailAddress;
            UsernameOrEmail = usernameOrEmail;
            Data = data;
        }

        public object Data { get; set; }

        public string EmailAddress { get; set; }

        public string IdUser { get; set; }

        public string Message { get; set; }

        public string NameUser { get; set; }
        public bool Success { get; set; }

        public string UsernameOrEmail { get; set; }
    }
}