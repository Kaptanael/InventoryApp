import { Component } from '@angular/core';
import { VendorService } from './vendor.service';

@Component({
  selector: 'app-vendor',
  templateUrl: './vendor.component.html',
  styleUrl: './vendor.component.css'
})
export class VendorComponent {
  public vendorlist: [] = [];
  constructor(private vendorService: VendorService) {
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
