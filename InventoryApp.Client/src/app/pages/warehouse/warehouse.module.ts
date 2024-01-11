import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WarehouseRoutingModule } from './warehouse-routing.module';
import { RouterModule } from '@angular/router';
import { WarehouseComponent } from './warehouse.component';


@NgModule({
  declarations: [WarehouseComponent],
  imports: [
    CommonModule,
    WarehouseRoutingModule,
    RouterModule
  ]
})
export class WarehouseModule { }
