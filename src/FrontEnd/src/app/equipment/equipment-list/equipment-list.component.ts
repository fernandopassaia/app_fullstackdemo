import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { EquipmentService } from 'src/app/services/equipment.service';
import { MatTableDataSource, MatSort, MatPaginator } from '@angular/material';

@Component({
  selector: 'app-equipment-list',
  templateUrl: './equipment-list.component.html',
  styles: []
})
export class EquipmentListComponent implements OnInit {

  @Input() employeeId: string;

  // When User click in a Equipment - It will change the "equipmentDetail" and the CU
  // is listening to it. So it will be reloaded showing details of another Equipment.
  equipmentId: string;
  equipmentDetail: MatTableDataSource<any>;

  listData: MatTableDataSource<any>;
  displayedColumns: string[] = ['Brand', 'Model', 'Description', 'actions'];
  @ViewChild(MatSort, { static: false }) sort: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  searchKey: string;

  constructor(private service: EquipmentService) { }

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    this.service.GetByEmployee(this.employeeId).subscribe(
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

  onSynteticData(row) {
    this.equipmentId = row.Id;
    this.service.GetEquipmentSyntetic(this.equipmentId).subscribe(
      list => {
        this.equipmentDetail = new MatTableDataSource(list);
      });
  }

  onFullData(row) {
    this.equipmentId = row.Id;
    this.service.GetEquipmentResumed(this.equipmentId).subscribe(
      list => {
        this.equipmentDetail = new MatTableDataSource(list);
      });
  }
}
