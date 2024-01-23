import { Component } from '@angular/core';
import { StockService } from './stock.service';

@Component({
  selector: 'app-stock',
  templateUrl: './stock.component.html',
  styleUrl: './stock.component.css'
})
export class StockComponent {
  public stocks: [] = [];
  constructor(private stockService: StockService) {
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
