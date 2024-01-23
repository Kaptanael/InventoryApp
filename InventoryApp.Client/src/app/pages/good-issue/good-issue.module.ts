import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GoodIssueRoutingModule } from './good-issue-routing.module';
import { GoodIssueComponent } from './good-issue.component';
import { TableModule } from 'primeng/table';


@NgModule({
  declarations: [GoodIssueComponent],
  imports: [
    CommonModule,
    GoodIssueRoutingModule,
    TableModule
  ]
})
export class GoodIssueModule { }
