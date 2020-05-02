namespace AppFullStackDemo.Domain.Results.User
{
    //This is a Model to Join the Token and the Refresh Token (class will be filled and send to Serialize on JsonSerializer)
    public class TokenResult
    {
        public string Token { get; set; }

        public bool LoggedSuccessful { get; set; }

        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public string UserId { get; set; }
    }
}