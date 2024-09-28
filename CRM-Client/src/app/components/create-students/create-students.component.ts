import { Component } from '@angular/core';
import { MenuComponent } from '../layout/menu/menu.component';
import { InfosBackComponent } from '../layout/infos-back/infos-back.component';

@Component({
  selector: 'app-create-students',
  standalone: true,
  imports: [MenuComponent, InfosBackComponent],
  templateUrl: './create-students.component.html',
  styleUrl: './create-students.component.scss'
})
export class CreateStudentsComponent {

  link: string = '/students-panel';
  title: string = "Cadastrar responsável";
}
