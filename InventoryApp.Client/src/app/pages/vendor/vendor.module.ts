import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VendorRoutingModule } from './vendor-routing.module';
import { VendorComponent } from './vendor.component';
import { TableModule } from 'primeng/table';


@NgModule({
  declarations: [VendorComponent],
  imports: [
    CommonModule,
    VendorRoutingModule,
    TableModule
  ]
})
export class VendorModule { }
