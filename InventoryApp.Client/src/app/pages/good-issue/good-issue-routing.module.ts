import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GoodIssueComponent } from './good-issue.component';

const routes: Routes = [{
  path: '',
  children:
    [
      {
        path: '',
        component: GoodIssueComponent
      }
    ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GoodIssueRoutingModule { }
