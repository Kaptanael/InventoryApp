import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService } from 'primeng/api';

import { RoleService } from '../../../_services/role.service';


@Component({
  selector: 'add-edit-role',
  templateUrl: './add-edit-role.component.html',
  styleUrl: './add-edit-role.component.css'
})
export class AddEditRoleComponent implements OnInit {

  public formGroup!: FormGroup;
  public selectedRole: any = null;
  public selectedRoleId: string | undefined;
  public title: string | undefined;

  constructor(private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private messageService: MessageService,
    private roleService: RoleService) {
    this.createFormGroup();
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => params.get('id') ? this.selectedRoleId = params.get('id')?.toString() : null);
    this.title = this.selectedRoleId ? 'Edit Role' : 'Add Role';
    this.getById();
  }

  createFormGroup(): void {
    this.formGroup = this.fb.group({
      name: ['', [this.noWhitespaceValidator, Validators.required, Validators.maxLength(50)]]          
    });
  }

  getById(): void {
    if (this.selectedRoleId) {
      this.roleService.getById(this.selectedRoleId).subscribe({
        next: (res) => {
          this.selectedRole = res.body;
          this.fillUpFields();
        },
        error: (err) => {
          console.log(err);
        }
      });
    }
  }

  fillUpFields(): void{
    if (this.selectedRole) {
      this.formGroup.patchValue({
        name: this.selectedRole.name             
      })
    }
  }

  noWhitespaceValidator(control: AbstractControl) {
    if (control && control.value && !control.value.replace(/\s/g, '').length) {
      control.setValue('');
    }
    return null;
  }

  getStringBoolean(value: boolean): string {
    if (value == true) {
      return "1";
    }
    return "0";
  }

  onClear(): void {
    this.formGroup.reset();    
  }

  onSubmit(): void {   

    const model = {
      id: this.selectedRoleId,
      name: this.formGroup.controls['name'].value         
    }    

    if (!this.selectedRoleId) {
      this.roleService.create(model)
        .subscribe({
          next: (res) => {
            if (res.status === 200 && (res as any).success) {
              this.messageService.add({ key: 'toastKey1', severity: 'success', summary: 'Success', detail: 'Role created successfully' });
              setTimeout(() => {
                this.router.navigate(['/role']);
              }, 1000);
            } else if (!(res as any).success) {              
              this.messageService.add({ key: 'toastKey1', severity: 'error', summary: 'Duplicate', detail: 'Role already exist' });
            }
          },
          error: (err) => {
            this.messageService.add({ key: 'toastKey1', severity: 'error', summary: 'Error', detail: 'Failed to create role' });
          }
        });
    } else {
      this.roleService.update(this.selectedRoleId, model)
        .subscribe({
          next: (rse) => {
            if (rse.status === 200) {
              this.messageService.add({ key: 'toastKey1', severity: 'success', summary: 'Success', detail: 'Role updated successfully' });
              setTimeout(() => {
                this.router.navigate(['/role']);
              },1000);              
            }
          },
          error: (err) => {
            this.messageService.add({ key: 'toastKey1', severity: 'error', summary: 'Error', detail: 'Failed to update role' });
          }
        });
    }
  }

}
