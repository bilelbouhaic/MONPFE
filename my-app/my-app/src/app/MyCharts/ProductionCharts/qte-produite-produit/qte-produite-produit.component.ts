import { Component, OnInit } from '@angular/core';
import { DataCubeService } from './qte-produite-produit.service';

@Component({
  selector: 'app-qte-produite-produit',
  templateUrl: './qte-produite-produit.component.html',
  styleUrls: ['./qte-produite-produit.component.css']
})
export class QteProduiteProduitComponent implements OnInit {
  data: any;
  options: any;

  constructor(private dataCubeService: DataCubeService) {}

  ngOnInit() {
    this.dataCubeService.getData().subscribe(
      response => {
        const labels = Object.keys(response);
        const dataValues = Object.values(response);

        this.data = {
          labels: labels,
          datasets: [
            {
              data: dataValues,
              backgroundColor: ['#F4A261', '#264653', '#E9C46A', '#42A5F5'],
              hoverBackgroundColor: ['#F4A261', '#264653', '#E9C46A', '#42A5F5']
            }
          ]
        };

        this.options = {
          indexAxis: 'y',
          scales: {
            x: {
              beginAtZero: true
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
