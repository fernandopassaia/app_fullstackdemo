import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { MatTableDataSource, MatSort, MatPaginator } from '@angular/material';
import { GetEquipmentResult } from 'src/app/results/equipment/GetEquipmentResult.model';

@Component({
  selector: 'app-equipment-cu',
  templateUrl: './equipment-cu.component.html',
  styles: []
})
export class EquipmentCuComponent implements OnInit {

  @Input() equipmentDetail: GetEquipmentResult; //will be load on the list of equipments and reflected here  

  constructor() { }

  ngOnInit() {
  }
}
