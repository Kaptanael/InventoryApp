import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './auth.guard';


const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: "branch", loadChildren: () => import('./pages/branch/branch.module').then(m => m.BranchModule)
      },
      {
        path: "warehouse", loadChildren: () => import('./pages/warehouse/warehouse.module').then(m => m.WarehouseModule)
      },
      {
        path: "stock", loadChildren: () => import('./pages/stock/stock.module').then(m => m.StockModule)
      },
      {
        path: "vendor", loadChildren: () => import('./pages/vendor/vendor.module').then(m => m.VendorModule)
      },
      {
        path: "purchase-order", loadChildren: () => import('./pages/purchase-order/purchase-order.module').then(m => m.PurchaseOrderModule)
      },
      {
        path: "receiving", loadChildren: () => import('./pages/receiving/receiving.module').then(m => m.ReceivingModule)
      },
      {
        path: "customer", loadChildren: () => import('./pages/customer/customer.module').then(m => m.CustomerModule)
      },
      {
        path: "sale-order", loadChildren: () => import('./pages/sale-order/sale-order.module').then(m => m.SaleOrderModule)
      },
      {
        path: "shipment", loadChildren: () => import('./pages/shipment/shipment.module').then(m => m.ShipmentModule)
      },
      {
        path: "transfer-order", loadChildren: () => import('./pages/transfer-order/transfer-order.module').then(m => m.TransferOrderModule)
      },
      {
        path: "product-type", loadChildren: () => import('./pages/product-type/product-type.module').then(m => m.ProductTypeModule)
      },
      {
        path: "good-issue", loadChildren: () => import('./pages/good-issue/good-issue.module').then(m => m.GoodIssueModule)
      },
      {
        path: "good-receive", loadChildren: () => import('./pages/good-receive/good-receive.module').then(m => m.GoodReceiveModule)
      },
      {
        path: "user", loadChildren: () => import('./pages/user/user.module').then(m => m.UserModule)
      },
      {
        path: "user-role", loadChildren: () => import('./pages/user-role/user-role.module').then(m => m.UserRoleModule)
      },
      {
        path: "role", loadChildren: () => import('./pages/role/role.module').then(m => m.RoleModule)
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

