import {Component, Input, ChangeDetectionStrategy} from '@angular/core';

export interface TableData {
  headerRow: string[];
  dataRows: string[][];
}

@Component({
  selector: 'app-md-table',
  templateUrl: './md-table.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MdTableComponent {
  @Input()
  public title: string;

  @Input()
  public subtitle: string;

  @Input()
  public cardClass: string;

  @Input()
  public data: TableData;

  constructor() { }
}
