import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AddEditWarehouseRoutingModule } from './add-edit-warehouse-routing.module';
import { AddEditWarehouseComponent } from './add-edit-warehouse.component';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [
    AddEditWarehouseComponent
  ],
  imports: [
    CommonModule,
    AddEditWarehouseRoutingModule,
    RouterModule
  ]
})
export class AddEditWarehouseModule { }
