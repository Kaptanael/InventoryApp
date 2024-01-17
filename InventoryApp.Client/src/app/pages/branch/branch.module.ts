import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BranchRoutingModule } from './branch-routing.module';
import { RouterModule } from '@angular/router';
import { BranchComponent } from './branch.component';


@NgModule({
  declarations: [BranchComponent],
  imports: [
    CommonModule,
    BranchRoutingModule,
    RouterModule,    
  ]
})
export class BranchModule { }
