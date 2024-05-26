import { Component, AfterViewInit } from '@angular/core';
import { DataCubeService } from './qte-produite-perimetre.service';
import { Chart, ChartOptions } from 'chart.js/auto';

@Component({
  selector: 'app-qte-produite-perimetre',
  templateUrl: './qte-produite-perimetre.component.html',
  styleUrls: ['./qte-produite-perimetre.component.css']
})
export class QteProduitePerimetreComponent implements AfterViewInit {
  constructor(private dataCubeService: DataCubeService) {}

  ngAfterViewInit() {
    this.dataCubeService.getData().subscribe(
      response => {
        const labels = Object.keys(response);
        const dataValues = Object.values(response);

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

        const options: ChartOptions<'pie'> = {
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
        new Chart(ctx, {
          type: 'pie',
          data: data,
          options: options
        });
      },
      error => {
        console.error('Error fetching data', error);
      }
    );
  }
}
