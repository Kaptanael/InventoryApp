import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService } from 'primeng/api';

import { MenuService } from '../../../_services/menu.service';

@Component({
  selector: 'add-edit-menu',
  templateUrl: './add-edit-menu.component.html',
  styleUrl: './add-edit-menu.component.css'
})
export class AddEditMenuComponent implements OnInit {

  public formGroup!: FormGroup;
  public selectedMenu: any = null;
  public selectedMenuId: string | undefined;
  public title: string | undefined;

  constructor(private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private messageService: MessageService,
    private menuService: MenuService) {
    this.createFormGroup();
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => params.get('id') ? this.selectedMenuId = params.get('id')?.toString() : null);
    this.title = this.selectedMenuId ? 'Edit Menu' : 'Add Menu';
    this.getById();
  }

  createFormGroup(): void {
    this.formGroup = this.fb.group({
      name: ['', [this.noWhitespaceValidator, Validators.required, Validators.maxLength(50)]],
      status: ['1', Validators.required]           
    });
  }

  getById(): void {
    if (this.selectedMenuId) {
      this.menuService.getById(this.selectedMenuId).subscribe({
        next: (res) => {
          this.selectedMenu = res.body;
          this.fillUpFields();
        },
        error: (err) => {
          console.log(err);
        }
      });
    }
  }

  fillUpFields(): void{
    if (this.selectedMenu) {
      this.formGroup.patchValue({
        name: this.selectedMenu.name,
        status: this.getStringBoolean(this.selectedMenu.status)               
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
    this.formGroup.patchValue({ status: 1 });
  }

  onSubmit(): void {   

    const model = {
      id: this.selectedMenuId,
      name: this.formGroup.controls['name'].value,
      status: +this.formGroup.controls['status'].value === 1 ? true : false,       
    }    

    if (!this.selectedMenuId) {
      this.menuService.create(model)
        .subscribe({
          next: (rse) => {
            if (rse.status === 200) {              
              this.messageService.add({ key: 'toastKey1', severity: 'success', summary: 'Success', detail: 'Menu created successfully' });
              setTimeout(() => {
                this.router.navigate(['/menu']);
              }, 1000);
            }
          },
          error: (err) => {
            this.messageService.add({ key: 'toastKey1', severity: 'error', summary: 'Error', detail: 'Failed to create menu' });
          }
        });
    } else {
      this.menuService.update(this.selectedMenuId, model)
        .subscribe({
          next: (rse) => {
            if (rse.status === 200) {
              this.messageService.add({ key: 'toastKey1', severity: 'success', summary: 'Success', detail: 'Menu updated successfully' });
              setTimeout(() => {
                this.router.navigate(['/menu']);
              },1000);              
            }
          },
          error: (err) => {
            this.messageService.add({ key: 'toastKey1', severity: 'error', summary: 'Error', detail: 'Failed to update menu' });
          }
        });
    }
  }

}
