import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ShipmentRoutingModule } from './shipment-routing.module';
import { ShipmentComponent } from './shipment.component';
import { TableModule } from 'primeng/table';


@NgModule({
  declarations: [ShipmentComponent],
  imports: [
    CommonModule,
    ShipmentRoutingModule,
    TableModule
  ]
})
export class ShipmentModule { }
