import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TransferOrderComponent } from './transfer-order.component';

const routes: Routes = [{
  path: '',
  component: TransferOrderComponent
}];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TransferOrderRoutingModule { }
