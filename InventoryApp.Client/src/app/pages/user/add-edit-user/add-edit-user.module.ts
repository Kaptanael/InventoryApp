import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AddEditUserRoutingModule } from './add-edit-user-routing.module';
import { MessageService } from 'primeng/api';
import { ToastModule } from 'primeng/toast';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { AddEditUserComponent } from './add-edit-user.component';


@NgModule({
  declarations: [AddEditUserComponent],
  imports: [
    CommonModule,
    AddEditUserRoutingModule,
    RouterModule,
    ReactiveFormsModule,
    ToastModule
  ],
  providers: [MessageService]
})
export class AddEditUserModule { }
