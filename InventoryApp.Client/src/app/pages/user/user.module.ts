import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { TableModule } from 'primeng/table';
import { UserComponent } from './user.component';
import { ConfirmationService, MessageService } from 'primeng/api';


@NgModule({
  declarations: [UserComponent],
  imports: [
    CommonModule,
    UserRoutingModule,
    TableModule
  ],
  providers: [ConfirmationService, MessageService]
})
export class UserModule { }
