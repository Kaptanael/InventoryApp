import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AddEditRoleComponent } from './add-edit-role.component';
import { RoleService } from '../../../_services/role.service';


const routes: Routes = [{
  path: '',
  children:
    [
      {
        path: '',
        component: AddEditRoleComponent
      }      
    ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: [RoleService]
})
export class AddEditRoleRoutingModule { }
