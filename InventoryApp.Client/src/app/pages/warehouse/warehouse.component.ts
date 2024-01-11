import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-warehouse',
  templateUrl: './warehouse.component.html',
  styleUrl: './warehouse.component.css'
})
export class WarehouseComponent {
  constructor(private router: Router) {
  }
  onNavigateAddEdit() {
    console.log("dada")
    //this.router.navigate(['/add-edit-warehouse']);
  }
}
