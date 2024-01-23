import { Component } from '@angular/core';
import { TransferOrderService } from './transfer-order.service';

@Component({
  selector: 'app-transfer-order',
  templateUrl: './transfer-order.component.html',
  styleUrl: './transfer-order.component.css'
})
export class TransferOrderComponent {
  public transferOrders: [] = [];
  constructor(private transferOrderService: TransferOrderService) {
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
