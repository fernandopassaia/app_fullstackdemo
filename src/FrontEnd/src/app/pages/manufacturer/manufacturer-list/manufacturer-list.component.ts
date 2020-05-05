import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatSort, MatPaginator, MatDialogConfig, MatDialog } from '@angular/material';
import { DialogService } from 'src/app/shared/dialog.service';
import { ManufacturerCuComponent } from '../manufacturer-cu/manufacturer-cu.component';
import { ManufacturerService } from 'src/app/services/manufacturer.service';

@Component({
  selector: 'app-manufacturer-list',
  templateUrl: './manufacturer-list.component.html'
})
export class ManufacturerListComponent implements OnInit {

  constructor(private service: ManufacturerService,
    private dialog: MatDialog,
    private dialogService: DialogService) { }

  listData: MatTableDataSource<any>;
  displayedColumns: string[] = ['Description', 'actions'];
  @ViewChild(MatSort, { static: false }) sort: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  searchKey: string;

  returnOfWebService: any;

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    this.service.getManufacturer().subscribe(
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

  onCreate() {
    this.service.initializeFormGroup();
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = '80%';
    this.dialog.afterAllClosed.subscribe(data => { this.loadData(); });
    this.dialog.open(ManufacturerCuComponent, dialogConfig);
  }

  onEdit(row) {
    this.service.initializeFormGroup();
    this.service.populateForm(row);
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = '80%';
    this.dialog.afterAllClosed.subscribe(data => { this.loadData(); });
    this.dialog.open(ManufacturerCuComponent, dialogConfig);
  }

  onDelete(Id) {
    this.dialogService.openConfirmDialog('Sure you want to delete?')
      .afterClosed().subscribe(res => {
        if (res) {
          this.service.deleteManufacturer(Id).subscribe(data => {
            this.returnOfWebService = data; this.loadData();
          });
        }
      });
  }
}