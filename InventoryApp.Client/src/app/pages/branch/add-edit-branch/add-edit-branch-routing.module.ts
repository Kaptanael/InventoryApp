import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddEditBranchComponent } from './add-edit-branch.component';
import { BranchComponent } from '../branch.component';


const routes: Routes = [{
  path: '',
  children:
    [
      {
        path: '',
        component: AddEditBranchComponent
      }      
    ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AddEditBranchRoutingModule { }
