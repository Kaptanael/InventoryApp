import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AddEditWarehouseComponent } from './add-edit-warehouse.component';
import { WarehouseService } from '../../../_services/warehouse.service';


const routes: Routes = [{
  path: '',
  children:
    [
      {
        path: '',
        component: AddEditWarehouseComponent
      }
    ]
}];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: [WarehouseService]
})
export class AddEditWarehouseRoutingModule { }
