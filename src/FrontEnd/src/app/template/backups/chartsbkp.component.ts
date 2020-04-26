import { Component, OnInit } from '@angular/core';

import * as Chartist from 'chartist';

@Component({
  selector: 'app-chartsbkp-cmp',
  templateUrl: './chartsbkp.component.html'
})

export class ChartsBkpComponent implements OnInit {
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
    /* ----------==========    Rounded Line Chart initialization    ==========---------- */

    const dataRoundedLineChart = {
      labels: ['M', 'T', 'W', 'T', 'F', 'S', 'S'],
      series: [
        [12, 17, 7, 17, 23, 18, 38]
      ]
    };

    const optionsRoundedLineChart: any = {
      lineSmooth: Chartist.Interpolation.cardinal({
        tension: 10
      }),
      axisX: {
        showGrid: false,
      },
      low: 0,
      high: 50,
      chartPadding: { top: 0, right: 0, bottom: 0, left: 0 },
      showPoint: false,
      showLine: true
    };

    const RoundedLineChart = new Chartist.Line('#roundedLineChart', dataRoundedLineChart, optionsRoundedLineChart);

    this.startAnimationForLineChart(RoundedLineChart);


    /*  **************** Straight Lines Chart - single line with points ******************** */

    const dataStraightLinesChart = {
      labels: ['\'07', '\'08', '\'09', '\'10', '\'11', '\'12', '\'13', '\'14', '\'15'],
      series: [
        [10, 16, 8, 13, 20, 15, 20, 34, 30]
      ]
    };

    const optionsStraightLinesChart: any = {
      lineSmooth: Chartist.Interpolation.cardinal({
        tension: 0
      }),
      low: 0,
      high: 50,
      // something for a better look
      chartPadding: { top: 0, right: 0, bottom: 0, left: 0 },
      classNames: {
        point: 'ct-point ct-white',
        line: 'ct-line ct-white'
      }
    };

    const straightLinesChart = new Chartist.Line('#straightLinesChart', dataStraightLinesChart,
      optionsStraightLinesChart);

    this.startAnimationForLineChart(straightLinesChart);


    /*  **************** Coloured Rounded Line Chart - Line Chart ******************** */


    const dataColouredRoundedLineChart = {
      labels: ['\'06', '\'07', '\'08', '\'09', '\'10', '\'11', '\'12', '\'13', '\'14', '\'15'],
      series: [
        [287, 480, 290, 554, 690, 690, 500, 752, 650, 900, 944]
      ]
    };

    const optionsColouredRoundedLineChart: any = {
      lineSmooth: Chartist.Interpolation.cardinal({
        tension: 10
      }),
      axisY: {
        showGrid: true,
        offset: 40
      },
      axisX: {
        showGrid: false,
      },
      low: 0,
      high: 1000,
      showPoint: true,
      height: '300px'
    };

    const colouredRoundedLineChart = new Chartist.Line('#colouredRoundedLineChart', dataColouredRoundedLineChart,
      optionsColouredRoundedLineChart);

    this.startAnimationForLineChart(colouredRoundedLineChart);


    /*  **************** Coloured Rounded Line Chart - Line Chart ******************** */


    const dataColouredBarsChart = {
      labels: ['\'06', '\'07', '\'08', '\'09', '\'10', '\'11', '\'12', '\'13', '\'14', '\'15'],
      series: [
        [287, 385, 490, 554, 586, 698, 695, 752, 788, 846, 944],
        [67, 152, 143, 287, 335, 435, 437, 539, 542, 544, 647],
        [23, 113, 67, 190, 239, 307, 308, 439, 410, 410, 509]
      ]
    };

    const optionsColouredBarsChart: any = {
      lineSmooth: Chartist.Interpolation.cardinal({
        tension: 10
      }),
      axisY: {
        showGrid: true,
        offset: 40
      },
      axisX: {
        showGrid: false,
      },
      low: 0,
      high: 1000,
      showPoint: true,
      height: '300px'
    };


    const colouredBarsChart = new Chartist.Line('#colouredBarsChart', dataColouredBarsChart,
      optionsColouredBarsChart);

    this.startAnimationForLineChart(colouredBarsChart);



    /*  **************** Public Preferences - Pie Chart ******************** */

    const dataPreferences = {
      labels: ['62%', '32%', '6%'],
      series: [62, 32, 6]
    };

    const optionsPreferences = {
      height: '230px'
    };

    new Chartist.Pie('#chartPreferences', dataPreferences, optionsPreferences);

    /*  **************** Simple Bar Chart - barchart ******************** */

    const dataSimpleBarChart = {
      labels: ['Jan', 'Feb', 'Mar', 'Apr', 'Mai', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
      series: [
        [542, 443, 320, 780, 553, 453, 326, 434, 568, 610, 756, 895]
      ]
    };

    const optionsSimpleBarChart = {
      seriesBarDistance: 10,
      axisX: {
        showGrid: false
      }
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


    const dataMultipleBarsChart = {
      labels: ['Jan', 'Feb', 'Mar', 'Apr', 'Mai', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
      series: [
        [542, 443, 320, 780, 553, 453, 326, 434, 568, 610, 756, 895],
        [412, 243, 280, 580, 453, 353, 300, 364, 368, 410, 636, 695]
      ]
    };

    const optionsMultipleBarsChart = {
      seriesBarDistance: 10,
      axisX: {
        showGrid: false
      },
      height: '300px'
    };

    const responsiveOptionsMultipleBarsChart: any = [
      ['screen and (max-width: 640px)', {
        seriesBarDistance: 5,
        axisX: {
          labelInterpolationFnc: function (value: any) {
            return value[0];
          }
        }
      }]
    ];

    const multipleBarsChart = new Chartist.Bar('#multipleBarsChart', dataMultipleBarsChart,
      optionsMultipleBarsChart, responsiveOptionsMultipleBarsChart);

    // start animation for the Emails Subscription Chart
    this.startAnimationForBarChart(multipleBarsChart);
  }
}
