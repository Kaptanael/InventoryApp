import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AddEditVendorComponent } from './add-edit-vendor.component';
import { BranchService } from '../../../_services/branch.service';


const routes: Routes = [{
  path: '',
  children:
    [
      {
        path: '',
        component: AddEditVendorComponent
      }      
    ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: [BranchService]
})
export class AddEditVendorRoutingModule { }
