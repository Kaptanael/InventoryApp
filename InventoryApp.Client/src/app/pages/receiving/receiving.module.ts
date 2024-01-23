import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ReceivingRoutingModule } from './receiving-routing.module';
import { ReceivingComponent } from './receiving.component';
import { TableModule } from 'primeng/table';


@NgModule({
  declarations: [ReceivingComponent],
  imports: [
    CommonModule,
    ReceivingRoutingModule,
    TableModule
  ]
})
export class ReceivingModule { }
