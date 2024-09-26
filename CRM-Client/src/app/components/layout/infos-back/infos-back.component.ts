import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-infos-back',
  standalone: true,
  imports: [],
  templateUrl: './infos-back.component.html',
  styleUrl: './infos-back.component.scss'
})
export class InfosBackComponent {
  @Input() link: string = ''; 
}
