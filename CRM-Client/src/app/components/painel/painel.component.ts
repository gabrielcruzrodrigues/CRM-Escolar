import { Component } from '@angular/core';
import { MenuComponent } from '../layout/menu/menu.component';
import { InfosComponent } from "../layout/infos/infos.component";

@Component({
  selector: 'app-painel',
  standalone: true,
  imports: [MenuComponent, InfosComponent],
  templateUrl: './painel.component.html',
  styleUrl: './painel.component.scss'
})
export class PainelComponent {

}
