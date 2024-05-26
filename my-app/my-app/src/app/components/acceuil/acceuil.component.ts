import { Component } from '@angular/core';

@Component({
  selector: 'app-acceuil',
  templateUrl: './acceuil.component.html',
  styleUrl: './acceuil.component.css'
})
export class AcceuilComponent {
  selectedDate: string;
  
  constructor() {
    this.selectedDate = '';
  }
  onDateChange(event: any): void {
    this.selectedDate = event.target.value;
  }
}
