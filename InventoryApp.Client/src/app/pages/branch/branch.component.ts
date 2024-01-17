import { Component, OnInit } from '@angular/core';
import { BranchService } from '../../_services/branch.service';

@Component({
  selector: 'app-branch',
  templateUrl: './branch.component.html',
  styleUrl: './branch.component.css'
})
export class BranchComponent implements OnInit {

  public branches: [] = [];

  constructor(private branchService: BranchService) {
  }

  ngOnInit(): void {
    this.getAll();
  }

  getAll() {
    this.branchService.getAll().subscribe({
      next: (res) => {
        this.branches = res.body;
        console.log(res);
      }
    })
  }

}
