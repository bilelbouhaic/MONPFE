import { Component, OnInit } from '@angular/core';
import { WilayaQTeService } from './wilayaqteService';

@Component({
  selector: 'app-qte-produite-temperature',
  templateUrl: './qte-produite-temperature.component.html',
  styleUrls: ['./qte-produite-temperature.component.css']
})
export class QteProduiteTemperatureComponent implements OnInit {
  data: any;
  options: any;

  constructor(private service: WilayaQTeService) {}

  ngOnInit() {
    this.service.getData1().subscribe(
      response1 => {
        this.service.getData3().subscribe(
          response2 => {
            this.service.getData33().subscribe(
              response3 => {
                this.data = {
                  labels: ['Avril', 'Mai'],
                  datasets: [
                    {
                      label: 'Adrar',
                      data: response1,
                      yAxisID: 'y-axis-2',
                      borderColor: 'orange',
                      backgroundColor: 'orange',
                      fill: false,
                      hidden: false // Afficher par défaut
                    },
                    {
                      label: 'Illizi',
                      data: response2,
                      yAxisID: 'y-axis-2',
                      borderColor: 'green',
                      backgroundColor: 'green',
                      fill: false,
                      hidden: false // Afficher par défaut
                    },
                    {
                      label: 'Autre Wilaya',
                      data: response3,
                      yAxisID: 'y-axis-2',
                      borderColor: 'blue',
                      backgroundColor: 'blue',
                      fill: false,
                      hidden: false // Afficher par défaut
                    }
                  ]
                };
              }
            );
          }
        );
      }
    );
  }
}
