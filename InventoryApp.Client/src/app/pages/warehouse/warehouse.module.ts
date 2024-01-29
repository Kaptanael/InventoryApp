import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { TableModule } from 'primeng/table';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ToastModule } from 'primeng/toast';

import { WarehouseRoutingModule } from './warehouse-routing.module';
import { WarehouseComponent } from './warehouse.component';
import { WarehouseService } from '../../_services/warehouse.service';


@NgModule({
  declarations: [WarehouseComponent],
  imports: [
    CommonModule,
    WarehouseRoutingModule,
    RouterModule,
    TableModule,
    ConfirmDialogModule,
    ToastModule
  ],
  providers: [ConfirmationService, MessageService, WarehouseService]
})
export class WarehouseModule { }
