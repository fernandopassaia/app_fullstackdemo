import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { AppApi } from "../app.api";
import { retry, catchError } from "rxjs/operators";
import { CreateUserCommand } from "../commands/user/CreateUserCommand.model";
import { of } from "rxjs";
import { FormGroup, FormControl, Validators } from "@angular/forms";

@Injectable({
    providedIn: "root",
})
export class UserService {
    headers = {
        headers: new HttpHeaders({
            "Content-Type": "application/json",
        }),
    };

    // Note: On the Create I`ll allow user to create just with First and LastName, Username (email) and Password.
    // Once User is logged, if user tries to UPDATE the profile, will be forced to add Address, Phone and other info.
    form: FormGroup = new FormGroup({
        Id: new FormControl(''),
        AditionalInfo: new FormControl(''),
        CountryRegistryNumber: new FormControl(''),
        StateRegistryNumber: new FormControl(''),
        EmailAddress: new FormControl('', Validators.required),
        FirstName: new FormControl('', Validators.required),
        LastName: new FormControl('', Validators.required),
        MobilePhoneNumber1: new FormControl(''),
        MobilePhoneNumber2: new FormControl(''),
        PhoneNumber1: new FormControl(''),
        PhoneNumber2: new FormControl(''),
        City: new FormControl(''),
        NeighborHood: new FormControl(''),
        Street: new FormControl(''),
        StreetNumber: new FormControl(''),
        ZipCode: new FormControl(''),
        UserName: new FormControl(''),
        Password: new FormControl('', Validators.required),
    });

    constructor(private http: HttpClient, private service: UserService) { }

    initializeFormGroup() { }

    createUser(command: CreateUserCommand) {
        command.UserName = command.EmailAddress; //small hack to create the first config of login with email
        console.log('Command enviado', command);
        return this.http
            .post(
                `${AppApi.MobileControlApiResourceUser}/v1`,
                JSON.stringify(command),
                this.headers
            )
            .pipe(
                retry(2), //if something happens, will retry 2x
                catchError((err) => {
                    return of(null); //if exception happens, i'll return null
                })
            );
    }
}
