namespace AppFullStackDemo.Api.Models
{
    //Here you will see complete information about these Fields and How it works. This Fields here will be Load/Reflect by AppSettings.Json (section AppSettings)
    public class AppSettings
    {
        //Emiter is the NAME of the System, you can put here the name of your project, or the Backend
        public string Emiter { get; set; }

        //Here you will define how many time token will expires (5 minutes, 30 minutes, 120 minutes...)
        public int ExpirationInMinutes { get; set; }

        //Here you will define how many Days the RefreshTokenKey (in Database) is valid. If you put 30 days, after that system will force user to Logout and Login again
        public int RefreshTokenExpirationInDays { get; set; }

        //If you set this property to True, RefreshToken Will never expires, only if the Status of the RefreshToken becomes Invalid in a "manual" form
        public bool RefreshTokenNeverExpires { get; set; }

        //Here you will put the SecretKey of the Token, this is very important and cannot be never lost
        public string TokenSecret { get; set; }

        //Here you will put where it can be used, localhost, localhost:4200, localhost:5000, or your real website
        public string ValidIn { get; set; }
        //NOTE: Emiter and ValidIn can be changed to ARRAY, so if we have more than one system, we can Handle it in the Future by changing this (more info in JWT Section - Startup.cs)

        //Note: New Fields relative an Email Classes
        public string EmailSender { get; set; }

        public string EmailPassWord { get; set; }

        public string EmailSmptAddress { get; set; }

        public int EmailPort { get; set; }

        public bool EmailEnableSsl { get; set; }

        public bool EmailUseDefaultCredentials { get; set; }
    }
}