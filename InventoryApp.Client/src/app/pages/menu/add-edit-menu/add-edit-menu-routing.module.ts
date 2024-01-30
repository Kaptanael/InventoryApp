import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AddEditMenuComponent } from './add-edit-menu.component';
import { MenuService } from '../../../_services/menu.service';


const routes: Routes = [{
  path: '',
  children:
    [
      {
        path: '',
        component: AddEditMenuComponent
      }      
    ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: [MenuService]
})
export class AddEditMenuRoutingModule { }
