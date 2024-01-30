import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { ToastModule } from 'primeng/toast';

import { AddEditMenuRoutingModule } from './add-edit-menu-routing.module';
import { AddEditMenuComponent } from './add-edit-menu.component';
import { MenuService } from '../../../_services/menu.service';


@NgModule({
  declarations: [AddEditMenuComponent],
  imports: [
    CommonModule,
    AddEditMenuRoutingModule,
    RouterModule,
    ReactiveFormsModule,
    ToastModule
  ],
  providers: [MessageService, MenuService]
})
export class AddEditMenuModule { }
