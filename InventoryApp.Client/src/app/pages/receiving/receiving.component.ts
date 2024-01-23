import { Component } from '@angular/core';
import { ReceivingService } from './receiving.service';

@Component({
  selector: 'app-receiving',
  templateUrl: './receiving.component.html',
  styleUrl: './receiving.component.css'
})
export class ReceivingComponent {
  public receivingList: [] = [];
  constructor(private receivingService: ReceivingService) {
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
