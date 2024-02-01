import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { TableModule } from 'primeng/table';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ToastModule } from 'primeng/toast';

import { VendorRoutingModule } from './vendor-routing.module';
import { VendorComponent } from './vendor.component';
import { VendorService } from '../../_services/vendor.service';


@NgModule({
  declarations: [VendorComponent],
  imports: [
    CommonModule,
    VendorRoutingModule,
    RouterModule,
    TableModule,
    ConfirmDialogModule,
    ToastModule
  ],
  providers: [ConfirmationService, MessageService, VendorService]
})
export class VendorModule { }
