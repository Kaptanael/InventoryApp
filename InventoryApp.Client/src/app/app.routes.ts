import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';


const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    children: [
      {
        path: "branch", loadChildren: () => import('./pages/branch/branch.module').then(m => m.BranchModule)
      },
      {
        path: "warehouse", loadChildren: () => import('./pages/warehouse/warehouse.module').then(m => m.WarehouseModule)
      },
      {
        path: "product-type", loadChildren: () => import('./pages/product-type/product-type.module').then(m => m.ProductTypeModule)
      },
      {
        path: "user", loadChildren: () => import('./pages/user/user.module').then(m => m.UserModule)
      }
    ]
  },
  {
    path: 'login',
    component: LoginComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

