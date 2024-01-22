import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddEditBranchComponent } from './add-edit-branch.component';
import { BranchService } from '../../../_services/branch.service';


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
  exports: [RouterModule],
  providers: [BranchService]
})
export class AddEditBranchRoutingModule { }
