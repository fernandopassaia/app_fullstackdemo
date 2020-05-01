import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import {
  FormGroup,
  FormControl,
  Validators,
  FormBuilder,
} from "@angular/forms";
import { map, catchError, retry } from "rxjs/operators";
import { AppApi } from "../app.api";
import { GetEmployeeResult } from "../models/employee/GetEmployeeResult.model";
import { CreateEmployeeCommand } from "../models/employee/CreateEmployeeCommand.model";
import { UpdateEmployeeCommand } from "../models/employee/UpdateEmployeeCommand.model";
import { of } from "rxjs";
import { CustomValidators } from "../shared/custom.validators";

@Injectable({
  providedIn: "root",
})
export class EmployeeService {
  public form: FormGroup;
  public singInform: FormGroup;

  constructor(private http: HttpClient, private fb: FormBuilder) {
    this.form = this.createSignupForm();

  }

  // Note: On the Create I`ll allow user to create just with First and LastName, Username (email) and Password.
  // Once User is logged, if user tries to UPDATE the profile, will be forced to add Address, Phone and other info.
  singInform: FormGroup = new FormGroup({
    UsernameOrEmail: new FormControl('', Validators.required),
    Password: new FormControl('', Validators.required)
  });






  listEmployee: GetEmployeeResult[];





  createSignupForm(): FormGroup {
    return this.fb.group(
      {
        Id: new FormControl(""),
        FirstName: new FormControl("", Validators.required),
        LastName: new FormControl("", Validators.required),
        TypePerson: new FormControl(2),
        CountryRegistryNumber: new FormControl("", Validators.required),
        StateRegistryNumber: new FormControl("", Validators.required),
        CityRegistryNumber: new FormControl(""),
        PhoneNumber1: new FormControl(""),
        PhoneNumber2: new FormControl(""),
        MobilePhoneNumber1: new FormControl(""),
        MobilePhoneNumber2: new FormControl(""),
        EmailAddress: new FormControl("", Validators.required),
        EmailAdminSystem: new FormControl("", Validators.required),
        AditionalInfo: new FormControl(""),
        UserName: new FormControl("", Validators.required),
        //Password: new FormControl('', Validators.required),
        //ConfirmPassword: new FormControl('', Validators.required),
        UserProfile: new FormControl(3),
        Subsidiary: new FormControl("1"),
        Position: new FormControl("1"),
        CostCenterArea: new FormControl("1"),
        Company: new FormControl("1"), //just temp-store the company of employee to reload the other cbbs options (position, centercost, subsidiary)

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
      }
    );
  }

  initializeFormGroup() {
    this.form.setValue({
      Id: 0,
      FirstName: "",
      LastName: "",
      TypePerson: 2,
      CountryRegistryNumber: "",
      StateRegistryNumber: "",
      CityRegistryNumber: "",
      PhoneNumber1: "",
      PhoneNumber2: "",
      MobilePhoneNumber1: "",
      MobilePhoneNumber2: "",
      EmailAddress: "",
      EmailAdminSystem: "",
      AditionalInfo: "",
      UserName: "",
      Password: "",
      ConfirmPassword: "",
      UserProfile: "3",
      Subsidiary: "1",
      Position: "1",
      CostCenterArea: "1",
      Company: "1",
    });
  }

  getEmployee() {
    return this.http.get(`${AppApi.MobileControlApiResourceEmployee}/v1`).pipe(
      retry(2), //if something happens, will retry 2x
      map((res) => (this.listEmployee = res as GetEmployeeResult[])),
      catchError((err) => {
        return of(null); //if exception happens, i'll return null
      })
    );
  }

  createEmployee(command: CreateEmployeeCommand) {
    return this.http
      .post(
        `${AppApi.MobileControlApiResourceEmployee}/v1`,
        JSON.stringify(command)
      )
      .pipe(
        retry(2), //if something happens, will retry 2x
        catchError((err) => {
          return of(null); //if exception happens, i'll return null
        })
      );
  }

  updateEmployee(command: UpdateEmployeeCommand) {
    return this.http
      .put(
        `${AppApi.MobileControlApiResourceEmployee}/v1`,
        JSON.stringify(command)
      )
      .pipe(
        retry(2), //if something happens, will retry 2x
        catchError((err) => {
          return of(null); //if exception happens, i'll return null
        })
      );
  }

  deleteEmployee(Id: string) {
    return this.http
      .delete(`${AppApi.MobileControlApiResourceEmployee}/v1/` + Id)
      .pipe(
        retry(3), //if something happens, will retry 2x
        catchError((err) => {
          return of(null); //if exception happens, i'll return null
        })
      );
  }

  populateForm(Employee) {
    this.http
      .get(`${AppApi.MobileControlApiResourceEmployee}/v1/` + Employee.Id)
      .subscribe((res) => {
        const EmployeeToBeChanged = res as UpdateEmployeeCommand;
        this.form.setValue({
          Id: EmployeeToBeChanged.Id,
          FirstName: EmployeeToBeChanged.FirstName,
          LastName: EmployeeToBeChanged.LastName,
          TypePerson: EmployeeToBeChanged.TypePerson,
          CountryRegistryNumber: EmployeeToBeChanged.CountryRegistryNumber,
          StateRegistryNumber: EmployeeToBeChanged.StateRegistryNumber,
          CityRegistryNumber: EmployeeToBeChanged.CityRegistryNumber,
          PhoneNumber1: EmployeeToBeChanged.PhoneNumber1,
          PhoneNumber2: EmployeeToBeChanged.PhoneNumber2,
          MobilePhoneNumber1: EmployeeToBeChanged.MobilePhoneNumber1,
          MobilePhoneNumber2: EmployeeToBeChanged.MobilePhoneNumber2,
          EmailAddress: EmployeeToBeChanged.EmailAddress,
          EmailAdminSystem: EmployeeToBeChanged.EmailAdminSystem,
          AditionalInfo: EmployeeToBeChanged.AditionalInfo,
          UserName: EmployeeToBeChanged.UserName,
          Password: EmployeeToBeChanged.Password,
          ConfirmPassword: EmployeeToBeChanged.Password,
          UserProfile: EmployeeToBeChanged.UserProfile.toString(), //i don't know why, but numbers needs to be converted
          Subsidiary: EmployeeToBeChanged.Subsidiary.toString(), //to strings to correctly load on combobox
          Position: EmployeeToBeChanged.Position.toString(),
          CostCenterArea: EmployeeToBeChanged.CostCenterArea.toString(),
          Company: EmployeeToBeChanged.Company.toString(),
        });
      });
  }
}
