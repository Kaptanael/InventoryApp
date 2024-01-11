import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-edit-branch',
  templateUrl: './add-edit-branch.component.html',
  styleUrl: './add-edit-branch.component.css'
})
export class AddEditBranchComponent {

  constructor(private router: Router) {
  }
}
