import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { ToastModule } from 'primeng/toast';

import { AddEditProductTypeRoutingModule } from './add-edit-product-type-routing.module';
import { AddEditProductTypeComponent } from './add-edit-product-type.component';
import { ProductTypeService } from '../../../_services/product-type.service';


@NgModule({
  declarations: [AddEditProductTypeComponent],
  imports: [
    CommonModule,
    AddEditProductTypeRoutingModule,
    RouterModule,
    ReactiveFormsModule,
    ToastModule
  ],
  providers: [MessageService, ProductTypeService]
})
export class AddEditProductTypeModule { }
