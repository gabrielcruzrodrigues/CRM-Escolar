import { Component } from '@angular/core';
import { MenuComponent } from '../../components/layout/menu/menu.component';
import { InfosComponent } from '../../components/layout/infos/infos.component';

@Component({
  selector: 'app-painel',
  standalone: true,
  imports: [MenuComponent, InfosComponent],
  templateUrl: './painel.component.html',
  styleUrl: './painel.component.scss'
})
export class PainelComponent {

}
