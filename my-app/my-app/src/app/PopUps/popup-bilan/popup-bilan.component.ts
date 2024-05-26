import { Component, EventEmitter, Output } from '@angular/core';
import { BilanService } from './popup-bilan.service';

@Component({
  selector: 'app-popup-bilan',
  templateUrl: './popup-bilan.component.html',
  styleUrls: ['./popup-bilan.component.css']
})
export class PopupBilanComponent {
  @Output() close = new EventEmitter<void>();

  constructor(private bilanService: BilanService) { }

  selectedType: string = ''; // Property to store the selected type
  selectedDate: string = ''; // Property to store the selected date

  closeBilanPopup() {
    this.close.emit();
  }

  imprimerBilan() {
    this.bilanService.generateBilanPDF().subscribe((data: Blob) => {
      const blob = new Blob([data], { type: 'application/pdf' });
      const url = window.URL.createObjectURL(blob);
      window.open(url); // Open the PDF in a new tab
    });
  }
}
