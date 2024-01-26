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
      //{
      //  path: 'add-edit-product-type', loadChildren: () => import('./add-edit-product-type/add-edit-product-type.module').then(m => m.AddEditProductTypeModule)
      //},
      //{
      //  path: 'add-edit-product-type/:id', loadChildren: () => import('./add-edit-product-type/add-edit-product-type.module').then(m => m.AddEditProductTypeModule)
      //}
    ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RoleRoutingModule { }
