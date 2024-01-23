import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TransferOrderRoutingModule } from './transfer-order-routing.module';
import { TransferOrderComponent } from './transfer-order.component';


@NgModule({
  declarations: [TransferOrderComponent],
  imports: [
    CommonModule,
    TransferOrderRoutingModule
  ]
})
export class TransferOrderModule { }
