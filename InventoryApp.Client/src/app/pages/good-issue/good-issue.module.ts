import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GoodIssueRoutingModule } from './good-issue-routing.module';
import { GoodIssueComponent } from './good-issue.component';


@NgModule({
  declarations: [GoodIssueComponent],
  imports: [
    CommonModule,
    GoodIssueRoutingModule
  ]
})
export class GoodIssueModule { }
