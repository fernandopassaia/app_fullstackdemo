import {Component, Input, OnInit, AfterViewInit, ChangeDetectionStrategy} from '@angular/core';
import * as Chartist from 'chartist';

export interface LegendItem {
  title: string;
  imageClass: string;
}

export enum ChartType {
  Pie,
  Line,
  Bar
}

@Component({
  selector: 'app-md-chart',
  templateUrl: './md-chart.component.html',
  styleUrls: ['./md-chart.component.css']
})

export class MdChartComponent implements OnInit, AfterViewInit {
  static currentId = 1;

  @Input()
  public title: string;

  @Input()
  public subtitle: string;

  @Input()
  public chartClass: string;

  @Input()
  public chartType: ChartType;

  @Input()
  public chartData: any;

  @Input()
  public chartOptions: any;

  @Input()
  public chartResponsive: any[];

  @Input()
  public footerIconClass: string;

  @Input()
  public footerText: string;

  @Input()
  public legendItems: LegendItem[];

  @Input()
  public withHr: boolean;

  public chartId: string;

  constructor() {
  }

  public ngOnInit(): void {
    this.chartId = `md-chart-${MdChartComponent.currentId++}`;
  }

  public ngAfterViewInit(): void {

    switch (this.chartType) {
      case ChartType.Pie:
        new Chartist.Pie(`#${this.chartId}`, this.chartData, this.chartOptions, this.chartResponsive);
        break;
      case ChartType.Line:
        new Chartist.Line(`#${this.chartId}`, this.chartData, this.chartOptions, this.chartResponsive);
        break;
      case ChartType.Bar:
        new Chartist.Bar(`#${this.chartId}`, this.chartData, this.chartOptions, this.chartResponsive);
        break;
    }
  }
}
