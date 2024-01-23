import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoleRoutingModule } from './user-role-routing.module';
import { UserRoleComponent } from './user-role.component';


@NgModule({
  declarations: [UserRoleComponent],
  imports: [
    CommonModule,
    UserRoleRoutingModule
  ]
})
export class UserRoleModule { }
