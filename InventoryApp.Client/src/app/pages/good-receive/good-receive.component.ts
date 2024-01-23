import { Component } from '@angular/core';
import { GoodReceiveService } from './good-receive.service';

@Component({
  selector: 'app-good-receive',
  templateUrl: './good-receive.component.html',
  styleUrl: './good-receive.component.css'
})
export class GoodReceiveComponent {
  public goodReceiveLists: [] = [];
  constructor(private goodIssueService: GoodReceiveService) {
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
