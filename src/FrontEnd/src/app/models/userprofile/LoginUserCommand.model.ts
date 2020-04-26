export class LoginUserCommand {
    UsernameOrEmail: string;
    Password: string;
    Source: number; //0 From Web Angular App / 1 from Mobile Android App / 2 from Mobile iPhone App / 3 from Raspberry
}