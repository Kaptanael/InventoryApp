import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GoodReceiveRoutingModule } from './good-receive-routing.module';
import { GoodReceiveComponent } from './good-receive.component';


@NgModule({
  declarations: [GoodReceiveComponent],
  imports: [
    CommonModule,
    GoodReceiveRoutingModule
  ]
})
export class GoodReceiveModule { }
