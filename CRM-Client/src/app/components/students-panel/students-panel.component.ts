import { Component } from '@angular/core';
import { MenuComponent } from '../layout/menu/menu.component';
import { InfosComponent } from '../layout/infos/infos.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-students-panel',
  standalone: true,
  imports: [MenuComponent, InfosComponent],
  templateUrl: './students-panel.component.html',
  styleUrl: './students-panel.component.scss'
})
export class StudentsPanelComponent {

  constructor(private router: Router) 
  { }

  redirectToCreate() : void {
    this.router.navigate(["/create-student"]);
  }
}
