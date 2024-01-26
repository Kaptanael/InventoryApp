import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { RoleComponent } from './role.component';


const routes: Routes = [{
  path: '',
  children:
    [
      {
        path: '',
        component: RoleComponent
      },
      {
        path: 'add-edit-role', loadChildren: () => import('./add-edit-role/add-edit-role.module').then(m => m.AddEditRoleModule)
      },
      {
        path: 'add-edit-role/:id', loadChildren: () => import('./add-edit-role/add-edit-role.module').then(m => m.AddEditRoleModule)
      }
    ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RoleRoutingModule { }
