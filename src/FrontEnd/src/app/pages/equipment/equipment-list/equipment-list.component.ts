import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { EquipmentService } from 'src/app/services/equipment.service';
import { MatTableDataSource, MatSort, MatPaginator } from '@angular/material';
import { GetEquipmentResult } from 'src/app/results/equipment/GetEquipmentResult.model';

@Component({
  selector: 'app-equipment-list',
  templateUrl: './equipment-list.component.html',
  styles: []
})
export class EquipmentListComponent implements OnInit {

  @Input() userId: string;

  // When User click in a Equipment - It will change the "equipmentDetail" and the CU
  // is listening to it. So it will be reloaded showing details of another Equipment.
  equipmentId: string;
  equipmentDetail: GetEquipmentResult;

  listData: MatTableDataSource<any>;
  displayedColumns: string[] = ['DeviceModel', 'ApiLevelDesc', 'SerialNumber', 'actions'];
  @ViewChild(MatSort, { static: false }) sort: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  searchKey: string;

  constructor(private service: EquipmentService) { }

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    this.service.GetEquipmentsByUser(this.userId).subscribe(
      list => {
        this.listData = new MatTableDataSource(list);
        this.listData.sort = this.sort;
        this.listData.paginator = this.paginator;
        this.listData.filterPredicate = (data, filter) => {
          return this.displayedColumns.some(ele => {
            return ele !== 'actions' && data[ele].toLowerCase().indexOf(filter) !== -1;
          });
        };
      });
  }

  applyFilter() {
    this.listData.filter = this.searchKey.trim().toLowerCase();
  }

  onSearchClear() {
    this.searchKey = '';
    this.applyFilter();
  }

  loadEquipmentDetails(row) {
    this.equipmentId = row.Id;
    this.service.GetEquipment(this.equipmentId).subscribe(
      res => {
        this.equipmentDetail = res as GetEquipmentResult;
      });
  }
}
