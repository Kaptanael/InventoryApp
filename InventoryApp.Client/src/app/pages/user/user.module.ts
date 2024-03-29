import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { TableModule } from 'primeng/table';
import { UserComponent } from './user.component';
import { ConfirmationService, MessageService } from 'primeng/api';
import { FormsModule } from '@angular/forms';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ToastModule } from 'primeng/toast';


@NgModule({
  declarations: [UserComponent],
  imports: [
    CommonModule,
    UserRoutingModule,
    TableModule,
    FormsModule,
    ConfirmDialogModule,
    ToastModule   
  ],
  providers: [ConfirmationService, MessageService]
})
export class UserModule { }
