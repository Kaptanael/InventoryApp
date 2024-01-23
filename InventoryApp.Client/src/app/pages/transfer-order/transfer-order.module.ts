import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TransferOrderRoutingModule } from './transfer-order-routing.module';
import { TransferOrderComponent } from './transfer-order.component';
import { TableModule } from 'primeng/table';


@NgModule({
  declarations: [TransferOrderComponent],
  imports: [
    CommonModule,
    TransferOrderRoutingModule,
    TableModule
  ]
})
export class TransferOrderModule { }
