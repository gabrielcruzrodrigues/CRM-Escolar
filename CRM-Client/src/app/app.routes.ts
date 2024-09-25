import { Routes } from '@angular/router';
import { PainelComponent } from './components/painel/painel.component';
import { StudentsPanelComponent } from './components/students-panel/students-panel.component';

export const routes: Routes = [
     {
          path: '', component: PainelComponent
     },
     {
          path: 'students-panel', component: StudentsPanelComponent
     }
];
