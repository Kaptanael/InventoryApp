import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { ToastModule } from 'primeng/toast';

import { AddEditRoleRoutingModule } from './add-edit-role-routing.module';
import { AddEditRoleComponent } from './add-edit-role.component';
import { RoleService } from '../../../_services/role.service';

@NgModule({
  declarations: [AddEditRoleComponent],
  imports: [
    CommonModule,
    AddEditRoleRoutingModule,
    RouterModule,
    ReactiveFormsModule,
    ToastModule
  ],
  providers: [MessageService, RoleService]
})
export class AddEditRoleModule { }
