import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddEditWarehouseComponent } from './add-edit-warehouse.component';

const routes: Routes = [{
  path: '',
  component: AddEditWarehouseComponent
}];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AddEditWarehouseRoutingModule { }
