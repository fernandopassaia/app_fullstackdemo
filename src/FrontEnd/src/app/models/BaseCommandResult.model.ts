// Note: you can read about how works this commandResult in the API > BaseCommandResult class
export class BaseCommandResult {
    Success: boolean;
    Message: string;
    ResponseDataObj: BaseCommandResultErrors[];
}

//I will always return an object with 2 fields (it comes from the Flunt Contract on BackEnd)
export class BaseCommandResultErrors {
    Property: string;
    Message: string;
}