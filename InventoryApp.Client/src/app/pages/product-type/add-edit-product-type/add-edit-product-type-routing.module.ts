import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AddEditProductTypeComponent } from './add-edit-product-type.component';
import { ProductTypeService } from '../../../_services/product-type.service';


const routes: Routes = [{
  path: '',
  children:
    [
      {
        path: '',
        component: AddEditProductTypeComponent
      }      
    ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: [ProductTypeService]
})
export class AddEditProductTypeRoutingModule { }
