import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AddEditWarehouseRoutingModule } from './add-edit-warehouse-routing.module';
import { AddEditWarehouseComponent } from './add-edit-warehouse.component';


@NgModule({
  declarations: [
    AddEditWarehouseComponent
  ],
  imports: [
    CommonModule,
    AddEditWarehouseRoutingModule
  ]
})
export class AddEditWarehouseModule { }
