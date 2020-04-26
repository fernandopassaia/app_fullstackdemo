import { Component, OnInit, ViewChild } from '@angular/core';
import { EmployeeService } from 'src/app/services/employee.service';
import { MatTableDataSource, MatSort, MatPaginator, MatDialogConfig, MatDialog } from '@angular/material';
// imports by Fernando
import { DialogService } from 'src/app/shared/dialog.service';
import { NotificationService } from 'src/app/shared/notification.service';
import { EmployeeCuComponent } from '../employee-cu/employee-cu.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html'
})
export class EmployeeListComponent implements OnInit {

  constructor(private router: Router,
    private service: EmployeeService,
    private dialog: MatDialog,
    private dialogService: DialogService) { }

  listData: MatTableDataSource<any>;
  displayedColumns: string[] = ['Name', 'EmailAddress', 'actions'];
  @ViewChild(MatSort, { static: false }) sort: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  searchKey: string;

  returnOfWebService: any;

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    this.service.getEmployee().subscribe(
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
    dialogConfig.height = '65%';
    this.dialog.afterAllClosed.subscribe(data => { this.loadData(); });
    this.dialog.open(EmployeeCuComponent, dialogConfig);
  }

  onEdit(row) {
    this.service.initializeFormGroup();
    this.service.populateForm(row);
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = '80%';
    dialogConfig.height = '65%';
    this.dialog.afterAllClosed.subscribe(data => { this.loadData(); });
    this.dialog.open(EmployeeCuComponent, dialogConfig);
  }

  onDelete(CategoryId) {
    this.dialogService.openConfirmDialog('Tem certeza que deseja excluir?')
      .afterClosed().subscribe(res => {
        if (res) {
          this.service.deleteEmployee(CategoryId).subscribe(data => {
            this.returnOfWebService = data; this.loadData();
          });
          NotificationService.showNotification('warning', 'top', 'right', 'Success!', 'Employee Deleted!');
        }
      });
  }

  goToDevices(row) {
    this.router.navigate(['equipment/' + row]);
  }
}