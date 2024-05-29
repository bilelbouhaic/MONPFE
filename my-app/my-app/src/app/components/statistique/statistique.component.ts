// statistique.component.ts
import { Component } from '@angular/core';
import { DateService } from './date.service';

@Component({
  selector: 'app-statistique',
  templateUrl: './statistique.component.html',
  styleUrls: ['./statistique.component.css']
})
export class StatistiqueComponent {
  selectedDate: string;

  constructor(private dateService: DateService) {
    this.selectedDate = '2017-05-10'; // Initialize with the default date
  }

  onDateChange(date: string) {
    this.dateService.updateDate(date);
  }
}
