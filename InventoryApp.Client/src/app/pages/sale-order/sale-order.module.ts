import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SaleOrderRoutingModule } from './sale-order-routing.module';
import { SaleOrderComponent } from './sale-order.component';
import { TableModule } from 'primeng/table';


@NgModule({
  declarations: [SaleOrderComponent],
  imports: [
    CommonModule,
    SaleOrderRoutingModule,
    TableModule
  ]
})
export class SaleOrderModule { }
