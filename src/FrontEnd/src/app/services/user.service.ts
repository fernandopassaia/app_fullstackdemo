import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { AppApi } from "../app.api";
import { retry, catchError, map } from "rxjs/operators";
import { CreateUserCommand } from "../commands/user/CreateUserCommand.model";
import { of } from "rxjs";
import { FormGroup, FormControl, Validators, FormBuilder } from "@angular/forms";
import { GetUsersResumed } from "../results/user/GetUsersResumed.model";
import { GetUserResult } from "../results/user/GetUserResult.model";
import { CustomValidators } from "../shared/custom.validators";
import { UpdateUserCommand } from "../commands/user/UpdateUserCommand.model";


@Injectable({
    providedIn: "root",
})
export class UserService {

    createSignupForm(): FormGroup {
        return this.fb.group(
            {
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

                Password: [
                    null,
                    Validators.compose([
                        Validators.required,
                        // check whether the entered password has a number
                        CustomValidators.patternValidator(/\d/, {
                            hasNumber: true,
                        }),
                        // check whether the entered password has upper case letter
                        CustomValidators.patternValidator(/[A-Z]/, {
                            hasCapitalCase: true,
                        }),
                        // check whether the entered password has a lower case letter
                        CustomValidators.patternValidator(/[a-z]/, {
                            hasSmallCase: true,
                        }),
                        // check whether the entered password has a special character
                        CustomValidators.patternValidator(
                            /[ !@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]/,
                            {
                                hasSpecialCharacters: true,
                            }
                        ),
                        Validators.minLength(8),
                    ]),
                ],
                ConfirmPassword: [null, Validators.compose([Validators.required])],
            },
            {
                // check whether our password and confirm password match
                validator: CustomValidators.passwordMatchValidator,
            });
    }

    listUsers: GetUsersResumed[];
    public form: FormGroup;

    constructor(private http: HttpClient, private fb: FormBuilder, private service: UserService) {
        this.form = this.createSignupForm();
    }

    initializeFormGroup() {
        this.form.setValue({
            Id: "",
            AditionalInfo: "",
            CountryRegistryNumber: "",
            StateRegistryNumber: "",
            EmailAddress: "",
            FirstName: "",
            LastName: "",
            MobilePhoneNumber1: "",
            MobilePhoneNumber2: "",
            PhoneNumber1: "",
            PhoneNumber2: "",
            City: "",
            NeighborHood: "",
            Street: "",
            StreetNumber: "",
            ZipCode: "",
            UserName: "",
            Password: "",
            ConfirmPassword: ""
        });
    }

    createUser(command: CreateUserCommand) {
        command.UserName = command.EmailAddress; //small hack to create the first config of login with email
        return this.http
            .post(
                `${AppApi.AppFullStackDemoApiResourceUser}/v1`,
                JSON.stringify(command)
            )
            .pipe(
                retry(2), //if something happens, will retry 2x
                catchError((err) => {
                    return of(null); //if exception happens, i'll return null
                })
            );
    }

    updateUser(command: UpdateUserCommand) {
        return this.http
            .put(
                `${AppApi.AppFullStackDemoApiResourceUser}/v1/` + command.Id,
                JSON.stringify(command)
            )
            .pipe(
                retry(2), //if something happens, will retry 2x
                catchError((err) => {
                    return of(null); //if exception happens, i'll return null
                })
            );
    }

    deleteUser(id: string) {
        return this.http
            .delete(
                `${AppApi.AppFullStackDemoApiResourceUser}/v1/` + id
            )
            .pipe(
                retry(2), //if something happens, will retry 2x
                catchError((err) => {
                    return of(null); //if exception happens, i'll return null
                })
            );
    }

    getUsers() {
        return this.http.get(`${AppApi.AppFullStackDemoApiResourceUser}/v1`).pipe(
            retry(2), //if something happens, will retry 2x
            map((res) => (this.listUsers = res as GetUsersResumed[])),
            catchError((err) => {
                return of(null); //if exception happens, i'll return null
            })
        );
    }

    populateForm(user) {
        this.http
            .get(`${AppApi.AppFullStackDemoApiResourceUser}/v1/` + user.Id)
            .subscribe((res) => {
                const user = res as GetUserResult;
                this.form.setValue({
                    Id: user.Id,
                    AditionalInfo: user.AditionalInfo,
                    CountryRegistryNumber: user.CountryRegistryNumber,
                    StateRegistryNumber: user.StateRegistryNumber,
                    EmailAddress: user.EmailAddress,
                    FirstName: user.FirstName,
                    LastName: user.LastName,
                    MobilePhoneNumber1: user.MobilePhoneNumber1,
                    MobilePhoneNumber2: user.MobilePhoneNumber2,
                    PhoneNumber1: user.PhoneNumber1,
                    PhoneNumber2: user.PhoneNumber2,
                    City: user.City,
                    NeighborHood: user.NeighborHood,
                    Street: user.Street,
                    StreetNumber: user.StreetNumber,
                    ZipCode: user.ZipCode,
                    UserName: user.UserName,
                    Password: user.Password,
                    ConfirmPassword: user.ConfirmPassword,
                });
            });
    }
}
