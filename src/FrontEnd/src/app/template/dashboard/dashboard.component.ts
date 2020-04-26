import { Component, OnInit } from '@angular/core';
import * as Chartist from 'chartist';
import { DashBoardService } from 'src/app/services/dashboard.service';
import { GetDashBoardResult } from 'src/app/models/dashboard/GetDashBoardResult';

declare const $: any;

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html'
})
export class DashboardComponent implements OnInit {
  apiData: GetDashBoardResult;

  numberOnlineEquips: string;
  numberOfflineEquips: string;
  percentOnlineEquips: string;
  percentOfflineEquips: string;
  percentOnlineEquipsN: number;
  percentOfflineEquipsN: number;
  androidVersions: string[] = [];
  androidVersionsN: number[] = [];
  deviceManufacturers: string[] = [];
  deviceManufacturersN: number[] = [];
  deviceManufacturerWithHigherNumber: number = 0;

  constructor(private dashBoardService: DashBoardService) {
  }

  startAnimationForLineChart(chart: any) {
    let seq: number, delays: number, durations: number;
    seq = 0;
    delays = 80;
    durations = 500;
    chart.on('draw', function (data: any) {

      if (data.type === 'line' || data.type === 'area') {
        data.element.animate({
          d: {
            begin: 600,
            dur: 700,
            from: data.path.clone().scale(1, 0).translate(0, data.chartRect.height()).stringify(),
            to: data.path.clone().stringify(),
            easing: Chartist.Svg.Easing.easeOutQuint
          }
        });
      } else if (data.type === 'point') {
        seq++;
        data.element.animate({
          opacity: {
            begin: seq * delays,
            dur: durations,
            from: 0,
            to: 1,
            easing: 'ease'
          }
        });
      }
    });

    seq = 0;
  }
  startAnimationForBarChart(chart: any) {
    let seq2: number, delays2: number, durations2: number;
    seq2 = 0;
    delays2 = 80;
    durations2 = 500;
    chart.on('draw', function (data: any) {
      if (data.type === 'bar') {
        seq2++;
        data.element.animate({
          opacity: {
            begin: seq2 * delays2,
            dur: durations2,
            from: 0,
            to: 1,
            easing: 'ease'
          }
        });
      }
    });

    seq2 = 0;
  }

  ngOnInit() {
    this.dashBoardService.getDashBoardData().subscribe(
      list => {
        this.apiData = this.dashBoardService.dashBoardData.ResponseDataObj as GetDashBoardResult;
        this.numberOnlineEquips = this.apiData.ListOfOnlineOfflineDevices[0].Value;
        this.numberOfflineEquips = this.apiData.ListOfOnlineOfflineDevices[1].Value;
        this.percentOnlineEquips = this.apiData.ListOfOnlineOfflineDevices[2].Value + '%';
        this.percentOfflineEquips = this.apiData.ListOfOnlineOfflineDevices[3].Value + '%';
        this.percentOnlineEquipsN = Number(this.apiData.ListOfOnlineOfflineDevices[2].Value);
        this.percentOfflineEquipsN = Number(this.apiData.ListOfOnlineOfflineDevices[3].Value);

        this.apiData.ListOfAndroid.forEach(item => {
          this.androidVersions.push(item.Field.replace('Android ', '') + '(' + item.Value + ')');
          this.androidVersionsN.push(Number(item.Value));
        });

        this.apiData.ListOfManufacturers.forEach(item => {
          this.deviceManufacturers.push(item.Field + '(' + item.Value + ')');
          this.deviceManufacturersN.push(Number(item.Value));

          if (Number(item.Value) > this.deviceManufacturerWithHigherNumber) {
            this.deviceManufacturerWithHigherNumber = Number(item.Value);
          }
        });

        //console.log('apiData: ', this.apiData);
        //console.log(this.apiData.ListOfOnlineOfflineDevices[0].Field, this.apiData.ListOfOnlineOfflineDevices[0].Value);
        //console.log(this.apiData.ListOfOnlineOfflineDevices[1].Field, this.apiData.ListOfOnlineOfflineDevices[1].Value);

        /*  **************** 1 Gráfico de Barra de Linha - Fabricante ******************** */
        const dataColouredRoundedLineChart = {
          labels: this.deviceManufacturers,
          series: [this.deviceManufacturersN]
        };

        const optionsColouredRoundedLineChart: any = {
          lineSmooth: Chartist.Interpolation.cardinal({
            tension: 10
          }),
          axisY: {
            showGrid: true,
            onlyInteger: true,
            offset: 40
          },
          axisX: {
            showGrid: false,
          },
          low: 0,
          high: this.deviceManufacturerWithHigherNumber, //valor MÁXIMO (maior número equips)
          showPoint: true,
          height: '300px'
        };

        const colouredRoundedLineChart = new Chartist.Line('#colouredRoundedLineChart', dataColouredRoundedLineChart,
          optionsColouredRoundedLineChart);

        this.startAnimationForLineChart(colouredRoundedLineChart);
        /*  **************** 1 Gráfico de Barra de Linha - Fabricante ******************** */


        /*  **************** 2 Gráfico de Barra - Versões Android ******************** */
        const dataSimpleBarChart = {
          labels: this.androidVersions, // this.androidVersions,
          series: [this.androidVersionsN]//this.androidVersionsN
        };

        //const dataSimpleBarChart = {
        //  labels: ['7.1', '6.0', '5.0'],
        //  series: [
        //    [4, 1, 3]
        //  ]
        //};

        const optionsSimpleBarChart = {
          seriesBarDistance: 10,
          axisX: {
            showGrid: false
          },
          axisY: {
            showGrid: true,
            onlyInteger: true,
            offset: 40
          },
          height: '300px'
        };

        const responsiveOptionsSimpleBarChart: any = [
          ['screen and (max-width: 640px)', {
            seriesBarDistance: 5,
            axisX: {
              labelInterpolationFnc: function (value: any) {
                return value[0];
              }
            }
          }]
        ];

        const simpleBarChart = new Chartist.Bar('#simpleBarChart', dataSimpleBarChart, optionsSimpleBarChart,
          responsiveOptionsSimpleBarChart);

        // start animation for the Emails Subscription Chart
        this.startAnimationForBarChart(simpleBarChart);

        /*  **************** 2 Gráfico de Barra - Versões Android ******************** */


        /*  **************** 3 Gráfico de Pizza - Disponibilidade ******************** */

        const dataPreferences = {
          labels: [this.percentOnlineEquips, this.percentOfflineEquips],
          series: [this.percentOnlineEquipsN, this.percentOfflineEquipsN]
        };

        const optionsPreferences = {
          height: '230px'
        };

        new Chartist.Pie('#chartPreferences', dataPreferences, optionsPreferences);

        /*  **************** 3 Gráfico de Pizza - Disponibilidade ******************** */
      });
  }
}
