import { Routes } from '@angular/router';
import { PainelComponent } from './pages/painel/painel.component';
import { StudentsPanelComponent } from './pages/students-panel/students-panel.component';
import { CreateStudentsComponent } from './pages/create-students/create-students.component';

export const routes: Routes = [
     {
          path: '', component: PainelComponent
     },
     {
          path: 'students-panel', component: StudentsPanelComponent
     },
     {
          path: 'create-student', component: CreateStudentsComponent
     }
];
