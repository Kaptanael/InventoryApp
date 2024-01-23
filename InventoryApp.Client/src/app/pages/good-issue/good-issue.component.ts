import { Component } from '@angular/core';
import { GoodIssueService } from './good-issue.service';

@Component({
  selector: 'app-good-issue',
  templateUrl: './good-issue.component.html',
  styleUrl: './good-issue.component.css'
})
export class GoodIssueComponent {
  public goodIssues: [] = [];
  constructor(private goodIssueService: GoodIssueService) {
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
