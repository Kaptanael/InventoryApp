import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AddEditUserRoutingModule } from './add-edit-user-routing.module';
import { MessageService } from 'primeng/api';
import { ToastModule } from 'primeng/toast';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { AddEditUserComponent } from './add-edit-user.component';
import { RoleService } from '../../../_services/role.service';


@NgModule({
  declarations: [AddEditUserComponent],
  imports: [
    CommonModule,
    AddEditUserRoutingModule,
    RouterModule,
    ReactiveFormsModule,
    ToastModule
  ],
  providers: [MessageService, RoleService]
})
export class AddEditUserModule { }
