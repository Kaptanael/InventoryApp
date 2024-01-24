import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { TableModule } from 'primeng/table';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmationService, MessageService } from 'primeng/api';

import { BranchRoutingModule } from './branch-routing.module';
import { BranchComponent } from './branch.component';
import { BranchService } from '../../_services/branch.service';
import { ToastModule } from 'primeng/toast';


@NgModule({
  declarations: [BranchComponent],
  imports: [
    CommonModule,
    BranchRoutingModule,
    RouterModule,
    TableModule,
    ConfirmDialogModule,
    ToastModule
  ],
  providers: [ConfirmationService, MessageService, BranchService]
})
export class BranchModule { }
