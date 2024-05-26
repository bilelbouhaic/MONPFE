import { Component, AfterViewInit } from '@angular/core';
import { DataCubeService } from './perimetre-rentable.service';
import { Chart, ChartOptions } from 'chart.js/auto';

@Component({
  selector: 'app-perimetre-rentable',
  templateUrl: './perimetre-rentable.component.html',
  styleUrls: ['./perimetre-rentable.component.css']
})
export class PerimetreRentableComponent implements AfterViewInit {
  constructor(private dataCubeService: DataCubeService) {}

  ngAfterViewInit() {
    this.dataCubeService.getData().subscribe(
      response => {
        const labels = Object.keys(response);
        const dataValues = labels.map(label => response[label].usd);

        const data = {
          labels: labels,
          datasets: [
            {
              data: dataValues,
              backgroundColor: ['#F4A261', '#264653', '#E9C46A', '#42A5F5'],
              hoverBackgroundColor: ['#F4A261', '#264653', '#E9C46A', '#42A5F5']
            }
          ]
        };

        const options: ChartOptions<'polarArea'> = {
          responsive: true,
          maintainAspectRatio: false,
          plugins: {
            legend: {
              position: 'top',
            },
            tooltip: {
              callbacks: {
                label: (tooltipItem) => {
                  const dataIndex = tooltipItem.dataIndex as number;
                  return `${labels[dataIndex]}: ${tooltipItem.raw} USD`;
                }
              }
            }
          }
        };

        const ctx = document.getElementById('myChart') as HTMLCanvasElement;
        if (ctx) {
          new Chart(ctx, {
            type: 'polarArea',
            data: data,
            options: options
          });
        }
      },
      error => {
        console.error('Error fetching data', error);
      }
    );
  }
}
