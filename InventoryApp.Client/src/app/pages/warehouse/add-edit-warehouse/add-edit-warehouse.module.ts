import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { ToastModule } from 'primeng/toast';

import { AddEditWarehouseRoutingModule } from './add-edit-warehouse-routing.module';
import { AddEditWarehouseComponent } from './add-edit-warehouse.component';
import { WarehouseService } from '../../../_services/warehouse.service';


@NgModule({
  declarations: [
    AddEditWarehouseComponent
  ],
  imports: [
    CommonModule,
    AddEditWarehouseRoutingModule,
    RouterModule,
    ReactiveFormsModule,
    ToastModule
  ],
  providers: [MessageService, WarehouseService]
})
export class AddEditWarehouseModule { }
