import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { AddEditBranchRoutingModule } from './add-edit-branch-routing.module';
import { AddEditBranchComponent } from './add-edit-branch.component';


@NgModule({
  declarations: [AddEditBranchComponent],
  imports: [
    CommonModule,
    AddEditBranchRoutingModule,
    RouterModule,
    ReactiveFormsModule
  ]
})
export class AddEditBranchModule { }
