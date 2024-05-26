import { Component } from '@angular/core';
import { CalendarModule } from 'primeng/calendar';
@Component({
  selector: 'app-statistique',
  templateUrl: './statistique.component.html',
  styleUrl: './statistique.component.css'
})
export class StatistiqueComponent {
  selectedDate: string;
  
  constructor() {
    this.selectedDate = '';
  }
  onDateChange(event: any): void {
    this.selectedDate = event.target.value;
  }

  

}
