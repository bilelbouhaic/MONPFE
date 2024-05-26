import { Component,OnInit} from '@angular/core';

@Component({
  selector: 'app-chart-nb-vendu',
  templateUrl: './chart-nb-vendu.component.html',
  styleUrl: './chart-nb-vendu.component.css'
})
export class ChartNbVenduComponent implements OnInit {

  data: any;
  options: any;

  ngOnInit() {
    this.data = {
      labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
      datasets: [
        {
          label: 'Prix du Petrole',
          data: [65, 59, 80, 81, 56, 55, 40, 70, 60, 75, 65, 50],
          fill: false,
          borderColor: '#F4A261',
          tension: 0.4
        },
        {
          label: 'Prix du GPL',
          data: [28, 48, 40, 19, 86, 27, 90, 60, 55, 65, 70, 65],
          fill: false,
          borderColor: '#42A5F5',
          tension: 0.4
        },
        {
          label: 'Ventes de véhicules électriques',
          data: [10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120],
          fill: true,
          borderColor: '#66BB6A',
          tension: 0.4
        }
      ]
    };

    this.options = {
      responsive: true,
      plugins: {
        legend: {
          position: 'top'
        }
      }
    };
  }
}
