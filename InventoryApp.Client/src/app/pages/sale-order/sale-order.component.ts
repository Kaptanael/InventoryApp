import { Component } from '@angular/core';
import { SaleOrderService } from './sale-order.service';

@Component({
  selector: 'app-sale-order',
  templateUrl: './sale-order.component.html',
  styleUrl: './sale-order.component.css'
})
export class SaleOrderComponent {
  public saleOrders: [] = [];
  constructor(private seleOrderService: SaleOrderService) {
  }

  ngOnInit(): void {
    this.getAll();
  }

  getAll() {
    //this.branchService.getAll().subscribe({
    //  next: (res) => {
    //    this.branches = res.body;
    //    console.log(res);
    //  },
    //  error: (err) => {
    //    console.log(err);
    //  }
    //});
  }
}
