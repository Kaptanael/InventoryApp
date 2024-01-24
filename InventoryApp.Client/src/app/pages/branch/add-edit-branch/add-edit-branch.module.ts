import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { ToastModule } from 'primeng/toast';

import { AddEditBranchRoutingModule } from './add-edit-branch-routing.module';
import { AddEditBranchComponent } from './add-edit-branch.component';
import { BranchService } from '../../../_services/branch.service';


@NgModule({
  declarations: [AddEditBranchComponent],
  imports: [
    CommonModule,
    AddEditBranchRoutingModule,
    RouterModule,
    ReactiveFormsModule,
    ToastModule
  ],
  providers: [ MessageService, BranchService]
})
export class AddEditBranchModule { }
