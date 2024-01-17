import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TableModule } from 'primeng/table';

import { BranchRoutingModule } from './branch-routing.module';
import { RouterModule } from '@angular/router';
import { BranchComponent } from './branch.component';


@NgModule({
  declarations: [BranchComponent],
  imports: [
    CommonModule,
    BranchRoutingModule,
    RouterModule,
    TableModule
  ]
})
export class BranchModule { }
