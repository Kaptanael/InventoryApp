import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PurchaseOrderRoutingModule } from './purchase-order-routing.module';
import { PurchaseOrderComponent } from './purchase-order.component';
import { TableModule } from 'primeng/table';


@NgModule({
  declarations: [PurchaseOrderComponent],
  imports: [
    CommonModule,
    PurchaseOrderRoutingModule,
    TableModule
  ]
})
export class PurchaseOrderModule { }
