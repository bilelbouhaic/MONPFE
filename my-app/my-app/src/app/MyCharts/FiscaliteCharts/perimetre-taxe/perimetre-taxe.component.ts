import { Component, AfterViewInit } from '@angular/core';
import { DataCubeService } from './perimetre-taxe.service';
import { Chart, ChartOptions } from 'chart.js/auto';



@Component({
  selector: 'app-perimetre-taxe',
  templateUrl: './perimetre-taxe.component.html',
  styleUrl: './perimetre-taxe.component.css'
})
export class PerimetreTaxeComponent  implements AfterViewInit {
  chartData: any;
  chartOptions: any;

  constructor(private dataCubeService: DataCubeService) {}

  ngAfterViewInit() {
    this.dataCubeService.getData().subscribe(
      response => {
        const labels = Object.keys(response);
        const dataValues = labels.map(label => response[label].usd);

        this.chartData = {
          labels: labels,
          datasets: [
            {
              data: dataValues,
              backgroundColor: ['#F4A261', '#264653', '#E9C46A', '#42A5F5'],
              hoverBackgroundColor: ['#F4A261', '#264653', '#E9C46A', '#42A5F5']
            }
          ]
        };

        this.chartOptions = {
          responsive: true,
          maintainAspectRatio: false,
          plugins: {
            legend: {
              position: 'top',
            },
            tooltip: {
              callbacks: {
                label: (tooltipItem: { dataIndex: number; raw: any; }) => {
                  const dataIndex = tooltipItem.dataIndex as number;
                  return `${labels[dataIndex]}: ${tooltipItem.raw} USD`;
                }
              }
            }
          }
        };
      },
      error => {
        console.error('Error fetching data', error);
      }
    );
  }
}

