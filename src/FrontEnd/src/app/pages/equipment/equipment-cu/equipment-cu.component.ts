import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { MatTableDataSource, MatSort, MatPaginator } from '@angular/material';

@Component({
  selector: 'app-equipment-cu',
  templateUrl: './equipment-cu.component.html',
  styles: []
})
export class EquipmentCuComponent implements OnInit {

  @Input() listData: MatTableDataSource<any>; //will be load on the list of equipments and reflected here
  displayedColumns: string[] = ['Field', 'Value'];
  @ViewChild(MatSort, { static: false }) sort: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  searchKey: string;

  constructor() { }

  ngOnInit() {
  }

  applyFilter() {
    this.listData.filter = this.searchKey.trim().toLowerCase();
  }

  onSearchClear() {
    this.searchKey = '';
    this.applyFilter();
  }
}
