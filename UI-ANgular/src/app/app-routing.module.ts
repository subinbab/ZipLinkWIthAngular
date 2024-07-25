import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DataDisplayComponent } from './data-display/data-display.component';

const routes: Routes = [
  { path: ':data', component: DataDisplayComponent }, // Route with a parameter
  { path: '', redirectTo: '/default', pathMatch: 'full' }, // Default route
  // Add other routes as needed
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
