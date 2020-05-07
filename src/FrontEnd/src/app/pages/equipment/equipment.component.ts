import { Component, OnInit } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-equipment",
  templateUrl: "./equipment.component.html",
  styles: [],
})
export class EquipmentComponent implements OnInit {
  userId: string;
  constructor(
    private _router: Router,
    private _activatedRoute: ActivatedRoute
  ) { }

  ngOnInit() {
    this._activatedRoute.paramMap.subscribe((params) => {
      this.userId = params.get("userId");
    });
  }
}
