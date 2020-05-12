import { Component, OnInit, ViewChild } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { MatTableDataSource, MatSort, MatPaginator, MatDialogConfig, MatDialog } from '@angular/material';
// imports by Fernando
import { DialogService } from 'src/app/shared/dialog.service';
import { NotificationService } from 'src/app/shared/notification.service';
//import { EmployeeCuComponent } from '../employee-cu/employee-cu.component';
import { Router } from '@angular/router';
import { UserCuComponent } from '../user-cu/user-cu.component';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html'
})
export class UserListComponent implements OnInit {

  constructor(private router: Router,
    private service: UserService,
    private dialog: MatDialog,
    private dialogService: DialogService) { }

  listData: MatTableDataSource<any>;
  displayedColumns: string[] = ['Name', 'Email', "City", 'actions'];
  @ViewChild(MatSort, { static: false }) sort: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  searchKey: string;

  returnOfWebService: any;

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    this.service.getUsers().subscribe(
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
    dialogConfig.height = '60%';
    this.dialog.afterAllClosed.subscribe(data => { this.loadData(); });
    this.dialog.open(UserCuComponent, dialogConfig);
  }

  onEdit(row) {
    this.service.initializeFormGroup();
    this.service.populateForm(row);
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = '80%';
    dialogConfig.height = '60%';
    this.dialog.afterAllClosed.subscribe(data => { this.loadData(); });
    this.dialog.open(UserCuComponent, dialogConfig);
  }

  onDelete(userId) {
    this.dialogService.openConfirmDialog('Are you sure you want to delete?')
      .afterClosed().subscribe(res => {
        if (res) {
          this.service.deleteUser(userId).subscribe(data => {
            this.returnOfWebService = data; this.loadData();
          });
        }
      });
  }

  goToDevices(row) {
    this.router.navigate(['equipment/' + row]);
  }
}