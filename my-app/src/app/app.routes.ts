
import { Routes } from '@angular/router';
import { StudentComponent } from './student/student';
import { NotFoundComponent } from './not-found/not-found'; 


export const routes: Routes = [
  { path: '', component: StudentComponent },  
  { path: '**', component: NotFoundComponent } 
];

