import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatSort, MatPaginator, MatDialogConfig, MatDialog } from '@angular/material';
// imports by Fernando
import { DialogService } from 'src/app/shared/dialog.service';
import { NotificationService } from 'src/app/shared/notification.service';
import { DeviceModelCuComponent } from '../devicemodel-cu/devicemodel-cu.component';
import { DeviceModelService } from 'src/app/services/devicemodel.service';

@Component({
  selector: 'app-devicemodel-list',
  templateUrl: './devicemodel-list.component.html'
})
export class DeviceModelListComponent implements OnInit {

  constructor(private service: DeviceModelService,
    private dialog: MatDialog,
    private dialogService: DialogService) { }

  listData: MatTableDataSource<any>;
  displayedColumns: string[] = ['Description', 'Category', 'Manufacturer', 'actions'];
  @ViewChild(MatSort, { static: false }) sort: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  searchKey: string;

  returnOfWebService: any;

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    this.service.getDeviceModel().subscribe(
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
    this.dialog.open(DeviceModelCuComponent, dialogConfig);
  }

  onEdit(row) {
    this.service.initializeFormGroup();
    this.service.populateForm(row);
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = '80%';
    this.dialog.afterAllClosed.subscribe(data => { this.loadData(); });
    this.dialog.open(DeviceModelCuComponent, dialogConfig);
  }

  onDelete(Id) {
    this.dialogService.openConfirmDialog('Tem certeza que deseja excluir?')
      .afterClosed().subscribe(res => {
        if (res) {
          this.service.deleteDeviceModel(Id).subscribe(data => {
            this.returnOfWebService = data; this.loadData();
          });
          NotificationService.showNotification('warning', 'top', 'right', 'Success!', 'Posição Excluída!');
        }
      });
  }
}