import { Component, AfterViewInit } from '@angular/core';
import {  DataCubeServiceKpi } from './acceuil.service';
import { DateService } from '../statistique/date.service';
import { DateService2 } from './date2.service';

@Component({
  selector: 'app-acceuil',
  templateUrl: './acceuil.component.html',
  styleUrls: ['./acceuil.component.css']
})
export class AcceuilComponent implements AfterViewInit {
  selectedDate: string;
  kpi1 = 0;
  kpi2 = 0;
  kpi3 = 0;

  constructor(private dataCubeService: DataCubeServiceKpi, private dateService: DateService2) {
    this.selectedDate = '2017-05-10'; // Initialize with the default date
  }

  onDateChange(date: string) {
    this.dateService.updateDate(date);
  }

  ngAfterViewInit() {
    // S'abonner aux changements de date
    this.dateService.selectedDate$.subscribe(date => {
      // Appeler le service pour obtenir les données en fonction de la nouvelle date
      this.dataCubeService.getData().subscribe(
        response => {
          console.log(response[0]);
          this.kpi1 = parseFloat(response[0].valeur.toFixed(2));
          // Si kpi2 et kpi3 doivent également être arrondis, utilisez la même méthode
          this.kpi2 = parseFloat(response[0].valeur1.toFixed(2));
          this.kpi3 = parseFloat(response[0].valeur2.toFixed(2));
        },
        error => {
          console.error('Error fetching data', error);
        }
      );
    });
  }
}
