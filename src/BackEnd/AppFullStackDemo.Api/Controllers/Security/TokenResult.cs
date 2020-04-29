namespace AppFullStackDemo.Api.Controllers.Security
{
    //This is a Model to Join the Token (class will be filled and send to Serialize on JsonSerializer)
    public class TokenResult
    {
        public string refreshToken { get; set; }

        public string token { get; set; }

        public bool loggedSuccessful { get; set; }

        public string employeeName { get; set; }

        public string employeeEmail { get; set; }

        public string employeeId { get; set; }

        public string companyName { get; set; }

        public string companyLogoUrl { get; set; }
    }
}