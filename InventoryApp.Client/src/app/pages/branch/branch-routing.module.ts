import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BranchComponent } from './branch.component';


const routes: Routes = [{
  path: '',
  children:
    [
      {
        path: '',
        component: BranchComponent
      },
      {
        path: 'add-edit-branch', loadChildren: () => import('./add-edit-branch/add-edit-branch.module').then(m => m.AddEditBranchModule)
      },
      {
        path: 'add-edit-branch/:id', loadChildren: () => import('./add-edit-branch/add-edit-branch.module').then(m => m.AddEditBranchModule)
      }
    ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BranchRoutingModule { }
