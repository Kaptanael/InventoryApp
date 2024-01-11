import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WarehouseComponent } from './warehouse.component';


const routes: Routes = [{
  path: '',
  children:
    [
      {
        path: '',
        component: WarehouseComponent
      },
      {
        path: 'add-edit-warehouse', loadChildren: () => import('./add-edit-warehouse/add-edit-warehouse.module').then(m => m.AddEditWarehouseModule)
      }
    ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WarehouseRoutingModule { }
