import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserComponent } from './user.component';


const routes: Routes = [{
  path: '',
  children: [
    {
      path: '',
      component: UserComponent,
    },
    {
      path: 'add-edit-user', loadChildren: () => import('./add-edit-user/add-edit-user.module').then(m => m.AddEditUserModule)
    },
    {
      path: 'add-edit-user/:id', loadChildren: () => import('./add-edit-user/add-edit-user.module').then(m => m.AddEditUserModule)
    }
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
