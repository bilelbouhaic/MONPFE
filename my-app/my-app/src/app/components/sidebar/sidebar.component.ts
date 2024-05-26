import { Chart } from 'chart.js/auto';
import { Component } from '@angular/core';
import { faHome,faChartLine, faCalculator ,faChartSimple, faOilWell, faCircleDollarToSlot, faFileInvoiceDollar, faFileArrowDown} from '@fortawesome/free-solid-svg-icons';
@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.css'
})
export class SidebarComponent {
 home= faHome;
 stat =faChartLine;
 calcul=faCalculator;
 Chart=faChartSimple
 Oil=faOilWell
 dollar=faCircleDollarToSlot
 trp=faFileInvoiceDollar
 rdv=faFileArrowDown

}
