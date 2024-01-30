import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { MenuComponent } from './menu.component';


const routes: Routes = [{
  path: '',
  children:
    [
      {
        path: '',
        component: MenuComponent
      },
      {
        path: 'add-edit-menu', loadChildren: () => import('./add-edit-menu/add-edit-menu.module').then(m => m.AddEditMenuModule)
      },
      {
        path: 'add-edit-menu/:id', loadChildren: () => import('./add-edit-menu/add-edit-menu.module').then(m => m.AddEditMenuModule)
      }
    ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MenuRoutingModule { }
