import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { VendorComponent } from './vendor.component';


const routes: Routes = [{
  path: '',
  children:
    [
      {
        path: '',
        component: VendorComponent
      },
      {
        path: 'add-edit-vendor', loadChildren: () => import('./add-edit-vendor/add-edit-vendor.module').then(m => m.AddEditVendorModule)
      },
      {
        path: 'add-edit-vendor/:id', loadChildren: () => import('./add-edit-vendor/add-edit-vendor.module').then(m => m.AddEditVendorModule)
      }
    ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VendorRoutingModule { }
