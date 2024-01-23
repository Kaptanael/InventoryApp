import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './auth.guard';


const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
   /* canActivate: [AuthGuard],*/
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
      },
      {
        path: "good-receive", loadChildren: () => import('./pages/good-receive/good-receive.module').then(m => m.GoodReceiveModule)
      }
    ]
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: '**',
    loadChildren: () => import('./pages/page-not-found/page-not-found.module').then(m => m.PageNotFoundModule)
    //redirectTo: "/page-not-found"
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

