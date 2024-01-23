import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GoodReceiveComponent } from './good-receive.component';

const routes: Routes = [{
  path: '',
  component: GoodReceiveComponent
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GoodReceiveRoutingModule { }
