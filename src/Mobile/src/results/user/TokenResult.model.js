export default class TokenAndRefreshToken {
    Token;
    LoggedSuccessful;
    UserName;
    UserEmail;
    UserId;
    constructor(token, loggedSuccessful, userName, userEmail, userId) {
        this.Token = token;
        this.LoggedSuccessful = loggedSuccessful;
        this.UserName = userName;
        this.UserEmail = userEmail;
        this.UserId = userId;
    }
}