import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { map, catchError, retry } from "rxjs/operators";
import { of } from "rxjs";
import { AppApi } from "../app.api";
import { BaseCommandResultDashBoard } from "../results/BaseCommandResultDashBoard.model";

@Injectable({
    providedIn: "root",
})
export class DashBoardService {

    constructor(private http: HttpClient) { }
    dashBoardData: BaseCommandResultDashBoard;

    initializeFormGroup() { }

    getDashBoardData() {
        return this.http
            .get(`${AppApi.MobileControlApiResourceDashBoard}/v1`)
            .pipe(
                retry(2), //if something happens, will retry 2x
                map(
                    (res) =>
                        (this.dashBoardData = res as BaseCommandResultDashBoard)
                ),
                catchError((err) => {
                    return of(null); //if exception happens, i'll return null
                })
            );
    }
}
