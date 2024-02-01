import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { ToastModule } from 'primeng/toast';

import { AddEditVendorRoutingModule } from './add-edit-vendor-routing.module';
import { AddEditVendorComponent } from './add-edit-vendor.component';
import { VendorService } from '../../../_services/vendor.service';


@NgModule({
  declarations: [AddEditVendorComponent],
  imports: [
    CommonModule,
    AddEditVendorRoutingModule,
    RouterModule,
    ReactiveFormsModule,
    ToastModule
  ],
  providers: [MessageService, VendorService]
})
export class AddEditVendorModule { }
