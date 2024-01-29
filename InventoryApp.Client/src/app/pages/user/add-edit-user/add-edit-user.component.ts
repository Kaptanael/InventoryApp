import { Component } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { UserService } from '../user.service';

@Component({
  selector: 'app-add-edit-user',
  templateUrl: './add-edit-user.component.html',
  styleUrl: './add-edit-user.component.css'
})
export class AddEditUserComponent {

  public formGroup!: FormGroup;
  public selectedUser: any = null;
  public selectedUserId: string | undefined;
  public title: string | undefined;

  constructor(private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private messageService: MessageService,
    private userService: UserService) {
    this.createFormGroup();
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => params.get('id') ? this.selectedUserId = params.get('id')?.toString() : null);
    this.title = this.selectedUserId ? 'Edit User' : 'Add User';
    this.getById();
  }

  createFormGroup(): void {
    this.formGroup = this.fb.group({
      userName: ['', [this.noWhitespaceValidator, Validators.required, Validators.maxLength(50)]],
      password: ['', [this.noWhitespaceValidator, Validators.maxLength(50)]],
      firstName: ['', [this.noWhitespaceValidator, Validators.required, Validators.maxLength(50)]],
      lastName: ['', [this.noWhitespaceValidator, Validators.required, Validators.maxLength(50)]],
      email: ['', [this.noWhitespaceValidator, Validators.required, Validators.maxLength(50)]],
      mobile: ['', [this.noWhitespaceValidator, Validators.required, Validators.maxLength(14)]],
      status: ['1', Validators.required],
    });
  }

  noWhitespaceValidator(control: AbstractControl) {
    if (control && control.value && !control.value.replace(/\s/g, '').length) {
      control.setValue('');
    }
    return null;
  }

  getById(): void {
    if (this.selectedUserId) {
      this.userService.getById(this.selectedUserId).subscribe({
        next: (res) => {
          this.selectedUser = res.body;
          this.fillUpFields();
        },
        error: (err) => {
          console.log(err);
        }
      });
    }
  }

  fillUpFields(): void {
    if (this.selectedUser) {
      this.formGroup.patchValue({
        userName: this.selectedUser.userName,
        firstName: this.selectedUser.description,
        lastName: this.selectedUser.description,
        email: this.selectedUser.streetAddress,
        mobile: this.selectedUser.city,
        status: this.getStringBoolean(this.selectedUser.status),
      })
    }
  }

  onClear(): void {
    this.formGroup.reset();
    this.formGroup.patchValue({ status: 1 });
  }

  getStringBoolean(value: boolean): string {
    if (value == true) {
      return "1";
    }
    return "0";
  }

  onSubmit(): void {

    const model = {
      id: this.selectedUserId,
      userName: this.formGroup.controls['userName'].value,
      password: this.formGroup.controls['password'].value,
      firstName: this.formGroup.controls['firstName'].value,
      lastName: this.formGroup.controls['lastName'].value,
      email: this.formGroup.controls['email'].value,
      mobile: this.formGroup.controls['mobile'].value,
      status: +this.formGroup.controls['status'].value === 1 ? true : false,
    }

    if (!this.selectedUserId) {
      this.userService.create(model)
        .subscribe({
          next: (res) => {
            if (res.status === 200) {
              this.messageService.add({ key: 'toastKey1', severity: 'success', summary: 'Success', detail: 'Created successfully' });
              setTimeout(() => {
                this.router.navigate(['/user']);
              }, 1000);
            }
          },
          error: (err) => {
            this.messageService.add({ key: 'toastKey1', severity: 'error', summary: 'Error', detail: 'Failed to create' });
          }
        });
    } else {
      this.userService.update(this.selectedUserId, model)
        .subscribe({
          next: (res) => {
            if (res.status === 200) {
              this.messageService.add({ key: 'toastKey1', severity: 'success', summary: 'Success', detail: 'Updated successfully' });
              setTimeout(() => {
                this.router.navigate(['/user']);
              }, 1000);
            }
          },
          error: (err) => {
            this.messageService.add({ key: 'toastKey1', severity: 'error', summary: 'Error', detail: 'Failed to update' });
          }
        });
    }
  }
}
