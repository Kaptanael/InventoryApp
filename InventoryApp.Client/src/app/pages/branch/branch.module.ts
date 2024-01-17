import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TableModule } from 'primeng/table';

import { BranchRoutingModule } from './branch-routing.module';
import { RouterModule } from '@angular/router';
import { BranchComponent } from './branch.component';
import { BranchService } from '../../_services/branch.service';


@NgModule({
  declarations: [BranchComponent],
  imports: [
    CommonModule,
    BranchRoutingModule,
    RouterModule,
    TableModule
  ],
  providers: [BranchService]
})
export class BranchModule { }
