import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-edit-branch',
  templateUrl: './add-edit-branch.component.html',
  styleUrl: './add-edit-branch.component.css'
})
export class AddEditBranchComponent {

  public formGroup!: FormGroup;
  public selectedBranch: any = {};
  public selectedBranchId: number | undefined;

  constructor(private fb: FormBuilder, private router: Router) {
    this.createFormGroup();
  }

  createFormGroup() {
    this.formGroup = this.fb.group({
      name: ['', Validators.compose([Validators.maxLength(50)])],
      description: ['', Validators.compose([Validators.maxLength(200)])],
      street: ['', Validators.compose([Validators.maxLength(200)])],
      city: ['', Validators.compose([Validators.maxLength(50)])],
      province: ['', Validators.compose([Validators.maxLength(50)])],
      country: ['', Validators.compose([Validators.maxLength(50)])]
    });
  }

  onSubmit() {
    console.log(this.formGroup);
  }

}
